<?php 
include "conexion.inc.php";
$usuario = $_GET["usuario"];
$password = $_GET["password"];
$sql="select * from usuario where usuario='".$usuario;
$sql.="' and password='".$password."'";
$resultado = mysqli_query($con, $sql);
$fila = mysqli_fetch_array($resultado);

if ($fila["usuario"] == $usuario and $fila["password"] == $password and $fila["usuario"] != "")
{ 
    session_destroy();
    session_start();
    
    $_SESSION["Usuario"] = $usuario;
    header("Location: bandeja.php?usuario=".$usuario);
}
else
    header("Location: login.php");

?>