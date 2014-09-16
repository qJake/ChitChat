INSERT INTO [User] (FirstName, LastName, Principal) VALUES ('Jake', 'Burgy', 'CSIINC\Jake')

INSERT INTO Category (Name, Foreground, Background, Timeout) VALUES ('Location', '#000000', '#0099CC', 15)
INSERT INTO Category (Name, Foreground, Background, Timeout) VALUES ('Server/LAN', '#000000', '#CC0000', 60)
INSERT INTO Category (Name, Foreground, Background, Timeout) VALUES ('Misc', '#000000', '#CC0099', 5)

INSERT INTO Post (Body, CatID, UserID) VALUES ('I''m OOO tomorrow. Peace out!', 1, 1)
INSERT INTO Post (Body, CatID, UserID) VALUES ('Leaving early today.', 1, 1)
INSERT INTO Post (Body, CatID, UserID) VALUES ('The server DM-IMIS20-1-JB is down for maintenance. Back up soon!', 2, 1)
INSERT INTO Post (Body, CatID, UserID) VALUES ('Hey, check out this cool link! http://google.com/', 3, 1)
INSERT INTO Post (Body, CatID, UserID) VALUES ('This is a really random, really long miscellaneous post. It also has line breaks (just because). It also has a lot of nonsense. Nonsense! Lorem ipsum dolor sit amet!' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Ha! I told you it was NONSENSE!', 3, 1)

INSERT INTO [Like] (UserID, PostID) VALUES (1, 4)
GO