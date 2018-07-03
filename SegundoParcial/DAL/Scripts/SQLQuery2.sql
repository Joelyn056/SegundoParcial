CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
GO
CREATE TABLE Vehiculo
(
   VehiculoId int primary key,
   Descripcion varchar(150),
   Mantenimiento decimal
);

sp_columms Vehiculo;

insert into Vehiculo(VehiculoId, Descripcion, Mantenimiento)values('1','Toyota Corrolla 2005 LE',0);

insert into Vehiculo(VehiculoId, Descripcion, Mantenimiento)values('2','Honda CRV 2015 touring',0);

select *from Vehiculo

