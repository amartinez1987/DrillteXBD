<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProyectoMolde.WebMethods.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body 
        {
            background-color:#D7D3D3;
        }

     #bordesTb
     {
        border: 2px solid #e9e9e9;
        border-radius: 10px;
        font-size:20px;
         background-color:  #F8F9FA;
     }
       #Titulo
     {
        background-color:  #31a9ff;
        color:#FBFBFD;
        border-radius: 5px;
     }

    </style>
</head>
<body>
    <form id="form1" runat="server">   
          <table id="bordesTb" style="width:40%;"   >
        <tr>
            <td colspan=2 id="Titulo" align="center">Bienvenido</td>
        </tr>
        <tr>
          <td colspan=2 align="">Los siguientes datos son para activar su usuario:</td>
        </tr>
        <tr>
            <td>Usuario</td>
            <td>Clave</td>            
        </tr>
       <tr>
         <td>{0}</td>
         <td>{1}</td>
        </tr>
    </table>
    </form>
   
</body>
</html>
