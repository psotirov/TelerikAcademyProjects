(function ($) {
    $.fn.treeView = function (options) {
        options = options || {};

        var element = this;
        if (options.collapsed) {
            element.find('li ul').hide();
        } else {
            element.find('li ul').show();
        }

        element.on('click', 'li a', function (event) {
            event.stopPropagation();
            $(event.target).parent().find('>ul').toggle();
        });

        element.on('click', 'li', function (event) {
            event.stopPropagation();
            $(event.target).find('>ul').toggle();
        });

        return this;
    }
})(jQuery);