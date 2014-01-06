/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.defineWithParent(Vegetables, "NonEatable", {
    Cucumber : WinJS.Class.derive(Vegetables.Vegetable, function (color, length) {
        Vegetables.Vegetable.call(this, color, false, length);
    }, {
        length: {
            get: function () { return this._dimension; },
            set: function (value) { this._dimension = value }
        }
    })
});