$(
    function () { 
        //#region  Custom Store
        // Our data Source
        var store = new DevExpress.data.CustomStore({
            key:"id",
            load:async function(params) {
                try{
                    let data = await $.get("https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users");
                    return data;
                }
                catch (error) {
                    DevExpress.ui.notify('Error loading data', 'error', 2000);
                    console.error('Load Error:', error);
                }
            },
    
            update: async function (key, values) {
                try {
                    let result = await $.ajax({
                        url: `https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users/${key}`,
                        method: 'PUT',
                        data: values
                    });
                    DevExpress.ui.notify(`Row updated: ${JSON.stringify(result)}`, 'success', 2000);
                    return result;
                } catch (error) {
                    DevExpress.ui.notify('Error updating data', 'error', 2000);
                    console.error('Update Error:', error);
                }
            },
    
            // Function to delete a record
            remove: async function (key) {
                try {
                    await $.ajax({
                        url: `https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users/${key}`,
                        method: 'DELETE'
                    });
                    DevExpress.ui.notify(`Row removed: ID = ${key}`, 'success', 2000);
                } catch (error) {
                    DevExpress.ui.notify('Error removing data', 'error', 2000);
                    console.error('Remove Error:', error);
                }
            },
    
            // Function to insert new data into API
            insert: async function (values) {
                try {
                    let result = await $.post("https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users/add", values);
                    DevExpress.ui.notify(`Row added: ${JSON.stringify(result)}`, 'success', 2000);
                    return result;
                } catch (error) {
                    DevExpress.ui.notify('Error adding data', 'error', 2000);
                    console.error('Insert Error:', error);
                }
            }
        })

        //#endregion




        //=======================================Row Editing (cell  mode )===============================

        const myGrid = $('#myGrid').dxDataGrid({
            dataSource: store,

            columns:[
                { dataField: "id", caption: "ID" },
                {
                    dataField:"Name",caption:"Name",
                    calculateCellValue:function(data){
                        return `${data.firstName} ${data.lastName}`; 
                    }
                },
                { dataField: 'username', caption: 'Username' },

                // Adding data validations as well
                { dataField: 'email', caption: 'Email' ,  // changes wont be saved if not valid
                    validationRules: [
                        { type: 'required' , message: 'Email is required' },
                        { type: 'email' , message: 'Invalid email format' }
                    ]
                }
            ],

            editing: {
                mode: "cell",  // Enables cell editing mode
                allowUpdating: true, 
                allowAdding: true,
                allowDeleting: true
            },

            // ======================================= Editing Events for cell ===============================
            
            onCellClick: function (e) {
                console.log("Cell clicked:", e.column.dataField, "Value:", e.value);
            },
            onCellDblClick: function (e) {
                console.log("Cell double-clicked:", e.column.dataField, "Row data:", e.data);
            },
            onCellHoverChanged: function (e) {
                // console.log("Cell hovered:", e.column.dataField);
                // console.log("Row : ", e.data);
                e.cellElement.css("background-color", e.event.type === "mouseover" ? "#f0f8ff" : "white");
            },
            onCellPrepared: function (e) {
                console.log(e)
                if (e.rowType === "data" && e.column.dataField === "id") {   // e.rowType could be data or header
                    e.cellElement.css("background-color", e.rowIndex % 2 === 0 ? "lightgreen" : "lightcoral");
                }
            }

        }).dxDataGrid('instance');
    }
)