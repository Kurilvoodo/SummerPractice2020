CREATE PROCEDURE AddUser
@Username NVARCHAR(50),
@Password VARBINARY(256)
AS
BEGIN
INSERT INTO Users(Username,Password)
VALUES(@Username,@Password)
END