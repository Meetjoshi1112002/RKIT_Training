// 1. Using Constructor Functions (Pre-ES6 Way)----------------------------------------------------------------------------

function User(name, age) {
    this.name = name;
    this.age = age;
}

// Adding methods using prototype
User.prototype.greet = function() {
    return `Hello, my name is ${this.name} and age is ${this.age}`;
};

const user1 = new User('Meet Joshi', 22);
console.log(user1.greet()); // "Hello, my name is Alice"


// 2. Using ES6 Class ------------------------------------------------------------------------------------------------
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    // Method
    greet() {
        return `Hello, my name is ${this.name}`;
    }
}

const per = new Person('Jay', 30);
console.log(per.greet()); // "Hello, my name is Jay joshi"

