class Messenger {
    constructor() {

    }

    send(request) {
        axios.get('/'.concat(request.address, "/", request.message))
            .then((response) => {
                if (request.receive) request.receive(response);
            })
            .catch((error) => {
                if (request.cache) request.cache(error);
            });
    }

    connect(login, password) {
        console.log(1);
        this.send({
            address: "login",
            message: login.concat(",", password),
            receive: () => console.log("Connection open"),
            cache: () => console.log("Failed connection open")
        });
    }

    close() {

    }
}