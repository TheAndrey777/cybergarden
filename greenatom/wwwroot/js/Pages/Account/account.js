const TITLE_KEY = "title";
const STATE_KEY = "state";

let messenger = new Messenger();
let toaster = new Toaster();
let titles = [], states = [];
for (let i = 0; i < 6; i++) {
    titles[i] = document.getElementById(TITLE_KEY + i);
    states[i] = document.getElementById(STATE_KEY + i);
}
let buttons = [];
for (let i = 0; i < 6; i++) {
    buttons[i] = document.getElementById("button" + i);
}

let adminButton = document.getElementById("adminButton");
messenger.get({address: "user", message: "", receive: (response) => {
        if (response.data.roles === 'admin') adminButton.style.visibility = "";
    }
});
messenger.get({address: "quiz/gettests", message: "",
    receive: (response) => {
        let tests = response.data.tests;
        for (let i = 0; i < 6; i++)
            titles[i].textContent = tests[i];
        for (let i = 0; i < 6; i++) {
            messenger.sendPostJson({
                address: "quiz/getready",
                message: {name: tests[i]},
                receive: (response) => {
                    states[i].style.color = response.data.ready ? "#7AC234" : "#e40000";
                    states[i].textContent = response.data.ready ? "Пройден" : "Не пройден";
                },
                cache: (error) => {
                    console.log(error)
                }
            });
        }
    }
});


