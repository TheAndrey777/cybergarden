let toaster = new Toaster();
document.getElementById("connectButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    let emailException = getEmailValidException(email);
    if (emailException) toaster.addToast({message: emailException, title: "Ошибка:", color: "red"});
    else toaster.addToast({message: "Письмо с кодом отправлено", title: "Успешно:", color: "green"});
});