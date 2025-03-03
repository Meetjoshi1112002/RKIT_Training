/*
    sorting modess

    Disabling sorting for specific columns

    making sorting on mulitple column

    predefined intial sorting using sortIndex and sortOrder on columns

    handling sorting externally
*/ 

$(
    function(){
        // Creating a custom store for data management with CRUD operations
        let virtualStore = new DevExpress.data.CustomStore({
            key: 'id',  // Unique identifier for each record

            // Function to load data from API
            load: async function () {
                try {
                    let data = await $.get("https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users");
                    return data;
                } catch (error) {
                    DevExpress.ui.notify('Error loading data', 'error', 2000);
                    console.error('Load Error:', error);
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
            },

            // Function to update an existing record
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
            }
        });

        const instance = $('#gridContainer').dxDataGrid({
            dataSource: virtualStore,
            columns: [
                { dataField: 'id', caption: 'ID', width: 50 },
                {
                    dataField: 'firstName', 
                    caption: 'First Name', 
                    allowSorting: false // Disables sorting for this column
                },
                { dataField: 'username', caption: 'Username' , sortOrder: 'asc' , sortIndex: 0},
                { dataField: 'email', caption: 'Email', sortOrder: 'desc' , sortIndex: 1}
            ],
            showBorders: true,
            sorting: {
                mode: "single" // Enables single-column sorting (default)
            }
        }).dxDataGrid('instance');

        instance.option('sorting.mode', 'multiple'); // shift click to make sorting on mulitple column

        const sortButton = $("#sort").dxButton({
            text: "UsernameSort",
            icon:"arrowdown",
            onClick: function () {
                instance.columnOption("username",{
                    sortIndex: 0,
                    sortOrder: "desc"
                });
            }
        })

        const clearsort = $("#clearSorting").dxButton({
            text: "Clear Sorting",
            icon:"clear",
            onClick: function () {
                instance.clearSorting();
            }
        })
    }
)