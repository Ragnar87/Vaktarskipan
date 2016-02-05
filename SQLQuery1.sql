CREATE TABLE [dbo].[Person] (
    [PersonID]  VARCHAR (50) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Telephone] NCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonID] ASC)
);

