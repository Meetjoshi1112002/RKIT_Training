$(
    function(){

        // Let us have two data source

        const widgetData = [
            { ID: 1, fullName: "John Heart", position: "CEO"},
            { ID: 2, fullName: "Samantha Bright", position: "COO", headID: 1 }
        ];
        
        const dropDownBoxData = [
            { ID: 1, email: "jheart@dx-email.com" },
            { ID: 2, email: "samanthab@dx-email.com" }
        ];  
        
        
        const DropDownBoxInstance = $("#myDropDown2").dxDropDownBox({

            dataSource: new DevExpress.data.ArrayStore({
                data: widgetData,
                key: "ID"
            }),

            valueExpr: "ID",

            displayExpr: "fullName",

            value: widgetData[1].ID,

            contentTemplate: function(e1) {
                const dataGrid = $("<div>").dxDataGrid({
                    dataSource: new DevExpress.data.ArrayStore({
                        data: dropDownBoxData,
                        key: "ID"
                    }),

                    selection: {
                        mode: "single"
                    },

                    selectedRowKeys: [e1.component.option("value")],

                    onSelectionChanged: function(e2) {
                        const keySelected = e2.component.option("selectedRowKeys");
                        e1.component.option("value", keySelected[0]);
                        e1.component.close();
                    }
                })
                return dataGrid;
            }
        }).dxDropDownBox("instance");


        const fruits = [
            { id: 1, text: "Apples", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" }, 
            { id: 2, text: "Oranges", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" }, 
            { id: 3, text: "Lemons", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" }, 
            { id: 4, text: "Pears", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" }, 
            { id: 5, text: "Pineapples", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" }
        ];

        DropDownBoxInstance.option({
            dataSource: new DevExpress.data.DataSource({
                store: new DevExpress.data.ArrayStore({ data: fruits, key: "id" }),
            }),


            value: fruits[0],

            fieldTemplate: function(value, fieldElement) {
                return value !== null? $("<div class='custom-item' />").append(
                    $("<img />").attr("src", value.image).attr("width","70px"),
                    $("<div class='product-name' />").dxTextBox({
                        value: value.text,
                        readOnly:true
                    })
                ) :"No item selected";
            },

            dropDownOptions:{
                title:"Select an item",
                showTitle: true,
                fullScreen: true,
                showCloseButton: true
            },
            // Some important config

            accessKey: "d",

            activeStateEnabled: true,

            placeholder: "This is a placeholder",

            showClearButton: true,

            deferRendering: true, // does lazy loading of the drop down content


            //This function receives values from the data field set in the displayExpr property and should return a string that contains text for the input field. 
            // If the displayExpr is not set, the function receives full data objects.
            displayValueFormatter: function (value) {
                return "Hello... " + value + "!";  // Format the value with a '$' symbol
            },


            onClosed: function () {
                console.log("Dropdown list closed.");
            },

            showDropDownButton: true,

            stylingMode: "outlined",  // underlined, filled

            visible: true,

            onValueChanged: function(e) {
                if (e.value === null || e.value === undefined) {
                    e.component.option("showDropDownButton", true);
                }
                console.log("close")
            },

            //The butto that we see ot open the drop down
            dropDownButtonTemplate:function () {
                return $("<img />").attr("src", "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7")
                .attr("width","30px")
            },

            contentTemplate: function(e) {

                // create a container

                const container = $("<div>");

                const list = $("<div>").dxList({
                    dataSource:e.component.option("dataSource"),
                    selectionMode:"single",
                    onSelectionChanged: function(e2) {
                        e.component.option("value", e2.addedItems[0]);
                        e.component.close();
                    }
                })

                const $button = $("<div>").dxButton({
                    text: "Click Me",
                    type: "success",
                    onClick: function () {
                        alert("Button inside DropDownBox clicked!");
                    }
                }).css({ "margin-top": "10px" });

                container.append(list, $button);

                return container;
            }

        })
    }
)