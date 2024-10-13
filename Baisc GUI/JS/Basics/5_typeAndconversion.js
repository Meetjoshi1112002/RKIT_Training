const marks = 99
console.log(typeof marks); //number

// important to note : Array and null is an object
const arr = [1, 2, 3, 4, 5]
console.log(typeof arr); //object
console.log(typeof null); //object

// we can convert one datatype to other datatype
const nullDt = null  // null --> 0 
console.log(Number(nullDt)); // 0
console.log(String(nullDt)); // "null"

const falseB = false; //false --> 0
console.log(Number(falseB)); // 0
console.log(String(falseB)); // "false"

const undef = undefined
console.log(Number(undef)); // gives not a number error as couldnt covert to number
console.log(String(undef)); // gives "undefined"

// similarly false and true become  0 and 1 on convert to number

