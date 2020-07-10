# DevFramework
Backend and Layered Architecture with C# 
Northwind database used.
Logs table added to Northwind database.

Northwind database script:
https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql
(click the download button)

Logs table script:

CREATE TABLE [dbo].[Logs] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Detail] NVARCHAR (MAX) NOT NULL,
    [Date]   DATETIME       NOT NULL,
    [Audit]  NVARCHAR (50)  NOT NULL
);


Users table script:

CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (50)  NOT NULL,
    [Password]  VARCHAR (50)  NOT NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [Email]     VARCHAR (100) NOT NULL
);


Roles table script:

CREATE TABLE [dbo].[Roles] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL
);

UserRoles table script:

CREATE TABLE [dbo].[UserRoles] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);



