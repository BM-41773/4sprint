$(document).ready(function () {
    $("#aprovefrnd").click(function () {
        var serchedname1 = $("#X_mainloginid").val();
        //  var a = parseInt(serchedname1);
        //  alert(serchedname1);
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/approve',
            data: { X_receiverid: serchedname1 },
            success: function (data) {

                for (var x = 0; x < data.length; x++) {
                    if (data[x].relation == 0) {
                        console.log("ID: " + data[x].LogginId + " name: " + data[x].FCFirstname + " picture: " + data[x].FCProfilepic);
                        var html = '<img src="' + data[x].Profilepic + '"style="height:35px;" /> <label>' + data[x].Firstname + '</label><label>' + data[x].Surname + '</label><input type="button" id="conformbtn" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Conform"/><input type="button" value="Delete Request" id="deletebtn"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/> <br> <br><hr>';
                        $(".fint").append(html);
                    }
                }

            }

        })


    });
});
$(document).on('click', '#conformbtn', function () {
    var reciverid = $("#X_mainloginid").val();
    var senderid = $(this).data("id");
    $(this).prop('value', 'Friend');
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/srch',
        data: { X_reciverid: reciverid, X_senderid: senderid },
        success: function (data) {
            $(".fint").empty();

            ////console.log(data[0]);
            //for (var x = 0; x < data.length; x++) {
            //    console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
            //    var html = '<img src="' + data[x].Profilepic + '"style="height:35px;" /> <label>' + data[x].Firstname + '</label><label>' + data[x].Surname + '</label><input type="button" id="X_frind" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Add Friend"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/> <br> <br><hr>';
            //    $(".fint").append(html);
            //}
            //$("#sch").hide();
        }

    })

});
