IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Empresas] (
    [ID] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Direccion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Empresas] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Productos] (
    [ID] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Categorias] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Precio] real NOT NULL,
    [Unidades] int NOT NULL,
    [EmpresaID] int NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Productos_Empresas_EmpresaID] FOREIGN KEY ([EmpresaID]) REFERENCES [Empresas] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Productos_EmpresaID] ON [Productos] ([EmpresaID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221111141716_Inicial', N'7.0.0');
GO

COMMIT;
GO

