let messenger = new Messenger();
let toaster = new Toaster();
document.getElementById("connectButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    if (email.length === 0) toaster.addToast({message: "Введите email", title: "Ошибка:", color: "red"});
    else if (!email.match("^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")) toaster.addToast({message: "Введите настоящий email", title: "Ошибка:", color: "red"});
    else if (password.length === 0) toaster.addToast({message: "Введите пароль", title: "Успешно:", color: "red"});
    else messenger.login(document.getElementById("email").value, document.getElementById("password").value);
});