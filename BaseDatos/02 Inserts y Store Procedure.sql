-- Insertar primeros valores Persona
INSERT INTO Persona (
	Nombre, ApellidoP, ApellidoM, Correoe
)
VALUES 
	('Juan', 'González', 'López', 'correo1@prueba.mx'),
	('María', 'Martínez', 'Hernández', 'correo2@prueba.mx'),
	('Carlos', 'García', 'Pérez', 'correo3@prueba.mx')


SELECT * FROM persona

-- Insertar primeros valores Examen
INSERT INTO Examen (
	Descripcion
)
VALUES 
('Matemáticas'),
('Física'),
('Química')

SELECT * FROM examen

-- Insertar primeros valores EvalXPersona
INSERT INTO EvalXPersona (
IdExamen, IdPersona, FecAsignacion
)
VALUES
(1,1, '2023-01-15'),
(1,2, '2023-01-11'),
(2,2, '2023-01-16'),
(2,3, '2023-01-22'),
(3,2, '2023-01-25'),
(3,3, '2023-02-08')


SELECT *
FROM evalxpersona

-- Store Procedure ListaPersona
CREATE PROCEDURE ListaPersona
AS
BEGIN
    SELECT * FROM Persona
END

EXEC ListaPersona

-- Store Procedure ListaExamen
CREATE PROCEDURE ListaExamen
AS
BEGIN
    SELECT * FROM Examen
END

-- Store Procedure ListaPersonaXEval
CREATE PROCEDURE ListaPersonaXEval
    @examenId INT
AS
BEGIN
    SELECT p.*
    FROM Persona p
    INNER JOIN EvalXPersona ep ON p.IdPersona = ep.IdPersona
    WHERE ep.IdExamen = @examenId
END

-- Llamando al procedimiento almacenado ListaPersonaXEval con un valor específico para el parámetro @examenId
EXEC ListaPersonaXEval 1


-- Store Procedure AsignarExamenAPersona
CREATE PROCEDURE AsignarExamenAPersona
    @examenId INT,
    @personaId INT,
    @fechaAsignacion DATE
AS
BEGIN
    INSERT INTO EvalXPersona (IdExamen, IdPersona, FecAsignacion)
    VALUES (@examenId, @personaId, @fechaAsignacion)
END

-- Llamando al procedimiento almacenado AsignarExamenAPersona con valores específicos
EXEC AsignarExamenAPersona @examenId = 2, @personaId = 2, @fechaAsignacion = '2023-01-18';

-- Store Procedure BuscarPersonaPorCorreo

CREATE PROCEDURE BuscarPersonaPorCorreo
    @correo VARCHAR(25)
AS
BEGIN
    SELECT *
    FROM Persona
    WHERE Correoe = @correo;
END

-- Llamar al procedimiento BuscarPersonaPorCorreo

EXEC BuscarPersonaPorCorreo 'correo2@prueba.mx'

