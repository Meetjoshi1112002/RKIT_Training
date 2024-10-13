sayHello(); // This works due to hoisting

function sayHello() {
  console.log("Hello, World!");
}


console.log(Meet); // because default of var is undefined

var Meet = "Meet";


console.log(jay); // right now jay is in temporal dead zone!
let jay;
jay = "meet"