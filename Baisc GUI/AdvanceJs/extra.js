// == and != allow type conversion.
// === and !== do not allow type conversion.


// == vs ===
console.log(5 == '5');  // true (loose equality: type coercion happens, so '5' becomes 5)
console.log(5 === '5'); // false (strict equality: no type coercion, different types)

// != vs !==
console.log(5 != '5');  // false (loose inequality: '5' is coerced to 5, so 5 != 5 is false)
console.log(5 !== '5'); // true (strict inequality: no type coercion, 5 is not strictly equal to '5')
