-- Crear Base de Datos
CREATE DATABASE ExamenPersona

-- Asignación DB para trabajar
USE ExamenPersona

-- Crear Tabla Persona
CREATE TABLE Persona (
    IdPersona INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    ApellidoP VARCHAR(50),
    ApellidoM VARCHAR(50),
    Correoe VARCHAR(25)
);

-- Crear Tabla Examen
CREATE TABLE Examen (
    IdExamen INT PRIMARY KEY IDENTITY,
    Descripcion VARCHAR(20)
);

-- Crear Tabla EvalXPersona
CREATE TABLE EvalXPersona (
    IdEvalXPersona INT PRIMARY KEY IDENTITY,
    IdExamen INT,
    IdPersona INT,
    FecAsignacion DATE,
    FOREIGN KEY (IdExamen) REFERENCES Examen(IdExamen),
    FOREIGN KEY (IdPersona) REFERENCES Persona(IdPersona)
);

