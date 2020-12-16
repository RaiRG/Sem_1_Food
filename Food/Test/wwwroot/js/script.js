function addMessege() {
    let a = document.getElementById("inputmessege").value;
    let date = new Date();
    let b = "<div class=\"media media-chat media-chat-reverse\"> " +
        "<div class=\"media-body\"> <p>" + a + "</p> <p class=\"meta\">" +
        "<time datetime=\"2020\">"+
        date.getDate() +"." +
        date.getMonth() +"." + 
        date.getFullYear() + 
        " "+ 
        date.getHours() + ":" + 
        date.getMinutes() + ":" + 
        date.getSeconds() 
        +
        "</time></p></div> </div>"

    $("#messege").append(b);
    document.getElementById("inputmessege").value = "";
    let data = "text=" + encodeURIComponent(a);
    
    $.ajax(
        {
            type: 'GET',
            url: '/Forum?handler=Send',
            headers: {
                'message' : encodeURIComponent(a)
            }
        });
}

var numberIngr = 0;

function addIngredients() {
    numberIngr = numberIngr + 1;
    if (numberIngr < 10) {
        var b = '<input type=\"text\" name=\"Ingridient_' + numberIngr + '\" class ="form-control" style=\"background-color: #cedd81; margin-bottom: 10px;\"> <br>'
        $("#Ingredients").append(b);
    }
}

var numberStep = 0;

function addStep() {
    numberStep++;
    if (numberStep < 5) {
        var b = '<div>' +
            '<h3>Шаг</h3>' +
            '<label class=\"h6\">Фото шага : </label> <br>' +
            '<input class=\"btn btn-success\" type=\"file\" name=\"Img_' + numberStep + '\">' +
            '<h6>Описание шага :</h6>' +
            '<input type=\"text\" name=\"Description_' + numberStep + '\" class ="form-control" style=\"background-color: #cedd81; width: 60%;height: 200px;\">' +
            '</div>'

        $("#steps").append(b);
    }
}


// $("form").on("submit", function(){
// 	addMessege();
// })
//
// $('#myModal').on('shown.bs.modal', function () {
// 	$('#myInput').focus()
// })
