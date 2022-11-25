let messenger = new Messenger();
messenger.connect("tom@gmail.com", "12345");
let count = 1;
let toaster = new Toaster({});
setInterval(() => {
    toaster.addToast({message: "Какое-то уведомление", title: "Основная страница", color: "green"});
    toaster.addToast({message: "Какое-то уведомление", title: "Основная страница", color: "blue"});
    toaster.addToast({message: "Какое-то уведомление", title: "Основная страница", color: "red"});
}, 1300);