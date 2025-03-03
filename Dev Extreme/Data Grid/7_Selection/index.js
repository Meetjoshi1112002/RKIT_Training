/*

    Single row selection

    Mulitple row seleciton with checkbox with default selection

    handling seleciton event
    selectedRowKeys → All currently selected row IDs
    selectedRowsData → Full data of selected rows
    currentSelectedRowKeys → The newly selected row(s)
    currentDeselectedRowKeys → The newly deselected row(s)

    check if a row is selected or not

    deselect and select dynamically 
*/

$(
    function () {
        //#region Store
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
        //#endregion
        
        
        const grid = $('#myGrid').dxDataGrid({
            dataSource: virtualStore,
            key: 'id', // Primary key
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
            // selection: {
            //     mode: "single" // Only one row can be selected at a time
            // },
            selection: {
                mode: "multiple",  // Enable multi-selection
                selectAllMode: "page",//["all", "page"]  Select all rows on the current page . all :>Selects all rows, across all pages
                allowSelectAll: true,  // Show "Select All" checkbox
                showCheckBoxesMode: "always" // Always show checkboxes
            },
            selectedRowKeys: [11, 20, 31], // Preselect rows with IDs 1, 5, and 18
            showBorders: true,
            paging: {
                pageSize: 10
            },
            onSelectionChanged: function(e) {
                console.log("Currently Selected Rows: ", e.selectedRowKeys);
                console.log("Selected Rows Data: ", e.selectedRowsData);
                console.log("Newly Selected Rows: ", e.currentSelectedRowKeys);
                console.log("Newly Deselected Rows: ", e.currentDeselectedRowKeys);
            }
        }).dxDataGrid('instance');


        if (grid.isRowSelected(11)) {
            console.log("Row 11 is selected");
        }
        
        var toggle = true;

        $("#button").dxButton({
            text: "Toggle Row 11",
            onClick: function () {
                if (toggle) {
                    grid.selectRows([11], true);  // true means preserving existing selection . False means to overwritew
                }else{
                    grid.deselectRows([11]); // Deselect row with ID 5
                }
                toggle = !toggle;
            }
        });

        $("#button2").dxButton({
            text: "Clear Selection",
            onClick: function () {
                grid.deselectAll();   // Deselect all rows
                grid.clearSelection(); // Equivalent way to clear selection
            }
        });
    }
)