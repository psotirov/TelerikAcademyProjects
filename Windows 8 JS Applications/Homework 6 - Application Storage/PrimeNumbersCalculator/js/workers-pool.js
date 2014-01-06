/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="primes-worker.js" />

var WorkersPool = WinJS.Class.define(function (count) {
    this.changeWorkersCount(count);
}, {
    calculateCachedPromise: function (from, to, count) {
        var self = this;
        return new WinJS.Promise(function (complete, error) {
            var localFolder = Windows.Storage.ApplicationData.current.localFolder;
            var fileName = "primes_" + from + "_" + to + "_" + count + ".txt"; // example: "primes_1_100_0.txt"
            localFolder.createFileAsync(fileName, Windows.Storage.CreationCollisionOption.failIfExists)
            .then(function (file) { // no cashed file - create it and calculate the data
                self.calculatePromise(from, to, count)
                .then(function (primes) { // then save the data to the file
                    file.openTransactedWriteAsync().then(function (transaction) {
                        var writer = Windows.Storage.Streams.DataWriter(transaction.stream);
                        writer.writeString(JSON.stringify(primes));
                        writer.storeAsync().done(function () {
                            transaction.commitAsync().done(function () {
                                transaction.close();
                                complete(primes); // done
                            });
                        });
                    },
                    function (message) { // something went wrong while saving data - delete the empty file 
                        WinJS.Application.local.remove(fileName);
                    });
                }, function (err) { // calculation failed
                    error(err);
                });
            }, function () { // file exists - use cashed data from it
                WinJS.Application.local.readText(fileName, "failed to open file")
                .then(function (content) {
                    var primes = JSON.parse(content);
                    complete(primes);
                });
            });
        });
    },
    calculatePromise: function (from, to, count) {
        var self = this;
        return new WinJS.Promise(function (complete, error) {
            var worker = self.getWorker();
            if (worker == null) {
                error("All workers are busy now");
            } else {
                worker.onmessage = function (event) {
                    self.releaseWorker(this);
                    complete(event.data);
                };
                worker.postMessage({
                    firstNumber: from,
                    lastNumber: to,
                    count: count
                });
            }
        });
    },
    getWorker: function () {
        for (var i = 0, len = this._count; i < len; i++) {
            if (this._available[i]) {
                this._available[i] = false;
                return this._pool[i];
            }
        }

        return null;
    },
    releaseWorker: function (worker) {
        for (var i = 0, len = this._count; i < len; i++) {
            if (this._pool[i] === worker) {
                this._available[i] = true;
                this._pool[i].onmessage = null;
                break;
            }
        }
    },
    changeWorkersCount: function (newCount) {
        this._count = newCount;
        this._pool = [];
        this._available = [];
        for (var i = 0; i < newCount; i++) {
            this._pool[i] = new Worker("/js/primes-worker.js");
            this._available[i] = true;
        }
    },
    hasBusyWorkers: function () {
        for (var i = 0, len = this._count; i < len; i++) {
            if (!this._available[i]) {
                return true;
            }
        }

        return false;
    }
});
