CREATE PROCEDURE AddAccess
@IdUser INT,
@IdFile INT
AS
BEGIN
INSERT INTO Access(IdUser,IdFile)
VALUES(@IdUser,@IdFile)
END