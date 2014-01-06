/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="primes-worker.js" />

var WorkersPool = WinJS.Class.define(function (count) {
    this._count = count;
    this._pool = [];
    this._available = [];
    for (var i = 0; i < count; i++) {
        this._pool[i] = new Worker("/js/primes-worker.js");
        this._available[i] = true;
    }
}, {
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
    }
});
