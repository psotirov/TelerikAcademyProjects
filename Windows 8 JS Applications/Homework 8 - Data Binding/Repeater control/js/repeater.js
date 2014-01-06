/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
var RepeaterControl = new WinJS.Class.define(
    //constructor 
    function (data, container, href, saveHandler) {
        this._template = new WinJS.Binding.Template(null, {
            href: href
        });
        this._data = data;
        this._saveHandler = saveHandler;
        this.container = container;
    },
    //instance members
    {
        render: function () {
            for (var i = 0; i < this._data.length; i++) {
                this._renderSingle(i);
            }
        },
        _renderSingle: function (index) {
            var div = document.createElement('div');
            div.classList.add('itemstyle');
            var self = this;
            this._template.render(this._data[index], div)
                .done(function (result) {
                    var rating = result.getElementsByClassName("ratingControl")[0];
                        rating.winControl
                        .onchange = function (event) {
                            self._data[index].rating = event.target.winControl.userRating;
                            self._saveHandler();
                        };
                    this.container.appendChild(result);
                });
        },
        renderLast: function () {
            this._renderSingle(this._data.length - 1);
        }
    },
    //static members
    {});