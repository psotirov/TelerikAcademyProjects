/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

var Mushroom =  {
    grow: function (amountWater) {
        if(this._dimension)
            this._dimension *= amountWater;
    }
};