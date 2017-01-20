$(document).ready(function () {
    $("#frdserch").click(function () {
        // var searchedname = $("#X_Firstname1").val();
        var serchedname1 = $("#X_mainloginid").val();
        var a = parseInt(serchedname1);
       alert("fghj")
        // console.log($("#X_Firstname1").val())
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/serch',
            data: { loginid: serchedname1 },
            success: function (data) {
                //  $(".fint").empty();
                //  $(".fint").empty();
                console.log(data[0]);
                for (var x = 0; x < data.length; x++) {
                    if (data[x].relation == 1) {
                        //  console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
                        var html = '<img src="' + data[x].FCProfilepic + '"style="height:35px;" /> <label>' + data[x].FCFirstname + '</label><label>' + data[x].FCSurname + '</label><input type="button" tyle="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="UN Friend" id="btndelet"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/> <br> <br><hr>';
                        $(".fint").append(html);
                    }
                    //else {
                    //    console.log("ID: " + data[x].LogginId + " name: " + data[x].Firstname + " picture: " + data[x].Profilepic);
                    //    var html = '<img src="' + data[x].Profilepic + '"style="height:35px;" /> <label>' + data[x].Firstname + '</label><label>' + data[x].Surname + '</label><input type="button" id="X_frind" style="margin-left:90px; margin-top:-5px " data-id="' + data[x].LogginId + '"  value="Add Friend"/><input type="hidden"  value="' + serchedname1 + '"style= margin-top:-1px ;height:28px;/>  <br> <br><hr>';
                    //}
                    //  $("#sch").hide();
                  



                }
            }
        })
    });
});
$(document).on('click', '#deletebtn', function () {
    var reciverid = $("#X_mainloginid").val();
    var senderid = $(this).data("id");
    // $(this).prop('value', 'dlt');
   // alert(" senderid")
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/ufrnd',
        data: { X_senderid: senderid, X_reciverid: reciverid },
        success: function (data) {
            //  $(".fint").empty();

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
$(document).on('click', '#btndelet', function () {
    var reciverid = $("#X_mainloginid").val();
    var senderid = $(this).data("id");
    // $(this).prop('value', 'dlt');
    // alert(" senderid")
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/dlt',
        data: { X_senderid: senderid, X_reciverid: reciverid },
        success: function (data) {
            //  $(".fint").empty();

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