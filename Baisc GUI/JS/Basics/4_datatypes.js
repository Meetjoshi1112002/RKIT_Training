// Data Types in javascript

// Primitive data types (all are called by values so modification done in other blocks is not visible)
// 1. Number
// 2. String
// 3. Boolean
// 4. Undefined
// 5. Null
// 6. Symbol
// 7. BigInt

// Non-primitive data types (are called by reference so modification done in other blocks is visible)
// 1. Array
// 2. Object
// 3. Function

let names = ["Meet"]

const updateArr = (arr)=>{
    arr.push("Jay");
}
updateArr(names)
console.log(names); // original array is modified


// same for object
let obj = {
    name: "Meet"
}
const updateObj = (obj)=>{
    obj.name = "Jay"
}
updateObj(obj);
console.log(obj);
