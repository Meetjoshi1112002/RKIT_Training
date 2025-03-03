/*
    paginaiton

*/

$(
    function(){
        // add a select box

        const data = [{
            ID: 1,
            Name: 'Banana',
            Category: 'Fruits',
            img:"https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7"
        }, {
            ID: 2,
            Name: 'Cucumber',
            Category: 'Vegetables',
            img:"https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7"
        }, {
            ID: 3,
            Name: 'Apple',
            Category: 'Fruits',
            img:"https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7"
        }, {
            ID: 4,
            Name: 'Tomato',
            Category: 'Vegetables',
            img:"https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7"
        }, {
            ID: 5,
            Name: 'Apricot',
            Category: 'Fruits',
            img:"https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7"
        }]

        const selectBoxInstance = $("#mySearchBox").dxSelectBox({}).dxSelectBox("instance");

        // Now we wil configure different opitons

        selectBoxInstance.option({

            //DataSource groups the data before passing it to SelectBox.
            dataSource: new DevExpress.data.DataSource({
                store: data,
                key: "ID",
                type:"array",
                group:"Category",
                paginate:true,
                pageSize:2
            }),

            //just tell select box that use grouping from datasource
            grouped:true,

            valueExpr:"ID",

            displayExpr:"Name",

            value: data[0].ID,

            searchEnabled:true,

            accesskey:"g",

            onValueChanged:function(e){
                console.log("Previous Value:", e.previousValue, "New Value:", e.value);
            },

            //The SelectBox uses the Popup component as a drop-down menu ( so here we are basically updating the )
            dropDownOptions: {
                closeOnOutsideClick:false,
                height: 300,
                deferRendering:true,
                fullScreen: false
            }

            // you can have valueChangedEvent (like keyup blur etc)

            // we can have mulitple onValueChagne hanlders like we did above 

        });

        // change the item appreacne

        // 1st : Minor updateion (add speicific stying in Data source only)
        // selectBoxInstance.option({
        //     valueExpr: 'text',
        //     displayExpr: 'text',
        //     dataSource: [
        //         { text: "HD Video Player" , visible: true , disabled:false },
        //         { text: "SuperHD Video Player", disabled: true },
        //         { text: "SuperPlasma 50", visible: false }
        //     ],
        //     placeholder: "Select a product..."
        // })

        // 2nd Use item tepmplate:> gives more control over dropdwon

        selectBoxInstance.option({


            // control over drop down
            itemTemplate:function(itemData, itemIndex, ItemElement){
                return $("<div>").append(
                    $("<img />").attr("src", itemData.img).attr("width","70px"),
                    $("<div />").dxTextBox({
                        value: itemData.Name,
                        readOnly:true
                    })
                )
            },

            // control over selected field

            fieldTemplate: function(value, fieldElement) {
                return value !== null? $("<div class='custom-item' />").append(
                    $("<img />").attr("src", value.img).attr("width","70px"),
                    $("<div class='product-name' />").dxTextBox({
                        value: value.Name,
                        readOnly:true
                    })
                ) :"No item selected!";
            },

            // enable searching
            searchEnabled: true,

            searchExpr: ['ID','Name'],

            searchMode: "contains", // or startsWith

            searchTimeout: 5000, // delay time 

            minSearchLength: 3 // minimum length of search to trigger seaching

        });


        // Grouping methods

        // Select box needs array of objects that have keys and item thats it
            // either we give it direclty 
            // or do it in dataSource
            // best learnign url : https://js.devexpress.com/jQuery/Documentation/21_1/Guide/UI_Components/SelectBox/Grouping/In_the_Data_Source/

        // Pagination when We have large number of items
        // configured in the datasource


        // Doesnt support multiple selection
        const selectBoxData = new DevExpress.data.DataSource({
            store: [
                { id: 1, firstName: "Rohanshu" },
                { id: 2, firstName: "Meet" },
                { id: 3, firstName: "Navneet" }
            ]
        });
        
        const mySearchBox2 = $("#mySearchBox2").dxSelectBox({}).dxSelectBox("instance");


        mySearchBox2.option({
            width: "20rem",
            height: "3rem",
            dataSource: selectBoxData,
            displayExpr: 'firstName',
            valueExpr: 'id',
            acceptCustomValue: true,
            onCustomItemCreating: function(arg) {
                let exists = selectBoxData.store()._array.some(item => item.firstName.toLowerCase() === arg.text.toLowerCase());
                
                if (exists) {
                    arg.customItem = null;  // Prevent insertion
                    mySearchBox2.option("value", arg.text);
                    return;
                } else {
                    let nextId = selectBoxData.store()._array.length + 1;
                    arg.customItem = { id: nextId, firstName: arg.text };
                    selectBoxData.store().insert(arg.customItem);
                    selectBoxData.reload();
                }
            },
            noDataText: "No data to display currently.",
            onItemClick: function(e) {
                console.log(e);
            },
            openOnFieldClick: false,
            wrapItemText: true,
            onValueChanged: function(e) {
                console.log(e);
            }
        });
        
    }
)