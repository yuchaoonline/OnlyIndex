
$(function () {
    $(".studentContent,.cjwtContent").find("li").mouseover(function () {
        $(this).siblings().css("border", "1px solid #ccc");
        $(this).css("border", "1px solid #9E9B91");
    });

    var text_content = $('#txtContent');
    $('#selectContent').find('li').click(function () {
        var tmp_txt = text_content.val() + $(this).text() + "\n";
        text_content.val(tmp_txt);
    });

    $('#fBook').submit(function () {
        if ($("input[name=name]").val().trim() == "") { alert("请填写您的姓名！"); $("input[name=name]").focus(); return false; }
        if ($("input[name=tel]").val().trim() == "") { alert("请填写您的电话！"); $("input[name=tel]").focus(); return false; }
        if ($("input[type=radio]:checked").val() == undefined) { alert("请填写回访时间！");return false; }
        if ($("input[name=qq]").val().trim() == "") { alert("请填写您的QQ！"); $("input[name=qq]").focus(); return false; }
        if ($("input[name=address]").val().trim() == "") { alert("请填写您的地址！"); $("input[name=address]").focus(); return false; }
        if ($("textarea[name=content]").val().trim() == "") { alert("请填写您的留言内容！"); $("textarea[name=content]").focus(); return false; }


        $(this).ajaxSubmit(function () {
            alert("提交成功！");
            $("#fBook").resetForm();
            return false;
        });
        return false; //阻止表单默认提交  
    });



});





