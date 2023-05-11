use Bulky
go
create table RoleMaster
(
RoleId int identity(9001,1),
RoleDescription varchar(20),
Created_on datetime
);
go
alter table RoleMaster
add constraint [PK_table_Rolemaster] primary key (RoleId);

go

INSERT INTO RoleMaster (RoleDescription, Created_on)
VALUES 
('Admin', GETDATE()), 
('User_A', GETDATE());


go

select * from RoleMaster