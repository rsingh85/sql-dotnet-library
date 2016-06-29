USE [INSERT_DB_NAME_HERE]
GO

CREATE ASSEMBLY SqlLibrary from '[INSERT_ASSEMBLY_PATH_HERE]\SqlLibrary.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION GetTextSimilarity(@inputOne [nvarchar](4000), @inputTwo [nvarchar](4000))
RETURNS [float] WITH EXECUTE AS CALLER, RETURNS NULL ON NULL INPUT
AS 
EXTERNAL NAME [SqlLibrary].[SqlLibrary.Text.StringCompare].[GetTextSimilarity]
GO
