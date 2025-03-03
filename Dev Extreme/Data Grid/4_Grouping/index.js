let customers = [
    { ID: 1, Name: "Alice", State: "California", City: "Los Angeles", Phone: "123-456-7890" },
    { ID: 2, Name: "Bob", State: "California", City: "San Francisco", Phone: "987-654-3210" },
    { ID: 3, Name: "Charlie", State: "New York", City: "New York City", Phone: "555-555-5555" },
    { ID: 4, Name: "David", State: "New York", City: "Buffalo", Phone: "666-666-6666" },
    { ID: 5, Name: "Eve", State: "Texas", City: "Dallas", Phone: "777-777-7777" }
];

$(function () {
    const dataGrid = $("#gridContainer").dxDataGrid({
        dataSource: customers,
        keyExpr: "ID",
        columns: [
            { dataField: "Name", caption: "Customer Name" },
            { dataField: "State", groupIndex: 0 }, // First level grouping  // now this will be used for indexing/grouping
            { dataField: "City", groupIndex: 1 },  // Second level grouping
            { dataField: "Phone" }
        ],
        grouping: {
            autoExpandAll: true,   // Expands all groups initially

            contextMenuEnabled: true, // Enables right-click menu for grouping when click on any column (it automatically use it in next index of grping)

            allowColumnDragging: true,  // Disables dragging columns inside group panel

            expandMode: "rowClick",  // Expands group when row is clicked

            allowCollapsing: true  // Allows collapsing grouped rows
        },
        groupPanel: {
            visible: true,// Displays a grouping panel for users to drag columns
            allowColumnDragging: false
        },
        allowColumnReordering: true,
        allowColumnResizing: true,
        showBorders: true,
        onRowExpanding: function(e) {
            console.log("Expanding row: ", e.key); // show meta grps of that row
        },
        onRowCollapsed: function(e) {
            console.log("Collapsed row: ", e.key); 
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
                                console.log(e.row.data.ID);
                                customers = customers.filter((obj)=> obj.ID !== e.row.data.ID)
                                e.component.option("dataSource",customers);
                            }
                        }
                    );
                }
            },
    });

    // Button to toggle expand/collapse all
    $("#toggleExpand").dxButton({
        text: "Toggle Group Expand",
        onClick: function () {
            let grid = $("#gridContainer").dxDataGrid("instance");
            let isExpanded = grid.option("grouping.autoExpandAll");
            grid.option("grouping.autoExpandAll", !isExpanded);
        }
    });


    $("#toggleGroup").dxButton({
        text: "Toggle Group (California → Los Angeles)",
        onClick: function () {
            let dataGrid = $("#gridContainer").dxDataGrid("instance"); // Ensure instance retrieval
            let groupKey = ["California", "Los Angeles"]; // Static input for 2-level grouping
    
            // Load the grouped data
            let dataSource = dataGrid.getDataSource();
            if (!dataSource) {
                DevExpress.ui.notify("Data source not found!", "error", 2000);
                return;
            }
    
            dataSource.load().done((groupedData) => {
                console.log(groupedData);
                // Check if the group exists
                let groupExists = checkGroupExists(groupedData, groupKey, 0);
    
                if (!groupExists) {
                    DevExpress.ui.notify("Group not found!", "warning", 2000);
                    return;
                }
    
                // Toggle expansion
                if (dataGrid.isRowExpanded(groupKey)) {
                    dataGrid.collapseRow(groupKey);
                } else {
                    dataGrid.expandRow(groupKey);
                }
            }).fail(() => {
                DevExpress.ui.notify("Failed to load data source!", "error", 2000);
            });
        }
    });
    
    function checkGroupExists(items, groupKey, level) {
        for (let item of items) {
            if (item.key === groupKey[level]) {
                if (level === groupKey.length - 1) return true; // Found the full group path
                return checkGroupExists(item.items || [], groupKey, level + 1); // Check deeper levels
            }
        }
        return false;
    }
    
    
});
