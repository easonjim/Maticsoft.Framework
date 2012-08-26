/* File Created: 六月 29, 2012 */

$(document).ready(function () {
    var timeoutid;
    $(".tabs>a").each(function (index) {
        $(this).click(function () {
            var liNode = $(this);
            timeoutid = setTimeout(function () {
                var test = $(".balancecontentin");
                $(".balancecontentin").removeClass("balancecontentin");
                test.addClass('balancexq');
                $("a.link").removeClass("link");
                $("div.balancexq").eq(index).addClass("balancecontentin");
                liNode.addClass("link");
            }, 100);
        }).mouseout(function () {
            clearTimeout(timeoutid);
        });
    });


    $(".nav>a").each(function (index) {
        $(this).click(function () {
            var liNode = $(this);
            timeoutid = setTimeout(function () {
                var test = $(".balancecontentin");
                $(".balancecontentin").removeClass("balancecontentin");
                test.addClass('balancexq');
                $("a.link").removeClass("link");
                $("div.balancexq").eq(index).addClass("balancecontentin");
                liNode.addClass("link");
            }, 100);
        }).mouseout(function () {
            clearTimeout(timeoutid);
        });
    });
});