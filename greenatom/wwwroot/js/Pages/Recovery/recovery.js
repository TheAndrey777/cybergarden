let toaster = new Toaster();
document.getElementById("connectButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    if (email.length === 0) toaster.addToast({message: "Введите email", title: "Ошибка:", color: "red"});
    else if (!(email.includes("@gmail.com") && email.includes("@mail.com"))) toaster.addToast({message: "Введите настоящий email", title: "Ошибка:", color: "red"});
    else toaster.addToast({message: "Письмо с кодом отправлено", title: "Ошибка:", color: "green"});
});