BASE DE DATOS

create database Veterinaria;
use Veterinaria
CREATE TABLE contacto(
id int identity not NULL ,
nombre varchar(80) not null,
direccion varchar(80),
email varchar(80) not null,
telefono int null,
ciudad varchar(100)not null,
mensaje varchar(300) null,
);
select * from contacto
