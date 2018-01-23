$(document).ready(function(){
    // displays form to add post
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

    // displays form to edit post
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

    // displays form to delete post
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

    // displays form to add a comment
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

    // toggles visibility of each post's comment section
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

    if(location.href.includes('Post') && !document.referrer.includes('Post')) {
        //$('#menu-blog').addClass('menu-blog-active');
        $('.menu-main').addClass('menu-inactive');
    } else if (location.href.includes('Post')){
        //$('#menu-blog').removeClass('menu-blog-active').addClass('menu-blog-standby');
        $('.menu-main').removeClass('menu-inactive').addClass('menu-standby');
    } else if (document.referrer != 'http://localhost:5000/'){
        $('.menu-main').remove('menu-standby').addClass('menu-active');
    };


})