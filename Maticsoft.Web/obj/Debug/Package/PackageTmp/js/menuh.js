$(document).ready(function(){
    $(".LeftMenuBox > a").click(function () {
		var ulNode = $(this).next(".dwCont");
		ulNode.slideToggle();
});
});
