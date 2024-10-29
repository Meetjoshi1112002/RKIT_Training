// Lets explore some strings in JS

// **********************************************Split***********************************************************************************

let sentences = "My name is Meet joshi,I am passionate about backend development! Thanks you. "

const arr = sentences.split(/[,.!\s]/);

console.log(arr);


// **********************************************Split mehtod with use of forEach to make a more complex example ****************


// example one

let complexSentence = "My name is Meet joshi,I am passionate about backend development! Thanks you."

const arr2 = complexSentence.split(/[,.!\s]/);

let formatedArray = []

arr2.forEach((v)=>{
    if(v !== '')formatedArray.push(v);
})

console.log(formatedArray);

//example two

let string  = "RKIT"

const arr3 = string.split("");

arr3.forEach((v,i,a)=>{
    a[i] += "-JS";
})

console.log(arr3.join("***"));      // explored join mehtod used to concate the elements of the array
 

/**********************************************************ToUpperCase, charAt, replace, trim, toLowerCase *********************************** */

// example one:

let sentences2 = "   my name is meet joshi   "
const capatilize = (string)=>{
    if(false){

        const arr = string.trim().split(" ");
        arr.forEach((v,i,a)=>{
            a[i] = a[i].charAt(0).toUpperCase() + a[i].slice(1);
        })
        return arr.join(" ");
    }
    else{
        // method 2 using replace
        return string.replace(/\b\w/g, (char) => char.toUpperCase()).trim(); // here we used a callback as the task was dynamic
        // we could use replaceAll if we dont want the g in regExp
    }
}

console.log(capatilize(sentences2));


/*****Slice , Splice (covered in array) , indexOf, includes , substring, lastIndexOf */

let str = "Hello, World!";
let slicedStr = str.slice( 5,); 
// suppose end  not specified then it considers the edges
console.log(slicedStr);


let text = "Hello, World!";
let hasHello = text.includes("Hello",5); 
let hasGoodbye = text.includes("World",5); 
console.log(hasHello, hasGoodbye);


let exampleStr = "Hello, World!";
let subStr = exampleStr.substring(0, 5);
console.log(subStr);


let searchStr = "Hello, World!";
let index = searchStr.indexOf("World",5); // Returns 7
console.log(index);

// mehtod like substring, indexOf, includes has a optional paratemer of start index


