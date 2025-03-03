$(
    function () {

        var store = new DevExpress.data.CustomStore({
            key: "id",
            load: function(loadOptions) {
                return $.getJSON("https://mydemoproject.free.beeceptor.com/api/user");
            },

            loadMode: "raw",

            insert: function(values) {
                let d = $.Deferred();
                return $.ajax({
                    url: "https://mydemoproject.free.beeceptor.com/api/user",
                    method: "POST",
                    data: values,
                    success: function(values){
                        d.resolve(values);
                    }
                });
            },


            update: function(key, values) {
                return $.ajax({
                    url: "https://mydemoproject.free.beeceptor.com/api/user/" + key,
                    method: "PUT",
                    data: values
                });
            },


            remove: function(key) {
                console.log(key);
                return $.ajax({
                    url: "https://mydemoproject.free.beeceptor.com/api/user/key",
                    method: "DELETE"
                });
            },


            byKey: function(key) {
                console.log(key);
                return $.get("https://mydemoproject.free.beeceptor.com/api/user/key");
            },

            cacheRawData: true,


            errorHandler: function(error) {
                console.log("Error:", error.message);
            },
        });


        store.byKey(1)
        .done(function (dataItem) {
            console.log("Data loaded successfully:", dataItem);
        })
        .fail(function (error) {
            // Handle the "error" here
            console.error("Error:", error);
        });


        store.insert({ id: 1, name: "John Doe" })
        .done(function (dataObj, key) {
            // Process the key and data object here
            console.log("Data inserted successfully. Key:", key ,"Data Object:", dataObj);
        })
        .fail(function (error) {
            // Handle the "error" here
            console.error("Error:", error);
        });


        // key and keyof are similar

        store.load()
        .done(function (data) {
            // Process "data" here
            console.log("Data loaded successfully:", data);
        })
        .fail(function (error) {
            // Handle the "error" here
            console.error("Error:", error);
        });


        // similarly on and off events exists here as well

        store.remove(1)
        .done(function (key, data) {
            // Process the "key" here
            console.log("Data deleted successfully. Key:", key);
            console.log("Data Object:", data);
        })
        .fail(function (error) {
            // Handle the "error" here
            console.error("Error:", error);
        });

        // Gets the total count of items the load() function returns.

        store.totalCount()
        .done(function (count) {
            // Process the "count" here
            console.log("Total count:", count);
        })
        .fail(function (error) {
            // Handle the "error" here
            console.error("Error:", error);
        });


        store.update(1, { name: "John Smith" })
        .done(function (dataObj, key) {
            // Process the key and data object here
        })
        .fail(function (error) {
            // Handle the "error" here
        });


        store.clearRawDataCache(); // clears the cache
    }
)