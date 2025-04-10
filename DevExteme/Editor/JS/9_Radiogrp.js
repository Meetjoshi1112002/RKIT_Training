// Data items used in the radio group
const priorities = ['Low', 'Normal', 'Urgent', 'High'];

const dataItems = [
    { text: "Low", color: "grey" },
    { text: "Normal", color: "green" },
    { text: "Urgent", color: "yellow" },
    { text: "High", color: "red" }
];

// New items for the radio group to be updated later
const newItems = [
    { text: "Low", color: "grey" },
    { text: "Normal", color: "green" },
    { text: "Urgent", color: "yellow" },
    { text: "High", color: "red" },
    { text: "Very High", color: "black" }
];

$(function () {

    // First RadioGroup - Simple use case with basic configuration
    $("#radioGroupContainer").dxRadioGroup({
        dataSource: dataItems,           // Array of items to display
        displayExpr: "text",             // Property to display (default: 'text')
        value: dataItems[1],             // Initial selected value (default: null)
        // layout: "horizontal",         // Layout of the radio group (options: 'horizontal', 'vertical'; default: 'vertical')
        onValueChanged: function (e) {
            // Event triggered when the value changes
            let previousValue = e.previousValue;  // Previous selected value
            let newValue = e.value;               // New selected value
            console.log(previousValue, newValue);
            // Event handling logic goes here
        }
    });

    // Custom RadioGroup with custom item template
    $("#customRadioGroupContainer").dxRadioGroup({
        dataSource: dataItems,           // Array of items to display
        itemTemplate: function (itemData, itemIndex, itemElement) {
            // Custom template for each radio item
            itemElement.append($("<div />")).attr("style", "color:" + itemData.color)  // Set color of text based on item data
                .text(itemData.text);    // Display text of each item
        },
        layout: "horizontal"             // Layout of the radio group (default: 'vertical')
    });

    // RadioGroup with various options and event handlers
    let radioGroupInstance = $("#radioGroupContainer2").dxRadioGroup({
        accessKey: 'x',                  // Access key for the radio group (default: null)
        activeStateEnabled: true,        // Enables/disables the active state (default: true)
        dataSource: dataItems,           // Array of items to display
        disabled: false,                 // If the widget is disabled (default: false)
        displayExpr: "text",             // Property to display (default: 'text')
        valueExpr: "color",              // Property to store as the selected value (default: 'value')
        focusStateEnabled: true,         // Enables/disables the focus state (default: false)
        // height: function() {
        //     return window.innerHeight / 1.5; // Function to determine the height (default: auto)
        // },
        hint: "Select an option",        // Hint to display when the widget is focused (default: null)
        hoverStateEnabled: true,         // Enables/disables the hover state (default: true)
        name: "color",                   // Name of the radio group (default: null)
        onOptionChanged: function (e) {
            // Event triggered when any option is changed (default: no event handler)
            console.log("Option changed:", e);
        },
        onValueChanged: function (e) {
            // Event triggered when the value changes
            console.log("Value changed:", e);
        },
        readonly: false,                 // Makes the widget read-only (default: false)
        rtlEnabled: false,               // Enables/disables right-to-left mode (default: false)
        visible: true,                   // Makes the widget visible (default: true)
        // width: "500px",                // Width of the widget (default: auto)
        layout: "horizontal"             // Layout of the radio group (default: 'vertical')
    }).dxRadioGroup("instance");

    // Update radio group items when the button is clicked
    $("#button").click(function () {
        radioGroupInstance.option("items", newItems);  // Change the items of the radio group
    });

    // Reset the layout option to its default value
    radioGroupInstance.resetOption("layout");

    // Events:
    // contentReady: Triggered when the widget's content is ready.
    // disposing: Triggered when the widget is disposed.
    // initialized: Triggered when the widget is initialized.
    // optionChanged: Triggered when any option changes.
    // valueChanged: Triggered when the value changes.
});

// Example of dynamically updating the API reference
// function updateRadioGroupOptions() {
//     // Dynamically update the dataSource and layout of the radio group
//     radioGroupInstance.option({
//         dataSource: newItems, // Update the data source
//         layout: "vertical"    // Change the layout to vertical
//     });
// }

// // Call the function to update the radio group options
// updateRadioGroupOptions();