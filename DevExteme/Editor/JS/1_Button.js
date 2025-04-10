$(
    function(){
        const myButton = $("#myButton2").dxButton({
            text:"Click Me !",

            type:"normal", // other available danger, success , default

            stylingMode:"outlined", // underlined, containded


            // can also give svg or url here
            icon:"like",// Large number of icons availbale // url: https://js.devexpress.com/jQuery/Documentation/21_1/Guide/Themes_and_Styles/Icons/#Built-In_Icon_Library

            useSubmitBehavior:true, // used for form behaviour( checks validation of validationGrp)

            validationGroup:"group1", // group of form elements that needs to be validated
            onClick: function(e){
                console.log(e);
            }
        }).dxButton("instance");

        /// we can even dynamically change this property
        //$("#disableButton").click(function () {
        //    myButton.option("disabled", true);
        //    console.log("Button Disabled");
        //});

        //$("#enableButton").click(function () {
        //    myButton.option("disabled", false);
        //    console.log("Button Enabled");
        //});

        //$("#changeTextButton").click(function () {
        //    myButton.option("text", "New Text");
        //    console.log("Button Text Changed");
        //});

        //$("#changeTypeButton").click(function () {
        //    myButton.option("type", "success");
        //    console.log("Button Type Changed");
        //});

        //$("#changeStylingModeButton").click(function () {
        //    myButton.option("stylingMode", "text");
        //    console.log("Button Styling Mode Changed");
        //});

        setTimeout(() => {
            myButton.dispose();
            console.log("HI");
        },2000)
    }
)