CREATE PROCEDURE UploadFile
@FileName NVARCHAR(60),
@OwnerId INT
AS
BEGIN
INSERT INTO Files(FileName,OwnerId)
VALUES(@FileName,@OwnerId)
END