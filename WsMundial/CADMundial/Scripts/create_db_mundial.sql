create database Mundial;
go
use Mundial;

create table Grupo(
Codigo varchar(1) not null primary key,
NombreGrupo varchar (50) not null unique
);
go
create table Equipo(
IdEqupo smallint not null identity primary key,
Codigo varchar(1) not null foreign key references Grupo (Codigo) on delete cascade,
Nombre varchar(150) not null 
);

go 
