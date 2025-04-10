$(
    function () {
        // Let us create a custom store that help us perform crud operation

        let store = new DevExpress.data.CustomStore({
            key: 'id',
            loadmode:'raw',
            load: async function () {
                try {
                    let data = $.get("https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users");
                    return data;
                }
                catch (error) {
                    DevExpress.ui.notify("Error loading the data");
                    console.error(error);
                    return [];
                }
            },

            // function to insert new data in it
            insert: async function (data) {
                try {
                    let response = await $.ajax({
                        url: "https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users",
                        method: 'POST',
                        data: data
                    });

                    DevExpress.ui.notify("Row added " + response.id);
                    return response;
                }
                catch (error) {
                    DevExpress.ui.notify("errror removing data" + error.StatusText);
                    console.error(error);
                    throw error;
                }
            },
            // Function to update an existing record
            update: async function (key, values) {
                try {
                    let result = await $.ajax({
                        url: `https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users/${key}`,
                        method: 'PUT',
                        data: values,
                    });
                    DevExpress.ui.notify(`Row updated: ID = ${key}`, 'success', 2000);
                    return result;
                } catch (error) {
                    DevExpress.ui.notify('Error updating data: ' + error.statusText, 'error', 2000);
                    console.error('Update Error:', error);
                    throw error;
                }
            },

            // Function to delete a record
            remove: async function (key) {
                try {
                    let result = await $.ajax({
                        url: `https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users/${key}`,
                        method: 'DELETE',
                    });
                    DevExpress.ui.notify(`Row removed: ID = ${key}`, 'success', 2000);
                    return result;
                } catch (error) {
                    DevExpress.ui.notify('Error removing data: ' + error.statusText, 'error', 2000);
                    console.error('Remove Error:', error);
                    throw error;
                }
            }
        });

        // other data
        let states = [
            {
                "id": 1,
                "name": "California"
            },
            {
                "id": 2,
                "name": "Texas"
            },
            {
                "id": 3,
                "name": "New York"
            },
            {
                "id": 4,
                "name": "Florida"
            },
            {
                "id": 5,
                "name": "Illinois"
            }
        ];

        let cities = [
            {
                "id": 1,
                "name": "Los Angeles",
                "stateId": 1
            },
            {
                "id": 2,
                "name": "San Francisco",
                "stateId": 1
            },
            {
                "id": 3,
                "name": "Houston",
                "stateId": 2
            },
            {
                "id": 4,
                "name": "Austin",
                "stateId": 2
            },
            {
                "id": 5,
                "name": "New York City",
                "stateId": 3
            },
            {
                "id": 6,
                "name": "Buffalo",
                "stateId": 3
            },
            {
                "id": 7,
                "name": "Miami",
                "stateId": 4
            },
            {
                "id": 8,
                "name": "Orlando",
                "stateId": 4
            },
            {
                "id": 9,
                "name": "Chicago",
                "stateId": 5
            },
            {
                "id": 10,
                "name": "Springfield",
                "stateId": 5
            }
        ];


        // Now let us configure the grid

        const myGrid = $("#gridContainer").dxDataGrid({
            dataSource: store,
            remoteOperations:false,
            // columns
            columns: [
                {
                    dataField: 'id',
                    caption: 'ID',
                    width: 50,
                },

                /// some field may be image url so we need to template it

                {
                    dataField: 'image',
                    caption: 'Profile Picture',
                    alignment: 'center',
                    hidingPriority: 0,

                    cellTemplate: function (container, items) {
                        $('<img>')
                            .attr('src', items.value)
                            .css({ width: '50px', height: '50px', borderRadius: '50%' })
                            .appendTo(container);
                    }
                },

                /// merging colums
                {
                    caption: 'Full Name',
                    alignment: 'center',
                    columns: [
                        {
                            dataField: 'firstName',
                            caption: 'First Name',
                            dataType: 'string'
                        },
                        {
                            dataField: 'lastName',
                            caption: 'Last Name',
                            dataType: 'string'
                        }
                    ]
                },

                /// calculating value fo a column
                {
                    caption: 'Full Name',
                    alignment: 'center',
                    dataField: "Full Name",
                    calculateCellValue: function (data) {
                        return `${data.firstName} ${data.lastName}`;
                    }
                },

                {
                    dataField: 'username',
                    caption: 'Username',
                    dataType: 'string'
                },
                {
                    dataField: 'email',
                    caption: 'Email',
                    dataType: 'string'
                },
                {
                    dataField: 'age',
                    caption: 'Age (years)',
                    dataType: 'number',
                    cellTemplate: function (container, options) {

                        let color = options.value < 25 ? 'red' : 'green';
                        $('<span>')
                            .text(options.value + " years old")
                            .css('color', color)
                            .appendTo(container);

                    }
                },
                {
                    dataField: 'birthDate',
                    caption: 'Birth Date',
                    format: 'yyyy-MM-dd',
                    dataType: 'date',
                    hidingPriority:1
                },
                {
                    dataField: 'gender',
                    caption: 'Gender',
                    dataType: 'string',
                    cellTemplate: function (container, options) {
                        let gender = options.value;
                        let color = gender === 'Male' ? 'blue' : gender === 'Female' ? 'pink' : 'black';

                        $('<span>')
                            .text(gender)
                            .css('color', color)
                            .appendTo(container);
                    }
                },
                /// look up example (where selecting one value can affect the other)
                {
                    caption: 'Address',
                    alignment: 'center',
                    columns: [
                        {
                            dataField: 'stateId',
                            caption: 'State',
                            groupIndex: 0,
                            setCellValue(rowData, value) {
                                rowData.stateId = value;
                                rowData.cityId = null;
                            },

                            lookup: {
                                dataSource: states,
                                valueExpr: 'id',
                                displayExpr:'name'
                            }
                        },
                        {
                            dataField: 'cityId',
                            caption: 'City',
                            lookup: {
                                dataSource(options) {
                                    return {
                                        store: cities,
                                        filter: options.data && options.data.stateId ? ['stateId', '=', options.data.stateId] : null,
                                    };
                                },
                                valueExpr: 'id',
                                displayExpr: 'name',
                            },
                        },
                    ]
                },
                {
                    type: 'buttons',
                    caption: 'Actions',
                    buttons: [
                        {
                            name: 'edit',
                            icon: 'edit'
                        },
                        {
                            name: 'delete',
                            icon: 'trash'
                        }
                    ]
                }
            ],

            columnChooser: { enabled: true }, // Allow users to show/hide columns

            //Filterting features

            // 1st Filter row:
            filterRow: {
                visible: true,
                applyFilter: "auto" // Applies filters automatically
            },

            // 2nd Header Filter (Dropdown Filtering)
            headerFilter: {
                visible: true,
                allowSearch: true
            },

            // 3rd Search Panel
            searchPanel: {
                visible: true,
                width: 240,
                placeholder: "Search..."
            },

            // 4th Filter panel
            filterPanel: {
                visible: true,
                width: 240
            },

            //5th Custom filter builder
            filterBuilder: {
                customOperations: [{
                    name: "MeetSearch",
                    caption: "MeetSearch",
                    dataTypes: ["string"], // Ensure lowercase "string"
                    hasValue: false, // No user input needed
                    calculateFilterExpression: function (filterValue, field) {
                        return [field.dataField, "=", "Meet"]; // Correct DevExpress filter syntax
                    }
                }]
            },

            columnAutoWidth: true,

            // editing modes
            editing: {
                mode: 'popup',
                allowAdding: true,
                allowUpdating: true,
                allowDeleting: true,
                popup: {
                    title: 'User Information',
                    showTitle: true,
                    width: 800,
                }
            },


            // Grouping options
            grouping: {
                // Automatically expand all groups when the grid is loaded
                autoExpandAll: true,

                // Enable the context menu for groups
                contextMenuEnabled: true,

                // Disable column dragging within groups
                allowColumnDragging: true,

                // Set the mode of expansion to row click (clicking a row expands it)
                expandMode: "rowClick",

                // Allow collapsing of grouped rows
                allowCollapsing: true
            },

            groupPanel: {
                visible: true, // Enabling the group panel at the top of the grid
            },
            
            filterSyncEnabled: false, // Disabling sync between different filter panels

            
            // Export data grid to an Excel file
            onExporting: function (e) {
                const workBook = new ExcelJS.Workbook(); // Create new workbook
                const worksheet = workBook.addWorksheet('Data'); // Add worksheet

                DevExpress.excelExporter.exportDataGrid({
                    worksheet: worksheet,
                    component: e.component
                }).then(function () {
                    workBook.xlsx.writeBuffer().then(function (buffer) {
                        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'DataGrid.xlsx');
                    });
                });
                e.cancel = true; // Prevent default export behavior
            },

            export: {
                enabled: true // Enable data export feature
            },

            columnHidingEnabled: true, // Enable column hiding for responsiveness

            selection: {
                mode: 'multiple',
                selectAllMode: "page",
                showCheckBoxesMode: "none" // // or "onClick" | "onLongTap" | "always" 
            },

            // summary settings**********************

            summary: {
                totalItems: [
                    {
                        column: "id",
                        summaryType: "count",
                        showInColumn: 'firstName',
                        customizeText: function (data) {
                            return `Total Count: ${data.value}`;
                        }
                    },
                    {
                        column: "age",
                        summaryType: "custom",
                        name: "customAgeSummary",
                        showInColumn: "age",
                        customizeText: function (data) {
                            return "Total Adults : " + data.value;
                        }
                    }
                ],
                groupItems: [
                    {
                        column: 'id',
                        summaryType: 'count',
                        displayFormat: 'Total People: {0}',
                        showInGroupFooter: true,
                        showInColumn: 'cityId'
                    }
                ],
                calculateCustomSummary: function (options) {
                    if (options.name == 'customAgeSummary') {
                        if (options.summaryProcess == 'start') {
                            options.totalValue = 0;
                        }
                        if (options.summaryProcess == 'calculate') {
                            if (options.value >= 18) {
                                options.totalValue += 1;
                            }
                        }
                    }
                }
            },

            allowColumnReordering: true,

            // pagination settings 

            paging: {
                pageSize: 10
            },

            pager: {
                showPageSizeSelector: true,  // Allow the user to select page size
                allowedPageSizes: [10, 20, 30],  // Page size options
                showInfo: true,  // Show current page information
                displayMode: 'adaptive',  // Adaptive mode for better UI on small screens
                infoText: 'Page {0} of {1} ({2} items)',  // Custom information text
                showNavigationButtons: true,  // Display navigation buttons for paging
                visible: 'auto'  // Automatically show/hide the pager based on data size
            },

            showBorders: true,

            // Toolbar with additional buttons and filters
            onToolbarPreparing: function (e) {
                e.toolbarOptions.items.unshift(
                    {
                        location: 'before',
                        widget: 'dxButton',
                        options: {
                            icon: 'refresh',
                            text: 'Refresh Data',
                            onClick: function () {
                                $("#gridContainer").dxDataGrid("instance").refresh();
                            }
                        }
                    },
                    {
                        location: 'before',
                        widget: 'dxSelectBox',
                        options: {
                            items: ['All', 'Male', 'Female', 'Other'],
                            value: 'All',
                            onValueChanged: function (args) {
                                let grid = $("#gridContainer").dxDataGrid("instance");

                                if (args.value === 'All') {
                                    grid.clearFilter(); // Remove all filters to show all data
                                } else {
                                    grid.filter(["gender", "=", args.value]);
                                }
                            }
                        }
                    },
                    {
                        location: 'after',
                        widget: 'dxTextBox',
                        options: {
                            placeholder: "Search...",
                            onValueChanged: function (e) {
                                let grid = $("#gridContainer").dxDataGrid("instance");
                                grid.searchByText(e.value);
                            }
                        }
                    }
                );
            }

        })
    }
)