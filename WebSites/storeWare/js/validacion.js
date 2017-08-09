function onKeyDecimal(e, thix) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
        return false;
    if ((keynum == 8 || keynum == 48 || keynum == 46))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}

function fecha(e, thix2) {
    var keynum2 = window.event ? window.event.keyCode : e.which;
    if (document.getElementById(thix2.id).value.indexOf('/') != -1 && keynum2 == 47)
        return false;
    if ((keynum2 == 8 || keynum2 == 48 || keynum2 == 47))
        return true;
    if (keynum2 <= 47 || keynum2 >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum2));
}

function soloNumeros(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if ((keynum == 8 || keynum == 48))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}

function soloLetras(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return true;

    return false;
}