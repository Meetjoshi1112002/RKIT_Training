$(
    function(){
        // Get Opiton Properties

        let buttonInstance = $("#myButton").dxButton("instance");
        // Why get an instance?
        // 1st Modify properties dynamically.
        // 2nd Call widget-specific methods.

        // getting single options property

        let buttonText = buttonInstance.option("text");  // Way to get property when we have an instance

        let buttoType = $("#myButton").dxButton("option", "type");  // Way to get property when we Dont have an instance

        // getting all options propety at once

        let ButtonAllProperty = $("#myButton").dxButton("option");  // Way to get property when we Dont have an instance

        ButtonAllProperty = buttonInstance.option();


        // Set Option Propertier

        // set single property

        buttonInstance.option("text", "Sumit-2"); // set when you have instance

        $("#myButtom").dxButton("option", "type", "danger"); // set without instance or set by jquery plugin

        //set mulitple property
        // NOTE :If you perform several property changes, wrap them with the beginUpdate() and endUpdate() method calls. 
        // This prevents the UI component from being unnecessarily refreshed and from events being raised. 
        // Use an object instead if you need to change several properties at once.

        var chart = $("#myChart").dxChart({
            valueAxis: [{
                name: "axis1"
            }, {
                name: "axis2"
            }]
        }).dxChart("instance");
         
        chart.beginUpdate();
        chart.option("valueAxis[0].visible", false);
        chart.option("valueAxis[1].grid.visible", false);
        chart.endUpdate();
    }
)