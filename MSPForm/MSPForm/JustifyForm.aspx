<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JustifyForm.aspx.cs" Inherits="MSPForm.JustifyForm" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Justify</title>
    <link href="estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Justifica un texto </h1>
    <form id="form1" runat="server">
        <p>Escriba un texto e indique el máximo número de caracteres por fila (distingue diptongos, triptongos, hiatos, ...) </p>
        <div id="galeria">
            <textarea runat="server" id="input" wrap="hard" placeholder="Introduce el texto a justificar."></textarea>
            <textarea runat="server" id="resultado" wrap="hard" placeholder="Resultado."></textarea>
        </div>
        <br />
        <label for="cols">Introduzca el número de caracteres </label><br />
        <input type="number" class="inputtext" placeholder="10" name="cols" /><br />

        <input runat="server" id="button1" type="submit" value="Justificar ✓" />
    </form>
    <footer>
        <p>
            Alumno: Antonio Alférez
            <br>
            Correo: aj.alferez@outlook.com
            <br>
        </p>
    </footer>
</body>
</html>
