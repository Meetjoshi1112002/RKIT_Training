// var is global  / function scoped fixed

var a = 10
function f() {
    if(true){
        var b = 20
    }
    console.log(a, b) // prints b since var is funciton scoped 
    // however would give an error if we try let or const for b
    // because let and const are block scoped and b is not defined in same block
}
f();
console.log(a); // error will come if we try to log b here


// let is block scoped:

// example 1
let x = 10;
function f() {
    let y = 9
    console.log(x);
    console.log(y);
}
f(); // if here x has was declared in a seperate block then it would give an error 



// example 2
let a = 10;
function f() {
    if (true) {
        let b = 9
        console.log(b); // prints 9
    }
    console.log(b); // error as seperate block
}
f();
console.log(a) //10



// example 3
{
// let a = 10
let a = 10  // It is not allowed
a = 10  // It is allowed
}


//  const has all properties of let except the fact the it cannot be reassigned in same block !!
//  also const need to be initialized at the time of declaration !!

const hi = "meet"

{
    const hi = "jay" // allowed as block are different
}

//const hi = "meet" // not allowed
hi = "jya" // not allowed
