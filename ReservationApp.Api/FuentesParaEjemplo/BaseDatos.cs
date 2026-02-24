namespace ReservationApp.Api.FuentesParaEjemplo
{
    public class BaseDatos
    {
        /*
          
          CREATE DATABASE CitasMedicasDB;

USE CitasMedicasDB;


CREATE TABLE Usuarios
(
    Id INT IDENTITY PRIMARY KEY,
    Usuario VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL
);

INSERT INTO Usuarios (Usuario, Password)
VALUES 
('admin', 'admin123'),
('doctor', 'doctor123');


CREATE TABLE Reservas
(
    Id INT IDENTITY PRIMARY KEY,
    Paciente VARCHAR(100) NOT NULL,
    Medico VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Fecha DATE NOT NULL,
    FechaCreacion DATETIME NOT NULL
);


INSERT INTO Reservas
(Paciente, Medico, Especialidad, Fecha, FechaCreacion)
VALUES
('Ana Pérez', 'Dr. Gómez', 'Cardiología', DATEADD(DAY, 1, GETDATE()), GETDATE()),
('Luis Mora', 'Dra. Vargas', 'Dermatología', DATEADD(DAY, 2, GETDATE()), GETDATE());

          
         */
    }
}
