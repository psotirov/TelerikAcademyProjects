// Cross Browser event attaching sequence
function setEvent(element, event, handler, useCapture) {
    if (!element || !event || !handler) {
        return; // nothing to attach
    }
    useCapture = useCapture || false;
    if (document.addEventListener) {
        // Modern Browsers
        element.addEventListener(event, handler, useCapture);
    } else if (document.attachEvent) {
        // IE6 - 8
        element.attachEvent(event, handler);
    } else {
        // Really old browsers
        element["on" + event] = handler;
    }
}

// inherit capability in a global scope
Function.prototype.inherits = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = this;
};

var controls = (function () { 
    function ImageGallery(selector) {
        var gallery = document.getElementById(selector);

        setEvent(gallery, "click",
        function (event) {
            event = event || window.event;
            event.stopPropagation();
            event.preventDefault();

            var clickedItem = event.target;
            if ((clickedItem instanceof HTMLHeadingElement)) {
                var sublist = clickedItem.nextElementSibling;
                while (sublist) {
                    if (sublist instanceof HTMLDivElement) {
                        if (sublist.style.display == "none") {
                            sublist.style.display = "";
                        } else {
                            sublist.style.display = "none";
                        }
                    }
                    sublist = sublist.nextElementSibling
                }
            }

            if ((clickedItem instanceof HTMLButtonElement)) {
                // TODO: rotate ascending/descending sort
                // TODO: BUG: Album's structure could be suddenly reordered 
                var parent = clickedItem.parentElement;
                var albums = parent.getElementsByClassName("album");
                var newOrder = document.createDocumentFragment();
                while (albums.length) {
                    var element = albums[0];
                    for (var i = 1, len = albums.length; i < len; i+=1) {
                        if (element.firstChild.innerText > albums[i].firstChild.innerText) {
                            element = albums[i];
                        }
                    }
                    newOrder.appendChild(element);
                }
                parent.appendChild(newOrder);
            }

            if ((clickedItem instanceof HTMLImageElement)) {
                // if clicked on zoomed element - destroy it
                if (clickedItem.id == "zoomImage") {
                    gallery.removeChild(clickedItem);
                } else {
                    var zoomImage = document.getElementById("zoomImage");
                    if (!zoomImage) {
                        zoomImage = document.createElement("img");
                        zoomImage.id = "zoomImage";
                        zoomImage.style.position = "absolute";
                        zoomImage.style.left = "50%";
                        zoomImage.style.top = "50%";
                        gallery.appendChild(zoomImage);
                    }
                    zoomImage.src = clickedItem.src;
                    zoomImage.style.height = parseInt(clickedItem.clientHeight) * 2 + "px";
                    zoomImage.style.width = parseInt(clickedItem.clientWidth) * 2 + "px";
                }
            }
        });

        // needs different method that deletes all previous elements
        // renders content and displays new content
        this.renderGallery = function () {
            while (gallery.firstChild) {
                gallery.removeChild(gallery.firstChild);
            }
            var gal = this.render();
            gal.className = "imageGallery";
            gallery.appendChild(gal);
            return this;
        };
    };
    ImageGallery.inherits(Album);

    return {
        getImageGallery: function (selector) {
            return new ImageGallery(selector);
        },
        buildImageGallery: function(selector, data) {
            var gallery = this.getImageGallery(selector);

            if (data) {
                for (var i = 0; i < data.length; i++) {
                    addItem(gallery, data[i]);
                }
            }

            return gallery;
        }
    }
}());