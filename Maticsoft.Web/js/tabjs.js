var timeoutid;
$(document).ready(function(){
		$(".bcUlbox > li").each(function(index){
			$(this).mouseover(function(){
			var liNode=$(this);			
			timeoutid=setTimeout(function(){				
				$(".bc > .contentin").removeClass("contentin");				
				$("li.tabin").removeClass("tabin");

				$(".bc > div").eq(index).addClass("contentin");
				liNode.addClass("tabin");
			},300);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});


	$("#slideBox1>ul>li").each(function(index){
		$(this).mouseover(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $("#slideBox1 > .contentinslide");
				$("#slideBox1 > .contentinslide").removeClass("contentinslide");
				test.addClass('xi');
				$("li.tabinslide").removeClass("tabinslide");

				$("div.xi").eq(index).addClass("contentinslide");
				liNode.addClass("tabinslide");
			},300);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});

	$("#slideBox2>ul>li").each(function(index){
		$(this).mouseover(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $("#slideBox2 > .contentinslide");
				$("#slideBox2 > .contentinslide").removeClass("contentinslide");
				test.addClass('xw');
				$("li.tabslide").removeClass("tabslide");

				$("div.xw").eq(index).addClass("contentinslide");
				liNode.addClass("tabslide");
			},300);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
});

$("#slideBox3>ul>li").each(function (index) {
    $(this).mouseover(function () {
        var liNode = $(this);
        timeoutid = setTimeout(function () {
            var test = $("#slideBox3 > .contentinslide");
            $("#slideBox3 > .contentinslide").removeClass("contentinslide");
            test.addClass('xow');
            $("li.taboslide").removeClass("taboslide");

            $("div.xow").eq(index).addClass("contentinslide");
            liNode.addClass("taboslide");
        }, 300);
    }).mouseout(function () {
        clearTimeout(timeoutid);
    });
});

	$("#orderTcont>ul>li").each(function(index){		
		$(this).mouseover(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $("#orderTcont > .ordercontentin");
				$("#orderTcont > .ordercontentin").removeClass("ordercontentin");
				test.addClass('xq');
				$("li.ordertabin").removeClass("ordertabin");

				$("div.xq").eq(index).addClass("ordercontentin");
				liNode.addClass("ordertabin");
			},300);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});

	$(".btextBox>ul>li").each(function(index){
		$(this).click(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $(".btextBox > .balancecontentin");
				$(".btextBox > .balancecontentin").removeClass("balancecontentin");
				test.addClass('balancexq');
				$("li.balancetabin").removeClass("balancetabin");

				$("div.balancexq").eq(index).addClass("balancecontentin");
				liNode.addClass("balancetabin");
			},100);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});

	$(".selectedBox>ul>li").each(function(index){
		$(this).click(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $(".selectedBox > .secontentin");
				$(".selectedBox > .secontentin").removeClass("secontentin");
				test.addClass('sexq');
				$("li.setabin").removeClass("setabin");

				$("div.sexq").eq(index).addClass("secontentin");
				liNode.addClass("setabin");
			},100);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});

	$(".openTab>ul>li").each(function(index){
		$(this).click(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $(".openTab > .opencontentin");
				$(".openTab > .opencontentin").removeClass("opencontentin");
				test.addClass('openxq');
				$("li.opentabin").removeClass("opentabin");

				$("div.openxq").eq(index).addClass("opencontentin");
				liNode.addClass("opentabin");
			},100);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});

	$(".listBox>ul>li").each(function(index){
		$(this).click(function(){
			var liNode=$(this);
			timeoutid=setTimeout(function(){
				var test = $(".listBox > .listcontentin");
				$(".listBox > .listcontentin").removeClass("listcontentin");
				test.addClass('listxq');
				$("li.listtabin").removeClass("listtabin");

				$("div.listxq").eq(index).addClass("listcontentin");
				liNode.addClass("listtabin");
			},100);
		}).mouseout(function(){
			clearTimeout(timeoutid);
		});
	});

});