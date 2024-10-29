// types of constructor the date class provides to us:

const date  = new Date(); // give date with current date and time
let date2 = new Date(1633072800000); // Creates a Date object using the specified number of milliseconds
let date3 = new Date("2024-10-29"); // Creates a Date object from a date string
let date4 = new Date(2024, 9, 28, 14, 30, 0, 0); // Creates a Date object for October 28, 2024, 14:30:00
let originalDate = new Date();
let copiedDate = new Date(originalDate); // Creates a new Date object with the same date and time as originalDate


/****************use of getFullYear, getMonth, getDate , getDay*******************/

// example 1 (make a function to get a formated date yyyy/mm/dd)

const getFormatedDate = ()=>{
    const date = new Date();
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2,0);
    const day = String(date.getDate()).padStart(2,0);
    return year+"/"+month+"/"+day
}

console.log(getFormatedDate());

/* getDay method to get the current day of the week */

// example 2: (find Birthday day )
const getCurrentDay = ()=>{
    const date = new Date("2024-11-01"); // My Birthday date
    const dayIndex = date.getDay();
    const dayMap = new Map();
    dayMap[0]= "Sunday";
    dayMap[1]= "Sunday";
    dayMap[2]= "Sunday";
    dayMap[3]= "Sunday";
    dayMap[4]= "Sunday";
    dayMap[5]= "Firday";
    dayMap[6]= "Sunday";
    return dayMap[dayIndex]
}

console.log(getCurrentDay());

// example 3: crete a deadline of x days from current time

const createDeadline = (days) => {
    const currentDate = new Date();
    const deadline = new Date(currentDate.getTime() + (days * 24 * 60 * 60 * 1000)); 
    return deadline;
}

console.log(createDeadline(10)); 


// example 3 : Getting ISO String of a date
console.log(new Date().toISOString())


// example 4 : Get remaing day from a give date

const getRemaingDays = (date)=>{
    const targetDate = new Date(date);
    const currentDate = new Date();
    const diffTime = targetDate.getTime() - currentDate.getTime();
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    return diffDays;
}
console.log(getRemaingDays("2024-11-01"));

// we can also compare two date objects