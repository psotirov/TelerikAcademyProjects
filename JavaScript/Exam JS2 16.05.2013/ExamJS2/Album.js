function Album(title) {
    var images = [];
    var albums = [];

    this.addAlbum = function (title) {
        var newAlbum = new Album(title);
        albums.push(newAlbum);
        return newAlbum;
    };

    this.addImage = function (title, source) {
        var newImage = new Image(title, source);
        images.push(newImage);
        return newImage;
    };

    this.render = function () {
        var itemNode = document.createElement("div");
        itemNode.className = "album";

        if (title) {
            itemNode.innerHTML = "<h3>" + title + "</h3>";
        }
        itemNode.innerHTML += "<button>Sort</button>";

        if (images.length > 0) {
            for (var i = 0, len = images.length; i < len; i += 1) {
                var subitem = images[i].render();
                itemNode.appendChild(subitem);
            }
        };

        if (albums.length > 0) {
            for (var i = 0, len = albums.length; i < len; i += 1) {
                var subalbum = albums[i].render();
                itemNode.appendChild(subalbum);
            }
        }

        return itemNode;
    };

    this.save = function () {
        var thisItem = {
            title: title
        };
        if (images.length > 0) {
            var serializedItems = [];
            for (var i = 0; i < images.length; i += 1) {
                var serItem = images[i].save();
                serializedItems.push(serItem);
            }
            thisItem.images = serializedItems;
        }

        if (albums.length > 0) {
            serializedItems = [];
            for (var i = 0; i < albums.length; i += 1) {
                serItem = albums[i].save();
                serializedItems.push(serItem);
            }
            thisItem.albums = serializedItems;
        }
        return thisItem;
    }
}