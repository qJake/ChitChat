CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Principal] VARCHAR(255) NOT NULL, 
    [FirstName] VARCHAR(255) NOT NULL, 
    [LastName] VARCHAR(255) NOT NULL, 
    [Picture] IMAGE NULL
)
