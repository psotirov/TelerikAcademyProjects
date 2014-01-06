(function () {
    WinJS.Namespace.define("Data", {
        getComputer: function (name, price, imageUrl, manufacturer, processorName, processorGHz, rating) {
            var comp = {
                name: name,
                imageUrl: imageUrl,
                manufacturer: manufacturer,
                price: price,
                processor: {
                    modelName: processorName,
                    frequencyGHz: processorGHz
                },
                rating: rating
            };
            // return WinJS.Binding.as(comp);
            return comp;
        },
        getComputerAs: function (comp) {
            return WinJS.Binding.as(comp);
        }
    });
})();