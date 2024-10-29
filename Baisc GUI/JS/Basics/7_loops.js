// Data examples
let city = "Mumbai";
const scores = [90, 75, 88, 62, 79];

// 1. Normal for loop
console.log("Normal loop:", "String");
for (let i = 0; i < city.length; i++) {
    console.log(city.charAt(i));
}

console.log("Normal loop:", "Array");
for (let i = 0; i < scores.length; i++) {
    console.log(scores[i]);
}

// 2. For-in loop
console.log("For-in loop:", "String");
for (let index in city) {
    console.log(city[index]);
}

console.log("For-in loop:", "Array");
for (let index in scores) {
    console.log(scores[index]);
}

// 3. For-of loop
console.log("For-of loop:", "String");
for (let char of city) {
    console.log(char);
}

console.log("For-of loop:", "Array");
for (let score of scores) {
    console.log(score);
}

// 4. While loop
console.log("While loop:", "String");
let i = 0;
while (i < city.length) {
    console.log(city[i]);
    i++;
}

console.log("While loop:", "Array");
i = 0;
while (i < scores.length) {
    console.log(scores[i]);
    i++;
}
