function getEmailValidException(email) {
    if (email.length === 0) return "Email не должен быть пустым";
    if (!email.includes("@")) return "Неверный формат Email";
    return 0;
}

function getPasswordValidException(password, repeatPassword) {
    if (password.length === 0) return "Пароль не должен быть пустым";
    if (repeatPassword && password !== repeatPassword) return "Пароли должны совпадать";
    return 0;
}