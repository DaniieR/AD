CREATE TABLE categoria (
    id bigint AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) NOT null UNIQUE
    );

insert into categoria (nombre) values ('Categoria 1');
insert into categoria (nombre) values ('Categoria 2');
insert into categoria (nombre) values ('Categoria 3');
insert into categoria (nombre) values ('Categoria 4');

CREATE TABLE articulo (
	id bigint auto_increment PRIMARY KEY,
	nombre varchar (50) NOT null UNIQUE,
	precio decimal (10,2),
	categoria bigint
);

ALTER TABLE articulo ADD foreign key (categoria) references categoria (id);

insert into articulo (nombre,precio,categoria) values ('articulo 1', 1,1);
insert into articulo (nombre,precio,categoria) values ('articulo 2', 2,2);
insert into articulo (nombre,precio) values ('articulo 3', 3,3);
insert into articulo (nombre) values ('articulo 4');
