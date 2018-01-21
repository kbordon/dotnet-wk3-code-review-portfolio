$(document).ready(function(){
    $('#create').click(function(){
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Post/Create',
            success: function(result){
            $('#form').html(result);
            }   
        });
    });
    $('.edit').click(function(){
        var x = $(this).parent().find(".edit-id").text();
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Post/Edit/' + x,
            success: function(result){
            $('#form').html(result);
            }
        });
            alert(x);   
    });
    $('.delete').click(function(){
        var x = $(this).parent().find(".edit-id").text();
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Post/Delete/' + x,
            success: function(result){
            $('#form').html(result);
            }   
        });
    });
    $('.comment-add').click(function(){
        var x = $(this).parent().find(".edit-id").text();
        var y = ".edit-id:contains('" + x + "')";
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Comment/Create/' + x,
            success: function(result){
            $(y).siblings('.comment-form').html(result);
            }
        });
    });
    $('.see-comment').click(function(){
        var x = $(this).parent().find(".edit-id").text();
        var y = ".edit-id:contains('" + x + "')";
        var z = $(this).text();
        if ($(y).parent().find(".comments").is(':visible')) {
            $(y).parent().find(".comments").css("display", "none");
            $(this).text("Hide Comments");
        } else {
            $(y).parent().find(".comments").css("display", "block");
            $(this).css("background-color", "pink");
            $(this).text(z);

        }
        alert(z);
    });
})