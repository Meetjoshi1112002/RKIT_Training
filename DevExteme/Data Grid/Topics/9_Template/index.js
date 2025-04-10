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

        // Initialize the grid with the custom store
        const myGrid = $('#myGrid').dxDataGrid({
            dataSource: virtualStore,
            // column customization
            columns:[
                {
                    dataField:'image',
                    caption:'Profile Pic',
                    alignment: 'center',
                    allowEditing: false,
                    cellTemplate: function (container, options) {
                        $('<img>')
                            .attr('src', options.value)
                            .css({ width: '50px', height: '50px', borderRadius: '50%' })
                            .appendTo(container);
                    }
                },
                {
                    caption: 'Full Name',
                    cellTemplate: function (container, options) {
                        let firstName = options.data.firstName;
                        let lastName = options.data.lastName;
                        container.text(firstName + " " + lastName);
                    }
                },
                {
                    dataField:'age',
                    caption:'Age',
                    cellTemplate: function (container, options) {
                        container.text(options.value + " years old");
                    }
                },
                {
                    dataField:'gender',
                    caption:'Gender',
                    alignment: 'center',
                    cellTemplate: function (container, options) {
                        let gender = options.value;
                        const color = gender === 'Male' ? 'blue' : 'pink';
                        $('<span>')
                            .text(gender)
                            .css({ color: color, fontWeight: 'bold' })
                            .appendTo(container);
                    }
                }
            ],
            onToolbarPreparing: function (e) {
                e.toolbarOptions.items.unshift(
                    {
                        location: 'after',
                        widget:'dxSelectBox',
                        options: {
                            items: ['Male', 'Female' ,'All'],
                            value:'All',
                            onValueChanged: function (e) {
                                let selectedValue = e.value;
                                if(selectedValue === 'All'){
                                    myGrid.clearFilter();
                                }else{
                                    myGrid.filter(['gender', '=', selectedValue]);
                                }
                                e.component.close();
                            }
                        }
                    },
                    {
                        location: 'after',
                        widget:'dxTextBox',
                        options: {
                            placeholder: 'Search...',
                            onValueChanged: function (e) {
                                myGrid.searchByText(e.value);
                            }
                        }
                    },
                    {
                        location: 'before',
                        widget: 'dxButton',
                        options: {
                            icon: 'add',
                            text: 'Add Row',
                            onClick: function () {
                                myGrid.addRow();
                            }
                        }
                    },
                    {
                        location: 'before',
                        widget: 'dxButton',
                        options: {
                            icon: 'refresh',
                            text: 'Refresh Data',
                            onClick: function () {
                                myGrid.refresh();
                            }
                        }
                    }
                )
            }
        }).dxDataGrid('instance');

        const myGrid2 = $('#myGrid2').dxDataGrid({
            dataSource: virtualStore,
            columns: [ // We need ot create TH for our rows
                {
                    dataField: 'id',
                    caption: 'ID',
                    alignment: 'center',
                    allowEditing: false,
                    width: 50
                },
                {
                    dataField: 'image',
                    caption: 'Profile Picture',
                    alignment: 'center',
                    allowEditing: false,
                },
                {
                    caption: 'Full Name',
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
                    dataField: 'birthDate',
                    caption: 'BirthDate'
                },
                {
                    dataField: 'gender',
                    caption: 'Gender',
                    alignment: 'center',
                },
                {
                    type: 'buttons',
                    caption: 'Action',
                    buttons: [
                        {
                            name: 'edit',
                            icon: 'edit'
                        },
                        {
                            name: 'delete',
                            icon: 'remove'
                        }
                    ]
                }
            ],
            rowTemplate: function (rowElement, rowInfo) {
                let rowData = rowInfo.data;
                let $row = $('<tr>');
    
                // Add data to each cell with customization
                $('<td>').text(rowData.id).css('text-align', 'center').appendTo($row);
                $('<td>').html('<img src="' + rowData.image + '" width="50" height="50" style="border-radius:50%">').css('text-align', 'center').appendTo($row);
                $('<td>').text(rowData.firstName + " " + rowData.lastName).appendTo($row);
                $('<td>').text(rowData.username).appendTo($row);
                $('<td>').text(rowData.email).appendTo($row);
                $('<td>').text(rowData.age + " years old").appendTo($row);
                $('<td>').text(rowData.birthDate).appendTo($row);
                $('<td>').css('color', rowData.gender === 'male' ? 'green' : 'pink').text(rowData.gender).css('text-align', 'center').appendTo($row);
    
                // Add buttons for actions
                let $actionCell = $('<td>').css('text-align', 'center');
                $('<button>')
                    .addClass('dx-button dx-button-normal')
                    .text('Edit')
                    .click(function () {
                        console.log('Edit clicked for ID:', rowData.id);
                    })
                    .appendTo($actionCell);
                $('<button>')
                    .addClass('dx-button dx-button-danger')
                    .text('Delete')
                    .click(function () {
                        console.log('Delete clicked for ID:', rowData.id);
                    })
                    .appendTo($actionCell);
    
                $actionCell.appendTo($row);
                rowElement.append($row);
            },
            
        }).dxDataGrid('instance');
    }
)