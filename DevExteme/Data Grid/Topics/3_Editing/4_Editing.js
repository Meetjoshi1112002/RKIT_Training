/*
    Impaortant things to learn from here:

    1st : how we used a custom logic to delete using contextmenu of right click on that row

    2nd : How we can use other UI components in form of editing and layout them using colcount

    3rd : Using toolbar to have additional buttons on grid for refresh and logger
*/




$(
    function(){
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
                },
                // { type: 'buttons', width: 100, buttons: ['edit', 'delete'] }, However this comes free with editin modes
            ],
            scrolling: {
                mode: 'virtual'  // For large datasets, improves performance by loading rows as you scroll
            },
            showBorders: true,
            allowColumnReordering: true,
            editing: {
                mode: "form", // Enables form editing mode
                allowUpdating: true,
                allowAdding: true,
                allowDeleting: true,
                form: {
                    colCount: 2, // Display fields in 2 columns
                    labelLocation: "top",
                    items: [ // Customizing fields
                        {
                            dataField: "username",
                            editorType: "dxTextBox",
                            editorOptions: { placeholder: "Enter Name" },
                            validationRules: [{ type: "required", message: "Name is required" }]
                        },
                        {
                            dataField: "email",
                            editorOptions: { mode: "email", placeholder: "Enter Email" },
                            validationRules: [{ type: "email", message: "Enter a valid email" }]
                        },
                        {
                            dataField: "id",
                            editorType: "dxNumberBox",
                            editorOptions: {
                                min:1,
                                max:1000,
                                showSpinButtons: true,
                                step:10
                            }
                        }
                    ]
                }
            },
            onEditingStart: function (e) {
                console.log("Editing started for:", e.data);
            },
            onRowUpdating: function (e) {
                console.log("Updating row:", e.oldData, "=>", e.newData);
                if (!e.newData.name) {
                    e.cancel = true;
                    DevExpress.ui.notify("Name cannot be empty!", "error", 2000);
                }
            },
            
            onSaving: function (e) {
                console.log("Saving changes:", e);
            },
            onEditCanceled: function (e) {
                console.log(e)
                console.log("Edit canceled for row:", e.rowIndex, "Row data:", e.data);
                DevExpress.ui.notify("Edit was canceled", "info", 2000);
            },
            onEditCanceling: function (e) {
                if (!confirm("Are you sure you want to cancel the edit?")) {
                    e.cancel = true;
                }
            },

            onContextMenuPreparing: function (e) { // onContextMenuPreparing is used to customize the right-click menu. 
            // You can add custom actions, like Export, Delete, Edit, etc.
                if (!e.items) e.items = [];  // Checks if e.items exists → If not, initializes an empty menu (e.items = []).
            
                if (e.row && e.row.rowType === "data") { //Verifies if the right-click happened on a "data row" (not header/footer).
                    e.items.push(
                        {
                            text: "Cosnole Data", //Adds a custom menu item called "Export Data".
                            icon: "export", // Add an icon
                            onItemClick: function () { 
                                console.log(e.row.data);
                            } // here we can have some custom actions
                        },
                        {
                            text: "Delete Row",
                            icon: "trash", // Trash icon
                            disabled: e.row.data.status === "Approved", // Disable if status is "Approved"
                            onItemClick: function () {
                                console.log(e.row.data.id)
                                store.remove(e.row.data.id)
                                .then((data)=>{
                                    console.log(data)
                                    e.component.refresh(); // Refresh the grid to reflect changes
                                })
                            }
                        }
                    );
                }
            },

            onDataErrorOccurred: function (e) { // Displays error messages when data validation fails.
                console.error("Data Error:", e.error.message);
                DevExpress.ui.notify("An error occurred: " + e.error.message, "error", 2000);
            },

            onToolbarPreparing: function (e) { 
                e.toolbarOptions.items.push(
                    {
                    location: "after", // Places the button after default items
                    widget: "dxButton",
                    options: {
                        icon: "search",
                        text: "Logger",
                        onClick: function () {
                            let dataSource = e.component.getDataSource(); // Get the grid's data source
                            let data = dataSource.items(); // Get all loaded records
                            
                            console.log("First 5 records:", data.slice(0, 5)); // Log the first 5 records
                        }
                    }
                },
                {
                    location: "after", // Places the button after default items
                    widget: "dxButton",
                    options: {
                        icon: "refresh",
                        text: "ReFresh",
                        onClick: function () {
                            e.component.refresh(); // reloads the data
                        }
                    }
                },

            
            );
            }

        }).dxDataGrid('instance');
    }
)