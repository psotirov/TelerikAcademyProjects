/// <reC:\Users\Pavel\Documents\MY PROGRAMS\Desktop Applications\New folder\Homework 1 - WinJS Classes\Vegetables\js\tomato.jsference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.defineWithParent(Vegetables, "Eatable", {
    Tomato : WinJS.Class.derive(Vegetables.Vegetable, function (color, radius) {
        Vegetables.Vegetable.call(this, color, true, radius);
    }, {
        radius: {
            get: function () { return this._dimension; },
            set: function (value) { this._dimension = value }
        }
    })
});