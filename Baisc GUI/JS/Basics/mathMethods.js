/*****random,floor******/
/*****round , Min, Max, floor******/

const result = Math.pow(4, Math.sqrt(16));
console.log(result);

console.log(Math.round(Math.floor(2.6789)))

//  finding range using max and min
const arr = [7, 1, 8, -3, 9, 2, 5];
const range = Math.max(...arr) - Math.min(...arr);
console.log(range); 

// finding log using math library
const result2 = Math.log(Math.E);
console.log(result2); // 1

// Using trigo here
console.log(Math.sin(Math.PI/2));

// Using absolute values here
console.log(Math.abs(-10));

// Using ceil and floor values here
console.log(Math.ceil(5.1) - Math.floor(6.99))



// example 1 (generate a random numer between u- l)
const generateRandomNumber = (upper, lower)=>{
    return Math.floor(Math.random() * (upper - lower + 1)) + lower;
}
console.log(generateRandomNumber(10,1));

// example 2 (check if the number is positive or not if yes then return sqrt else return abs value)
const checkSign = (num)=>{
    return num>= 0 ? Math.sqrt(num): Math.abs(num)
}
console.log(checkSign(10));



