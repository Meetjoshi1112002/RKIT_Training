const button = document.getElementById("button");
        button.addEventListener("click", () => {
            console.log("Button Clicked");
            if(true){
                throw Error("This is an error")
            }
        })
        const textarea = document.getElementById("textarea");
        textarea.addEventListener("mouseover", () => {
            alert(textarea.value);
        })

        const num1 = document.getElementById("num1");
        const num2 = document.getElementById("num2");
        const cal = document.getElementById("cal");
        const res = document.getElementById("res");
        function checkEmpty(num1,num2){
            if(num1.value === "" || num2.value === ""){
                alert("Please fill all the fields");
                return 1;
            }
        }
        function add(num1,num2){
            return (num1.value+ num2.value);
        }
        cal.addEventListener("click", () => {
            const flag =checkEmpty(num1.value,num2.value);
            if(flag) return;
            res.innerText = "The sum of "+num1.value+" and "+ num2.value +" is "+ add(num1,num2);
        })