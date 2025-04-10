$(

    function () {
        //#region  Custom Store
        // Our data Source
        var store = new DevExpress.data.CustomStore({
            key:"id",
            load:async function(params) {
                try{
                    let data = await $.get("https://67ac7b0a5853dfff53dae5a1.mockapi.io/api/v1/users");
                    return data;
                }
                catch (error) {
                    DevExpress.ui.notify('Error loading data', 'error', 2000);
                    console.error('Load Error:', error);
                }
            },
    
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
            }
        })

        //#endregion


        //=======================================Row Editing (batch + single mode )===============================
        var mygrid = $('#myGrid').dxDataGrid({
            dataSource: store,
            columns:[
                { dataField: "id", caption: "ID" },
                {
                    dataField:"Name",caption:"Name",
                    calculateCellValue:function(data){
                        return `${data.firstName} ${data.lastName}`; 
                    }
                },
                { dataField: 'username', caption: 'Username' },

                // Adding data validations as well
                { dataField: 'email', caption: 'Email' ,  // changes wont be saved if not valid
                    validationRules: [
                        { type: 'required' , message: 'Email is required' },
                        { type: 'email' , message: 'Invalid email format' }
                    ]
                }
            ],
            editing: {
                mode: 'batch',  // Enables row-wise editing
                allowUpdating: true,  // Allow row updates
                allowDeleting: true,  // Allow row deletions
                allowAdding: true  // Allow adding new rows
            },

            onRowUpdating: function (e) {
                console.log('Row updating:', e.oldData, '=>', e.newData);
            },
            onRowInserted: function (e) {
                console.log('Row inserted:', e.data);
            },
            onRowRemoved: function (e) {
                console.log('Row removed:', e.data);
            },
            
            showBorders:true,
            allowColumnReordering: true,  // Allow column reordering
            scrolling: {
                mode: 'infinite'  // Enable virtual scrolling
            },
        //======================================= Editing Events ===============================

            onEditorPreparing: function (e) {
                if(e.dataField === 'id'){
                    e.editorOptions.readOnly = true;  // Make 'id' field non-editable
                    console.log("Id blocked from being update")
                }
            },

            onSaving: function (e) {
                console.log('Changes to be saved:', e.changes);
            },
            onSaved: function (e) {
                console.log('Changes saved successfully');
            },
            onEditCanceling: function (e) {
                console.log('Edit action canceled');
            }
            
        }).dxDataGrid("instance");





        
    

        // on batch editing we can control using buttons
        $('#saveButton').dxButton({
            text: "Save Changes",
            onClick: function () {
                mygrid.saveEditData();  // Saves all batch edits
            }
        });
        
        $('#cancelButton').dxButton({
            text: "Cancel Changes",
            onClick: function () {
                mygrid.cancelEditData();  // Cancels all unsaved edits -->calls onEditCanceling
            }
        });
        

        
    }
)