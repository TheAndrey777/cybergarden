let messenger = new Messenger();
let toaster = new Toaster();
const INPUT_KEYS = ["FullName", "DateBirth"];
const KEYS = ["Occupation", "FamiliarWithProgramming", "MajorCommercialProjects"];
let form = {};

document.getElementById("sendButton").addEventListener("click", () => {
    INPUT_KEYS.forEach(key => {
        if (document.getElementById(key).value) form[key] = document.getElementById(key).value
    });
    KEYS.forEach(key => {
        let count = document.getElementsByName(key).length;
        console.log(document.getElementsByName(key))
        for (let i = 0; i < count; i++) {
            console.log(document.getElementById(key + i).checked)
            if (!document.getElementById(key + i).checked) continue;
            form[key] = i;
        }
    });
    console.log(Object.keys(form).length, KEYS.length + 2, Object.keys(form).length === KEYS.length + 2)
    if (Object.keys(form).length === KEYS.length + 2)
        messenger.sendPost({
            address: "form", message: form,
            receive: (response) => {
                window.location = response.data.URL;
            },
            cache: () => {
                console.log("Not well")
            }
        });
    else toaster.addToast({message: "Заполните все поля", title: "Ошибка:", color: "red"});
});
