$(
    function(){

        // useage : Mulitline text area
        const myTextArea = $("#myTextArea").dxTextArea({
            value:"This is a text area",
            spellcheck:false,
            readonly:false,


            // Make the size fixed
            height:200,
            width: 300,

            // Make height according ot content
            autoResizeEnabled: true,
            minHeight: 200,
            maxHeight: 300,

            // When to set the value 
            valueChangeEvent:"keyup", // as soon as we type

            onValueChanged: function (e) {
                const previousValue = e.previousValue;
                const newValue = e.value;
                // Event handling commands go here

                console.log(previousValue)
                console.log(newValue)
            },
            onChange: function(e){
                console.log("change ", e);  // triggers at blur 
            },
            onInput: function(e){
                console.log("input ", e);   // triggers at every character enetered
            },
            // limit the max length
            maxLength: 200
        }).dxTextArea("instance");

    }
)