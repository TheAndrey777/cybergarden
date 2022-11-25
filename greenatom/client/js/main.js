let count = 1;
let toaster = new Toaster({});
setInterval(() => {
    toaster.addToast({message: "Какое-то уведомление", sender: "Основная страница", color: "green"});
    toaster.addToast({message: "Какое-то уведомление", sender: "Основная страница", color: "blue"});
    toaster.addToast({message: "Какое-то уведомление", sender: "Основная страница", color: "red"});
}, 1300);