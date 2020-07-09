# DevFramework
C# ile backend ve katmanlı mimari 
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


