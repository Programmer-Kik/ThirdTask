USE [master]
GO
/****** Object:  Database [Job]    Script Date: 10.06.2020 16:01:30 ******/
CREATE DATABASE [Job]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Job', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Job.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Job_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Job_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Job] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Job].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Job] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Job] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Job] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Job] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Job] SET ARITHABORT OFF 
GO
ALTER DATABASE [Job] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Job] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Job] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Job] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Job] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Job] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Job] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Job] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Job] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Job] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Job] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Job] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Job] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Job] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Job] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Job] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Job] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Job] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Job] SET  MULTI_USER 
GO
ALTER DATABASE [Job] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Job] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Job] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Job] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Job] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Job] SET QUERY_STORE = OFF
GO
USE [Job]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 10.06.2020 16:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[award_id] [int] IDENTITY(1,1) NOT NULL,
	[award_title] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[award_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_name] [varchar](50) NOT NULL,
	[employee_date_of_birth] [date] NOT NULL,
	[employee_age] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_awards]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_awards](
	[employee_id] [int] NOT NULL,
	[award_id] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_awards]  WITH CHECK ADD FOREIGN KEY([award_id])
REFERENCES [dbo].[Award] ([award_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee_awards]  WITH CHECK ADD FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[Add_award_for_employee]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_award_for_employee]
@employee_id int,
@award_id int
AS
BEGIN
insert into Employee_awards(award_id, employee_id) values
(@award_id, @employee_id)
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_award_by_id]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_award_by_id]
@id int
AS
BEGIN
delete Award where Award.award_id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_employee_by_id]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_employee_by_id]
@id int
AS
BEGIN
delete Employee where Employee.employee_id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_into_award]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_into_award]
@title varchar(100)
AS
BEGIN
insert into Award(award_title) values
(@title)
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_into_employee]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_into_employee]
@name varchar(50),
@date date,
@age int
AS
BEGIN
insert into Employee(employee_name, employee_date_of_birth, employee_age) values
(@name, @date, @age)
END
GO
/****** Object:  StoredProcedure [dbo].[Select_award]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_award]
AS
BEGIN
select * from Award
END
GO
/****** Object:  StoredProcedure [dbo].[Select_employee]    Script Date: 10.06.2020 16:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_employee]
AS
BEGIN
select Employee.employee_id, Employee.employee_name, Employee.employee_date_of_birth, Employee.employee_age, Award.award_id, Award.award_title
from Employee_awards
join Employee on Employee_awards.employee_id = Employee.employee_id
join Award on Employee_awards.award_id = Award.award_id
END
GO
USE [master]
GO
ALTER DATABASE [Job] SET  READ_WRITE 
GO
