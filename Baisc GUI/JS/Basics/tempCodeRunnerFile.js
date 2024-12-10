const createDeadline = (days) => {
    const currentDate = new Date();
    const deadline = new Date(currentDate.getTime() + (days * 24 * 60 * 60 * 1000)); 
    return deadline;
}

console.log(createDeadline(10)); 