$(document).ready(function(){
    $('#comment-create').submit(function(event){
        var currentUrl = window.location.href;
        if(currentUrl.toString().includes('Entry')){
            event.preventDefault();
            $.ajax({
                url: '/Comment/CreateFromEntry',
                type: 'POST',
                // does it need to return anything?
                dataType: 'html',
                data: $(this).serialize(),
                success: function(result) {
                    location.reload();

                }
            });
        };
    });

     // exit modal
    $('.exit').click(function(){
        if($("#form").length)
        {
          $('#form').css("display", "none");
        }
        else
        {
            $(this).parents('div.comment-form').css("display", "none");
        }
    });
});