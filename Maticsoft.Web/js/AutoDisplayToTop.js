var Sys = {};
var ua = navigator.userAgent.toLowerCase();
var s;
(s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
        (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
        (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
        (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
        (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;

var speed = 5;  //滚动速度
var stayPeriod = 10 * 1000; //停留时间
var baseMT = -223;  //内容高度
var nowMT = -223;   //内容高度

if (Sys.ie) speed = speed - 2 < 1 ? 1 : speed ;
//if (Sys.firefox) speed = 5;
if (Sys.chrome) speed = speed * 2;
//if (Sys.opera) speed = 5;
//if (Sys.safari) speed = 5;


var tagMT = 0;
var adobj;
var opendiv;
var closdiv;
var addfunc;
var handobj;
var reducefunc;
window.onload = function () {
    adobj = document.getElementById("bigad");
    opendiv = document.getElementById("opendiv");
    closdiv = document.getElementById("closdiv");
    if (nowMT <= 0) {
        adobj.style.display = "block";
        addfunc = setInterval("addheight()", 1);
    }
};
function closetopad() {
    if (nowMT <= speed) {
        callreduceheight();
        if (typeof (handobj) == "number") {
            clearTimeout(handobj);
        }
    }
}
function addheight() {
    nowMT += speed;
    if (nowMT > tagMT) {
        clearInterval(addfunc);
        handobj = setTimeout("callreduceheight()", stayPeriod);
        return;
    }
    adobj.style.marginTop = nowMT + "px";

}
function callreduceheight() {
    reducefunc = setInterval("reduceheight()", 1);
}
function reduceheight() {
    adobj.style.marginTop = nowMT + "px";
    nowMT -= speed;
    if (nowMT <= baseMT) {
        clearInterval(reducefunc);
        adobj.style.display = "none";
        return;
    }
}
