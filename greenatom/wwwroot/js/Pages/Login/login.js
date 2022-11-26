let messenger = new Messenger();
let toaster = new Toaster();

function login(email, password) {
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

document.getElementById("connectButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let emailException = getEmailValidException(email), passwordException = getPasswordValidException(password);
    if (emailException || passwordException) toaster.addToast({message: emailException || passwordException, title: "Ошибка:", color: "red"});
    else messenger.login(email, password);
});

