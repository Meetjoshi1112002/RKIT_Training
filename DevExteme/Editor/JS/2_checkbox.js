$(
    function(){
        //The CheckBox is a small box, which when selected by the end user, shows that a particular feature has been enabled or a specific property has been chosen.
        
        let checkBoxInstance = $("#checkboxContainer").dxCheckBox({
            onInitialized: function (e) {
                console.log("CheckBox initialized!", e.component);
            }
        }).dxCheckBox("instance");

        // Check box can have 3 states
        // 1. Checked (true)        // 2. Unchecked (false)

        // 3. Indeterminate (undefined)

        checkBoxInstance.option({
            text:"Click Me !",
            value:true
        })

        //To process a new CheckBox value, you need to handle the value change event

        //If the handling function is not going to be changed during the lifetime of the UI component, assign it to the onValueChanged property when you configure the UI component.

        checkBoxInstance.option("onValueChanged",function(e){
            const PreviousValue = e.previousValue;
            const NewValue = e.value;
            console.log("handler 0" +NewValue,PreviousValue);
        })

        // suppose we want to have dynamic handlers during runtime or mutiple then do using on

        function clickHandler1(){
            console.log("Handler 1");
        }

        function clickHandler2(){
            console.log("Handler 2");
        }

        checkBoxInstance
        .on("valueChanged",clickHandler1)
        .on("valueChanged",clickHandler2);


        // register key handler

        // registereing keyboard keys with the widget instance.
        function registerKeyHandlers() {
            console.log("h;loop");
            checkBoxInstance.registerKeyHandler("backspace", function (e) {
                console.log(e);
        
                // The argument "e" contains information on the event
            });
            checkBoxInstance.registerKeyHandler("space", function (e) {
                console.log(e);
                // ...
            });
        }

        registerKeyHandlers();

 
        checkBoxInstance.beginUpdate(); // Stops the UI update

        // Options of checkbox

        // 1st : Access KEY :> There can be only one accerss key !

        checkBoxInstance.option("accessKey","A"); // Now the check box will be focused by pressing "A" key

        // 2nd : activeStateEnabled

        checkBoxInstance.option("activeStateEnabled",true); // Now there will no animation effect when user interacts

        // 3rd : disabled :> The component will be disabled and will have no interaction

        checkBoxInstance.option("disabled",false); 

        //4th : Focust state enabled :> determine wheather the widget can be focused using any tab !
        // Also this will disable the register key handklers on htis widget if set false

        checkBoxInstance.option("focusStateEnabled",true);


        // 5th : elmentattr :> This property can be used to add custom attributes to the container HTML element  !

        checkBoxInstance.option("elementAttr",{
            "class":"custom-class",
            "id":"custom-id",
            "my_attr":"my_value"
        });

        //6th : Height :> The height of the outer most widge container

        // checkBoxInstance.option("height",100);

        // checkBoxInstance.option("height","10rem"); 

        // checkBoxInstance.option("height",heightSetter);
        // function heightSetter() {
        //     return window.innerHeight / 3; // One-third of viewport height
        // }

        // 7th : Hint :> Shows a tooltip when the user hovers over the checkbox.

        checkBoxInstance.option("hint","We can add some T and C here");

        // 8th : Hover :> hoverStateEnabled (Visual Change on Hover)

        checkBoxInstance.option("hoverStateEnabled",true);

        // 9th : Name :> Sets the name of underlying input element . Useful for form handinig and api classs

        checkBoxInstance.option("name","myCheckbox");
        
        //10th : On content Ready :> runs when the ui component is fully ready

        checkBoxInstance.option("onContentReady",function(e){
            console.log(" I am ready meet jnoshi"); 
        });

        //11th : On Disposing : runs before the UI component is dispossed

        checkBoxInstance.option("onDisposing",function(e){
            console.log(" I am being killed meet joshi"); 
        });

        //12th : On initalzaiotn : runs when the UI compoent is initialzed

        // give this during the creation of the widget only

        // 13th : OnOptionchaged

        checkBoxInstance.option("onOptionChanged",function(e){
            console.log("Property changed:", e.name, "New Value:", e.value);
        });

        // 14th : ReadOnly

        checkBoxInstance.option("readOnly",false);

        // 15th : OnValueChanged

        checkBoxInstance.option("onValueChanged",function(e){
            console.log("Handler 3 :> Previous Value:", e.previousValue, "New Value:", e.value);
        });

        // 16th : RtlEnabled
        // switched the text direction from right to left 
        //checkBoxInstance.option("rtlEnabled",true); // THis is useful for arebic text

        // 17th : Tabindex
        // This property is used to determine the tab order of the widget in a tabbing order.
        checkBoxInstance.option("tabindex",1);


        // 18th : Text :> The text that appears next to the checkbox

        checkBoxInstance.option("text","Accept Me !");

        // 19th : Value :> The value of the checkbox

        checkBoxInstance.option("value",undefined);

        // 20th : Visible

        checkBoxInstance.option("visible",true);


        

        checkBoxInstance.endUpdate(); // All options that are applied above will be aggreageted and applied at once so prevent multipler renders for each update

        // on and off


        checkBoxInstance
        .on("valueChanged",clickHandler1)
        .on("valueChanged",clickHandler2);

        checkBoxInstance
        .off("valueChanged",clickHandler1);

        checkBoxInstance
        .off("valueChanged");


        let button = $("#myButton").dxButton({
            text:"Click Me"
        }).dxButton("instance");

        button.on("click",function(e){
            checkBoxInstance.focus();  // Focuses the checkbox, highlighting it for user interaction
        });


        // repaint()
        let t = false;
        button.on("click",function(e){
            if(t){
                checkBoxInstance.option("visible",false);
            }else{
                checkBoxInstance.option("visible",true);
                checkBoxInstance.repaint(); ///Manually refresh UI to ensure it reflects the latest changes

                checkBoxInstance.blur(); // Removes focus from the checkbox, if it has focus
            }
            t = !t;
        })

        // use Repaint to refersh the UI of the component without data reloading ( ie state and values are not changed)

        // Reset and reset opiton

        // button.on("click",function(e){
        //     checkBoxInstance.reset(); // Here value is reset (false) (only value)
        //     checkBoxInstance.resetOption("text"); // Here text is reset to defautl
        // })


        // setTimeout(function(){
        //     checkBoxInstance.dispose(); //Removes all resources used by the checkbox and removes it from the dom
        //     checkBoxInstance.repaint(); // This makes the component re-render (or reinsanceciated with previous states !)
        // },5000);
    }
)