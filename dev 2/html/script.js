function addMessege()
{
	var a = document.getElementById("inputmessege").value;

	var b = "<div class=\"media media-chat media-chat-reverse\"> <div class=\"media-body\"> <p>" + a + "</p> <p class=\"meta\"><time datetime=\"2018\">00:06</time></p> </div> </div>"

	$("#messege").prepend(b);

	document.getElementById("inputmessege").value = "";
}

function addIngredients()
{
	var b = "<input type=\"text\" name=\"\" class=\"menucalor\" style=\"margin-bottom: 10px;\"> <br>"

	$("#Ingredients").append(b);
}

function addStep()
{
	var b = "<div>" +
        "<h3>Шаг</h3>" + 
        "<label for=\"img\" class=\"h6\">Фото шага : </label> <br>" +
        "<input class=\"btn btn-success\" type=\"file\" name=\"img\">" + 
        "<h6>Описание шага :</h6>" +
        "<textarea form=\"#add\" name=\"discription\" class=\"menucalor\" style=\"width: 60%;height: 200px;\"></textarea>" +
      "</div>"

	$("#steps").append(b);
}


$("form").on("submit", function(){
	addMessege();
})

$('#myModal').on('shown.bs.modal', function () {
  $('#myInput').focus()
})
