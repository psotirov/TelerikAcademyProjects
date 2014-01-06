var GoogleMaps = {
    init: function(container, mapList, left, right) {
        this.container = container;
        this.mapList = mapList;
        this.mapOptions = {
            zoom: 7,
            center: null,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        this.index = 0;
        var self = this;
        var links = $("<ul/>");
        for (var i = 0; i < this.mapList.length; i++) {
            var link = $('<li/>');
            link.html(this.mapList[i].city.replace(' ','&nbsp;'));
            link.bind('click', { index: i }, function (event) {
                var data = event.data;
                self.index = data.index;
                self.render();
            });
            links.append(link);
            links.append(' ');
        }
        $('#' + this.container).before(links);
        
        $(left).on('click', function () {
            self.index--;
            if (self.index < 0) {
                self.index = self.mapList.length - 1;
            }
            self.render();
        });
        $(right).on('click', function () {
            self.index++;
            if (self.index >= self.mapList.length) {
                self.index = 0;
            }
            self.render();
        });
    },
    render: function () {
        this.mapOptions.center = new google.maps.LatLng(this.mapList[this.index].lat, this.mapList[this.index].lng)
        var map = new google.maps.Map(document.getElementById(this.container), this.mapOptions);
        var marker = new google.maps.Marker({
            position: map.getCenter(),
            map: map,
            title: "Center of " + this.mapList[this.index].city,
        });
        var info = new google.maps.InfoWindow({
            content: this.mapList[this.index].info
        });
        google.maps.event.addListener(marker, 'click', function () {
            map.setZoom(11);
            map.setCenter(marker.getPosition());
            info.open(map, marker);
        });
    },
};

if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}
