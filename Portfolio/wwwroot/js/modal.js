$(document).ready(function(){
// exit modal
    $('.exit').click(function(){
        if($('#form').length)
        {
            $('#form').css("display", "none"); 
        }
        $(this).parents('div.comment-form').css("display", "none"); 
    });
})
 