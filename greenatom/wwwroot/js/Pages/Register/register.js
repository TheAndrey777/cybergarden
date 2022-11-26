let messenger = new Messenger();
let toaster = new Toaster();
document.getElementById("registerButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value, repeatPassword = document.getElementById("repeatPassword").value;
    if (email.length === 0) toaster.addToast({message: "Введите email", title: "Ошибка:", color: "red"});
    else if (!(email.includes("@gmail.com") && email.includes("@mail.com"))) toaster.addToast({message: "Введите настоящий email", title: "Ошибка:", color: "red"});
    else if (password.length === 0) toaster.addToast({message: "Введите пароль", title: "Ошибка:", color: "red"});
    else if (password !== repeatPassword) toaster.addToast({message: "Пароли должны совпадать", title: "Ошибка:", color: "red"});
    else messenger.register(email, password);
});