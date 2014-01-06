(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            // TODO: Initialize the page here.

            // Initialize the ListView
            WinJS.UI.processAll(element);
            element.querySelector("#listView").winControl
                .oniteminvoked = function (args) {
                    var articleIndex = args.detail.itemIndex;
                    var articleTitle = TableOfContents.items.getAt(articleIndex).title;
                    WinJS.Navigation.navigate("/pages/article/article.html", { articleTitle: articleTitle, articleIndex: articleIndex });
                };
        }
    });
})();
