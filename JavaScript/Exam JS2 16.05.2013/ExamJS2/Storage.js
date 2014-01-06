(function () {
    if (!Storage.prototype.saveObject) {
        Storage.prototype.saveObject = function (key, obj) {
            this.setItem(key, JSON.stringify(obj));
        }
    }

    if (!Storage.prototype.loadObject) {
        Storage.prototype.loadObject = function (key) {
            return JSON.parse(this.getItem(key));
        }
    }
}());

var imageGalleryRepository = (function () {
    return {
        save: function (name, imageGallery) {
            var galleryData = imageGallery.save();
            localStorage.saveObject(name, galleryData);
        },
        load: function (name) {
            return localStorage.loadObject("gal");
        }
    }
}());