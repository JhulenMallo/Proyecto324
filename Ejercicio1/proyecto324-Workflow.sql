create table FlujoProceso					
(
	Flujo varchar(3),
	Proceso varchar(3),
	ProcesoSiguiente varchar(5),
	Tipo varchar(1),
	Pantalla varchar(20),
	Rol varchar(20)
);

insert into FlujoProceso values('F1','P1','P2','I','Inicio','Alumno');
insert into FlujoProceso values('F1','P2','P3','P','PresentarDocumentos','Alumno');
insert into FlujoProceso values('F1','P3',null,'C','AlDia','Kardex');
insert into FlujoProceso values('F1','P4','P11','p','CausaNegativa','Kardex');
insert into FlujoProceso values('F1','P5','p6','P','AnotaenSistema','Kardex');
insert into FlujoProceso values('F1','P6','p7','P','ElegirCarrera','Alumno');
insert into FlujoProceso values('F1','P7','p8','P','SolicitaCodigo','Alumno');
insert into FlujoProceso values('F1','P8','p9','P','CompraCarnet','Caja');
insert into FlujoProceso values('F1','P9','p10','P','AnotarenListas','Kardex');
insert into FlujoProceso values('F1','P10','P11','P','AveriguarHorarios','Alumno');
insert into FlujoProceso values('F1','P11',null,'F','CerrarInsc','Kardex');

insert into FlujoProceso values('F2','P1','P2','P','InicioRetyAdi','Alumno');
insert into FlujoProceso values('F2','P2','p3','P','Habilitar','Kardex');
insert into FlujoProceso values('F2','P3','P4','P','RetiraroAdicionar','Alumno');
insert into FlujoProceso values('F2','P4','P5','P','VerificaEleccion','Comite');
insert into FlujoProceso values('F2','P5',null,'F','CerrarRetyAdi','Kardex');

-- averigua fechas para retiro y adicion -> kardex habilita retiro y adi -> retira o adiciona -> 

create table FlujoProcesoCondicionante
(			
	Flujo varchar(3),
	Proceso varchar(3),
	ProcesoSI varchar(3),
	ProcesoNO varchar(3)
);

insert into FlujoProcesoCondicionante values('F1','P3','P4','P5');


CREATE TABLE Usuario
(
	id int,
    usuario varchar(20),
    password varchar(20)
);

insert into Usuario values(1, 'Jhulen', '123456');
insert into Usuario values(2, 'Kardex1', '123456');
insert into Usuario values(3, 'Kardex2', '123456');
insert into Usuario values(4, 'Alumno1', '123456');
insert into Usuario values(5, 'Alumno2', '123456');
insert into Usuario values(6, 'Caja', '123456');

CREATE TABLE Rol
(
	id int,
    rol varchar(20)
);
insert into Rol values(1, 'Alumno');
insert into Rol values(2, 'Kardex');
insert into Rol values(3, 'Caja');

CREATE TABLE RolUsuario
(
	IdUsuario varchar(20),
	IdRol int
);

insert into RolUsuario values(1, 1);
insert into RolUsuario values(2, 2);
insert into RolUsuario values(3, 2);
insert into RolUsuario values(4, 1);
insert into RolUsuario values(5, 1);
insert into RolUsuario values(6, 3);

CREATE TABLE FlujoProcesoSeguimiento
(
    Flujo varchar(3),
    Proceso varchar(3),	
    NumeroTramite varchar(4),
    Usuario varchar(20),
    FechInicio DATE,
    HoraInicio TIME,
    FechaFin DATE,
    HoraFin TIME
);

insert into FlujoProcesoSeguimiento values('F1','P1','1000','Jhulen','2022/04/20','10:00:00','2022/04/20','14:00:00');
insert into FlujoProcesoSeguimiento values('F1','P2','1000','Jhulen','2022/04/20','14:01:00','2022/04/22','10:00:00');
insert into FlujoProcesoSeguimiento values('F1','P3','1000','Jhulen','2022/04/22','10:01:00',null,null);
insert into FlujoProcesoSeguimiento values('F1','P1','2020','Alumno1','2022/04/20','10:10:00','2022/04/21','11:10:00');
insert into FlujoProcesoSeguimiento values('F1','P2','2020','Alumno1','2022/04/21','11:11:00',null,null);
insert into FlujoProcesoSeguimiento values('F1','P1','1010','Kardex1','2022/04/11','09:00:00','2022/04/11','09:10:00');
insert into FlujoProcesoSeguimiento values('F1','P2','10','Kardex2','2022/04/11','09:11:00',null,null);
insert into FlujoProcesoSeguimiento values('F1','P8','102','Caja','2022/04/11','09:11:00',null,null);
insert into FlujoProcesoSeguimiento values('F2','P1','1777','Alumno1','2022/04/20','10:00:00',null,null);
insert into FlujoProcesoSeguimiento values('F2','P2','1778','Alumno2','2022/04/20','14:01:00',null,null);