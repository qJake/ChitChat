﻿CREATE TABLE [dbo].[Post]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    [CatID] INT NOT NULL, 
    [Body] TEXT NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Posts_User] FOREIGN KEY ([UserID]) REFERENCES [User]([ID]), 
    CONSTRAINT [FK_Posts_Category] FOREIGN KEY ([CatID]) REFERENCES [Category]([ID]) 
)
