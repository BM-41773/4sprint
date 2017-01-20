function mavaldt() {

    var e = document.getElementById("phn").value;
    var a = e.indexOf("@");
    var d = e.lastindex(".");
    if (a < 1 || d < a + 2 || d + 2 >= e.length) {
        alert("Not a valied E-mail adress");
        return false;
    }
}
 var pass = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    if (paswrd.value == pass) {
        alert('Correct....')
        return true;
    }
    else {
        alert('Wrong...!')
        return false;
    }

}