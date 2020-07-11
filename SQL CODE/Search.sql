CREATE PROC Search
@Search nvarchar(50)
as
select @Search = RTRIM(@Search) + '%' 
begin
SELECT * FROM Files where FileName LIKE @Search
end
