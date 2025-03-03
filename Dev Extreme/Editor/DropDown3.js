$(
    function(){

        // Let us learn drop down with mulit select

        const fruits = ["Apple", "Banana", "Cherry", "Date", "Elderberry"];

        $("#myDropDown3").dxDropDownBox({
            items: fruits, // Array of fruits
            placeholder: "Select fruits...", // Placeholder text
            value: [], // Initialize with no selected values

            // Define content template
            contentTemplate: function(e) {
                const $list = $("<div>").dxList({
                    dataSource: e.component.option("items"), // Data source from the items
                    selectionMode: "multiple", // Enable multiple selection
                    showSelectionControls: true, // Show selection controls (checkboxes)
                    displayExpr: "this", // Display item text (same as value in simple array)
                    selectedItems: e.component.option("value"), // Bind selected items
                    onSelectionChanged: function (args) {
                        let selectedItems = e.component.option("value") || []; // Ensure selectedItems is always an array

                        // Clone the array to avoid modifying the reference
                        selectedItems = [...selectedItems];

                        // Ensure `addedItems` exists and is not empty before pushing
                        if (args.addedItems?.length > 0 && args.addedItems[0] !== undefined) {
                            selectedItems.push(args.addedItems[0]);
                        }

                        // Ensure `removedItems` exists and is not empty before filtering
                        if (args.removedItems?.length > 0 && args.removedItems[0] !== undefined) {
                            selectedItems = selectedItems.filter(item => item !== args.removedItems[0]);
                        }

                        // Debugging logs to check what's happening
                        console.log("Added Items:", args.addedItems);
                        console.log("Removed Items:", args.removedItems);
                        console.log("Updated Selected Items:", selectedItems);

                        // Update the component with the new value array
                        e.component.option("value", selectedItems);

                    }
                });

                return $list;
            }
        });
    }
)