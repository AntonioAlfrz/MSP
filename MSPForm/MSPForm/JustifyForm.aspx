<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JustifyForm.aspx.cs" Inherits="MSPForm.JustifyForm" %>

<!DOCTYPE html>

<html>
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
                   
                     border: 0;
                     background-color: #cccccc;
                     padding:20px;
                               width:30%;
                max-width:600px;
                height:200px;
                
                margin:20px;
    		    }
             ::-moz-selection  {
                background-color: #444444;
                color:white;
            }
                textarea:focus{
                      outline-color: #353535;
                     outline-style: solid;
                     outline-width: 1px;
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
                border-radius:20px;
                padding:10px;
                display:inline-block;
      
            }

            #galeri {
                display:inline-block;
                width:100%;
            }
            #texto {
                display: inline-block;
            }

            footer {
                font-variant:small-caps;
            }
            .inputtext {
                outline:none;
                padding:3px;
                border:0;
                background-color: #cccccc;
                margin:10px;
            }


input[type=number] {
    -moz-appearance:textfield;
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
                    </div>
    		        <br />
                    <label for="cols">Introduzca el número de columnas</label><br />
                    <input type="number" class="inputtext" placeholder="5" name="cols"/><br />

                <input runat="server" id="button1" type="submit" value="Justificar ✓"/>
            </form>
           
    	    <footer>
    		    <p>Alumno: Antonio Alférez<br>
    			    Correo: aj.alferez@outlook.com <br>
    		    </p>
    	    </footer>
    </body>
</html>
