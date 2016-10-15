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

function setarVisibilidade(){
	document.getElementById("modal").style.visibility = "hidden";
	console.log("foi");
}




