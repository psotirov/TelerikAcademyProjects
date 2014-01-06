var GridView = {
    init: function (container) {
        this.container = container;
        this.header = null;
        this.rows = [];
    },
    addHeader: function () {
        var header = Object.create(GridViewHeader);
        header.init(arguments);
        this.header = header;
        return header;
    },
    addRow: function () {
        var row = Object.create(GridViewRow);
        row.init(arguments);
        this.rows.push(row);
        return row;
    },
    render: function () {
        var table = $("<table/>");
        if (this.header) {
            table.append(this.header.render());
        }

        for (var i = 0, len = this.rows.length; i < len; i++) {
            table.append(this.rows[i].render());
            if (this.rows[i].nestedGridView) {
                table.append($('<tr/>').append($('<td colspan="' + this.rows[i].columns.length + '"/>').append(this.rows[i].nestedGridView.render())).addClass("nested").hide());
            }
        }

        if (!this.container) {
            return table;
        }

        return $("#" + this.container).append(table);
    }
}

var GridViewRow = {
    init: function (columns) {
        this.columns = columns;
        this.nestedGridView = null;
    },
    nestedView: function () {
        var view = Object.create(GridView);
        view.init(null);
        this.nestedGridView = view;
        return view;
    },
    handleClick: function () {
        if ($(this).next().hasClass("nested")) {
            $(this).next().toggle();
        }
    },
    render: function () {
        var row = $("<tr/>");
        for (var i = 0, len = this.columns.length; i < len; i++) {
            row.append("<td>" + this.columns[i] + "</td>");
        }
        if (this.nestedGridView) {
            row.addClass("selector");
        }

        row.click(this.handleClick);
        return row;
    }
}

var GridViewHeader = {
    init: function (columns) {
        this.columns = columns;
    },
    render: function () {
        var header = $("<tr/>");
        for (var i = 0, len = this.columns.length; i < len; i++) {
            header.append("<th>" + this.columns[i] + "</th>");
        }

        return header;
    }
}

if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}