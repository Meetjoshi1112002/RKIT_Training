$(
    function () {

        // Create a simple TextBox widget
        $("#myTextBox").dxTextBox({
            value: "Hello, DevExtreme!",
            placeholder: "Type something...",
        });

        // Get the widget instance
        let textBoxInstance = $("#myTextBox").dxTextBox("instance");

        // Toggle state
        let toggle = false;

        //Two different approaches for calling methods
        setInterval(() => {
            if (toggle) {
                // Approach 1: Calling the method using the instance
                textBoxInstance.reset();
                console.log("Method called using instance: textBoxInstance.reset();");
            } else {
                // Approach 2: Calling the method using jQuery plugin
                $("#myTextBox").dxTextBox("focus");
                console.log('Method called using jQuery plugin: $("#myTextBox").dxTextBox("focus");');
            }
            toggle = !toggle;
        }, 2000);
    }
)