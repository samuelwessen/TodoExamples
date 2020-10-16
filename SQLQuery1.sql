CREATE TABLE Todos (
	Id int not null identity(1,1) primary key,
	Activity nvarchar(100) not null,
	Completed bit not null,
	Created datetime2 not null
)