function addMessege()
{
	var a = document.getElementById("inputmessege").value;

	var b = "<div class=\"media media-chat media-chat-reverse\"> <div class=\"media-body\"> <p>" + a + "</p> <p class=\"meta\"><time datetime=\"2018\">00:06</time></p> </div> </div>"

	$("#messege").prepend(b);

	document.getElementById("inputmessege").value = "";
}
var numberIngr =0;
function addIngredients()
{
	numberIngr=numberIngr+1;
	if (numberIngr<10) {
		var b = '<input type=\"text\" name=\"ingridient_' + numberIngr + '\" class ="form-control" style=\"background-color: #cedd81; margin-bottom: 10px;\"> <br>'
		$("#Ingredients").append(b);
	}
}
var numberStep =0;
function addStep()
{
	numberStep++;
	if (numberStep<5) {
		var b = '<div>' +
			'<h3>Шаг</h3>' +
			'<label class=\"h6\">Фото шага : </label> <br>' +
			'<input class=\"btn btn-success\" type=\"file\" name=\"img_' + numberStep + '\">' +
			'<h6>Описание шага :</h6>' +
			'<input type=\"text\" name=\"Description_' + numberStep + '\" class ="form-control" style=\"background-color: #cedd81; width: 60%;height: 200px;\">' +
			'</div>'

		$("#steps").append(b);
	}
}


$("form").on("submit", function(){
	addMessege();
})

$('#myModal').on('shown.bs.modal', function () {
	$('#myInput').focus()
})
