// import { employees, states, cities } from "./data.js";
/*
    Important things to learn:
    1st : how columns can have lookup with different data source

    2nd: How we can use setCellValue to get entire row data and modify it 

*/

//#region  DATA
const employees = [{
    ID: 1,
    FirstName: 'John',
    LastName: 'Heart',
    Prefix: 'Mr.',
    Position: 'CTO',
    DepId: 1,
    SubId: 1,
}, {
    ID: 2,
    FirstName: 'Olivia',
    LastName: 'Peyton',
    Prefix: 'Mrs.',
    Position: 'HR Manager',
    DepId: 1,
    SubId: 2,
}, {
    ID: 3,
    FirstName: 'Robert',
    LastName: 'Reagan',
    Prefix: 'Mr.',
    Position: 'IT Manager',
    DepId: 2,
    SubId: 4,
}];

const Department = [{
    ID: 1,
    Name: 'CP',
}, {
    ID: 2,
    Name: 'IT',
}];

const Subjects = [{
    ID: 1,
    Name: 'OS',
    DepId: 1,
}, {
    ID: 2,
    Name: 'COA',
    DepId: 1,
}, {
    ID: 3,
    Name: 'WebDev',
    DepId: 2,
}, {
    ID: 4,
    Name: 'PHP',
    DepId: 2,
}];
//#endregion
$(() => {
    $('#myGrid').dxDataGrid({
        dataSource: employees,
        keyExpr: "ID",
        showBorders: true,
        columns: [
            "ID",
            {
                dataField: "FullName",  // Corrected Field
                caption: "Name",
                calculateCellValue: function (data) {
                    return `${data.FirstName} ${data.LastName}`;
                }
            },
            {
                dataField: "DepId",
                caption: "Department",
                setCellValue: function (row, value) {
                    row.DepId = value; // Update DepId
                    row.SubId = null;  // Reset Subject when Department changes
                },
                lookup: {
                    dataSource: Department,
                    valueExpr: 'ID',
                    displayExpr: 'Name'
                }
            },
            {
                dataField: "SubId",
                caption: "Subject",  // Fixed Typo
                lookup: {
                    dataSource: function (options) {
                        return {
                            store: Subjects,
                            filter: options.data ? ["DepId", "=", options.data.DepId] : null,  // Filter subjects based on department
                        };
                    },
                    valueExpr: "ID",
                    displayExpr: "Name"
                }
            }
        ],
        editing: {
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            mode: 'row',
        },
    });
});



