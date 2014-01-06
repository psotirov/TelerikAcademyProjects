/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("Vegetables", {
    Vegetable: WinJS.Class.define(function (color, canEat, dimension) {
        this.color = color;
        this.canEat = canEat || false;
        this._dimension = (dimension | 0) || 1;
    })
});