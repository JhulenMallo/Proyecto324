<?php
session_start();
include "conexion.inc.php";
$flujo=$_GET["flujo"];
$proceso=$_GET["proceso"];
$sql="select * from flujoproceso ";
$sql.="where Flujo='$flujo' and Proceso='$proceso'";
$resultado=mysqli_query($con, $sql);
$fila=mysqli_fetch_array($resultado);
$pantalla=$fila['Pantalla'];
$pantalla.=".inc.php";
$pantallalogica=$fila['Pantalla'];
$pantallalogica.=".main.inc.php";
$procesoanterior=$proceso;
$proceso=$fila['ProcesoSiguiente'];


?>
<html>
	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<title>Workflow</title>
		<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
	</head>
<body>
	<form class="" action="motor.php" method="GET">
		<!--iframe src="pantalla.php"></iframe-->
		<input type="hidden" name="flujo" value="<?php echo $flujo;?>"/>
		<input type="hidden" name="proceso" value="<?php echo $proceso;?>"/>
		<input type="hidden" name="procesoanterior" value="<?php echo $procesoanterior;?>"/>
		<div class="card text-center">
			<div class="card-header">
				<h1>
				<?php
					include $pantallalogica;
				?>
				</h1>
			</div>
			<div class="card-body" style="max-height: 620px;">
				<?php
					include $pantalla;
				?>
				<br>
				<input class="btn btn-primary px-5" type="submit" name="Anterior" value="Anterior"/>
				<input class="btn btn-primary px-5" type="submit" name="Siguiente" value="Siguiente"/>
			</div>
			
		</div>
		
	</form>
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>