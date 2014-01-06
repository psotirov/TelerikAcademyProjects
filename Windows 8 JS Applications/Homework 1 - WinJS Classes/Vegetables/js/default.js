/// <reference path="tomato.js" />
/// <reference path="tomatoGMO.js" />
/// <reference path="mushroom.js" />
/// <reference path="vegetable.js" />
/// <reference path="cucumber.js" />
/// <reference path="cucumberGMO.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509

(function () {
    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {

        var newTomato = new Vegetables.Eatable.Tomato("red");
        var newCucumber = new Vegetables.NonEatable.Cucumber("green", 2);
        var newTomatoGMO = new GMO.TomatoGMO("red", 3);
        var newCucumberGMO = new GMO.CucumberGMO("green", 4);

        console = new DomLogger(document.getElementById("output"));

        console.log("Tomato has " + newTomato.color + " color and " + newTomato.radius + " radius");
        console.log("Cucumber has " + newCucumber.color + " color and " + newCucumber.length + " length");
        console.log("TomatoGMO has " + newTomatoGMO.color + " color and " + newTomatoGMO.radius + " radius");
        console.log("CucumberGMO has " + newCucumberGMO.color + " color and " + newCucumberGMO.length + " length");

        newTomatoGMO.grow(2);
        newCucumberGMO.grow(4);
        console.log("TomatoGMO has " + newTomatoGMO.color + " color and " + newTomatoGMO.radius + " radius");
        console.log("CucumberGMO has " + newCucumberGMO.color + " color and " + newCucumberGMO.length + " length");
    };

    app.start();
})();
