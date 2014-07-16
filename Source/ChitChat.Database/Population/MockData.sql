INSERT INTO [User] (FirstName, LastName, Principal) VALUES ('Jake', 'Burgy', 'CSIINC\Jake')

INSERT INTO Category (Name, Color) VALUES ('Location', '#006699')
INSERT INTO Category (Name, Color) VALUES ('Server/LAN', '#CC0000')

INSERT INTO Post (Body, CatID, UserID) VALUES ('I''m OOO tomorrow. Peace out!', 1, 1)
INSERT INTO Post (Body, CatID, UserID) VALUES ('Leaving early today.', 1, 1)
INSERT INTO Post (Body, CatID, UserID) VALUES ('The server DM-IMIS20-1-JB is down for maintenance. Back up soon!', 2, 1)
GO