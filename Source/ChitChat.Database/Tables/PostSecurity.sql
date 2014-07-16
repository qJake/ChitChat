CREATE TABLE [dbo].[PostSecurity]
(
	[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [PostID] INT NOT NULL, 
    [Principal] VARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_PostSecurity_Posts] FOREIGN KEY ([PostID]) REFERENCES [Post]([ID]) 
)
