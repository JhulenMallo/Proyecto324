<?php
include "conexion.inc.php";
session_start();
$sql="select * from flujoprocesoseguimiento ";
$sql.="where Usuario='".$_SESSION["Usuario"]."' ";
$sql.="and HoraFin is null ";
$resultado=mysqli_query($con, $sql);
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>INF324</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <link rel="stylesheet" href="styleslogin.css">
</head>
<body>
    <div class="container-md mx-5">
        <h1>Bienvenido
             <?php echo  $_SESSION["Usuario"] ?>
        </h1>
        <div class="row justify-content-md-center mx-5">
        <table class="table table-striped ">
            <tr>
            <td>Nro Tramite</td>
            <td>Tipo de Proceso</td>
            <td>Flujo</td>
            <td>Proceso</td>
            <td>Operacion</td>
            </tr>
            <?php 
            while ($fila=mysqli_fetch_array($resultado))
            {
            echo "<tr>";
            echo "<td>".$fila["NumeroTramite"]."</td>";
            if ($fila["Flujo"]=='F1')
                echo "<td>Proceso de Inscripcion</td>";
            else
                echo "<td>Proceso de Retiro y Adicion</td>";
            echo "<td>".$fila["Flujo"]."</td>";
            echo "<td>".$fila["Proceso"]."</td>";
            echo "<td><a href='principal.php?flujo=".$fila["Flujo"]."&proceso=".$fila["Proceso"]."'>Editar</a></td>";
            echo "</tr>";
            }
            ?>
        </table>
        </div>
    </div>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/js/bootstrap.bundle.min.js"></script>
</body>
</html>