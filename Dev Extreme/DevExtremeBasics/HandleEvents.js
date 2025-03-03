$(
    function () {
        

        // we can subscribe to an event using a configuration property. All event handling properties are given names that begin with on.
        let buttonWidget = $("#myButton").dxButton("instance");

        buttonWidget.on({
            "click":clickHandler1
        }).on({
            "click":clickHandler2
        })

        function clickHandler1(e){                                   // Note: arrow funciton are not hoisted !
            console.log("Button Clicked at "+e.event.timeStamp);
        }

        function clickHandler2(e){                                   // Note: arrow funciton are not hoisted !
            console.log("Handler 2");
        }


        // Now we have two handler to 

        buttonWidget.off("click", clickHandler1);  // deregistering a handler

        buttonWidget.off("click"); // deregistering all handlers

        buttonWidget.option("onclick",undefined); // deregistering all

    }
)