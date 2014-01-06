function Image(title, source) {
    this.render = function () {
        var itemNode = document.createElement("div");
        itemNode.className = "image";

        // creates image container
        itemNode.innerHTML = "<p>" + title + "</p>";
        // adds img tag with proper attributes
        var image = document.createElement("img");
        image.alt = title;
        image.src = source;
        image.style.display = "";
        itemNode.appendChild(image);

        return itemNode;
    };

    this.save = function () {
        var thisItem = {
            title: title,
            source: source
        };
        return thisItem;
    }
}