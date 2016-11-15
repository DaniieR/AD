<<<<<<< HEAD
create table categoria (
  id bigint auto_increment primary key,
  nombre varchar(50) not null unique
);

insert into categoria (nombre) values ('categoría 1');
insert into categoria (nombre) values ('categoría 2');
insert into categoria (nombre) values ('categoría 3');

create table articulo (
  id bigint auto_increment primary key,
  nombre varchar(50) not null unique,
  precio decimal(10,2),
  categoria bigint
);

alter table articulo add foreign key (categoria) 
  references categoria (id);

insert into articulo (nombre, precio, categoria) values ('artículo 1', 1, 1);
insert into articulo (nombre, precio, categoria) values ('artículo 2', 2, 2);
insert into articulo (nombre, precio) values ('artículo 3', 3);
insert into articulo (nombre) values ('artículo 4');

=======
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
>>>>>>> 7efccaf48b7ec54963797cd75834b9891da0dac6
