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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220408165733_Initial')
BEGIN
    CREATE TABLE [ComidasRapidas] (
        [Id] int NOT NULL IDENTITY,
        [titulo] nvarchar(max) NOT NULL,
        [precio] int NOT NULL,
        CONSTRAINT [PK_ComidasRapidas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220408165733_Initial')
BEGIN
    CREATE TABLE [Persona] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [FechaNacimiento] datetime2 NOT NULL,
        CONSTRAINT [PK_Persona] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220408165733_Initial')
BEGIN
    CREATE TABLE [ComidasPersonas] (
        [ComidaRapidaId] int NOT NULL,
        [PersonaId] int NOT NULL,
        [ComidasRapidasId] int NOT NULL,
        CONSTRAINT [PK_ComidasPersonas] PRIMARY KEY ([ComidaRapidaId], [PersonaId]),
        CONSTRAINT [FK_ComidasPersonas_ComidasRapidas_ComidasRapidasId] FOREIGN KEY ([ComidasRapidasId]) REFERENCES [ComidasRapidas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ComidasPersonas_Persona_PersonaId] FOREIGN KEY ([PersonaId]) REFERENCES [Persona] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220408165733_Initial')
BEGIN
    CREATE INDEX [IX_ComidasPersonas_ComidasRapidasId] ON [ComidasPersonas] ([ComidasRapidasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220408165733_Initial')
BEGIN
    CREATE INDEX [IX_ComidasPersonas_PersonaId] ON [ComidasPersonas] ([PersonaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220408165733_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220408165733_Initial', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220417165256_IdentityTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220417165256_IdentityTables', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220419194841_RolAdmin')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''89086180-b978-4f90-9dbd-a7040bc93f41'', N''0cf75cc5-9d87-451b-b3e2-fc6c99cb02fe'', N''admin'', N''admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220419194841_RolAdmin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220419194841_RolAdmin', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220420203905_AdminUser')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''c4002263-bf83-4da5-bbcb-535773f21366''
    WHERE [Id] = N''89086180-b978-4f90-9dbd-a7040bc93f41'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220420203905_AdminUser')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''cf5fae49-64dc-4da9-8757-52f1e5664c29'', 0, N''c7fc5e16-0f5e-4cf5-be84-85cb85c68d58'', N''jdrosof@gmail.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''jdrosof@gmail.com'', N''jdrosof@gmail.com'', N''AQAAAAEAACcQAAAAEKCQgzkN75DihSWMnSrjeVlqYogvPdM+HiFwawzEOzDmHkmxjdlONrlqFWkHErtu1g=='', NULL, CAST(0 AS bit), N''ba36395f-b341-472c-b4f8-aacdf1504db2'', CAST(0 AS bit), N''jdrosof@gmail.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220420203905_AdminUser')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''89086180-b978-4f90-9dbd-a7040bc93f41'', N''cf5fae49-64dc-4da9-8757-52f1e5664c29'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220420203905_AdminUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220420203905_AdminUser', N'6.0.4');
END;
GO

COMMIT;
GO

