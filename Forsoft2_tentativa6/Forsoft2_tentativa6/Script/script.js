function validaInfo() { 
    if (document.formulario.usuario.value == "") {
       document.formulario.usuario.focus();
       document.formulario.usuario.style.borderColor="#3DA2F4";
       document.getElementById("msg_erro").style.visibility = "visible";      
       return false;
    }else{
        document.formulario.usuario.style.borderColor="transparent";
        document.getElementById("msg_erro").style.visibility = "hidden"; 
    }
    
    if (document.formulario.senha.value == ""){
        document.formulario.senha.focus();
        document.formulario.senha.style.borderColor="#2570E6";
        document.getElementById("msg_erro").style.visibility = "visible"; 
        return false;
    }else{
        document.formulario.usuario.style.borderColor="transparent";
    }
}

//function validainfo2(){
//    if ($('label[for="input-usuario"]').val() == "") {
//        this.focus();
//        this.style.borderColor = "#3DA2F4";
//        $("#msg_erro").style.visibility = "visible";
//    } if($('label[id="email"]'))
//}
$.validator.setDefaults({
    debug: true,
    success: "valid"
});
$("#formulario").validate({
    rules: {
        email: {
            required: true,
            email: true
        },
        inputusuario: {
            required: true
        }
    }
});

function setarVisibilidade(){
    //$("#modal").style.visibility = 'visible';
    document.getElementById("modal").style.visibility = "hidden";
	console.log("foi");
}





