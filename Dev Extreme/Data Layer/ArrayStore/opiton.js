// We will see the prop that config the array store

// Arry store is associatied with the array as storage so we need to give it array in data

// NOTE
// The ArrayStore is immutable. You cannot change its configuration at runtime. However, you can use its methods to manipulate it.


// Basic Concept
// Think of ArrayStore like a mini in-memory database. Every time you:

// Add a record → onInserting (before), onInserted (after)
// Update a record → onUpdating (before), onUpdated (after)
// Delete a record → onRemoving (before), onRemoved (after)
// Load data → onLoading (before), onLoaded (after)
// Modify (add/update/remove any data) → onModifying (before), onModified (after)

$(
    function(){

        const array = [
            { id: 1, name: "John", age: 30 },
            { id: 2, name: "Jane", age: 25 },
            { id: 3, name: "Bob", age: 40 }
        ];



        const store = new DevExpress.data.ArrayStore({
        
            // 1st: Data : Specifies the store's associated array.
            data:array,

            // 2nd Error Hndler :Specifies the function that is executed when the store throws an error.
            errorHandler: function(error) {
                console.log(error.message)
            },

            // 3rd : key :Specifies the primary key for our data source. 
            //Used for efficient data access, updates, and deletions in DevExpress store
            key: "id", // we can give me composite as well 



            // 4th  OnInserted : A function that is executed after a data item is added to the store.
            onInserting: function(value) {
                console.log("Inserting data");
                console.log(value);
            },
            onInserted: function(value, key) {
                console.log("After Inserting data");
                console.log(value, key);
            },

            

            // 5th : Update
            onUpdating: function (key, values) { // We already knew that key is requrid during update
                console.log("Before Update: Key =", key, "New Values:", values);
            },
        
            onUpdated: function (key, values) {
                console.log("After Update: Key =", key, "Updated Values:", values);
            },


            //6th : Delete 
            onRemoving: function (key) {
                console.log("Before Remove: Key =", key);
            },
        
            onRemoved: function (key) {
                console.log("After Remove: Key =", key);
            },


            // 7th : Load
            onLoading: function (loadOptions) {
                console.log("Before Load: Load Options =", loadOptions);
            },
        
            onLoaded: function (result) {
                console.log("After Load: Data Loaded =", result);
            },


            // Trigger on all CRUD ( whenever the store data is modified it will runj)
            onModifying: function () {
                console.log("Something is about to change...");
            },
        
            onModified: function () {
                console.log("Something has changed!");
            },
        });


        
        // Correct insert (Will work)
        insertWithValidation({ id: 7, name: "Alice", age: 30 })
        .done(() => console.log("Insert successful"))
        .fail(err => console.log("Insert failed:", err.message));
        
        
        store.update(2,{name:"Meet"}).done(function(){
            console.log("Data updated successfully.");
        })

        store.remove(3).done(function(){
            console.log("Data deleted successfully.");
        })
        
        // Pushing new data
        store.push([{ type: "insert", data: { id: 5, name: "Mouse" ,age: 20} }]);
        
        // Loading data
        store.load().done((data) => {
            console.log("Data loaded successfully:", data);
        });
        
        // Custom insert function with validation
        function insertWithValidation(data) {
            if (!data.age) {
                return $.Deferred().reject(new Error("Age is required")).promise(); // Reject promise to prevent insert
            }
            return store.insert(data);
        }
        
    }
)
