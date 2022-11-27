const INPUT_KEYS = ["name", "date"];
const KEYS = ["occupation", "familiarWithProgramming", "majorCommercialProjects"];
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
    console.log(form)
});
