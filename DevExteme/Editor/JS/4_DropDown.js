$(
    function(){
        // Drop down with a basic List:
        const fruits = ["Apples", "Oranges", "Lemons", "Pears", "Pineapples"]; // Our data source

        const Customers = [
            {
                ID:1,
                Name:"Rohanshu",
                City:"New York"
            },
            {
                ID:2,
                Name:"Meet joshi",
                City:"Ahemdabad"
            },
            {
                ID:3,
                Name:"Navneet",
                City:"Delhi"
            }
        ]

        let DropDownBoxInstance = $("#myDropDownBox").dxDropDownBox({
            // Show default selected value
            value:fruits[0]??"No Item found", // Show default selected text on input field
            dataSource:fruits,
            // Define inside the drop down ie Here list
            contentTemplate:function (e1){
                // Here we will crete a list and simple return it
                const list = $("<div>").dxList({
                    dataSource:e1.component.option("dataSource"),
                    selectionMode:"single",
                    // When any selction change occurs we need to change the input of our drop down as well
                    onSelectionChanged:function(e2){
                        e1.component.option("value", e2.addedItems[0]); // Update the value option
                        e1.component.close(); // close the drop down
                    }
                });
                return list;
            }
        }).dxDropDownBox("instance");



        //In this example, the dropdown contains a DataGrid instead of a simple list.

        
        DropDownBoxInstance.option({
            valueExpr:"ID",          // When we are using object then we mention the feild name of the object that used to point any obj selected

            value:Customers[0]?.ID??"No Item found", // ID of the object whose any value we want to show on input field

            displayExpr: "Name",    // Field of the object we want to display

            dataSource: new DevExpress.data.ArrayStore({  // when drop down have cusotm object then we need to create a array store for it
                data:Customers,
                key:"ID"
            }),

            // now we will create a data grid

            contentTemplate: function(e1) {
                const dataGrid = $("<div>").dxDataGrid({
                    dataSource: e1.component.option("dataSource"),
                    columns: ["ID", "Name", "City"],
                    height: 300,
                    selection: {
                        mode: "single"
                    },
                    selectedRowKeys: [Customers[0].ID],
                    onSelectionChanged: function(e2) {
                        const selectedRowKeys = e2.component.option("selectedRowKeys");
                        const hasSelection = selectedRowKeys.length;
                        e1.component.option("value", hasSelection ? selectedRowKeys[0] : null);
                        e1.component.close();
                    }
                });
                return dataGrid;
            }

        })
    }
)