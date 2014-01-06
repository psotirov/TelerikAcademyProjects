var Slider = {
    init: function (content) {
        this.content = content;
    },
    render: function (selector) {
        this.selector = selector;
        for (var j = 0, len = this.content.length; j < len; j++) {
            if (j == 0) {
                $(this.selector).append('<div class="current first"> ' + this.content[j] + '</div>');
            } else if (j == len - 1) {
                $(this.selector).append('<div class="hidden last"> ' + this.content[j] + '</div>');
            } else {
                $(this.selector).append('<div class="hidden"> ' + this.content[j] + '</div>');
            }
        }
    },
    next: function () {
        var curContent = $('.current');
        if (!curContent)
            return;
        var nextContent = curContent.next();
        if (nextContent.length == 0)
            nextContent = $('.first');
        curContent.removeClass('current').addClass('hidden');
        nextContent.removeClass('hidden').addClass('current');
    },
    previous: function () {
        var curContent = $('.current');
        if (!curContent)
            return;
        var prevContent = curContent.prev();
        if (prevContent.length == 0)
            prevContent = $('.last');
        curContent.removeClass('current').addClass('hidden');
        prevContent.removeClass('hidden').addClass('current');
    }
};

if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}