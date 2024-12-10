import APIservices from "./exportsFile.js";

APIservices.sample = async()=>{

}

const findServerDate = async() => {
    const serverDate = await APIservices.findServerDate();
    console.log(serverDate);
}

const getClientData = async() => {
    const clientData = await APIservices.getClientData();
    console.log(clientData);
}

findServerDate()
.then(()=>{
    getClientData(); // will be executed first
})


// This is because of event Loop and callback queue architecture