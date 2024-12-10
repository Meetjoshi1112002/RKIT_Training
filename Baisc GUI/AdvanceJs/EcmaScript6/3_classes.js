class Human {
    #name;
    constructor(name) {
        this.#name = name;
    }

    origin() {
        console.log(`${this.#name} is my name`);
    }

    getName(){
        return this.#name
    }
}

class Sample extends Human {
    #country
    constructor(name, country) {
        super(name);  // Call the parent constructor
        this.#country = country;
    }

    tellMePlace() {
        const name = this.getName();
        super.origin();
        console.log(`${name} is from ${this.#country}`);
    }
}

const meet = new Sample('Meet', 'Bhavnagar');
meet.tellMePlace();  
