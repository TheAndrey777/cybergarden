let messenger = new Messenger();
let toaster = new Toaster();
document.getElementById("connectButton").addEventListener("click", () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let emailException = getEmailValidException(email), passwordException = getPasswordValidException(password);
    if (emailException || passwordException) toaster.addToast({message: emailException || passwordException, title: "Ошибка:", color: "red"});
    else messenger.login(email, password);
});