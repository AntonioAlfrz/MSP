<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JustifyForm.aspx.cs" Inherits="MSPForm.JustifyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style>
            * {

                font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            }
    		    h1{
    			    text-align: center;
    		    }
    		    textarea{
    			    overflow: auto;
                     resize:none;
                     outline:none;
                     border: 0;
                     background-color: #cccccc;
                     padding:20px;
                               width:30%;
                max-width:600px;
                height:40%;
                max-height: 500px;
    		    }
                div{
                    text-align: center;
                }

            #form1 {
                text-align:center;
            }

            #button1 {

                color:white;
                background-color:#444444;
                outline:none;
                border:0;
                border-radius:16px;
                padding:5px;
                display:inline-block;
      
            }

            #galeri {
                display:inline-block;
                width:100%;
            }
            #texto {
                display: inline-block;
            }

            
        </style>
    </head>
    <body>
        <h1> Justifica un texto </h1> 
    	    <form id="form1" runat="server">
                <p> Texto: </p>
                <div id="galeri">
                    <textarea runat="server" id="input"  wrap="hard" placeholder="Introduce el texto a justificar."></textarea>
                
                    <textarea runat="server" id="resultado" wrap="hard" placeholder="Resultado."></textarea>
                    <!-- <p id="texto" runat="server">Resultado</p></div><br>-->
    		        <br />
                
                <input runat="server" id="button1" type="submit" value="Submit"/>
            </form>
           
    	    <footer>
    		    <p>Alumno: Antonio Julián  Alférez Zamora<br>
    			    Correo: aj.alferez@alumnos.upm.es <br>
    			    Fecha: <script type="text/javascript"> document.write(new Date()); </script>
    		    </p>
    	    </footer>
    </body>
</html>
