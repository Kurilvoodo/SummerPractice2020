CREATE PROCEDURE AddRequest
@RequestId INT,
@FileId INT,
@OwnerId INT
AS
BEGIN
INSERT INTO Requests (OwnerId,FileId, RequestId)
VALUES(@OwnerId, @FileId, @RequestId)
END