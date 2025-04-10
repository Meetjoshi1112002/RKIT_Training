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
        const myGrid = $("#myGrid").dxDataGrid({
            dataSource: virtualStore,

            // Column definitions
            columns: [
                {
                    dataField: 'id',
                    caption: 'ID',
                    alignment: 'center',
                    allowEditing: true,
                    width: 50
                },
                {
                    dataField: 'username',
                    caption: 'Username'
                },
                {
                    dataField: 'email',
                    caption: 'Email'
                },
                {
                    dataField: 'age',
                    caption: 'Age (Year)',
                },
                {
                    dataField: 'gender',
                    caption: 'Gender',
                    alignment: 'center',
                },
            ],

            summary: {
                totalItems: [
                    {
                        column: "email",
                        summaryType: "count"  // Counts the total number of email entries
                    }, 
                    {
                        column: "age",
                        summaryType: "avg",   // Calculates the average age
                        showInColumn: "gender",  // Displays the summary in the 'gender' column
                        alignment: "center"  
                    },
                    {
                        column: "age",
                        summaryType: "custom",  // if custom then we need to name this item as well so that we provide formula in calculateCustomSummary
                        name: "customAgeSummary",
                        showInColumn: "age",
                        customizeText: function (data) {
                            return "Total Adults Age: " + data.value;   // here 
                        },
                        alignment: "center"
                    }
                ],
                calculateCustomSummary: function (options) {
                    if (options.name === "customAgeSummary") {
                        if (options.summaryProcess === "start") {  // Reset counter on start
                            options.totalValue = 0; // Reset counter
                        }
                        if (options.summaryProcess === "calculate") {
                            if (options.value >= 18) { // Count only users aged 18+
                                options.totalValue += 1;
                            }
                        }
                    }
                },
            }
            
        })
    }
)