create database products;
use products;
create table product(
idproducto int auto_increment primary key,
nombre varchar(30) not null,
codigo varchar(13) not null unique,
descripcion varchar(100) not null,
stock int unsigned not null, 
precio decimal(10,3) not null,
estado ENUM('Activo', 'Inactivo') DEFAULT 'Activo',
fecha_actualizacion DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
