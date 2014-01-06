/// <reference path="cucumber.js" />
/// <reference path="mushroom.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("GMO", {
    CucumberGMO: WinJS.Class.mix(Vegetables.NonEatable.Cucumber, Mushroom)
});