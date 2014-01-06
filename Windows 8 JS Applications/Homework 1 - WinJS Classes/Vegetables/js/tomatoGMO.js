/// <reference path="tomato.js" />
/// <reference path="mushroom.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("GMO", {
    TomatoGMO : WinJS.Class.mix(Vegetables.Eatable.Tomato, Mushroom)
});