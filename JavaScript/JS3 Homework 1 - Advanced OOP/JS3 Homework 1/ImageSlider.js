var ImageSlider = {
    init: function (images) {
        this.images = images;
        this._currentIndex = 0;
    },
    render: function (containerId) {
        var container = document.getElementById(containerId);

        var leftArrow = Object.create(SliderArrow);
        leftArrow.init("&lt;=", "left", "arrow");
        this._renderArrow(leftArrow, container);

        this._renderImages(container);

        var rightArrow = Object.create(SliderArrow);
        rightArrow.init("=&gt;", "right", "arrow");
        this._renderArrow(rightArrow, container);
    },
    _renderImages: function (container) {
        for (i = 0, len = this.images.length; i < len; i++) {
            var imageItem = document.createElement("img");
            if (i == this._currentIndex) {
                imageItem.setAttribute("src", this.images[i].largeImageUrl);
            } else {
                imageItem.setAttribute("src", this.images[i].tumbnailUrl);
            }
            imageItem.setAttribute("id", this.images[i].title);
            container.appendChild(imageItem);
        }
    },
     _renderArrow: function (arrow, container) {
        var arrowContainer = document.createElement("a");
        arrowContainer.id = arrow.arrowId;
        arrowContainer.className = "arrow";
        arrowContainer.href = "#";
        arrowContainer.innerHTML = arrow.name;

        var self = this;
        arrowContainer.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }

            if (ev.preventDefault) {
                ev.preventDefault();
            }

            if (ev.stopPropagation) {
                ev.stopPropagation();
            }

            var previousImage = document.getElementById(self.images[self._currentIndex].title);
            previousImage.setAttribute("src", self.images[self._currentIndex].tumbnailUrl);

            if (this.id == "left") {
                if (self._currentIndex > 0) {
                    self._currentIndex--;
                } else {
                    self._currentIndex = self.images.length - 1;
                }
            } else if (this.id == "right") {
                if (self._currentIndex < self.images.length - 1) {
                    self._currentIndex++;
                } else {
                    self._currentIndex = 0;
                }
            }

            var currentImage = document.getElementById(self.images[self._currentIndex].title);
            currentImage.setAttribute("src", self.images[self._currentIndex].largeImageUrl);
        }, false);

        container.appendChild(arrowContainer);
    }
};

var Image = {
    init: function (title, tumbnailUrl, largeImageUrl) {
        this.title = title;
        this.tumbnailUrl = tumbnailUrl;
        this.largeImageUrl = largeImageUrl;
    }
};

var SliderArrow = {
    init: function (name, arrowId) {
        this.name = name;
        this.arrowId = arrowId;
    }
};