class Messenger {
    constructor() {

    }

    send(request) {
        axios.post('/' + request.address, request.message, {responseType: 'document'})
            .then((response) => {
                if (request.receive) request.receive(response);
            })
            .catch((error) => {
                if (request.cache) request.cache(error);
            });
    }

    connect(email, password) {
        console.log({login: email, password: password})
        this.send({
            address: "login",
            message: {email: email, password: password},
            receive: (response) => {
                console.log("Connection open")
                console.log(response)
                window.redirect(response.data.URL);
            },
            cache: (error) => {
                console.log("Failed connection open")
                console.log(error)
            }
        });
    }

    close() {

    }
}