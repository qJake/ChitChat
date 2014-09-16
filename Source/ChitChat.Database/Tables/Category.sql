CREATE TABLE [dbo].[Category]
(
	[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL, 
    [Foreground] VARCHAR(7) NOT NULL,
	[Background] VARCHAR(7) NOT NULL,
    [Timeout] INT NOT NULL
)
