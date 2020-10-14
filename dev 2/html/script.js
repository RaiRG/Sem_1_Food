function addMessege()
{
	var a = document.getElementById("inputmessege").value;

	var b = "<div class=\"media media-chat media-chat-reverse\"> <div class=\"media-body\"> <p>" + a + "</p> <p class=\"meta\"><time datetime=\"2018\">00:06</time></p> </div> </div>"

	$("#messege").prepend(b);

	document.getElementById("inputmessege").value = "";
}


// $("form").on("submit", function(){
// 	addMessege();
// })