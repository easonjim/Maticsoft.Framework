<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="CourseComment.aspx.cs" Inherits="Maticsoft.Web.PubCourse.CourseComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            ajaxload();
        });

        var CPageID; //页码全局变量
        var CPageName; //总页码

        //--------------封装循环显示的评论方便回调的时候使用--------------------//	
        function xunhuan(data, pageIndex) {
            $('#divComm').empty();
            var libody = "";
            $.each(data, function (i, n) {


                var html = '';
                html += '<div class="act">';
                html += '<dl>';
                html += '<dt style="height:auto;font-style:normal;font-size:12px;line-height:18px;margin-bottom:10px;"><span class="NameHuiFU">' + getName(n.UserID) + '</span>&nbsp;&nbsp;&nbsp;&nbsp;<span>' + n.CommentInfo + '</span><div style="color:#7d7d7d;">' + n.CommentDate + '<span class="HuiFSub" >回复(' + n.CCount + ')</span></div></dt>';


                html += '<div class = "ajaxHF" id="' + n.CommentID + '">';



                html += '</div>';

                html += '<div class="TianChon">';
                html += '</div>';
                html += '</dl><a href=#""><img src="' + getimg(n.UserID) + '" width="44" height="44" class="imgCss"/></a></div>'

                libody += html;


            });


            $('#divComm').append(libody);

            CreatetCom();

            $(".top").each(function (index) {

                $(".top").eq(index).html($(".ajaxHF").eq(index).children(".HuiFURw").length);

            })


            CPageID = pageIndex; //获取返回的页码

            var Fir = Number($(".CpageID").eq(0).text());
            var zongye = Math.round(Number(CPageName) / 10);
            $(".CpageID").each(function (a) {

                if (Number($(this).text()) == CPageID) {
                    if (a > 8) {
                        var d = a - 4;
                        $(".CpageID").empty();

                        for (var b = Fir, g = 0; b < Fir + 10, g < 10; b++, g++) {
                            var num = b + d;
                            $(".CpageID").eq(g).html("<a href=\"javascript:void(0);\">" + num + "</a>");
                            if (b + d >= Number(CPageName))
                                break;
                        }
                    }
                    if (a == 0 && Fir != 1) {
                        var d = 5 - a;
                        $(".CpageID").empty();
                        for (var b = Fir, g = 0; b < Fir + 10, g < 10; b++, g++) {
                            var num = b - d;
                            $(".CpageID").eq(g).html("<a href=\"javascript:void(0);\">" + num + "</a>");
                        }
                    }
                }
            })

            $(".CpageID").each(function () {
                if (Number($(this).text()) == CPageID) {
                    $(".CpageID").css("background", "#FFF");
                    $(this).css("background", "#FC9");
                }
            })

            if (Number(CPageID) == 1)//先初始化
            {
                $(".CFirst").css("cursor", "default");
                $(".CFirst").css("background", "#F3F4F6");
                $(".CFirst").css("color", "#999");
                $(".CpageID").eq(0).css("background", "#FC9");
                $(".CNext").css("cursor", "pointer");
                $(".CNext").css("color", "#000");
                $(".CFirst").css("text-decoration", "none");
            }
            else {
                $(".CFirst").css("cursor", "pointer");
                $(".CFirst").css("color", "#000");
                if (Number(CPageName) == Number(CPageID))//判断是否点击最后一个数
                {
                    $(".CNext").css("cursor", "default");
                    $(".CNext").css("background", "#F3F4F6");
                    $(".CNext").css("color", "#999");
                    $(".CNext").css("text-decoration", "none");
                }
                else {
                    $(".CNext").css("cursor", "pointer");
                    $(".CNext").css("color", "#000");
                }
            }

            if (Number(CPageName) == 1 && Number(CPageID) == 1) {
                $(".CFirst").css("cursor", "default");
                $(".CFirst").css("background", "#F3F4F6");
                $(".CFirst").css("color", "#999");
                $(".CFirst").css("text-decoration", "none");
                $(".CNext").css("cursor", "default");
                $(".CNext").css("background", "#F3F4F6");
                $(".CNext").css("color", "#999");
                $(".CNext").css("text-decoration", "none");
            }

        }


        function CreatetCom() {
            $('.ajaxHF').each(function (index) {
                $.ajax({
                    url: "HomeIndex.aspx",
                    type: 'post',
                    dataType: 'json',
                    timeout: 10000,
                    data: {
                        action: "joinCom",
                        ParentID: $('.ajaxHF').eq(index).attr('id')
                    },
                    success: function (ChildData) {
                        if (ChildData.STATUS == "SUCCESS") {
                            var libody = "";
                            $.each(ChildData.DATA, function (j, n) {

                                var html = '';

                                html += '<div class="HuiFURw">';
                                html += '<img src="' + getimg(n.UserID) + '" width="42" height="42"  class="imgCss"/>';
                                html += '<span class="NameHuiFU">' + getName(n.UserID) + '</span>';
                                html += ' <span class="countHuiFu">' + n.CommentInfo + '</span>';


                                html += '</div>';
                                html += '<span class="color" style="float:left; margin-left:20px;">' + n.CommentDate + '</span><br/>'
                                libody += html
                            });
                            $('.ajaxHF').eq(index).html(libody);
                        } else {
                            $("#divComm").html("暂无评论信息");
                        }
                    }
                });
            });
        }


        function getName(uid) {
            var uname;
            $.ajax({
                url: "HomeIndex.aspx",
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                data: {
                    action: "UserInfo",
                    Uid: uid
                },
                async: false,
                success: function (UserData) {
                    if (UserData.STATUS == "SUCCESS") {
                        uname = UserData.UserName;

                    } else {
                    }
                }
            });
            return uname;
        }
        function getimg(uid) {
            var uimg;
            $.ajax({
                url: "HomeIndex.aspx",
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                data: {
                    action: "UserInfo",
                    Uid: uid
                },
                async: false,
                success: function (UserData) {
                    if (UserData.STATUS == "SUCCESS") {
                        uimg = UserData.UserAvatar;
                    } else {
                    }
                }
            });
            return uimg;
        }

        //------------------封装遍历循环的评论回复框-------------------------//
        function HuiFu() {
            $('.HuiFSub').each(function (index) {
                var stre = function () {//填充函数
                    var textBox = '<br/><div class="HuiFBox" style="display:none;" > <ol style=" margin-bottom:10px;"><li style="overflow:hidden;padding:5px 0;"><textarea name="HuiFuBox"  class="textarea04" style="width:530px; height:56px;margin-right:5px;"></textarea></li><li  style="height:100%;overflow:hidden;padding:5px 0;"><input name="" type="button" class="button29"  style="float:right;margin-right:10px;"/></li></ol></div>'
                    $('.TianChon').eq(index).html(textBox);
                    $('.HuiFBox').slideDown();
                    $('.button29').click(function () {
                        if ($('.textarea04').val() == "") {
                            ShowFailTip("内容不能为空!!!");
                            return false;
                        } else {
                            if ($('.textarea04').val().length > 110) {
                                ShowFailTip("输入内容过多");
                                return false;
                            }
                            $.ajax({
                                url: "HomeIndex.aspx",
                                type: 'post',
                                dataType: 'json',
                                timeout: 10000,
                                data: {
                                    action: "InsertCom",
                                    Uid: $("[id$='hfUid']").val(),
                                    Mid: $.getUrlParam('mid'),
                                    Cid: $.getUrlParam('CourseId'),
                                    Pid: $('.ajaxHF').eq(index).attr('id'),
                                    Con: $(".textarea04").val()
                                },
                                success: function (AddData) {
                                    if (AddData.STATUS == "SUCCESS") {
                                        var libody = "";
                                        $.each(AddData.DATA, function (j, n) {

                                            var html = '';

                                            html += '<div class="HuiFURw">';
                                            html += '<img src="' + getimg(n.UserID) + '" width="42" height="42"  class="imgCss"/>';
                                            html += '<span class="NameHuiFU">' + getName(n.UserID) + '</span>';
                                            html += ' <span class="countHuiFu">' + n.CommentInfo + '</span>';


                                            html += '</div>';
                                            html += '<span class="color" style="float:left; margin-left:20px;">' + n.CommentDate + '</span><br/>'
                                            libody += html
                                        });
                                        $(".ajaxHF").eq(index).append(libody);
                                        $('.HuiFBox').slideUp('slow', function () {//下滑完全结束时回调函数
                                            $('.TianChon').empty();
                                        });
                                    } else {

                                    }
                                }
                            });
                        }
                    })
                };
                //----------------滑动显示评论回复的效果----------------------//
                var save = $(this);
                save.click(function () {
                    if ($('.TianChon').eq(index).children('.HuiFBox').length > 0) {
                        $('.HuiFBox').slideUp('slow', function () {
                            $('.TianChon').empty();
                        });
                    } else {
                        if ($('.HuiFBox').length > 0) {
                            $('.HuiFBox').slideUp('slow', function () {
                                $('.TianChon').empty();
                                stre();
                            });
                        } else {
                            stre();
                        }
                    }
                })
            })
        }


        function ajaxload() {
            $.ajax({
                url: "HomeIndex.aspx",
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                data: {
                    action: "VideoComPage",
                    PageIndex: 1,
                    Mid: $.getUrlParam('mid'),
                    Cid: $.getUrlParam('CourseId')
                },
                success: function (resultData) {
                    if (resultData.STATUS == "SUCCESS") {
                        CPageName = resultData.PAGECOUNT;
                        if (resultData.PAGECOUNT != 0) {
                            var countPage = "<a class=\"CFirst\" href=\"javascript:void(0);\">上一页</a>";
                            if (resultData.PAGECOUNT > 10) {
                                for (i = 1; i <= 10; i++) {
                                    countPage += "<a  class=\"CpageID\" href=\"javascript:void(0);\">" + i + "</a>";
                                }
                            }
                            else {
                                for (i = 1; i <= resultData.PAGECOUNT; i++) {
                                    countPage += "<a class=\"CpageID\" href=\"javascript:void(0);\">" + i + "</a>";
                                }
                            }
                            countPage += "<a class=\"CNext\" href=\"javascript:void(0);\">下一页</a>";
                            $('.cpages').empty();
                            $('.cpages').append(countPage);

                            $(".CpageID").click(function () {
                                var pageIndex = $(this).text();
                                LoadData(pageIndex);
                            });

                            $(".CFirst").click(function () {
                                if ($(".CFirst").css("cursor") == "pointer") {
                                    var pageIndex = parseInt(CPageID) - 1;
                                    if (pageIndex == 0) {
                                        alert('当前已经是第一页了！');
                                        return false;
                                    }
                                    CPageID = parseInt(CPageID) - 1;
                                    LoadData(pageIndex);
                                }
                            });
                            $(".CNext").click(function () {
                                if ($(this).css("cursor") == "pointer") {
                                    var pageIndex = parseInt(CPageID) + 1;
                                    LoadData(pageIndex);
                                }
                            });
                        }
                    } else {

                    }
                }
            });
            LoadData(1);
        }

        function LoadData(pageIndex) {

            $.ajax({
                url: "HomeIndex.aspx",
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                data: {
                    action: "VideoCom",
                    PageIndex: pageIndex,
                    Mid: $.getUrlParam('mid'),
                    Cid: $.getUrlParam('CourseId')
                },
                success: function (PageData) {
                    if (PageData.STATUS == "SUCCESS") {
                        xunhuan(PageData.DATA, pageIndex);
                        HuiFu(); //评论信息
                    } else {
                        $("#divComm").html("暂无评论信息");
                    }
                }
            });
        }
    </script>
    
<link href="/css/videoCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" id="hfUid" runat="server"  />
<!-- start main -->
<div class="main">

<!-- start input0125 -->
<div class="input0125 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>已开课程</strong> > <strong>查看评论</strong></div>
<h2>查看评论</h2>
<div class="padding">
<div class="pinglun border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content" id='ComM'>
<h2 style="color:#3a568d; font-size:14px; font-family:微软雅黑; background:url(../imagesN/TLaoShi_border012.gif) no-repeat 0 5px; position:relative;left:20px;top:-8px;margin-bottom:-8px;width:177px; text-align:center;text-indent:0px;">此课程最新热门评论</h2>

<div id="divComm">
</div>
<div class="cpages" style="text-align:center;"></div>

</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
</div>


</div>
</div>
</div>
</div>
</div>
<!-- end input5 -->

</div>
<!-- end main -->
</asp:Content>
