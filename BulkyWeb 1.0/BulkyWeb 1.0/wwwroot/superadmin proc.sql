use Bulky
select * from [dbo].[AspNetRoles];


select * from [dbo].[AspNetUsers];

select * from [dbo].[AspNetUserRoles];

insert into [dbo].[AspNetUserRoles]
(UserId,RoleId) values((select id from [dbo].[AspNetUsers] where UserName='jenish.prajapati@cotiviti.com'),(select id from [dbo].[AspNetRoles] where Name='Admin'))


/*truncate table [dbo].[AspNetUserRoles] */


CREATE or alter PROCEDURE dbo.setSuperUser @username nvarchar(50),@role nvarchar(50)
AS
insert into 
[dbo].[AspNetUserRoles] (UserId,RoleId) 
values
((select id from [dbo].[AspNetUsers] where UPPER(UserName) like UPPER(@username)),(select id from [dbo].[AspNetRoles] where UPPER(Name) like UPPER(@role)))
GO

 exec dbo.setSuperUser 'jenish.prajapati@cotiviti.com','admin'


 select a.*,b.NormalizedUserName,c.Name from [dbo].[AspNetUserRoles] as a 
 left join[dbo].[AspNetUsers] as b 
 on a.UserId=b.Id
 left join [dbo].[AspNetRoles] as c
 on a.RoleId=c.Id