/****** Script for SelectTopNRows command from SSMS  ******/

use Bulky
go
begin
 select a.*,b.username,c.Name as ROLE from [dbo].[UserRoles] as a left join [Bulky].[dbo].[Users] as b on b.id=a.userid
  left join [dbo].[Roles] as c on c.id=a.roleid
end