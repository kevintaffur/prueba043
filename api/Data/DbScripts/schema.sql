create database prueba043;

use prueba043;

create table Usuarios (
	Id int primary key identity(1,1),
	Username varchar(20) not null,
	PasswordHash varchar(255) not null,
);

create table Publicaciones (
	Id int primary key identity(1,1),
	Titulo varchar(20) not null,
	Contenido varchar(100) not null,
	Fecha date not null,
	UsuarioId int not null,

	constraint productos_usuarios_fk foreign key(UsuarioId) references Usuarios(Id),
);

create table Comentarios (
	Id int primary key identity(1,1),
	Contenido varchar(100) not null,
	Fecha date not null,
	UsuarioId int not null,
	PublicacionId int not null,

	constraint productos_usuarios_fk foreign key(UsuarioId) references Usuarios(Id),
	constraint comentarios_publicaciones_fk foreign key(PublicacionId) references Comentarios(Id),
);

create table Seguidores (
	Id int primary key identity(1,1),
	UsuarioId int not null,
	SiguiendoId int not null,

	constraint seguidores_usuario_fk foreign key(UsuarioId) references Usuarios(Id),
	constraint seguidores_siguiendo_fk foreign key(SiguiendoId) references Usuarios(Id),
);


-- pg
-- Create the database
CREATE DATABASE prueba043;

-- Connect to the database
--c prueba043;

-- Create the Usuarios table
CREATE TABLE Usuarios (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(20) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL
);

-- Create the Publicaciones table
CREATE TABLE Publicaciones (
    Id SERIAL PRIMARY KEY,
    Titulo VARCHAR(20) NOT NULL,
    Contenido VARCHAR(100) NOT NULL,
    Fecha DATE NOT NULL,
    UsuarioId INT NOT NULL,
    CONSTRAINT publicaciones_usuarios_fk FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

-- Create the Comentarios table
CREATE TABLE Comentarios (
    Id SERIAL PRIMARY KEY,
    Contenido VARCHAR(100) NOT NULL,
    Fecha DATE NOT NULL,
    UsuarioId INT NOT NULL,
    PublicacionId INT NOT NULL,
    CONSTRAINT comentarios_usuarios_fk FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    CONSTRAINT comentarios_publicaciones_fk FOREIGN KEY (PublicacionId) REFERENCES Publicaciones(Id)
);

-- Create the Seguidores table
CREATE TABLE Seguidores (
    Id SERIAL PRIMARY KEY,
    UsuarioId INT NOT NULL,
    SiguiendoId INT NOT NULL,
    CONSTRAINT seguidores_usuario_fk FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    CONSTRAINT seguidores_siguiendo_fk FOREIGN KEY (SiguiendoId) REFERENCES Usuarios(Id)
);
