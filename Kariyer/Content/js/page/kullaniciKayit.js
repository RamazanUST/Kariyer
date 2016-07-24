function TcAc() {
    $("#divTc").fadeIn("fast");
    $("#divYabanci").fadeOut("fast");
    $("#C_K_YABANCI").prop("checked", false);
}

function YabanciAc() {
    $("#divTc").fadeOut("fast");
    $("#divYabanci").fadeIn("fast");
    $("#C_K_TCLI").prop("checked", false);
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

function ValidateTc(sender, args) {
    var tcMi = $("#divTc").css("display");
    if (tcMi != "none") {
        var tc = $('#C_K_TC').val();
        if (tc != "") {
            if (tc.substr(0, 1) == 0 || tc.length != 11) {
                args.IsValid = false;
            }
            var i = 9, md = '', mc = '', digit, mr = '';
            while (digit = tc.charAt(--i)) {
                i % 2 == 0 ? md += digit : mc += digit;
            }
            if (((eval(md.split('').join('+')) * 7) - eval(mc.split('').join('+'))) % 10 != parseInt(tc.substr(9, 1), 10)) {
                args.IsValid = false;
            }
            for (c = 0; c <= 9; c++) {
                mr += tc.charAt(c);
            }
            if (eval(mr.split('').join('+')) % 10 != parseInt(tc.substr(10, 1), 10)) {
                args.IsValid = false;
            }
            args.IsValid = true;

        } else {
            args.IsValid = false;
        }
    } else {
        args.IsValid = true;
    }
}

function ValidateUyruk(sender, args) {
    var yabancimi = $("#divYabanci").css("display");
    if (yabancimi != "none") {
        if ($('#C_K_UYRUK').val() == "") {
            args.IsValid = false;
        } else {
            args.IsValid = true;
        }
    } else {
        args.IsValid = true;
    }
}
