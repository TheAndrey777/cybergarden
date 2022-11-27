const TITLE_KEY = "title";

let messenger = new Messenger();
let toaster = new Toaster();
let titles = [];
for (let i = 0; i < 6; i++)
    titles[i] = document.getElementById(TITLE_KEY + i);

messenger.get({address: "quiz/gettests", message: "",
    receive: (response) => {
        let tests = response.data.tests;
        for (let i = 0; i < 6; i++)
            titles[i].textContent = tests[i];
        for (let i = 0; i < 6; i++) {
            messenger.sendPost({
                address: "quiz/getready",
                message:  {name: tests[i]},
                receive: (response) => {
                    console.log(tests[i], response.data)
                    console.log(response)
                },
                cache: (error) => {
                    console.log(error)
                }
            });
        }
    }
});


