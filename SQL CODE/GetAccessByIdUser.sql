CREATE PROCEDURE GetAccessByIdUser
@IdUser INT
AS
BEGIN
SELECT * FROM Access WHERE IdUser = @IdUser
END