BEGIN TRANSACTION;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'c4002263-bf83-4da5-bbcb-535773f21366'
WHERE [Id] = N'89086180-b978-4f90-9dbd-a7040bc93f41';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
VALUES (N'cf5fae49-64dc-4da9-8757-52f1e5664c29', 0, N'c7fc5e16-0f5e-4cf5-be84-85cb85c68d58', N'jdrosof@gmail.com', CAST(1 AS bit), CAST(0 AS bit), NULL, N'jdrosof@gmail.com', N'jdrosof@gmail.com', N'AQAAAAEAACcQAAAAEKCQgzkN75DihSWMnSrjeVlqYogvPdM+HiFwawzEOzDmHkmxjdlONrlqFWkHErtu1g==', NULL, CAST(0 AS bit), N'ba36395f-b341-472c-b4f8-aacdf1504db2', CAST(0 AS bit), N'jdrosof@gmail.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
VALUES (N'89086180-b978-4f90-9dbd-a7040bc93f41', N'cf5fae49-64dc-4da9-8757-52f1e5664c29');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220420203905_AdminUser', N'6.0.4');
GO

COMMIT;
GO

