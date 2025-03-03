$(
    function () {

        //The TextBox is a UI component that enables a user to enter and edit a single line of text.

        // we use it as single line input 

        // ie for password, name , email or other singel line or word input
        const myTextBox = $("#myTextBox").dxTextBox({
            // value: "The value that should not be edited",

            //the mode property impacts the visual representation of the UI component
            mode:"text", // other modes : email ,url , tel , search

            valueChangeEvent:"keyup",

            onValueChanged:function(e){
                console.log("Previous Value:", e.previousValue, "\nNew Value:", e.value);
            },

            maxLength: 20,

            // Mask format for date (DD/MM/YYYY)
            mask: "00/00/0000",  // Mask format for date (day/month/year)

            maskRules: {
                "0": /[0-9]/,  // Any digit (0-9)
            },
            maskChar:"_",
            placeholder: "Enter your Date (DD/MM/YYYY)",

            useMaskedValue: true,  // Show the masked value ( now text = mask value)

            showMaskMode: "onFocus", // Mask visible when focused

            maskInvalidMessage: "Invalid date format",  // Error message for invalid input  

            readOnly: false
        }).dxTextBox("instance");


        myTextBox.option("onEnterKey", function(e) {
            // we will make it disable
            // myTextBox.option("readOnly", true)

            // let us console masked and unmasked values
            const maskedValue = $("#myTextBox").dxTextBox("option", "text");
            const unmaskedValue = $("#myTextBox").dxTextBox("option", "value");

            console.log("Masked Value:", maskedValue);
            console.log("Unmasked Value:", unmaskedValue);
        })
    }
)