;(function(){
    
    if ($("#DataCheck").prop("checked")) {
        $("#DateSearchInputContainer").slideToggle();
    }
    
    

    $("#DataCheck").click(function () {
        $("#DateSearchInputContainer").slideToggle();
    });

})();
