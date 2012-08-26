/**
* $itemname$.js
*
* 功 能： [N/A]
*
* Ver    变更日期                            负责人  变更内容
* ───────────────────────────────────
* V0.01 2012年6月28日 10:12:02  Rock    初版
*
* Copyright (c) $year$ Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
//CharMode函数测试某个字符是属于哪一类. 
function CharMode(iN) {
    if (iN >= 48 && iN <= 57) //数字 
        return 1;
    if (iN >= 65 && iN <= 90) //大写字母 
        return 2;
    if (iN >= 97 && iN <= 122) //小写 
        return 4;
    else
        return 8; //特殊字符 
}
//bitTotal函数计算出当前密码当中一共有多少种模式 
function bitTotal(num) {
    modes = 0;
    for (i = 0; i < 4; i++) {
        if (num & 1) modes++;
        num >>>= 1;
    }
    return modes;
}
//checkStrong函数返回密码的强度级别 
function checkStrong(sPW) {
    if (sPW.length <= 4)
        return 0; //密码太短 
    Modes = 0;
    for (i = 0; i < sPW.length; i++) {
        //测试每一个字符的类别并统计一共有多少种模式. 
        Modes |= CharMode(sPW.charCodeAt(i));
    }
    return bitTotal(Modes);
}
//pwStrength函数
function pwStrength(pwd) {
    O_color = "#EEEFF4";
    L_color = "#ffe658";
    M_color = "#FF9900";
    H_color = "#33CC00";
    if (pwd == null || pwd == '') {
        Lcolor = Mcolor = Hcolor = O_color;
    }
    else {
        S_level = checkStrong(pwd);
        switch (S_level) {
            case 0:
                Lcolor = Mcolor = Hcolor = O_color;
            case 1:
                Lcolor = L_color;
                Mcolor = Hcolor = O_color;
                break;
            case 2:
                Lcolor = Mcolor = M_color;
                Hcolor = O_color;
                break;
            default:
                Lcolor = Mcolor = Hcolor = H_color;
        }
    }
    document.getElementById("strength_L").style.background = Lcolor;
    document.getElementById("strength_M").style.background = Mcolor;
    document.getElementById("strength_H").style.background = Hcolor;
    return;
} 