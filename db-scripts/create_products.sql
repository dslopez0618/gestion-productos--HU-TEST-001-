-- CREACION DE TABLA PROD[dbo].[Products]UCTS
CREATE TABLE [dbo].[Products] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,               -- IDENTIFICADOR UNICO
    [Name] NVARCHAR(100) NOT NULL,                    -- NOMBRE DEL PRODUCTO
    [Description] NVARCHAR(255) NULL,                 -- DESCRIPCION OPCIONAL
    [Price] DECIMAL(10,2) NOT NULL CHECK ([Price] > 0), -- PRECIO MAYOR A 0
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE()   -- FECHA DE CREACION
);

-- DATOS DE PRUEBA
INSERT INTO [dbo].[Products] ([Name], [Description], [Price])
VALUES 
('Laptop Lenovo', 'Laptop de 14 pulgadas con procesador i5', 3200000.00),
('Mouse Logitech', 'Mouse inalámbrico ergonómico', 95000.00),
('Teclado Mecánico', 'Teclado RGB con switches azules', 210000.00),
('Monitor LG', 'Monitor LED 24 pulgadas Full HD', 750000.00),
('Auriculares Sony', 'Auriculares inalámbricos con cancelación de ruido', 1200000.00);
