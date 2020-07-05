USE master

GO

IF EXISTS(SELECT * FROM SysDataBases WHERE name='ProyectoSegundo2019')
BEGIN
	DROP DATABASE ProyectoSegundo2019
END

GO

CREATE DATABASE ProyectoSegundo2019

GO

USE ProyectoSegundo2019

CREATE TABLE Usuario (
	documento INT NOT NULL PRIMARY KEY,
	contrasena VARCHAR(6) NOT NULL CHECK (contrasena LIKE '[a-zA-Z][a-zA-Z][a-zA-Z][0-9][0-9][|°¬¿?¡!"#$%&/\()=@´`¨+-*~{}^_<>,;.:]'),
	nombreCompleto VARCHAR(50) NOT NULL check (rtrim(ltrim(nombreCompleto)) <> '')
)

--INSERT INTO Usuario VALUES(2234, 'agX33@', 'Ejemplo')

CREATE TABLE Empleado (
	documento INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Usuario(documento),
	horaInicio TIME(0) NOT NULL check (rtrim(ltrim(horaInicio)) <> ''),
	horaFin TIME(0) NOT NULL check (rtrim(ltrim(horaFin)) <> '')
)
	
CREATE TABLE Solicitante(
	documento INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Usuario(documento),
	telefono INT NOT NULL check(telefono > 0)
)
	
create table EmpleadoHorasExtra (
	documento INT not null foreign key references Empleado(documento),
	fecha DATE not NULL DEFAULT GETDATE(),
	minutosExtra INT not null check (minutosExtra >= 1),
    primary key (documento, fecha)
)

CREATE TABLE Documentacion (
	codigoInterno INT NOT NULL PRIMARY KEY,
	nomDocumentacion VARCHAR(50) NOT NULL check (rtrim(ltrim(nomDocumentacion)) <> ''),
	lugar VARCHAR(50) NOT NULL check (rtrim(ltrim(lugar)) <> ''),
	activo BIT NOT NULL DEFAULT 1
)

CREATE TABLE Tramite (
	codigoTramite VARCHAR(9) NOT NULL PRIMARY KEY CHECK (codigoTramite LIKE '[0-9][0-9][0-9][0-9][a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z]'),
	nombreTramite VARCHAR(50) NOT NULL check (rtrim(ltrim(nombreTramite)) <> ''),
	descripcion VARCHAR(80) NOT NULL check (rtrim(ltrim(descripcion)) <> ''),
	precio decimal NOT NULL check (precio > 0),
	activo BIT NOT NULL DEFAULT 1
)
	
CREATE TABLE Solicitud (
	numero INT NOT NULL PRIMARY KEY IDENTITY,
	estado VARCHAR(20) NOT NULL DEFAULT 'alta' CHECK(estado = 'alta' OR estado = 'ejecutada' OR estado = 'anulada'),
	fechaHora DATETIME NOT NULL check (DAY(fechaHora) >= DAY(GETDATE())),
	docSolicitante INT NOT NULL FOREIGN KEY REFERENCES Solicitante(documento),
	codTramite VARCHAR(9) NOT NULL FOREIGN KEY REFERENCES Tramite(codigoTramite),
)

CREATE TABLE Exigen (
	codTramite VARCHAR(9) NOT NULL FOREIGN KEY REFERENCES Tramite(codigoTramite),
	codDocumentacion INT NOT NULL FOREIGN KEY REFERENCES Documentacion(codigoInterno)
	PRIMARY KEY (codTramite, codDocumentacion)
)

GO

insert into Tramite values ('1034geros', 'tramite ', 'descripcion', 150.00, 1);
insert into Tramite values ('1035geros', 'tramite  2', 'descripcion', 150.00, 1);
insert into Tramite values ('1036geros', 'tramite  3', 'descripcion', 150.00, 1);
insert into Tramite values ('1037geros', 'tramite  4', 'descripcion', 150.00, 1);

insert into Documentacion values (1, 'cedula', 'registro civil', 1);

insert into Exigen values ('1034geros', 1);
insert into Exigen values ('1035geros', 1);
insert into Exigen values ('1036geros', 1);
insert into Exigen values ('1037geros', 1);

select * from Usuario;
select * from Empleado;
select * from Solicitud;
select * from Documentacion;
select * from Tramite;
select * from Solicitante;
exec AltaSolicitante 46813407, 'AAA22?', 'Gabriel Bermudez', 091651452;
exec AltaSolicitante 464532133, 'AAA22?', 'Geronimo somma', 091654252;
exec AltaSolicitante 8685490, 'AAA22?', 'Geronimo somma', 091654252;

DECLARE @fecha DATETIME 
set @fecha = GETDATE();
exec AltaSolicitud 'alta', @fecha, 8685490, '1037geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1036geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1035geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1034geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1034geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1034geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1036geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1037geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1037geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1034geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1034geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1036geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1037geros';
exec AltaSolicitud 'alta', @fecha, 8685490, '1037geros';

select * from Solicitud
-------------SP Empleado-----------
--use ProyectoSegundo2019;
EXEC AltaEmpleado 99, 'AAA22?', 'Empleado', '14:00', '22:00';
EXEC AltaEmpleado 4645321, 'AAA22?', 'Luis Fagundez', '00:00', '02:30';
SELECT * FROM Solicitante
go
CREATE PROCEDURE AltaEmpleado
@documento VARCHAR(50),
@contrasena VARCHAR(6),
@nombreCompleto VARCHAR(50),
@horaInicio TIME(0),
@horaFin TIME(0)
AS
BEGIN
	IF EXISTS (SELECT * FROM Usuario WHERE documento = @documento)
	BEGIN
		RETURN -1
	END

	BEGIN TRANSACTION;
	INSERT INTO Usuario VALUES (@documento, @contrasena, @nombreCompleto)
	IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN -2
		END
	INSERT INTO Empleado VALUES (@documento, @horaInicio, @horaFin)
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION;
		RETURN -3
	END

	DECLARE @VarSentencia VARCHAR(200)
	SET @VarSentencia = 'CREATE LOGIN [' + convert(varchar(MAX),@documento) + '] WITH PASSWORD = ' + QUOTENAME(@contrasena, '''')
	EXEC (@VarSentencia)
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION;
		RETURN -4
	END
	
	DECLARE @VarSentencia2 VARCHAR(200)
	SET @VarSentencia2 = 'Create User [' + convert(varchar(MAX),@documento) + '] From Login [' + convert(varchar(MAX),@documento) + ']'
	EXEC (@VarSentencia2)
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION;
		RETURN -5
	END
	COMMIT TRANSACTION;

	EXEC sp_addsrvrolemember @loginame=@documento, @rolename='securityadmin'	
	IF (@@ERROR <> 0)
		RETURN -6

	EXEC sp_addrolemember @rolename='db_accessadmin', @membername=@documento
	IF (@@ERROR <> 0)
		RETURN -7
	
	EXEC sp_addrolemember @rolename='db_securityadmin', @membername=@documento
	IF (@@ERROR <> 0)
		RETURN -8
		
		
	EXEC sp_addrolemember @rolename='db_owner', @membername=@documento
	IF (@@ERROR <> 0)
		RETURN -10
	
	EXEC sp_addrolemember @rolename='db_rol_empleado' , @membername=@documento
	IF (@@ERROR <> 0)
		RETURN -9
	
END

GO

CREATE PROCEDURE BuscarEmpleado
@documento INT
AS
BEGIN
	SELECT Usuario.*, Empleado.horaInicio, Empleado.horaFin
	FROM Usuario INNER JOIN Empleado
	ON Usuario.documento = Empleado.documento
	WHERE Usuario.documento = @documento
END

GO

CREATE PROCEDURE ModificarEmpleado
@documento INT,
@contrasena VARCHAR(6),
@nombreCompleto VARCHAR(50),
@horaInicio TIME,
@horaFin TIME
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE documento = @documento)
	BEGIN
		RETURN -1
	END

	BEGIN TRANSACTION;
		UPDATE Usuario
		SET nombreCompleto = @nombreCompleto, contrasena = @contrasena
		WHERE documento = @documento
		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN -2
		END
		UPDATE Empleado
		SET horaInicio = @horaInicio, horaFin = @horaFin
		WHERE documento = @documento
		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN -3
		END
	COMMIT TRANSACTION;
	
	DECLARE @VarSentencia VARCHAR(50);
	SET @VarSentencia = 'EXEC sp_PASSWORD NULL, [' + @contrasena + '], ' + convert(varchar(MAX),@documento) + ';'
	EXEC (@VarSentencia)
	IF (@@ERROR <>0)
		RETURN -8
		
END
	
GO

CREATE PROCEDURE BajaEmpleado
@documento INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE documento = @documento)
	BEGIN
		RETURN -1
	END

	BEGIN TRANSACTION;
	IF EXISTS (SELECT * FROM EmpleadoHorasExtra WHERE documento = @documento)
	BEGIN
		DELETE FROM EmpleadoHorasExtra
		WHERE documento = @documento
		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN -6
		END
	END
	
	DELETE FROM Empleado
	WHERE documento = @documento
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION;
		RETURN -2
	END
	DELETE FROM Usuario
	WHERE documento = @documento
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION;
		RETURN -3
	END

	DECLARE @VarSentencia VARCHAR(200)
	SET @VarSentencia = 'REVOKE EXECUTE TO [' + convert(varchar(MAX),@documento) + ']'
	EXEC (@VarSentencia)
	IF (@@ERROR <> 0)
	BEGIN
	    ROLLBACK TRANSACTION;
		RETURN -6
	END
	
    SET @VarSentencia = 'DROP USER [' + convert(varchar(MAX),@documento) + ']'
    EXEC (@VarSentencia)
	IF (@@ERROR <> 0)
	BEGIN
	   ROLLBACK TRANSACTION;
       RETURN -4
    END
    
    SET @VarSentencia = 'DROP LOGIN [' + convert(varchar(MAX),@documento) + ']'
    EXEC (@VarSentencia)
	IF (@@ERROR <> 0)
	BEGIN
	   ROLLBACK TRANSACTION;
       RETURN -5
    END
	
	COMMIT TRANSACTION;
END

GO

-----------SP Solicitante-----------
CREATE PROCEDURE AltaSolicitante
@documento INT,
@contrasena VARCHAR(6),
@nombreCompleto VARCHAR(50),
@telefono INT
AS
BEGIN
	IF EXISTS (SELECT * FROM Solicitante WHERE documento = @documento)
	BEGIN
		RETURN -1
	END

	BEGIN TRANSACTION 
	INSERT INTO Usuario VALUES (@documento, @contrasena, @nombreCompleto)
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RETURN -2
	END
	INSERT INTO Solicitante VALUES (@documento, @telefono)
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RETURN -3
	END

	DECLARE @VarSentencia VARCHAR(200)
	SET @VarSentencia = 'CREATE LOGIN [' + convert(varchar(MAX),@documento) + '] WITH PASSWORD = ' + QUOTENAME(@contrasena, '''')
	EXEC (@VarSentencia)
	IF (@@ERROR <> 0)
	begin
		ROLLBACK TRANSACTION
		RETURN -4
	end
	
	DECLARE @VarSentencia2 VARCHAR(200)
	SET @VarSentencia2 = 'Create User [' + convert(varchar(MAX),@documento) + '] From Login [' + convert(varchar(MAX),@documento) + ']'
	EXEC (@VarSentencia2)
	IF (@@ERROR <> 0)
	begin
		ROLLBACK TRANSACTION
		RETURN -6
	end	

	COMMIT TRANSACTION	

	DECLARE @VarSentencia3 VARCHAR(200)
	SET @VarSentencia3 = 'EXEC sp_addrolemember [db_rol_solicitante] , [' + convert(varchar(MAX),@documento) + '];'
	EXEC (@VarSentencia3)
	IF (@@ERROR <> 0)
	BEGIN	
		RETURN -8
	END
END

GO

CREATE PROCEDURE BuscarSolicitante
@documento INT
AS
BEGIN
	SELECT Usuario.*, Solicitante.documento, Solicitante.telefono
	FROM Usuario INNER JOIN Solicitante
	ON Usuario.documento = Solicitante.documento
	WHERE Usuario.documento = @documento
END

GO

-----------SP Documentacion-----------
CREATE PROCEDURE AltaDocumentacion
@codigoInterno INT,
@nomDocumentacion VARCHAR(50),
@lugar VARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT * FROM Documentacion WHERE codigoInterno = @codigoInterno AND activo = 1)
	BEGIN
		RETURN -1
	END

	IF EXISTS (SELECT * FROM Documentacion WHERE codigoInterno = @codigoInterno AND activo = 0)
	BEGIN
		UPDATE Documentacion
		SET activo = 1, 
			nomDocumentacion = @nomDocumentacion,
			lugar = @lugar 
		WHERE codigoInterno = @codigoInterno
	END
	ELSE
	BEGIN
		INSERT INTO Documentacion VALUES (@codigoInterno, @nomDocumentacion, @lugar, 1)
		IF (@@ERROR <> 0)
			RETURN -2
	END
END;

GO

CREATE PROCEDURE BuscarDocumentacion
@codigoInterno INT
AS
BEGIN
	SELECT * 
	FROM Documentacion 
	WHERE codigoInterno = @codigoInterno AND activo = 1
END

GO


CREATE PROCEDURE BuscarDocumentacionAux
@codigoInterno INT
AS
BEGIN
	SELECT * 
	FROM Documentacion 
	WHERE codigoInterno = @codigoInterno
END

GO

exec BuscarDocumentacionAux 1;


GO

CREATE PROCEDURE ModificarDocumentacion
@codigoInterno INT,
@nomDocumentacion VARCHAR(50),
@lugar VARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Documentacion WHERE codigoInterno = @codigoInterno AND activo = 1)
		BEGIN
			RETURN -1
		END

	UPDATE Documentacion
	SET nomDocumentacion = @nomDocumentacion, lugar = @lugar
	WHERE codigoInterno = @codigoInterno
	IF (@@ERROR <> 0)
		RETURN -2
END

GO

CREATE PROCEDURE BajaDocumentacion
@codigoInterno INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Documentacion WHERE codigoInterno = @codigoInterno)
		BEGIN
			RETURN -1
		END
	IF EXISTS (SELECT * FROM Exigen WHERE codDocumentacion = @codigoInterno)
		BEGIN
			UPDATE Documentacion SET activo = 0 WHERE codigoInterno = @codigoInterno
			IF (@@ERROR <> 0)
			BEGIN
				RETURN -2
			END
		END
	ELSE
		BEGIN
			DELETE FROM Documentacion WHERE codigoInterno = @codigoInterno
			IF (@@ERROR <> 0)
			BEGIN
				RETURN -3
			END
		END
END

GO

-----------SP Tramite-----------
ALTER PROCEDURE AltaTramite 
@codigoTramite VARCHAR(9),
@nombreTramite VARCHAR(50),
@descripcion VARCHAR(80),
@precio decimal
AS
BEGIN
	IF EXISTS (SELECT * FROM Tramite WHERE codigoTramite = @codigoTramite AND activo = 1)
	BEGIN
		RETURN -1
	END

	IF EXISTS (SELECT * FROM Tramite WHERE codigoTramite = @codigoTramite AND activo = 0)
	BEGIN
		UPDATE Tramite
		SET activo = 1, 
			nombreTramite = @nombreTramite, 
			descripcion = @descripcion,
			precio = @precio
		WHERE codigoTramite = @codigoTramite
	END
	ELSE
	BEGIN
		INSERT INTO Tramite VALUES (@codigoTramite, @nombreTramite, @descripcion, @precio, 1)
		IF (@@ERROR <> 0)
			RETURN -2
	END
END

GO

CREATE PROCEDURE BuscarTramite
@codigoTramite VARCHAR(9)
AS
BEGIN
	SELECT *
	FROM Tramite t
	WHERE t.activo = 1 AND t.codigoTramite = @codigoTramite
END

GO

CREATE PROCEDURE BuscarTramiteAux
@codigoTramite VARCHAR(9)
AS
BEGIN
	SELECT *
	FROM Tramite t
	WHERE t.codigoTramite = @codigoTramite
END



exec BuscarTramiteAux '1035geros';
exec BuscarDocumentacionTramite '1034geros';
exec BuscarDocumentacion 1;
GO

CREATE PROCEDURE BuscarDocumentacionTramite
@codigoTramite varchar(9)
AS
BEGIN
	SELECT *
	FROM Exigen
	WHERE codTramite = @codigoTramite
END

GO

CREATE PROCEDURE ModificarTramite
@codigoTramite VARCHAR(9),
@nombreTramite VARCHAR(50),
@descripcion VARCHAR(80),
@precio decimal
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Tramite WHERE codigoTramite = @codigoTramite AND activo = 1)
	BEGIN
		RETURN -1
	END

	UPDATE Tramite
	SET nombreTramite = @nombreTramite, descripcion = @descripcion, precio = @precio
	WHERE codigoTramite = @codigoTramite
	IF (@@ERROR <> 0)
		RETURN -2
END

GO

alter PROCEDURE BajaTramite
@codigoTramite VARCHAR(9)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Tramite WHERE codigoTramite = @codigoTramite)
	BEGIN
		RETURN -1
	END
	IF EXISTS (SELECT * FROM Solicitud WHERE codTramite = @codigoTramite)
	BEGIN
		UPDATE Tramite SET activo = 0 WHERE codigoTramite = @codigoTramite
		IF (@@ERROR <> 0)
		BEGIN
			RETURN -2
		END
	END
	ELSE
	BEGIN
		BEGIN TRANSACTION
		DELETE FROM Exigen where codTramite = @codigoTramite	
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -3
				END
		DELETE FROM Tramite WHERE codigoTramite = @codigoTramite
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -4
				END
		COMMIT TRANSACTION
	END
END

GO

-----------SP Solicitud-----------
CREATE PROCEDURE AltaSolicitud
@estado VARCHAR(20),
@fechaHora DATETIME,
@docSolicitante INT,
@codTramite VARCHAR(9)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Solicitante WHERE documento = @docSolicitante)
	BEGIN
		RETURN -1
	END
		
	IF NOT EXISTS (SELECT * FROM Tramite WHERE codigoTramite = @codTramite AND activo = 1)
	BEGIN
		RETURN -2
	END
				 
	INSERT INTO Solicitud VALUES (@estado, @fechaHora, @docSolicitante, @codTramite)
	IF (@@ERROR <> 0)
		RETURN -3

	RETURN @@IDENTITY
END

GO

create PROCEDURE AltaHoraExtra
@documentoEmpleado int,
@fecha DATE,
@minutosExtra INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE documento = @documentoEmpleado)
	BEGIN
		RETURN -1
	END
	
	IF EXISTS (SELECT * FROM EmpleadoHorasExtra WHERE documento = @documentoEmpleado AND CAST(fecha as DATE) = CAST(@fecha as DATE))
	BEGIN
		UPDATE EmpleadoHorasExtra 
		SET minutosExtra = @minutosExtra
		WHERE documento = @documentoEmpleado AND CAST(fecha as DATE) = CAST(@fecha as DATE);
		IF (@@ERROR <> 0)
			RETURN -2

	END
	ELSE
	BEGIN
		INSERT INTO EmpleadoHorasExtra VALUES (@documentoEmpleado, @fecha, @minutosExtra);
		IF (@@ERROR <> 0)
			RETURN -3

	END
END

GO

CREATE PROCEDURE ListadoDocumentacion
AS
BEGIN 
	SELECT * FROM Documentacion WHERE activo = 1
END
go
EXEC ListadoDocumentacion;
GO

CREATE PROCEDURE ListadoTramites
AS
BEGIN 
	SELECT *
	FROM Tramite t
	WHERE t.activo = 1
END

GO

CREATE PROCEDURE ListadoSolicitudes
AS
BEGIN
	SELECT Solicitud.*, Tramite.*, Solicitante.*, Usuario.*
	FROM Tramite INNER JOIN Solicitud
	ON Tramite.codigoTramite = Solicitud.codTramite INNER JOIN Solicitante
	ON Solicitud.docSolicitante = Solicitante.documento INNER JOIN Usuario
	ON Solicitante.documento = Usuario.documento
	WHERE YEAR(Solicitud.fechaHora) = YEAR(GETDATE()) AND Solicitud.estado = 'alta'
END

go
CREATE PROCEDURE ListadoSolicitudess
AS
BEGIN
	SELECT *
	FROM Solicitud
	WHERE YEAR(fechaHora) = YEAR(GETDATE())
END

GO

CREATE PROCEDURE CambioEstadoSolicitud
@numero int,
@accion int                                  
AS
BEGIN
	DECLARE @estado varchar(20)
	IF EXISTS (SELECT * FROM Solicitud WHERE numero = @numero)
	BEGIN
		SELECT @estado = estado FROM Solicitud WHERE numero = @numero
		IF @estado = 'alta'
		BEGIN
			IF (@accion = 1)
			BEGIN
				UPDATE Solicitud
				SET estado = 'ejecutada'
				WHERE numero = @numero
				IF @@ERROR <> 0
					RETURN -1
			END
			ELSE IF (@accion = 2)
			BEGIN 
				UPDATE Solicitud
				SET estado = 'anulada'
				WHERE numero = @numero
				IF @@ERROR <> 0
					RETURN -1
			END
		END
		ELSE
		BEGIN
			RETURN -3
		END
	END
END

GO

CREATE PROCEDURE BuscarSolicitud
@numero int 
AS
BEGIN
	SELECT s.* 
	FROM Solicitud s 
	WHERE S.numero = @numero
END

GO

-----------SP Exigen-----------
CREATE PROCEDURE AltaExigen
@codTramite VARCHAR(9),
@codDocumentacion INT
AS
BEGIN
	INSERT INTO Exigen VALUES(@codTramite, @codDocumentacion)
	IF (@@ERROR <> 0)
		RETURN -1
END

GO

CREATE PROCEDURE BajaExigen
@codTramite VARCHAR(9)
AS
BEGIN
	DELETE FROM Exigen WHERE codTramite = @codTramite
	IF (@@ERROR <> 0)
		RETURN -2
END


--roles
--go
go
USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS WITH DEFAULT_DATABASE = master
GO

USE ProyectoSegundo2019
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

GRANT Execute to [IIS APPPOOL\DefaultAppPool]
--go
EXEC master..sp_addsrvrolemember @loginame = N'IIS APPPOOL\DefaultAppPool', @rolename = N'securityadmin'
GO
USE [ProyectoSegundo2019]
GO
EXEC sp_addrolemember N'db_owner', N'IIS APPPOOL\DefaultAppPool'
GO
USE [ProyectoSegundo2019]
GO
EXEC sp_addrolemember N'db_accessadmin', N'IIS APPPOOL\DefaultAppPool'
GO
USE [ProyectoSegundo2019]
GO
EXEC sp_addrolemember N'db_securityadmin', N'IIS APPPOOL\DefaultAppPool'
GO

EXEC sp_addrolemember[db_rol_solicitante], [IIS APPPOOL\DefaultAppPool]


create ROLE db_rol_empleado
CREATE ROLE db_rol_solicitante

GRANT EXECUTE ON dbo.AltaEmpleado TO [db_rol_empleado]
GRANT EXECUTE ON dbo.AltaDocumentacion TO [db_rol_empleado]
GRANT EXECUTE ON dbo.AltaExigen TO [db_rol_empleado]
GRANT EXECUTE ON dbo.AltaHoraExtra TO [db_rol_empleado]
GRANT EXECUTE ON dbo.AltaSolicitante TO [db_rol_solicitante]
GRANT EXECUTE ON dbo.AltaSolicitud TO [db_rol_solicitante]
GRANT EXECUTE ON dbo.AltaTramite TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BajaDocumentacion TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BajaEmpleado TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BajaExigen TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BajaTramite TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarDocumentacion TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarDocumentacionAux TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarDocumentacionTramite TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarEmpleado TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarSolicitante TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarEmpleado TO [db_rol_solicitante]
GRANT EXECUTE ON dbo.BuscarSolicitante TO [db_rol_solicitante]
GRANT EXECUTE ON dbo.BuscarSolicitud TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarSolicitud TO [db_rol_solicitante]
GRANT EXECUTE ON dbo.BuscarTramite TO [db_rol_empleado]
GRANT EXECUTE ON dbo.BuscarTramite TO [db_rol_solicitante]
GRANT EXECUTE ON dbo.BuscarTramiteAux TO [db_rol_empleado]
GRANT EXECUTE ON dbo.CambioEstadoSolicitud TO [db_rol_empleado]
GRANT EXECUTE ON dbo.ListadoDocumentacion TO [db_rol_empleado]
GRANT EXECUTE ON dbo.ListadoSolicitudes TO [db_rol_empleado]
GRANT EXECUTE ON dbo.ListadoTramites TO [db_rol_empleado]
GRANT EXECUTE ON dbo.ModificarDocumentacion TO [db_rol_empleado]
GRANT EXECUTE ON dbo.ModificarEmpleado TO [db_rol_empleado]
GRANT EXECUTE ON dbo.ModificarTramite TO [db_rol_empleado]



--GO

--CREATE PROCEDURE ListarHorasExtras
--AS
--BEGIN
--	SELECT u.*, e.horaInicio, e.horaFin, x.fecha, x.minutosExtra
--	FROM EmpleadoHorasExtra x INNER JOIN Empleado e	
--		ON x.documento = e.documento INNER JOIN Usuario u
--			ON e.documento = u.documento
--END

--GO

--exec ListarHorasExtras;

----====================================SENTENCIASSSSSS========================================|||||||||||||||||||||||||||||||||||||||||||||



--exec CambioEstadoSolicitud 4;

--DECLARE @RC int
--DECLARE @documentoEmpleado int
--DECLARE @fecha datetime
--DECLARE @minutosExtra int

--SET @documentoEmpleado = 46453213
--SET @fecha = GETDATE()
--SET @minutosExtra = 15

--EXECUTE @RC = [ProyectoSegundo2019].[dbo].[AltaHoraExtra] 
--   @documentoEmpleado
--  ,@fecha
--  ,@minutosExtra
--GO


--exec ListadoSolicitudes 4645321;
--EXEC ListadoTramites;
--GO
--exec AltaSolicitante 4645321, '123456', 'Geronimo Somma', 091654252;
--exec AltaSolicitud 'Alta', 13012020, 46453213, '123';

--INSERT INTO Solicitud (fechaHora, docSolicitante, codTramite)
--VALUES (GETDATE(), 4645321, '123')

--exec AltaTramite '123', 'Certificado de Domicilio', 'certificado emitido en jefatura que certifica la direccion de un individuo.', 250;




--exec ListadoDocumentacion;

--go
--EXEC AltaEmpleado 46453213, '123456', 'Geronimo Somma', '24:00', '06:00'
--GO
--DECLARE @RC int
--DECLARE @documento int
--DECLARE @contrasena varchar(6)
--DECLARE @nombreCompleto varchar(50)
--DECLARE @horaInicio varchar(5)
--DECLARE @horaFin varchar(5)

--set @documento = 46453213
--set @contrasena = '123456'
--set @nombreCompleto = 'Geronimo Somma'
--set @horaInicio = '24:00'
--set @horaFin = '06:00'

--EXECUTE @RC = [ProyectoSegundo2019].[dbo].[AltaEmpleado] 
--   @documento
--  ,@contrasena
--  ,@nombreCompleto
--  ,@horaInicio
--  ,@horaFin
--select @RC
--GO


--====================================SENTENCIASSSSSS=======================================|||||||||||||||||||||||||||||||||||||||||||||