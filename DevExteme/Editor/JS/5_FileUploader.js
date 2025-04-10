$(
    function(){


        const myFileUploader = $("#myFileUploader").dxFileUploader({

            // Allow multiple files
            multiple: true,

            // label text
            labelText: "Upload a file here MJ",


            // 2 Modes to upload a file to server
            // 1st Traditional (HTML Form Upload) --> set mode to useForms

            //2nd Ajax --> set mode to :> Instantly or useButton

            uploadMode:"onButtons", // Ajaz approach

            //when we are sending a file in chunks 
            // backend needs to assemble it all ( this logic is custom and needs to be handled)
            chunkSize: 400000, // 400 KB

            // Additional params for ajax mode:>( not required for HTML form upload)

            uploadUrl:"https://js.devexpress.com/Demos/Mvc/api/UploadFile", // we can modify this url

            // Control on the types of file being uploaded

            allowedFileExtensions: [".jpg", ".png"],

            accept:"image/",

            allowCancellation:true,

            invalidFileExtensionMessage: "wrong file extension",


            minFileSize: 1024, // 1 KB
            invalidMaxFileSizeMessage: "max file size crossed",


            maxFileSize: 1024 * 1024, // 1 MB
            invalidMinFileSizeMessage: "minimum file size not achieved",

            // through this each file gets a unique guid
            onValueChanged: function(e){
                //on every file upload assign a guid to file query
                var url = e.component.option("uploadUrl");
                url = updateQueryStringParameter(url, "fileGuid", uuidv4());
                e.component.option("uploadUrl", url); 
            },

            // we can have our headers here !

            uploadHeaders: {
                Bearer: "JWT TOKEN" 
            },


            // Some event listners of file uploader

            onBeforeSend: function (e) {
                console.log("Triggers before file sending");
            },
            onContentReady: function (e) {
                console.log("Content ready", e);
            },
            onDropZoneEnter: function (e) {
                console.log("Entered dropping zone.", e);
            },
            onDropZoneLeave: function (e) {
                console.log("Leaving dropping zone.", e);
            },
            onFilesUploaded: function (e) {
                console.log("All files are uploaded.", e);  // triggers once
            },
            onUploaded: function (e) {
                //useful for chunks uploads 
                // for each chunk a request is made
                console.log(e.request.getResponseHeader('File-Guid'));  // triggers with every file upload in multiple uploads
            },
            onProgress: function (e) {
                console.log("progress: ", e);
            },
            onUploadAborted: function (e) {
                console.log("Aborted. ", e);
            },
        }).dxFileUploader("instance");


        // get the files uploaded during the runtime

        const files = myFileUploader.option("value");


        // A simple example where selection of one item from select box cnage url of the file uploader

        let data = [
            {
                ID: 1,
                Name: "John Heart",
                Position: "CEO",
                Email: "jheart@dx-email.com",
                Phone: "123-456-7890"
            },
            {
                ID: 2,
                Name: "Samantha Bright",
                Position: "COO",
                Email: "samanthab@dx-email.com",
                Phone: "123-456-7890"
            }
        ]

        const mySelectBox3 = $("#mySelectBox3").dxSelectBox({
            dataSource: data,

            displayExpr: "Name",

            searchEnabled: true,

            value: data[0],

            onValueChanged: function(e){
                console.log(e.value);
                var url = myFileUploader.option("uploadUrl");
                url = updateQueryStringParameter(url, "ID", e.value.ID);
                myFileUploader.option("uploadUrl", url);
                console.log(myFileUploader.option("uploadUrl"));
            }
        }).dxSelectBox("instance");



        // GUid generater
        function uuidv4() {
            return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
                var r = (Math.random() * 16) | 0,
                    v = c === "x" ? r : (r & 0x3) | 0x8;
                return v.toString(16);
            });
        }
        
        // Helper function:>
        function updateQueryStringParameter (uri, key, value) {
            var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
            var separator = uri.indexOf('?') !== -1 ? "&" : "?";
            if (uri.match(re)) {
                return uri.replace(re, '$1' + key + "=" + value + '$2');
            }
            else {
                return uri + separator + key + "=" + value;
            }
        }
    }
)