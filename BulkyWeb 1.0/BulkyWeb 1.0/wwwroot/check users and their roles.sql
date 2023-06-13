/****** Script for SelectTopNRows command from SSMS  ******/

use Bulky
go
begin
 select a.*,b.username,c.Name as ROLE from [dbo].[UserRoles] as a left join [Bulky].[dbo].[Users] as b on b.id=a.userid
  left join [dbo].[Roles] as c on c.id=a.roleid
end


select * from [dbo].[QuizResults] order by QuizResult_ID desc


SELECT *
FROM (
    SELECT
        ROW_NUMBER() OVER (PARTITION BY User_ID ORDER BY QuizResult_ID desc) AS RANK,
        *
    FROM
        [dbo].[QuizResults]
) AS Subquery where RANK<(select COUNT(distinct Question_ID) from  ;



SELECT *
FROM (
    SELECT
        ROW_NUMBER() OVER (PARTITION BY User_ID ORDER BY QuizResult_ID desc) AS RANK,
        *
    FROM
        [dbo].[QuizResults]
) AS Subquery

select * from [dbo].[Prasna]
select * from [dbo].[QuizResults]
truncate table quizresults
select * from [dbo].[Users]


select a.Id,a.Name,a.UserName,c.Question,b.Answer from [dbo].[Users] a 
left join [dbo].[QuizResults] b
on b.User_ID=a.Id
left join  [dbo].[Prasna] c
on c.Question_ID=b.Question_ID