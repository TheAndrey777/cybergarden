let messenger = new Messenger();
let toaster = new Toaster();
let question = document.getElementById("question");
let questionID = -1;

let answers = [];

function build(quest) {
    questionID++;
    question.textContent = quest.question;
    let divAnchor = document.getElementById("questionDiv");
    answers.push([]);
    for (let i = 0; i < quest.answers.length; i++) {
        let div = document.createElement('div');
        let checkBox = document.createElement('input');
        checkBox.type = "checkbox";
        let answer = document.createElement("span");
        answer.textContent = " " + quest.answers[i];
        div.append(checkBox);
        div.append(answer);
        answers[questionID].push({checkBox: checkBox, answer: answer});
        divAnchor.after(div);
        divAnchor = div;
    }
}
