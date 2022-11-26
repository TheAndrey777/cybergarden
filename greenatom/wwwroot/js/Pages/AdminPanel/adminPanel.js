let questionBox = document.getElementById("answerBox");
let questions = [{questionBox: document.getElementById("answer")}];
let buttons = [
    document.getElementById("buttonAdd"),
    document.getElementById("buttonRemove")
];
let div = document.getElementById("div");
let id = 1;
let clicks = [
    (div) => {
        let p = document.createElement('p');
        div.append(p);
        let checkBox = document.createElement('input');
        checkBox.type = "checkbox";
        div.append(checkBox);
        let input = document.createElement('input');
        input.class = "input300";
        input.placeholder="Вариант ответа";
        input.style = "padding-top: 25px; padding-left: 5px;border-bottom: solid; border-bottom-color:#808080";
        div.append(input);
        questions.push({p: p, checkBox: checkBox, input: input});
        id++;
    },
    (div) => {
        if (id < 0) return;
        for (let key in questions[id]) questions[id][key].remove();
        questions.splice(id, 1);
        id--;
    }
];
for (let i = 0; i < buttons.length; i++) buttons[i].addEventListener("click", () => clicks[i](div));