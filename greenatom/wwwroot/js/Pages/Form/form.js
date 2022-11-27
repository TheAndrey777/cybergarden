let messenger = new Messenger();
const INPUT_KEYS = ["FullName", "DateBirth"];
const KEYS = ["Occupation", "FamiliarWithProgramming", "MajorCommercialProjects"];
let form = {};

document.getElementById("sendButton").addEventListener("click", () => {
    INPUT_KEYS.forEach(key => form[key] = document.getElementById(key).value);
    KEYS.forEach(key => {
        let count = document.getElementsByName(key).length;
        console.log(document.getElementsByName(key))
        for (let i = 0; i < count; i++) {
            console.log(document.getElementById(key + i).checked)
            if (!document.getElementById(key + i).checked) continue;
            form[key] = i;
        }
        document.getElementById("name").value = form;
    });
    messenger.sendPost({address: "form", message: form,
        receive: () => {
        console.log("Well")
        },
        cache: () => {
        console.log("Not well")
        }
    });
});
