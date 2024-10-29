/********************************************Splice*****************************************************************/
let sampleArray = ["THis ", 1 , 2 ,"Done", "sample"]

const deletedElementsArray = sampleArray.splice(1,2,"Added Newly");
// addes this newly from the point of deletion/ start index
// modifies the original array
console.log(sampleArray + " "+ deletedElementsArray);

/*********Ways to create Array (important from basics)**********/ 
const way1= []
const way2 = new Array();
const way3 = Array.of("Meet","Joshi")
const way4 = Array.from(way3 ?? "ITERABLE_OBJECT")
console.log(way4);

// example 1 (Question: Given an array let arr = [3, 5, 7];, use methods to add 9 at the start and remove the last element.)
let arr = [1,2,5,6]
arr.unshift(9); // return new lenght 
arr.pop();
console.log(arr);


// example 2: (Question: Concatenate arr1 = [1, 2, 3] with arr2 = [4, 5, 6] and store the result in a new array.)
let arr1 = [1, 2, 3];
let arr2 = [4, 5, 6];
let combined = arr1.concat(arr2);
console.log(combined); 


// example 3: (Question: Given let arr = [2, 3, 2, 4, 3, 5, 2];, find the index of the last occurrence of 2.)
let arrr = [2, 3, 2, 4, 3, 5, 2];
let lastIndex = arrr.lastIndexOf(2);
console.log(lastIndex); // 6

// join method to join array element with a delimeter
// .sort and .reverse to perform the corrosponding taks


/* Some challenge questions to learn all important methods of array  */

// example 1 :( Push and Unshift: Building a Stack and Queue)
const stack = [];
stack.push(10);
stack.push(20)
console.log(stack.pop());
const queue = [];
queue.push(1);
queue.push(2);
console.log(queue.shift()); // similar to deque


//example 2: (sort in descending order) ---> sort, localeCompare
let words = ['banana', 'apple', 'pear', 'mango'];
words.sort((a, b) => b.localeCompare(a));
console.log(words); // ['pear', 'mango', 'banana', 'apple']

// example 3:(Use of slice to create a deep copy of array)
let ar = [10, 20, 30];
let copy = ar.slice();
copy[0] = -1
console.log(copy+" "+ar); // [10, 20, 30]

// example 4: (Determine the element present or not if yes find its occurances) // includes, indexOf, LastIndexOf, sort
const findOccurances = (arr,ele)=>{
    const copy = arr;
    copy.sort();
    if(copy.includes(ele)){
        return copy.lastIndexOf(ele) - copy.indexOf(ele) + 1;
    }
    else throw new Error("Number not present")
}
console.log(findOccurances([8,9,1,2,5],7));


// use of map
const people = [
    { name: "Alice", age: 25 },
    { name: "Bob", age: 30 },
    { name: "Charlie", age: 35 }
  ];
  
  const names = people.map(person => person.name);
  console.log(names); // Output: ["Alice", "Bob", "Charlie"]

  
//   use of filter 
const mixedNumbers = [12, -5, 10, -8, 3];
const positiveNumbers = mixedNumbers.filter(num => num > 0);
console.log(positiveNumbers); // Output: [12, 10, 3]



// use of reduce to get count of each value in array
const fruits = ["apple", "banana", "apple", "orange", "banana", "apple"];
const counts = fruits.reduce((acc, fruit) => {
  acc[fruit] = (acc[fruit] || 0) + 1;
  return acc;
}, {});

console.log(counts); // Output: { apple: 3, banana: 2, orange: 1 }


// use of forEach to print oddd and even
const nums = [1, 2, 3, 4, 5, 6];
nums.forEach(num => {
  if (num % 2 === 0) {
    console.log(`${num} is even`);
  } else {
    console.log(`${num} is odd`);
  }
});






