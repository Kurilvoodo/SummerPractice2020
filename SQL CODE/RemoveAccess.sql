CREATE PROCEDURE RemoveAccess
@IdFile INT,
@IdUser INT
AS
BEGIN
DELETE FROM Access WHERE IdUser = @IdUser AND IdFile=@IdFile
END

