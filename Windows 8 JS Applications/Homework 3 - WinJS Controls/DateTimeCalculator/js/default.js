/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll());

            document.getElementById("time-select-switch-id")
                .addEventListener("change", function (event) {
                    document.getElementById("start-time-id").winControl.disabled = !this.winControl.checked;
                    document.getElementById("end-time-id").winControl.disabled = !this.winControl.checked;
                    if (!this.winControl.checked) {
                        document.getElementById("start-time-id").winControl.current = '0:00';
                        document.getElementById("end-time-id").winControl.disabled = '0:00';
                    }
                });

            document.getElementById("calculate-button-id")
                .addEventListener("click", function (event) {
                    document.getElementById("calculate-menu-id").winControl.show();
                });

            document.getElementById("days-menu-button-id")
                .addEventListener("click", function (event) {
                    calculate(1); 
                });
            document.getElementById("hours-menu-button-id")
                .addEventListener("click", function (event) {
                    calculate(2);
                });
            document.getElementById("days-hours-menu-button-id")
                .addEventListener("click", function (event) {
                    calculate(3);
                });
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

    function calculate(type) { // type = 1 by days, type = 2 by hours, type = 3 by days and hours
        var hours = getHoursDifference();
        var result = 'The difference is '
        switch (type) {
            case 1:
                result += Math.floor(hours / 24) + " days";
                break;
            case 2:
                result += hours + " hours";
                break;
            case 3:
                result += Math.floor(hours / 24) + " days and " + hours % 24 + " hours";
                break;
        }

        document.getElementById("result").innerHTML = result;
    }

    function getHoursDifference() {
        var startDate = new Date(document.getElementById("start-date-id").winControl.current);
        var endDate = new Date(document.getElementById("end-date-id").winControl.current);
        var startTime = new Date(document.getElementById("start-time-id").winControl.current);
        var endTime = new Date(document.getElementById("end-time-id").winControl.current);
        var hours =Math.abs( Math.floor((startDate.getTime() - endDate.getTime()
            + startTime.getTime() - endTime.getTime()) / (1000 * 60 * 60)));

        return hours;
    }
})();
