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
        x = ".edit-id:contains('" + x + "')";
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Comment/Create/',
            success: function(result){
            $(x).siblings('.comment-form').html(result);
            }   
        });
        alert(x);
    });
})