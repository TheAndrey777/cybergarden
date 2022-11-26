let questID = 0;
let quests = [{
        questionBox: document.getElementById("questionBox"),
        div: document.getElementById("div"),
        answers: [{
            answer: document.getElementById("answer"),
            div: document.getElementById("div"),
            checkBox: document.getElementById("checkbox")
        }],
    }
];
let createButton = document.getElementById("createButton");
createButton.addEventListener("click", () => {
    let quest = {};
    quest.div = document.createElement('div');
    quest.div.className = "wrap-input100 validate-input";
    document.getElementById("buttonDiv").before(quest.div);
    quest.questionBox = document.createElement('input');
    quest.div.append(quest.questionBox);
    quests.push(quest);
    questID++;
});
let buttons = [
    document.getElementById("buttonAdd"),
    document.getElementById("buttonRemove")
];
let clicks = [
    (question) => {
        let div = document.createElement('div');
        div.className = "wrap-input100 validate-input";
        let checkBox = document.createElement('input');
        checkBox.type = "checkbox";
        let input = document.createElement('input');
        input.className = "input100";
        input.placeholder = "Вариант ответа";
        question.div.after(div);
        question.answers.push({
            answer: input,
            div: div,
            checkBox: checkBox
        });
        div.append(checkBox);
        div.append(input);
    },
    (question) => {
        if (question.answers.length === 1) return;
        question.answers[question.answers.length - 1].div.remove();
        //for (let key in question.answers[question.answers.length - 1]) question.answers[question.answers.length - 1][key].remove();
        question.answers.splice(question.answers.length - 1, 1);
    }
];

for (let i = 0; i < buttons.length; i++)
    buttons[i].addEventListener("click", () => clicks[i](quests[questID]));