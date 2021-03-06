USE [master]
GO
CREATE LOGIN [UsrMundial] WITH PASSWORD=N'12345', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [UsrMundial]
GO
USE [Mundial]
GO
CREATE USER [UsrMundial] FOR LOGIN [UsrMundial]
GO
USE [Mundial]
GO
ALTER ROLE [db_datareader] ADD MEMBER [UsrMundial]
GO
USE [Mundial]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [UsrMundial]
GO
USE [Mundial]
GO
ALTER ROLE [db_owner] ADD MEMBER [UsrMundial]
GO
