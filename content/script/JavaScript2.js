$(document).ready(function () {
    $("#aprovefrnd").click(function () {
        var serchedname1 = $("#X_mainloginid").val();
      //  var a = parseInt(serchedname1);
       alert("success");
        console.log($("#X_Firstname1").val());
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/approve',
            data: { X_reciverid: searchedname1 },
            success: function (data) {
                 // $(".fint").empty();
                //console.log(data[0]);
                for (var x = 0; x < data.length; x++) {
                    if (data[x].relation == 0) {
                        console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
                        var html = '<img src="' + data[x].FCProfilepic + '"style="height:35px;" /> <label>' + data[x].FCFirstname + '</label><label>' + data[x].FCSurname + '</label><input type="button" id="conformbtn" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Conform"/><input type="button" value="Delete Request" id="deletebtn"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/> <br> <br><hr>';
                        $(".fint").append(html);
                    }
                }
            }
            })
    });
});