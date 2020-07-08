CREATE PROCEDURE RemoveRequest
@RequestId INT,
@FileId INT,
@OwnerId INT
AS
BEGIN
DELETE FROM Requests WHERE OwnerId =@OwnerId AND FileId = @FileId AND RequestId = @RequestId
END