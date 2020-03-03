
CREATE TABLE Cte (
    codigo INT PRIMARY KEY IDENTITY (1, 1),
    numeroCte VARCHAR (50) NOT NULL,
    ICMS Decimal(11,2) NOT NULL,
    DataEnvio DATETIME
);