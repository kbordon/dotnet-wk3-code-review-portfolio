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
    $('.toggle-comment').click(function(){
        if ($(this).siblings('.comments').css('display') !== 'none') 
        {
            $(this).siblings('.comments').css('display', 'none');
            $(this).find(".see-comment").css('display', 'inline');
            $(this).find(".hide-comment").css('display', 'none');
        }
        else
        {
            $(this).siblings('.comments').css('display', 'block');
            $(this).find(".see-comment").css('display', 'none');
            $(this).find(".hide-comment").css('display', 'inline');
        }
    });
})