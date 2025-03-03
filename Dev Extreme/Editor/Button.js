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
    }
)