// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var messagesDisplayed = 0;

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
        }

        var remoteUrl = 'http://posted.apphb.com/api/posts';

        //user input
        var authorElement = document.getElementById("author");
        var messageElement = document.getElementById("message");
        var sendButton = document.getElementById("send-btn");

        sendButton.addEventListener("click", function(){                
            var author = authorElement.value;
            var message = messageElement.value;
            if (author.length == 0 || message.length == 0) {
                new Windows.UI.Popups.MessageDialog('Author or Message cannot be empty.').showAsync().done();
                return;
            }

            WinJS.xhr({
                url: remoteUrl,
                type: "POST",
                headers: { "Content-type": "application/json" },
                data: JSON.stringify({ Author: author, Content: message })
            }).done();

            messageElement.value = '';
            messageElement.focus();
        });
        
        setInterval(function () {
            WinJS.Promise.timeout(1500, WinJS.xhr({
                url: remoteUrl,
                //headers: { "Content-type": "application/json" },
                responseType: 'json'
            })).then(function (response) {
                    var outputElement = document.getElementById("output");
                    if (messagesDisplayed == 0) {
                        WinJS.Utilities.empty(outputElement);
                    }

                    var jsonResponse = JSON.parse(response.responseText);
                    var posts = '';

                    for (var i = messagesDisplayed; i < jsonResponse.length; i++) {
                        if (jsonResponse[i].Content == null || jsonResponse[i].Content.length == 0) {
                            continue;
                        }

                        posts += '(' + (i+1) + ') ' + 
                            '<i>[' + jsonResponse[i].Author + ']</i> ' +
                            jsonResponse[i].Content + '<br />'
                    }

                    outputElement.innerHTML += posts;
                }, function (error) { });
        }, 30000); // delay 30 sec        
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
