$(document).ready(function(){
    console.log(window.location.href);
    console.log("from " + document.referrer);

    if (window.location.href === "http://localhost:5000/Account/Login" && document.referrer === "http://localhost:5000/Post")
    {

    }


    // Get starred projects if the div isn't already displayed.
    $('#menu-works').click(function(){
        if(($('#home-projects').css('height') === '0px' || $('#home-projects').css('width') === '0px') && $('#home-projects').length)
        {
            alert("this hasn't been opened yet.");
            $.ajax({
                type: 'GET',
                dataType: 'html',
                url: '/Home/GetProjects',
                success: function(result){
                    $('#home-projects').html(result);
                }
            });
        }
        else
        {
            // Testing conditional.
            //alert("this is the height: " + $('#home-projects').css('height') + " this is the width : " + $('#home-projects').css('height')); 
        }
    });

    // on log-in failure page, to show register modal.
    $('#register').click(function(){
        if(!$('#form-log').length){
            $.ajax({
                type: 'GET',
                dataType: 'html',
                url: '/Account/Register',
                success: function(result){
                    $('#register-form').html(result); 
                    $('.modal-form').first().css('display', 'none');
                }
            });
        };
     });


    // displays form to log in on the blog page.
    $('#log-in').click(function(){
        $('#form-log').css("display", "flex");
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Account/Login',
            success: function(result){
            $('#form-log').html(result);
            }
        });
    });

    // exit modal. if on the failed log-in page. Other wise, on blog page.
    $('.exit').click(function(){
        if(!$('#form-log').length){
            $('.modal-form').last().css('display', 'none');
            $('.modal-form').first().css('display', 'none');
        } else {
            $('#form-log').css("display", "none");
        }
    });

    // displays form to add post
    $('#create').click(function(){        
        $('#form').css("display", "flex");
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
        $('#form').css("display", "flex");
        var x = $(this).parent().parent().find(".edit-id").text();  
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Post/Edit/' + x,
            success: function(result){
            $('#form').html(result);
            }
        });
    });

    // displays form to delete post
    $('.delete').click(function(){
        $('#form').css("display", "flex");
        var x = $(this).parent().parent().find(".edit-id").text();
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
        var x = $(this).parent().parent().find(".edit-id").text();
        var y = ".edit-id:contains('" + x + "')";
        if ($('.post-bottom').length)
        {
           $.ajax({
                type: 'GET',
                dataType: 'html',
                url: '/Comment/Create/' + x, 
                success: function(result){
                 $('#form').html(result);
                 $('#form').css("display", "flex");
                //$(y).siblings('.post-bottom').find('.comment-form').html(result);
                //$(y).siblings('.post-bottom').find('.comment-form').css('display', 'flex'); 
                }
            }); 
        }
        else
        {
            $.ajax({                 type: 'GET',                 dataType: 'html',                 url: '/Comment/Create/' + x,                 success: function(result){                 $(y).siblings('.comment-form').html(result);                 $(y).siblings('.comment-form').css("display", "flex");                 }             });
        }

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

    //controls menu animation
    // when going to blog section
    if(location.href.includes('Post') && !document.referrer.includes('Post')) {
        //$('#menu-blog').addClass('menu-blog-active');
        $('.menu-main').addClass('menu-inactive');
    } else if (location.href.includes('Post')){ // when still in the blog section
        //$('#menu-blog').removeClass('menu-blog-active').addClass('menu-blog-standby');
        $('.menu-main').removeClass('menu-inactive').addClass('menu-standby');
    } else if (!location.href.includes('Post') && !document.referrer.includes('Post')) { // when reloading homepage
        $('menu-main').addClass('menu-standby');
    } else if (document.referrer != 'http://localhost:5000/'){ // returning to main menu
        $('.menu-main').remove('menu-standby').addClass('menu-active');
    };

})