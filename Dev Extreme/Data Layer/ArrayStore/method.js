$(
    function (){
        const array = [
            { id: 1, Department:"IT", name: "John", age: 30 },
            { id: 2,Department:"CP", name: "Jane", age: 25 },
            { id: 2,Department:"IT", name: "Bob", age: 40 }
        ];


        const store =  new DevExpress.data.ArrayStore({
            key: ["id" , "Department"],
            data: array,
            errorHandler: function(error) {
                console.log(error.message)
            },
        });

        //Fetches a data item by its key.
        //Works with both single-field and composite keys.
        store.byKey({ id: 1, Department:"IT" })
        .done(function(dataItem) {
            console.log("Data loaded successfully:", dataItem);
        })
        .fail(function (error) {
            console.error("Error:", error);
        });

        var query = store.createQuery();
        console.log(query); // Query object created


        
        store.insert({id:7,Department:"IT",name:"Meet",age:20})
        .done(function() {
            console.log("Data inserted successfully.");
        })
        .fail(function (error) {
            console.error("Error:", error);
        });

        // Retrieves the key field name.
        console.log(store.key());

        //Gets the key value of a given object for a given store
        var key = store.keyOf({ id: 5, Department:"IT", age: 30, name: "John" });
        console.log(key); // 5

        

        // Remove a itme by key
        store.remove({ id: 1, Department:"IT"})
        .done(function () {
            console.log("Item removed!");
        })
        .fail(function (error) {
            console.error("Error:", error);
        });

        // Gets totla itme count
        store.totalCount()
        .done(function (count) {
            console.log("Total items:", count);
        });

        store.update({ id: 2, Department:"IT"}, { name: "Alice Updated" })
        .done(function (dataObj) {
            console.log("Updated:", dataObj);
        })
        .fail(function (error) {
            console.error("Update failed:", error);
        });



        // Fetches data from the store (supports filtering and sorting).
        store.load()
        .done(function (data) {
            console.log("Loaded data:", data);
        })
        .fail(function (error) {
            console.error("Load failed:", error);
        });

        //Use case: Reset or clear existing data.
        store.clear();
    }
)