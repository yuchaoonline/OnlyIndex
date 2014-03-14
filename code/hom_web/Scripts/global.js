var jj;

//获取文章标题和内容简介
var indexListTC = function (obj, url, target) {
    $.getJSON(url, function (json) {
        jj = json;
        if (json.status == 200) {
            $('#' + target).html(json.content);
        }
    })
}

//获取菜单
var Menu = function (obj, url, target) {
    $.getJSON(url, function (json) {
        if (json.status == 200) {
            $("#" + target).html(json.content);
        }
    })
}