let errorText = document.getElementById('errorShow');
if (errorText) {
    setTimeout(function () { errorText.style = 'display: none;'; }, 10000)
}

$('#email').on('keypress', function (e) {
    validate();
})
$('#email').on('change', function (e) {
    validate()
})

document.addEventListener('keydown', function (e) {
    if (e.keyCode == 8) {
        console.log("backspace typed")
        validate();

    } else if (e.keyCode == 46) {
        console.log("delete typed")
        validate();
    }
})

function validate() {
    setTimeout(() => {
   var validIco = $('#valid_email_ico');
    if (/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test($('#email')[0].value)) {
        console.log("valid", $('#email')[0].value)
        validIco.removeClass('d-none')
    } else {
        validIco.addClass('d-none')
        console.log("invalid", $('#email')[0].value)
    }
    }, 300)
}