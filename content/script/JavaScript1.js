$(document).ready(function () {
    $("#srh").click(function () {
        var searchedname = $("#X_Firstname1").val();
        var serchedname1 = $("#X_mainloginid").val();
        var a = parseInt(serchedname1);
        console.log($("#X_Firstname1").val())
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/serchfrnd',
            data: { name: searchedname },
            success: function (data) {
                //  $(".fint").empty();
                $(".fint").empty();
                //console.log(data[0]);
                for (var x = 0; x < data.length; x++) {
                    if ((data[x].relation == 0) && ( data[x].sender==a)  ) {
                        console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
                        var html = '<img src="' + data[x].FCProfilepic + '"style="height:35px;" /> <label>' + data[x].FCFirstname + '</label><label>' + data[x].FCSurname + '</label><input type="button" id="X_frind" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Request send"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/> <br> <br><hr>';
                    }
                    else {
                        console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
                        var html = '<img src="' + data[x].Profilepic + '"style="height:35px;" /> <label>' + data[x].Firstname + '</label><label>' + data[x].Surname + '</label><input type="button" id="X_frind" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Add Friend"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/>  <br> <br><hr>';
                    }
                    $("#sch").hide();
                    $(".fint").append(html);



                }
            }
        })
    });
    $(document).on('click', '#X_frind', function () {
        var reciverid = $(this).data("id");
        var senderid = $("#X_mainloginid").val();
        $(this).prop('value', 'request sent');
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/friend',
            data: { X_reciverid: reciverid, X_senderid: senderid },
            success: function (data) {
                ////console.log(data[0]);
                //for (var x = 0; x < data.length; x++) {
                //    console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
                //    var html = '<img src="' + data[x].Profilepic + '"style="height:35px;" /> <label>' + data[x].Firstname + '</label><label>' + data[x].Surname + '</label><input type="button" id="X_frind" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Add Friend"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/> <br> <br><hr>';
                //    $(".fint").append(html);
                //}
                //$("#sch").hide();
            }

        })

    })
});
