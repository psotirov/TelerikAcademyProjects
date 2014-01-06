(function () {
    WinJS.Namespace.define("Data", {
        getComputer: function (name, price, imageUrl, processorName, processorGHz, rating) {
            var comp = {
                name: name,
                imageUrl: imageUrl,
                price: price,
                processor: {
                    modelName: processorName,
                    frequencyGHz: processorGHz
                },
                rating: rating
            };
            return WinJS.Binding.as(comp);
        },
        getComputerAs: function (comp) {
            return WinJS.Binding.as(comp);
        }
    });
})();