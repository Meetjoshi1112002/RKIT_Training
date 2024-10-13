class vector{
    #x
    #y
    constructor(x, y){
        this.#x = x
        this.#y = y
    }

    getDimesions(){
        return [this.#x, this.#y]
    }

    display(){
        console.log(this.#x, this.#y)
    }
}

class AddVec {
    static add(v1, v2){
        return new vector(v1.getDimesions()[0] + v2.getDimesions()[0], v1.getDimesions()[1] + v2.getDimesions()[1]);
    }
}

const v1 = new vector(1, 2);
const v2 = new vector(2, 3);
const v3 = AddVec.add(v1, v2);
v3.display();

