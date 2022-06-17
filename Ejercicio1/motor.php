<?php
include "conexion.inc.php";
session_start();
$pregunta=$_GET["pregunta"];
$flujo=$_GET["flujo"];
$proceso=$_GET["procesoanterior"]; //p2 traendo p1
$procesosiguiente=$_GET["proceso"]; //p1 traendo p2
$sql="select * from flujoproceso ";
$sql.="where Flujo='$flujo' and Proceso='$proceso'";
$resultado=mysqli_query($con, $sql);
$fila=mysqli_fetch_array($resultado);
$pantalla=$fila['Pantalla'];
$pantalla.=".motor.inc.php";
include $pantalla;


if ((($proceso == 'P11' && $flujo == 'F1') || ($proceso == 'P5' && $flujo == 'F2')) && !isset($_GET["Anterior"])) {
	$sql="select * from flujoproceso where Flujo='".$flujo."' and Proceso='".$proceso."'";

	$resultado2=mysqli_query($con, $sql);
	$fila2=mysqli_fetch_array($resultado2);
	$procesosiguiente = $fila2["ProcesoSiguiente"];
	if($procesosiguiente == null)
		header("Location: login.php");
}
else
{
	if (isset($_GET["Anterior"]))
	{
		$sql="select * from flujoproceso ";
		$sql.="where Flujo='$flujo' and ProcesoSiguiente='$proceso'";
		$resultado1=mysqli_query($con, $sql);
		$fila1=mysqli_fetch_array($resultado1);
		$procesosiguiente=$fila1["Proceso"];
		if($proceso != "P1")
			header("Location: principal.php?flujo=$flujo&proceso=$procesosiguiente"."&funcion=1");
		else
			header("Location: principal.php?flujo=$flujo&proceso=$proceso"."&funcion=2");
	}
	else{
		$sql="select * from flujoproceso where Flujo='".$flujo."' and Proceso='".$proceso."'";
		$resultado=mysqli_query($con, $sql);
		$fila=mysqli_fetch_array($resultado);
		$procesosiguiente=$fila["ProcesoSiguiente"];
		if ($procesosiguiente==NULL && $fila["Tipo"]=='C')
		{
			$sql="select * from flujoprocesocondicionante where Flujo='".$flujo."' and Proceso='".$proceso."'";
			$resultado2=mysqli_query($con, $sql);
			$fila2=mysqli_fetch_array($resultado2);
			if ($pregunta=='Si')
				$procesosiguiente=$fila2["ProcesoSI"];
			else{
				if ($pregunta=='No')
					$procesosiguiente=$fila2["ProcesoNO"];
				else
					header("Location: principal.php?flujo=".$flujo."&proceso=".$fila2['Proceso']."&funcion=".$pregunta);
			} 
				
		}
		header("Location: principal.php?flujo=".$flujo."&proceso=".$procesosiguiente."&funcion=3");
	}
}

?>