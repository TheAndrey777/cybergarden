let messenger = new Messenger();
let toaster = new Toaster();
document.getElementById("registerButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value, repeatPassword = document.getElementById("repeatPassword").value;
    let emailException = getEmailValidException(email), passwordException = getPasswordValidException(password, repeatPassword || password + "1");
    if (emailException || passwordException) toaster.addToast({message: emailException || passwordException, title: "Ошибка:", color: "red"});
    else messenger.register(email, password);
});