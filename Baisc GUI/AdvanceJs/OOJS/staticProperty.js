class Configuration {
    static defaultTimeout = 5000;

    static getTimeout() {
        return `Default timeout is ${Configuration.defaultTimeout} ms`;
    }
}

console.log(Configuration.defaultTimeout); // 5000
console.log(Configuration.getTimeout()); // "Default timeout is 5000 ms"
