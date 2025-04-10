$(
    function () {
        //#region Store
        let store = new DevExpress.data.CustomStore({
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

        
        let customColumns = [
            { dataField: 'id', caption: 'ID', width: 50, fixed: true }, // Fixed Column
            { dataField: 'firstName', caption: 'First Name', allowSorting: false }, // Sorting disabled
            { dataField: 'username', caption: 'Username', visible: false }, // Initially hidden
            { dataField: 'email', caption: 'Email', sortOrder: 'asc' }, // Default sorting
            { type: 'buttons', width: 110, buttons: ['edit', 'delete'] } // Action buttons
        ];
        
        let dynamicColumns;
        store.load().done(function (data) {
            if (data && data.length > 0) {
                dynamicColumns = Object.keys(data[0]).map(field => ({
                    dataField: field,
                    caption: field.charAt(0).toUpperCase() + field.slice(1), // Capitalize column names
                    allowEditing: field !== "id" // Make ID column read-only
                }));
            }
        });
        
        const myGrid = $("#myGrid").dxDataGrid({
            dataSource: store, // Custom store
            columns: dynamicColumns, // Predefined columns
            columnFixing: { enabled: true }, // Allow fixing columns
            columnChooser: { enabled: true }, // Enable column selection
            showBorders: true, // Show grid borders
            allowColumnReordering: true, // Drag to reorder columns
            allowColumnResizing: true, // Resize columns
            columnAutoWidth: true, // Auto-adjust column width
            paging: { pageSize: 10 }, // Enable pagination (10 rows per page)
            
            // Enable inline row editing
            editing: {
                mode: 'row', 
                allowUpdating: true,
                allowDeleting: true,
                allowAdding: true
            },
        
            // Events for debugging
            onRowUpdating: function (e) {
                console.log('Row updating:', e.oldData, '=>', e.newData);
            },
            onRowInserted: function (e) {
                console.log('Row inserted:', e.data);
            },
            onRowRemoved: function (e) {
                console.log('Row removed:', e.data);
            }
        }).dxDataGrid('instance');

        const myGrid2 = $("#myGrid2").dxDataGrid({
            dataSource: store, 
            columns: [
                {
                    dataField: 'id',
                    caption: 'ID',
                    width: 50,
                    fixed: true
                },
                {
                    caption: 'Full Name', // Multi-row header
                    columns: [
                        { dataField: 'firstName', caption: 'First Name' },
                        { dataField: 'lastName', caption: 'Last Name' }
                    ]
                },
                { dataField: 'username', caption: 'Username' },
                { dataField: 'email', caption: 'Email' },
                {
                    type: "buttons",
                    width: 150,
                    buttons: [
                        { name: 'edit', icon: 'edit' },
                        { name: 'delete', icon: 'remove' },
                        {
                            hint: "Send Email",
                            icon: "email",
                            onClick: function (e) {
                                alert(`Sending email to ${e.row.data.firstName}`);
                            }
                        }
                    ]
                }
            ],
            columnFixing: { enabled: true }, // Fix columns in place
            columnChooser: { enabled: true }, // Allow users to show/hide columns
            allowColumnReordering: true, // Drag to reorder columns
            allowColumnResizing: true, // Resize columns
            columnResizingMode: "widget", // widget, nextColumn
            columnAutoWidth: true, // Adjust width automatically
            stateStoring: {
                enabled: true,
                type: 'localStorage', // Saves settings in browser storage
                key: 'gridState',
                ignore: ["sorting", "filtering"] // Ignore sorting/filter changes
            }
            

        }).dxDataGrid('instance');
        
        $("#button").dxButton({
            text: "Reset Grid State",
            onClick: function () {
                localStorage.removeItem("storage"); // Clear stored state
                location.reload(); // Reload page to reset
            }
        });
        
        
    }
)