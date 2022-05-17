CREATE DATABASE Tutorias
GO

USE Tutorias
GO

CREATE TABLE Usuarios(
Id_Usuario INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[User] NVARCHAR(10) NOT NULL,
[Pass] NVARCHAR(MAX) NOT NULL,
[TIPO] NUMERIC NOT NULL,
Visibilidad BIT NOT NULL,
);
GO

create table Alumno(
Id_Alumno INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Usuario INT NOT NULL,
Nombre NVARCHAR(50) NOT NULL,
Apellido_Pat NVARCHAR(40) NOT NULL,
Apellido_Mat NVARCHAR(40) NOT NULL,
Correo NVARCHAR(30) NULL,
Grupo NVARCHAR(6) NOT NULL,
TUTORIA BIT NOT NULL,

CONSTRAINT fk_Usuario_Alumno FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO
CREATE TABLE AreaTutorias(
Id_Area INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Usuario INT NOT NULL,
NombreArea NVARCHAR(50) NOT NULL,
Administrador NVARCHAR(50) NOT NULL,
CONSTRAINT fk_Usuario_Admin FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO
create table Profesor(
Id_Profesor INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Usuario INT NOT NULL,
Nombre NVARCHAR(50) NOT NULL,
Apellido_Pat NVARCHAR(50) NOT NULL,
Apellido_Mat NVARCHAR(50) NOT NULL,
Correo NVARCHAR(50) NULL,	
Grupo NVARCHAR(6) NOT NULL,
HorasTotales INT NOT NULL,
HorasTutoria INT NOT NULL,
CONSTRAINT fk_Usuario_Profesor FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO


create table Inscripcion(
Id_Inscripcion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Id_Profesor INT NOT NULL,
Id_Alumno INT NOT NULL,
Fecha DATE NOT NULL,
Folio NVARCHAR(11) NOT NULL,
CONSTRAINT fk_Alumno FOREIGN KEY(Id_Alumno) REFERENCES Alumno(Id_Alumno),
CONSTRAINT fk_Profesor FOREIGN KEY(Id_Profesor) REFERENCES Profesor(Id_Profesor)
);
GO

SELECT * FROM Alumno

SELECT * FROM Profesor

SELECT * FROM Usuarios

SELECT * FROM Inscripcion

SELECT A.Id_Alumno, A.Nombre, A.Apellido_Pat, A.Apellido_Mat, U.[User],U.[Pass]
FROM Usuarios as U
INNER JOIN Alumno as A
ON U.Id_Usuario = A.Id_Usuario;

--SELECT al.Nombre, al.Apellido_Mat, al.Apellido_Mat
--FROM Inscripcion AS i
--INNER JOIN Alumno AS al
--ON al.Id_Alumno = i.Id_Alumno WHERE i.Id_Profesor = 5
