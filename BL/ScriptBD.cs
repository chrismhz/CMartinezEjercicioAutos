using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ScriptBD
    {
        /*
         
         Aqui se concentra el query para la realiacion de esta base de datos en base a este proyecto: 

        CREATE TABLE Marca (
            IdMarca INT PRIMARY KEY,
            Nombre VARCHAR(50) NOT NULL
        );

        CREATE TABLE Modelo (
            IdModelo INT PRIMARY KEY,
            Nombre VARCHAR(50) NOT NULL,
            IdMarca INT,
            FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca)
        );

        CREATE TABLE Version (
            IdVersion INT PRIMARY KEY,
            Nombre VARCHAR(50) NOT NULL,
            IdModelo INT,
            FOREIGN KEY (IdModelo) REFERENCES Modelo(IdModelo)
        );

        CREATE TABLE Autos (
            IdAuto INT PRIMARY KEY IDENTITY,
            Año INT NOT NULL,
            Color VARCHAR(50),
            Kilometraje INT,
            NumeroPuertas INT,
            Transmisión VARCHAR(20),
            Combustible VARCHAR(20),
            Precio DECIMAL(10, 2),
            IdMarca INT,
            IdModelo INT,
            IdVersion INT,
            FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca),
            FOREIGN KEY (IdModelo) REFERENCES Modelo(IdModelo),
            FOREIGN KEY (IdVersion) REFERENCES Version(IdVersion)
        );

         
         INSERT INTO Marca  VALUES (1, 'Toyota');
            INSERT INTO Marca  VALUES (2, 'Honda');
            INSERT INTO Marca  VALUES (3, 'Ford');
            INSERT INTO Marca  VALUES (4, 'Chevrolet');
            INSERT INTO Marca  VALUES (5, 'Volkswagen');
            INSERT INTO Marca  VALUES (6, 'Nissan');
            INSERT INTO Marca  VALUES (7, 'Hyundai');
            INSERT INTO Marca  VALUES (8, 'Kia');
            INSERT INTO Marca  VALUES (9, 'BMW');
            INSERT INTO Marca  VALUES (10, 'Mercedes-Benz');

            INSERT INTO Modelo VALUES (1, 'Corolla', 1);
            INSERT INTO Modelo VALUES (2, 'Camry', 1);
            INSERT INTO Modelo VALUES (3, 'Civic', 2);
            INSERT INTO Modelo VALUES (4, 'Accord', 2);
            INSERT INTO Modelo VALUES (5, 'Mustang', 3);
            INSERT INTO Modelo VALUES (6, 'Fusion', 3);
            INSERT INTO Modelo VALUES (7, 'Cruze', 4);
            INSERT INTO Modelo VALUES (8, 'Malibu', 4);
            INSERT INTO Modelo VALUES (9, 'Jetta', 5);
            INSERT INTO Modelo VALUES (10, 'Passat', 5);
            INSERT INTO Modelo VALUES (11, 'Sentra', 6);
            INSERT INTO Modelo VALUES (12, 'Altima', 6);
            INSERT INTO Modelo VALUES (13, 'Elantra', 7);
            INSERT INTO Modelo VALUES (14, 'Sonata', 7);
            INSERT INTO Modelo VALUES (15, 'Forte', 8);
            INSERT INTO Modelo VALUES (16, 'Optima', 8);
            INSERT INTO Modelo VALUES (17, '3 Series', 9);
            INSERT INTO Modelo VALUES (18, '5 Series', 9);
            INSERT INTO Modelo VALUES (19,'C-Class', 10);
            INSERT INTO Modelo VALUES (20, 'E-Class', 10);

            INSERT INTO Version  VALUES (1, 'SE', 1);
            INSERT INTO Version  VALUES (2, 'XSE', 1);
            INSERT INTO Version  VALUES (3, 'LE', 2);
            INSERT INTO Version  VALUES (4, 'XLE', 2);
            INSERT INTO Version  VALUES (5, 'LX', 3);
            INSERT INTO Version  VALUES (6, 'EX', 3);
            INSERT INTO Version  VALUES (7, 'Sport', 4);
            INSERT INTO Version  VALUES (8, 'Touring', 4);
            INSERT INTO Version  VALUES (9, 'EcoBoost', 5);
            INSERT INTO Version  VALUES (10, 'GT', 5);
            INSERT INTO Version  VALUES (11, 'SE', 6);
            INSERT INTO Version  VALUES (12, 'Titanium', 6);
            INSERT INTO Version  VALUES (13, 'LS', 7);
            INSERT INTO Version  VALUES (14, 'Premier', 7);
            INSERT INTO Version  VALUES (15, 'LT', 8);
            INSERT INTO Version  VALUES (16, 'Premier', 8);
            INSERT INTO Version  VALUES (17, 'S', 9);
            INSERT INTO Version  VALUES (18, 'SEL', 9);
            INSERT INTO Version  VALUES (19, 'Wolfsburg', 10);
            INSERT INTO Version  VALUES (20, 'SE', 10);
            INSERT INTO Version  VALUES (21, 'S', 11);
            INSERT INTO Version  VALUES (22, 'SV', 11);
            INSERT INTO Version  VALUES (23, 'SR', 12);
            INSERT INTO Version  VALUES (24, 'Platinum', 12);
            INSERT INTO Version  VALUES (25, 'SE', 13);
            INSERT INTO Version  VALUES (26, 'Limited', 13);
            INSERT INTO Version  VALUES (27, 'SEL', 14);
            INSERT INTO Version  VALUES (28, 'Limited', 14);
            INSERT INTO Version  VALUES (29, 'LX', 15);
            INSERT INTO Version  VALUES (30, 'EX', 15);
            INSERT INTO Version  VALUES (31, 'LX', 16);
            INSERT INTO Version  VALUES (32, 'SX', 16);
            INSERT INTO Version  VALUES (33, '330i', 17);
            INSERT INTO Version  VALUES (34, 'M340i', 17);
            INSERT INTO Version  VALUES (35, '530i', 18);
            INSERT INTO Version  VALUES (36, '540i', 18);
            INSERT INTO Version  VALUES (37, 'C300', 19);
            INSERT INTO Version  VALUES (38, 'AMG C43', 19);
            INSERT INTO Version  VALUES (39, 'E350', 20);
            INSERT INTO Version  VALUES (40, 'AMG E63', 20);

            SELECT * FROM Autos;

            INSERT INTO Autos VALUES (2022, 'Rojo', 15000, 4, 'Automática', 'Gasolina', 20000, 1, 1, 1);


            CREATE PROCEDURE GetAllAutos
            AS
            BEGIN
                SELECT Autos.IdAuto, 
		               Autos.Año,
		               Autos.Color,
		               Autos.Kilometraje,
		               Autos.NumeroPuertas,
		               Autos.Transmisión,
		               Autos.Combustible,
		               Autos.Precio,
		               Marca.Nombre AS MarcaNombre,
		               Modelo.Nombre AS ModeloNombre,
		               Version.Nombre AS VersionNombre
                FROM Autos
	            INNER JOIN Marca ON Autos.IdMarca = Marca.IdMarca
                INNER JOIN Modelo ON Autos.IdModelo = Modelo.IdModelo
                INNER JOIN Version ON Autos.IdVersion = Version.IdVersion;
            END;


            ALTER PROCEDURE [dbo].[AutoInsert]
                @Año INT,
                @Color NVARCHAR(50),
                @Kilometraje FLOAT,
                @NumeroPuertas INT,
                @Transmisión NVARCHAR(50),
                @Combustible NVARCHAR(50),
                @Precio DECIMAL(18, 2),
                @IdMarca INT,
                @IdModelo INT,
                @IdVersion INT
            AS
            BEGIN
                INSERT INTO Autos (Año, 
					                Color, 
					                Kilometraje, 
					                NumeroPuertas, 
					                Transmisión, 
					                Combustible, 
					                Precio, 
					                IdMarca, 
					                IdModelo, 
					                IdVersion)
                VALUES (@Año, 
	                    @Color, 
			            @Kilometraje, 
			            @NumeroPuertas, 
			            @Transmisión, 
			            @Combustible, 
			            @Precio, 
			            @IdMarca, 
			            @IdModelo, 
			            @IdVersion);
            END;
            
         
         */
    }
}
