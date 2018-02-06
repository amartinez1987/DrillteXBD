<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ProyectoMolde.Forms.Usuarios.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Inicio Sesi&oacute;n</title>

    <!-- Bootstrap Core CSS -->
    <link href="../../bootstrapLibrerias/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">        

    <!-- MetisMenu CSS -->
    <link href="../../bootstrapLibrerias/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">          

    <!-- Custom CSS -->
    <link href="../../bootstrapLibrerias/dist/css/sb-admin-2.min.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../../bootstrapLibrerias/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">    

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body>    
    <form id="form1" runat="server">
         
        <div class="container">
            
            
           
        <div   id="boxMessages"  class="row" style="position:absolute; text-align:left; left:70%">
        </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form" id="frmLogin">
                            <fieldset>
                                <div class="form-group">
                                    <input id="nombreUsuario" onblur="" class="form-control" placeholder="E-mail" name="nombreUsuario" type="email" autofocus>
                                </div>
                                <div class="form-group">
                                    <input id="clave" class="form-control" placeholder="Password" name="clave" type="password" value="">
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" value="Remember Me">Recordar Contraseña
                                    </label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <div id="btnIngresar" class="btn btn-lg btn-success btn-block">Login</div>
                                <br />
                                <a id="btnRegistrace" class="glyphicon glyphicon-list " href="frmRegistrarse.aspx"><label> Registrarse</label> </a>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
            
        </div>
            
    </div>

    </form>
     <!-- jQuery -->
    <script src="../../bootstrapLibrerias/vendor/jquery/jquery.min.js"></script>
    

    <!-- Bootstrap Core JavaScript -->
    <script src="../../bootstrapLibrerias/vendor/bootstrap/js/bootstrap.min.js"></script>        

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../../bootstrapLibrerias/vendor/metisMenu/metisMenu.min.js"></script>        

    <!-- Custom Theme JavaScript -->
    <script src="../../bootstrapLibrerias/dist/js/sb-admin-2.min.js"></script>
    
    <!-- FunctionsJs -->    
    <script src="../../Js/configAjax.js"></script> 

    <script src="../../Js/cajasTexto.js"></script>

    <script src="../../Js/login.js"></script>      
</body>
</html>
