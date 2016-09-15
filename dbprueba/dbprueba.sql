CREATE TABLE categoria (
    id bigint AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) NOT null UNIQUE
    );

insert into categoria (nombre) values ('Categoria 1');
insert into categoria (nombre) values ('Categoria 2');
insert into categoria (nombre) values ('Categoria 3');
insert into categoria (nombre) values ('Categoria 4');
