﻿CREATE TABLE [dbo].[Vaktir]
(
	[VaktID] INT NOT NULL PRIMARY KEY, 
    [PersonID] VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Person(PersonID), 
    [Type] VARCHAR(50) NOT NULL, 
    [Date] DATE NOT NULL, 
    [Start] DATETIME NOT NULL, 
    [End] DATETIME NOT NULL, 
    [isFree] BIT NOT NULL
	
)