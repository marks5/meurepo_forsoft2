function validaInfo() { 
    if (document.formulario.usuario.value == "") {
       document.formulario.usuario.focus();
       document.formulario.usuario.style.borderColor="#ff0000";
       document.getElementById("msg_erro").style.visibility = "visible";      
       return false;
    }else{
        document.formulario.usuario.style.borderColor="transparent";
        document.getElementById("msg_erro").style.visibility = "hidden"; 
    }
    
    if (document.formulario.senha.value == ""){
        document.formulario.senha.focus();
        document.formulario.senha.style.borderColor="#ff0000";
        document.getElementById("msg_erro").style.visibility = "visible"; 
        return false;
    }else{
        document.formulario.usuario.style.borderColor="transparent";
    }
}
