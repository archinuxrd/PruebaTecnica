$(document).ready(function() {
    let dataSource = $("#grid").kendoGrid({
        dataSource: {
            pageSize: 10,
            transport: {
                read:  {
                    url: "/Product/Get",
                    type: "POST",
                    dataType: "json",
                    data: function(model) {
                        return {
                            model
                        };
                    },
                    success: function (e) {
                        alert("hola ");
                    }
                },
                update: {
                    url: "/Product/Edit",
                    type: "PUT",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                destroy: {
                    url: "/Product/Delete",
                    type: "DELETE",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                create: {
                    url: "/Product/Create",
                    type: "POST",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                parameterMap: function(options, operation) {
                    if (operation !== "read" && options.model) {
                        return { model: options.model};
                    }
                }
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { editable: false, nullable: true },
                        Sku: { type: "string", validation: { required: true }, },
                        Name: { type: "string", validation: { required: true }, },
                        Description: { type: "string", validation: { required: true }, }
                    }
                }
            },
            requestEnd: function (e) {
                if (e.type === "update") {
                    this.read();
                }
                if (e.type === "create") {
                    this.read();
                }
            }
        },
        batch: true,
        height: 500,
        sortable: true,
        pageable: {
            refresh: true
        },
        toolbar: ["create", "search"],
        detailInit: detailInit,
        columns: [
            {
                field: "Sku",
                title: "Sku",
                width: "110px"
            },
            {
                field: "Name",
                title: "Name",
                width: "185px"
            },
            {
                field: "Description",
                title: "Description"
            },
            { command: [{ text: "View", click: showDetails, title: "&nbsp;" }, "edit", "destroy"], title: "&nbsp;", width: "275px" }
        ],
        editable: "inline",
    });
});

function showDetails(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "/Product/Details/"+dataItem.Id;

}

function detailInit(e) {
    $("<div/>").appendTo(e.detailCell).kendoGrid({
        dataSource: {
            transport: {
                read:  {
                    url: "/Combination",
                    type: "POST",
                    dataType: "json",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                destroy: {
                    url: "/Combination/Delete",
                    type: "DELETE",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                update: {
                    url: "/Combination/Edit",
                    type: "PUT",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                create: {
                    url: "/Combination/Create",
                    type: "POST",
                    data: function(model) {
                        return {
                            model
                        };
                    }
                },
                parameterMap: function(options, operation) {
                    if (operation !== "read" && options) {
                        return { model: options.model };
                    }
                }
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { editable: false, nullable: true },
                        ProductId: { type: "number", editable: false, defaultValue:  e.data.Id  },
                        Quantity: { type: "number", format: "{0:#}", validation: { required: true, min: 1, max: 10000 }, defaultValue: 1},
                        Color: { type: "string", validation: { required: true } },
                        UnitPrice: { type: "number",  validation: { required: true, min: 1, max: 1000000 } },
                    }
                }
            },
            requestEnd: function (e) {
                if (e.type === "update") {
                    this.read();
                }
                if (e.type === "create") {
                    this.read();
                }
            },
            filter: { field: "ProductId", operator: "eq", value: e.data.Id }
        },
        columns: [ 
            { field: "Quantity", format: "{0:#}", width: 150 },
            {
                field: "Color",
                title: "Color",
                editor: combinationEditor,
                groupHeaderTemplate: "Color: #=data.value#)#"
            },
            { field: "UnitPrice", title: "Unit Price", format: "{0:c}", width: 165 },
            { command: ["edit", "destroy"], title: "&nbsp;", width: 190 }
        ],
        toolbar: ["create", "search"],
        editable: "inline",
    });
}

function combinationEditor(container, options) {
    $('<input required name="Color">')
        .appendTo(container)
        .kendoDropDownList({
            dataTextField: "Name",
            dataValueField: "Key",
            dataSource: {
                transport: {
                    read: {
                        url: "/Combination/Color",
                        type: "GET",
                        dataType: "json"
                    },
                    data: function (model) {
                        return {
                            model
                        };
                    }
                }
            }
        });
}

function error_handler(e) {
    if (e.errors) {
        let message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function() {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}
