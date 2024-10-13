console.log(document.cookie); //will log all cookies

document.cookie = "username=Meet; expires=Fri, 31 Dec 2020 23:59:59 GMT"; // will set cookie with given expiry date

// To delete this cookie we can set expire date to some previous date

document.cookie = "username=Meet; expires=Thu, 01 Jan 1970 00:00:00 GMT"; // will set cookie with given expiry date

// since cookie are seperate by ; we can use it in key or name
// to use it we use encodeURIComponent

const key  = input("Enter your name");
const value = input("Enter your password");

document.cookie = `${encodeURIComponent(key)}=${encodeURIComponent(value)}`

// now to use it we need to decodeURIComponent

// we can make cookie visible to limited path as well 

document.cookie = `${encodeURIComponent(";;asdf")}=${encodeURIComponent("as;dlfj")}; path=/limited paths`