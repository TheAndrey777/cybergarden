class Messenger {
    constructor() {
        this.toaster = new Toaster();
    }

    sendPost(request) {
        axios.post('/' + request.address, request.message, {responseType: 'document'})
            .then((response) => {
                if (request.receive) request.receive(response);
            })
            .catch((error) => {
                if (request.cache) request.cache(error);
                this.toaster.addToast({message: "Не удалось подключиться.", title: "Ошибка:", color: "red"});
            });
    }

    login(email, password) {
        this.sendPost({
            address: "login",
            message: {email: email, password: password},
            receive: (response) => {
                if (response.data.URL !== window.location.href) window.location = response.data.URL;
                else this.toaster.addToast({message: "Не верные данные", title: "Ошибка:", color: "red"});
            },
            cache: (error) => {
                console.log(error)
            }
        });
    }

    register(email, password) {
        this.sendPost({
            address: "register",
            message: {email: email, password: password},
            receive: (response) => {
                window.location = response.data.URL;
            },
            cache: (error) => {
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
                console.log(error)
            }
        });
    }
}