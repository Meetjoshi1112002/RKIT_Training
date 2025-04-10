/*

    DateBox.js Doubts

    Pickertype is not setting for date format

*/

$(function() {

    // Define holiday dates
    let holiday = [
        new Date(2025, 2, 8), // March 8, 2025
        new Date(2025,1,14), // Make valentinday holiday
        new Date(2025, 2, 9)  // March 9, 2025
    ];

    let dateBoxInstance = $("#myDateTimeBox").dxDateBox({
        type: "date",  // Default: date only --> options: date, time, datetime
        pickerType:"calender",
        // value: new Date()
    }).dxDateBox("instance");

    dateBoxInstance.beginUpdate();

    // Set min and max date
    dateBoxInstance.option("min", new Date(2025, 1, 1)); // February 1, 2025

    dateBoxInstance.option("max", new Date(2025, 5, 25)); // June 25, 2025

    // Handle value change event
    dateBoxInstance.on("valueChanged", changeHandler);

    function changeHandler(e) {
        console.log("New Value:", e.value);
    }

    
    dateBoxInstance.option("disabledDates", function(args) {
        const dayOfWeek = args.date.getDay(); // Get day of the week (0=Sunday, 6=Saturday)

        const isWeekend = dayOfWeek === 0 || dayOfWeek === 6; // Check if it's Saturday or Sunday

        return (isWeekend || isHoliday(args.date));
    });

    // Set the picker type

    // dateBoxInstance.option({
    //     pickerType: "list",
    //     interval: 15
    // });


    // set the name of underlying input elemenmt

    dateBoxInstance.option("name", "myDateTimeBox");

    // set the format of the date selected

    dateBoxInstance.option("displayFormat", "dd/MM/yyyy"); 

    dateBoxInstance.option("displayFormat", "HH:mm");

    dateBoxInstance.option("displayFormat", "HH:mm:ss");

    dateBoxInstance.option("displayFormat",'EEEE, d of MMMM, yyyy');


    // placeholder

    dateBoxInstance.option("placeholder", "Select a date please");

    // Mask input

    dateBoxInstance.option("useMaskBehavior", true); // Now Mouse whell or arrow keys will increate or decrease the date


    // apply value Mode :>  instantly(set instanly when selected) , useButton ( click done to finalize the date )

    dateBoxInstance.option("applyValueMode", "instantly"); // or useButton

    // out of range error me3ssage

    dateBoxInstance.option("outOfRangeMessage", "Date is out of range");

    // value changed trigger:> normally the value is updated when the UI goes out of focus
    dateBoxInstance.option("valueChangeEvent", "blur");

    // show value
    dateBoxInstance
    .on("valueChanged", showValue)

    dateBoxInstance.endUpdate();

    // Check if the date is a holiday
    function isHoliday(date) {
        return holiday.some(day =>
            day.getDate() === date.getDate() && day.getMonth() === date.getMonth()
        );
    }

    function showValue(e){
        console.log("New Date"+ e.value);
    }

    console.log("The time is " +dateBoxInstance.option("value"));

});
