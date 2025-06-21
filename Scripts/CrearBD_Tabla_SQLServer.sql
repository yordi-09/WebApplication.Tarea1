--Crear la Base de datos en SQL Server
CREATE DATABASE Tarea1_Yordi

--Crear la tabla
USE Tarea1_Yordi
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL
);