//<![CDATA[
$(document).ready(function() {
    var d = new Date();
    var dayNumber = d.getDay() % 12;
    $(".spriteHeader").addClass(GetClass(dayNumber)).css("min-height", "81px").css("background", GetCss("Header", dayNumber));

    $(".spriteFooter").addClass(GetClass(dayNumber)).css("min-height", "81px").css("background", GetCss("Footer", dayNumber));

    if ($("#SetFocus").length > 0) {
        ErrorAlert();
        CheckHide();
        SetPanelHeigthToFitWindow();
    }
});


function GetClass(dayNumber) {
    switch (dayNumber) {
    case 0:
        return "black";
    case 1:
        return "blue";
    case 2:
        return "bluegreen";
    case 3:
        return "bronze";
    case 4:
        return "gold";
    case 5:
        return "green";
    case 6:
        return "red";
    case 7:
        return "redgreen";
    case 8:
        return "redblue";
    case 9:
        return "silver";
    case 10:
        return "violet";
    case 11:
        return "white";
    default:
        return "white";
    }
};

function GetCss(spriteType, dayNumber) {

    switch (dayNumber) {
    case 0:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 0";
    case 1:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -81px";
    case 2:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -162px";
    case 3:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -243px";
    case 4:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -324px";
    case 5:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -405px";
    case 6:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -486px";
    case 7:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -567px";
    case 8:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -648px";
    case 9:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -729px";
    case 10:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -810px";
    case 11:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -891px";
    default:
        return "transparent url('/Content/Images/Bootstrap" + spriteType + "Composed.jpg') 0 -891px";
    }
};


/* --- Dialogs --- */

function userConfirms(question) {
    var confirm = window.confirm(question.toString());
    if (confirm) {
        return true;
    } else {
        return false;
    }
}

function informUser(message) {
    alert(message);
}

function isValidDate(date) {
    date = date.replace("-", "/");
    date = date.replace("-", "/");
    if (Date.parse(date)) {
        return true;
    } else {
        return false;
    }
}

function todayDate() {
    var d = new Date();
    var yyyy = d.getFullYear().toString();
    var mm = (d.getMonth() + 1).toString();
    if (mm.length === 1) mm = "0" + mm;
    // getMonth() is zero-based
    var dd = d.getDate().toString();
    if (dd.length === 1) dd = "0" + dd;
    return yyyy + "-" + mm + "-" + dd;
}

function isFutureDate(date, todayOkAsFuture) {
    if (!isValidDate(date)) {
        return false;
    }
    var today = todayDate();
    if (todayOkAsFuture) {
        if (date >= today) {
            return true;
        }
    } else {
        if (date > today) {
            return true;
        }
    }
    return false;
}


function validateEmailList(divMail) {
    var regexEmail = new RegExp(/^([\wÅÄÖåäö\-_]+(\.[\wÅÄÖåäö\-_]+)*@[\wÅÄÖåäö\-_]+(\.[a-z0-9-]+)*(\.[a-z]{2,4});{1})*[\wÅÄÖåäö\-_]+(\.[\wÅÄÖåäö\-_]+)*@[\wÅÄÖåäö\-_]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/);
    //var regex_email = new RegExp(/^[\W]*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4}[\W]*;{1}[\W]*)*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4})[\W]*$/);
    if (!regexEmail.test($(divMail).val())) {
        return false;
    }
    return true;
}


function validateEmail(divMail) {
    //var regex_email = new RegExp(/^[\wÅÄÖåäö\-_]+(\.[\wÅÄÖåäö\-_]+)*@[\wÅÄÖåäö\-_]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/);
    var regexEmail = new RegExp(/^[\wÅÄÖåäö\-_]+(\.[\wÅÄÖåäö\-_]+)*@[\wÅÄÖåäö\-_]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/);

    if (!regexEmail.test($(divMail).val())) {
        return false;
    }
    return true;
}


function are_cookies_enabled() {
    var cookieEnabled = (navigator.cookieEnabled) ? true : false;
    if ((typeof navigator.cookieEnabled === "undefined") && (!cookieEnabled)) {
        document.cookie = "testcookie";
        cookieEnabled = (document.cookie.indexOf("testcookie") !== -1) ? true : false;
    }
    return (cookieEnabled);
}

function NoFrame() {
    $("#myframe", function() { $("#myframe", function() { $("#divIframe").html("") }).remove(); }).attr("src", "");
};

function AddFrame() {
    var a = "http://9elements.com/io/projects/html5/canvas/";
    $("#divIframe", function() { $("#myframe", function() { SetPanelHeigthToFitWindow(); }).attr("src", a); }).html("<iframe id='myframe' width='2000px' height='600px'></iframe>");
};

function ToggleScript() {
    if ($.cookie("ScriptOn") == "True") {
        $.cookie("ScriptOn", "False", 365);
        NoFrame();
    } else {
        $.cookie("ScriptOn", "True", 365);
        AddFrame();
        setTimeout(Reload, 100);
    }
};

function Reload() {
    window.location.reload(false);
};

function SetPanelHeigthToFitWindow() {
    var h = document.body.clientHeight - 160;
    if (document.getElementById("myframe") != null) {
        document.getElementById("myframe").height = h
    };
};


function runAnimate() {
    $("#divWeather").css("visibility", "visible").hide()
        //                        .animate({ height: "hide" }, 2000, "easeInBounce")
        .animate({ height: "show" }, 2000, "easeOutBounce");
};

var divSwirl = $("#divSwirl");

function HideText(selector, callback) {
    $(selector).css("visibility", "visible").show().fadeOut("slow", callback);
};

function ShowText(selector, callback) {
    $(selector).css("visibility", "visible").hide().fadeIn("slow", callback);
};

function Spinn() {
    divSwirl.css("visibility", "visible").css("display", "none").toggle("swirl", { spins: 6 }, 1500, function() {
        ShowText("#divText", function() { ShowText("#divDownload", function() { ShowText("#divContact", function() { runAnimate() }) }) });
    });
};

$(window).load(function() {
    if ($.cookie("ScriptOn") === "True") {
        ShowText("#divSwirl", function() { ShowText("#divText", function() { ShowText("#divDownload", function() { ShowText("#divContact", function() { runAnimate() }) }) }) });
    }
    Spinn();
});


function CheckIB(p) {
    var GetVal = jQuery.fn.V = function() { return $("#" + p).val(); };
    var re = new RegExp("^([0]|[1-9][0-9]{0,4}|EoS)$");
    if (!re.test(GetVal())) {
        alert(p + " must be within 0 and 99999!");
        return false;
    } else {
        return true;
    }
};

function CheckFR(p) {
    var GetVal = jQuery.fn.V = function() { return $("#" + p).val(); };
    var re = new RegExp("^([1-9]|[1-9][0-9]|100|[0-9][.,][0-9]{0,4}[1-9])$");
    if (!re.test(GetVal())) {
        alert(p + " must be within 0.00001 and 100!");
        return false;
    } else {
        return true;
    }
};

function CheckRS(p) {
    var GetVal = jQuery.fn.V = function() { return $("#" + p).val(); };
    var re = new RegExp("^([0]|[1-9][0-9]{0,4}|EoS)$");
    if (!re.test(GetVal())) {
        alert(p + " must be within 0 and 9999!");
        return false;
    } else {
        return true;
    }
};

function CheckRL(p) {
    var GetVal = jQuery.fn.V = function() { return $("#" + p).val(); };
    var re = new RegExp("^([0]|[1-9]|[1-9][0-9]|100)$");
    if (!re.test(GetVal())) {
        alert(p + " must be within 0 and 100!");
        return false;
    } else {
        return true;
    }
};

function Collapse() {
    $(Content0).slideToggle("slow", function() {
        ChangeText();
        SetPanelHeigthToFitWindow();
    });

};

//]]>