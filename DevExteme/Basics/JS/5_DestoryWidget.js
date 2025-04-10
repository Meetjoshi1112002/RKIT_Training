$(
    function(){
        let button = $("#myButton").dxButton("instance");
        button.dispose(); /// This just removes the funcitnonlaity
        button.empty(); /// this removes the html as well
    }
)