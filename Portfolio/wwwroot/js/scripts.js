$(document).ready(function)(){
    $('#create').click(function(){
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '',
            success: function(result){
            $('#create-form').html(result);
            }   
        });
    });
}  