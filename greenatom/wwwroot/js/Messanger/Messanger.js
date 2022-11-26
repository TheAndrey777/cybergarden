class Messenger {
    constructor() {

    }

    sendPost(request) {
        axios.post('/' + request.address, request.message, {responseType: 'document'})
            .then((response) => {
                if (request.receive) request.receive(response);
            })
            .catch((error) => {
                if (request.cache) request.cache(error);
            });
    }

    login(email, password) {
        this.sendPost({
            address: "login",
            message: {email: email, password: password},
            receive: (response) => {
                window.redirect(response.data.URL);
            },
            cache: (error) => {
                console.log("Failed connection open")
                console.log(error)
            }
        });
    }

    logout(email, password) {
        this.sendPost({
            address: "logout",
            receive: (response) => {
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