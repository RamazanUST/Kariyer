
function KadinSec() {
    $('#asker').fadeOut("fast");
}

function ErkekSec() {
    $('#asker').fadeIn("fast");
}

function AskerTarihAc() {
    $('#askerTarih').fadeIn("fast");
}

function AskerTarihKapa() {
    $('#askerTarih').fadeOut("fast");
}


function ValidateCinsiyet(sender, args) {
    var erkek = document.getElementById("C_K_ERKEK").checked;
    var kadin = document.getElementById("C_K_KADIN").checked;
    if (erkek == false && kadin == false) {
        args.IsValid = false;
    } else {
        args.IsValid = true;
    }
}

function ValidateDogumTarih(sender, args) {
    var yil = document.getElementById("C_K_YIL").value;
    var ay = document.getElementById("C_K_AY").value;
    var gun = document.getElementById("C_K_GUN").value;

    if (yil == "0" || ay == "0" || gun == "0") {
        args.IsValid = false;
    } else {
        args.IsValid = true;
    }
}

function ValidateMedeniDurum(sender, args) {
    var evli = document.getElementById("C_K_EVLI").checked;
    var bekar = document.getElementById("C_K_BEKAR").checked;
    if (evli == false && bekar == false) {
        args.IsValid = false;
    } else {
        args.IsValid = true;
    }
}