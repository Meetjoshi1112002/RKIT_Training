$(function () {

    // Step 1: Create Array Store
    const array = [
        { id: 1, Department: "IT", name: "Navneet", age: 30 },
        { id: 2, Department: "CP", name: "Jane", age: 25 },
        { id: 3, Department: "IT", name: "Bob", age: 42 },
        { id: 4, Department: "IT", name: "Meet", age: 30 },
        { id: 5, Department: "IT", name: "Jay", age: 50 },
        { id: 6, Department: "IT", name: "Dharam", age: 10 },
        { id: 7, Department: "IT", name: "NK", age: 20 },
        { id: 8, Department: "IT", name: "VR", age: 21 },
        { id: 9, Department: "IT", name: "Rohanshu", age: 22 },
    ];

    // Step 2: Create DevExtreme Array Store
    const store = new DevExpress.data.ArrayStore({
        key: "id",
        data: array
    });

    // Step 3: Create DataSource to act as a mediator between store and UI
    const ds = new DevExpress.data.DataSource({
        store: store,

        // Enable filtering
        // filter: [["Department", "=", "IT"]],  // Uncomment to filter by IT department  // generally used with custom store

        // Enable sorting
        sort: [{ selector: "name", desc: false } , { selector: "age", desc: true }],

        // Grouping
        group: "Department",

        // Enable searching on 'name', 'Department', and 'age'
        searchExpr: ["name", "Department", "age"],
        searchOperation: "contains",
        searchEnabled: true,

        // Pagination enabled
        paginate: true,
        pageSize: 3, // Display 3 records per page

        // Error handling
        onLoadError: function (error) {
            console.error("Failed to load data:\n", error.message);
        }
    });

    // Step 4: Initialize dxSelectBox
    const myselectbox = $("#myselectbox").dxSelectBox({
        dataSource: ds,
        displayExpr: "name",
        valueExpr: "id",
        searchEnabled: true,
        grouped: true
    }).dxSelectBox("instance");

});
