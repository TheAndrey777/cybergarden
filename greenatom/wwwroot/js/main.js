let messenger = new Messenger();
document.getElementById("connectButton").addEventListener("click", () => {
    messenger.login(document.getElementById("email").value, document.getElementById("password").value);
});

// let count = 1;
// let toaster = new Toaster({});
// setInterval(() => {
//     toaster.addToast({message: "Какое-то уведомление", title: "Основная страница", color: "green"});
//     toaster.addToast({message: "Какое-то уведомление", title: "Основная страница", color: "blue"});
//     toaster.addToast({message: "Какое-то уведомление", title: "Основная страница", color: "red"});
// }, 1300);
