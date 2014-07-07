CREATE TABLE [dbo].[PostSecurity]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [PostID] INT NOT NULL, 
    [Principal] VARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_PostSecurity_Posts] FOREIGN KEY ([PostID]) REFERENCES [Post]([ID]) 
)
