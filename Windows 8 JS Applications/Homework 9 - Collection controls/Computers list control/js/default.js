// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var computers;
    var listView;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }

            WinJS.UI.processAll();
            
            computers = new WinJS.Binding.List();
            readCurrentState().done(function (computersStorage) {
                if (!computersStorage) {
                    computers.push(Data.getComputer("Dell Studio 1535", 2000, "/images/studio-1535.png", "Jar", "Core i5", 2.0, 2));
                    computers.push(Data.getComputer("HP 650", 1500, "/images/hp-650.jpg", "Jar", "Intel 1000M", 1.8, 1));
                    writeCurrentState();
                } else {
                    for (var i = 0, len = computersStorage.length; i < len; i++) {
                        computers.push(computersStorage[i]);
                    }
                }


                // Create the groups for the ListView from the item data and the grouping functions
                var groupedComputers = computers.createGrouped(getGroupKey, getGroupData, compareGroups);

                var container = document.getElementById("container");
                listView = new WinJS.UI.ListView(container, {
                    groupHeaderTemplate:document.getElementById("group-computer-template"),
                    itemTemplate: document.getElementById("computer-template"),
                    //itemDataSource: computers.dataSource,
                    itemDataSource: groupedComputers.dataSource,
                    groupDataSource: groupedComputers.groups.dataSource,
                    layout: { type: WinJS.UI.GridLayout },
                    scrollPosition:0
                });
            });

            document.getElementById("create-computer").addEventListener("click", addNewComputer);
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
        
    };

    app.start();

    function addNewComputer() {
        var manufact = document.getElementById("manufact").value;
        var name = document.getElementById("name").value;
        var price = document.getElementById("price").value;
        var procModel = document.getElementById("model").value;
        var procFreq = document.getElementById("freq").value;
        var image = document.getElementById("image").value;
        if (!image.length) {
            image = "/images/hp-650.jpg"; // default picture
        }

        computers.push(Data.getComputer(name, price, image, manufact, procModel, procFreq, 0));

        writeCurrentState();
    }

    // Write current state data to a file
    function writeCurrentState() {

        var computersData = [];
        for (var i = 0, len = computers.length; i < len; i++) {
            computersData.push(computers.getAt(i));
        }

        Windows.Storage.ApplicationData.current.localFolder
        .createFileAsync("dataFile.txt", Windows.Storage.CreationCollisionOption.replaceExisting)
           .done(function (dataFile) {
               Windows.Storage.FileIO.writeTextAsync(dataFile, JSON.stringify(computersData)).done();
           });
    }

    // Read current state data from a file
    function readCurrentState() {
        return new WinJS.Promise(function (complete) {
            Windows.Storage.ApplicationData.current.localFolder
            .getFileAsync("dataFile.txt")
                .done(function (dataFile) {
                    Windows.Storage.FileIO.readTextAsync(dataFile)
                        .then(function (dataString) {
                            var result = (dataString.length) ? JSON.parse(dataString) : null;
                            complete(result);
                        });
                }, function () {
                    complete(null);
                });
        });
    }


    // Grouped Listview - Sorts the groups by its first character
    function compareGroups(leftKey, rightKey) {
        return leftKey.charCodeAt(0) - rightKey.charCodeAt(0);
    }

    // Grouped Listview - Returns the group key that an item belongs to
    function getGroupKey(dataItem) {
        return dataItem.manufacturer.toUpperCase();
    }

    // Grouped Listview - Returns the title for a group
    function getGroupData(dataItem) {
        return {
            manufacturer: dataItem.manufacturer.toUpperCase()
        };
    }
})();
