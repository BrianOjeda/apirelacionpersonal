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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013210545_Initial')
BEGIN
    CREATE TABLE [Personas] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        [Apellido] nvarchar(max) NULL,
        [Dni] nvarchar(max) NULL,
        [FechaNacimiento] datetime2 NOT NULL,
        [IdTipoDocumento] int NOT NULL,
        CONSTRAINT [PK_Personas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013210545_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221013210545_Initial', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014011547_TipoDni')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personas]') AND [c].[name] = N'IdTipoDocumento');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Personas] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Personas] DROP COLUMN [IdTipoDocumento];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014011547_TipoDni')
BEGIN
    ALTER TABLE [Personas] ADD [TipoDniId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014011547_TipoDni')
BEGIN
    CREATE TABLE [TipoDni] (
        [Id] int NOT NULL IDENTITY,
        [Tipo] nvarchar(max) NULL,
        CONSTRAINT [PK_TipoDni] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014011547_TipoDni')
BEGIN
    CREATE INDEX [IX_Personas_TipoDniId] ON [Personas] ([TipoDniId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014011547_TipoDni')
BEGIN
    ALTER TABLE [Personas] ADD CONSTRAINT [FK_Personas_TipoDni_TipoDniId] FOREIGN KEY ([TipoDniId]) REFERENCES [TipoDni] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014011547_TipoDni')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221014011547_TipoDni', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014014452_Nacionalidad')
BEGIN
    ALTER TABLE [Personas] ADD [NacionalidadId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014014452_Nacionalidad')
BEGIN
    CREATE TABLE [Nacionalidad] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Nacionalidad] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014014452_Nacionalidad')
BEGIN
    CREATE INDEX [IX_Personas_NacionalidadId] ON [Personas] ([NacionalidadId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014014452_Nacionalidad')
BEGIN
    ALTER TABLE [Personas] ADD CONSTRAINT [FK_Personas_Nacionalidad_NacionalidadId] FOREIGN KEY ([NacionalidadId]) REFERENCES [Nacionalidad] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014014452_Nacionalidad')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221014014452_Nacionalidad', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    ALTER TABLE [Personas] DROP CONSTRAINT [FK_Personas_Nacionalidad_NacionalidadId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    ALTER TABLE [Personas] DROP CONSTRAINT [FK_Personas_TipoDni_TipoDniId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    DROP INDEX [IX_Personas_TipoDniId] ON [Personas];
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personas]') AND [c].[name] = N'TipoDniId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Personas] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Personas] ALTER COLUMN [TipoDniId] int NOT NULL;
    ALTER TABLE [Personas] ADD DEFAULT 0 FOR [TipoDniId];
    CREATE INDEX [IX_Personas_TipoDniId] ON [Personas] ([TipoDniId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    DROP INDEX [IX_Personas_NacionalidadId] ON [Personas];
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personas]') AND [c].[name] = N'NacionalidadId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Personas] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Personas] ALTER COLUMN [NacionalidadId] int NOT NULL;
    ALTER TABLE [Personas] ADD DEFAULT 0 FOR [NacionalidadId];
    CREATE INDEX [IX_Personas_NacionalidadId] ON [Personas] ([NacionalidadId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    ALTER TABLE [Personas] ADD CONSTRAINT [FK_Personas_Nacionalidad_NacionalidadId] FOREIGN KEY ([NacionalidadId]) REFERENCES [Nacionalidad] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    ALTER TABLE [Personas] ADD CONSTRAINT [FK_Personas_TipoDni_TipoDniId] FOREIGN KEY ([TipoDniId]) REFERENCES [TipoDni] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015200444_CambiosenPersona')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221015200444_CambiosenPersona', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015203942_Sexo')
BEGIN
    ALTER TABLE [Personas] ADD [SexoId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015203942_Sexo')
BEGIN
    CREATE TABLE [Sexo] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Sexo] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015203942_Sexo')
BEGIN
    CREATE INDEX [IX_Personas_SexoId] ON [Personas] ([SexoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015203942_Sexo')
BEGIN
    ALTER TABLE [Personas] ADD CONSTRAINT [FK_Personas_Sexo_SexoId] FOREIGN KEY ([SexoId]) REFERENCES [Sexo] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221015203942_Sexo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221015203942_Sexo', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    ALTER TABLE [Personas] DROP CONSTRAINT [FK_Personas_TipoDni_TipoDniId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    DROP TABLE [TipoDni];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    EXEC sp_rename N'[Personas].[TipoDniId]', N'TipoDocumentoId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    EXEC sp_rename N'[Personas].[IX_Personas_TipoDniId]', N'IX_Personas_TipoDocumentoId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    CREATE TABLE [TipoDocumento] (
        [Id] int NOT NULL IDENTITY,
        [Tipo] nvarchar(max) NULL,
        CONSTRAINT [PK_TipoDocumento] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    ALTER TABLE [Personas] ADD CONSTRAINT [FK_Personas_TipoDocumento_TipoDocumentoId] FOREIGN KEY ([TipoDocumentoId]) REFERENCES [TipoDocumento] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016205120_TipoDniATipoDocumento')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221016205120_TipoDniATipoDocumento', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016211351_DniANumeroDocumentoPersona')
BEGIN
    EXEC sp_rename N'[Personas].[Dni]', N'NumeroDocumento', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016211351_DniANumeroDocumentoPersona')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221016211351_DniANumeroDocumentoPersona', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221018213106_Relacion')
BEGIN
    CREATE TABLE [Relaciones] (
        [Id] int NOT NULL IDENTITY,
        [PersonaId_Padre] int NOT NULL,
        [PersonaId_Hijo] int NOT NULL,
        [PersonaPadreId] int NULL,
        [PersonaHijoId] int NULL,
        [TipoRelacionId] int NOT NULL,
        CONSTRAINT [PK_Relaciones] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Relaciones_Personas_PersonaHijoId] FOREIGN KEY ([PersonaHijoId]) REFERENCES [Personas] ([Id]),
        CONSTRAINT [FK_Relaciones_Personas_PersonaPadreId] FOREIGN KEY ([PersonaPadreId]) REFERENCES [Personas] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221018213106_Relacion')
BEGIN
    CREATE TABLE [TipoRelacions] (
        [Id] int NOT NULL IDENTITY,
        [Relacion] nvarchar(max) NULL,
        CONSTRAINT [PK_TipoRelacions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221018213106_Relacion')
BEGIN
    CREATE INDEX [IX_Relaciones_PersonaHijoId] ON [Relaciones] ([PersonaHijoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221018213106_Relacion')
BEGIN
    CREATE INDEX [IX_Relaciones_PersonaPadreId] ON [Relaciones] ([PersonaPadreId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221018213106_Relacion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221018213106_Relacion', N'6.0.10');
END;
GO

COMMIT;
GO

