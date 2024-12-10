$(
    function() {
        // Create a jQuery object with HTML content
        const div = $('<div><h1>Practise</h1><button>click it</button></div>');

        // Append the div to the body
        $('body').append(div);
        $('button').click(function(){
            $('div h1').append("<h1>Makes a man perfect</h1>")
        })

    }
);
