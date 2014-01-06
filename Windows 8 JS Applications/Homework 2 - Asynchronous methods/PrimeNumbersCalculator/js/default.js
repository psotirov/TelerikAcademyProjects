/// <reference path="workers-pool.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var workersPool = new WorkersPool(3);

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
            
            var calculatePrimesButton = document.getElementById("calculate-primes");
            var primesFirstInput = document.getElementById("primes-first");
            var primesLastInput = document.getElementById("primes-last");
            var primesCountInput = document.getElementById("primes-count");

            calculatePrimesButton.addEventListener("click", function () {
                workersPool.calculatePromise(primesFirstInput.value | 0, primesLastInput.value | 0, primesCountInput.value | 0)
                .done(function (primes) {
                    var primesOutput = document.createElement("div");
                    primesOutput.innerText = primes.join(", ");
                    document.body.appendChild(primesOutput);
                }, function (error) {
                    var errorOutput = document.createElement("div");
                    errorOutput.innerText = error;
                    document.body.appendChild(errorOutput);
                });
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
})();
