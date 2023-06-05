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

go

create table UserMaster
(
Uid int identity primary key,
name varchar(20),
userid varchar(20),
password varchar(20),
is_active bit,
role int references RoleMaster(roleid),
created_on datetime default getdate()
)

select * from UserMaster