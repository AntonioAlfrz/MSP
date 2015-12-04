<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JustifyForm.aspx.cs" Inherits="MSPForm.JustifyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style>
    		    h1{
    			    text-align: center;
    		    }
    		    textarea{
    			    overflow: auto;
    		    }
                div{
                    text-align: center;
                }
        </style>
    </head>
    <body>
        <h1> Justifica un texto </h1> 
    	    <form id="form1" runat="server">
                <p> Texto: </p>
                <div>
                    <textarea runat="server" id="input" rows="10" cols="10" wrap="hard" placeholder="Introduce el texto a justificar."></textarea>
                </div>
    		    <br/>
                <input runat="server" id="button1" type="submit" value="Submit" OnServerClick="justifica"/>
            </form>
            <p id="texto" runat="server">Resultado</p>
    	    <footer>
    		    <p>Alumno: Antonio Julián  Alférez Zamora<br>
    			    Correo: aj.alferez@alumnos.upm.es <br>
    			    Fecha: <script type="text/javascript"> document.write(new Date()); </script>
    		    </p>
    	    </footer>
    </body>
</html>
