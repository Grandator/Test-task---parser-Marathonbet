$("button._Y8TrgKVZ").click();
setTimeout(function () {
    var Login = document.querySelector('input[data-field="login"]');
    Login.click();
    Login.focus();
    Login.select();
    document.execCommand("insertText", false, "Grandator")

    var Password = document.querySelector('input[data-field="password"]');
    Password.click();
    Password.focus();
    Password.select();
    document.execCommand("insertText", false, "Grandator1")

    document.querySelector('button[type="submit"]').click();
}, 100);

    
