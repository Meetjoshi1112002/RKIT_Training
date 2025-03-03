$(
    function () { 
        const NumberBox = $("#myNumberBox").dxNumberBox({
            value: 20,
            min: 1,
            max: 300,
            valueChangeEvent:"keyup", // Now the value will be udpated on every key up


            /*
                valueChangeEvent: "input" // Updates as soon as you type
                valueChangeEvent: "blur"  // Updates only when focus is lost
                valueChangeEvent: "change" // Updates when user finishes editing

            */
            onValueChanged:function(e){
                console.log("Previous Value:", e.previousValue, "New Value:", e.value);
            }
        }).dxNumberBox("instance");

        // this option are given first 
        NumberBox
        .on("valueChanged",changeHandler1)
        .on("valueChanged",changeHandler2);

        NumberBox.option({
            showSpinButtons:true,
            step:5
        })


        NumberBox
        .registerKeyHandler("space",function(e){
            e.target.value = parseInt(e.target.value) +  5;
            console.log(e.target.value);
        })


        //some other custom options

        NumberBox.option({
            showClearButton:true,
            width: "15rem",
            height: "3rem",
            rtlEnabled: false,
            stylingMode:"outlined",
            useLargeSpinButtons: true
        })

        // Lets add spin buttton to this


        function changeHandler1(e) {
            console.log("Hnbalder 1");
        }

        function changeHandler2(e) {
            console.log("Hnbalder 2");
        }
    }
)