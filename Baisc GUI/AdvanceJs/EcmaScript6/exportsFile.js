const findServerDate = () =>{
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(new Date())
        }, 5000);
        if(false){
            // if something goes wrong
            reject(new Error('Something went wrong!'))
        }
    })
}

const getClientData = () =>{
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve({name: 'Jay', age: 30})
        }, 1000);
        if(false){
            // if something goes wrong
            reject(new Error('Something went wrong!'))
        }
    })
}

export default {findServerDate , getClientData}

