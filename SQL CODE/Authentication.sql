CREATE PROCEDURE Authentication
@Username NVARCHAR(50),
@Password NVARCHAR(256)
AS
BEGIN
	SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password
END