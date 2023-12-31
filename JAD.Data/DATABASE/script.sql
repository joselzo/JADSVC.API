USE [master]
GO
/****** Object:  Database [JADSVCS]    Script Date: 11/10/2023 10:30:07 AM ******/
CREATE DATABASE [JADSVCS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JADSVCS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\JADSVCS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JADSVCS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\JADSVCS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [JADSVCS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JADSVCS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JADSVCS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JADSVCS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JADSVCS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JADSVCS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JADSVCS] SET ARITHABORT OFF 
GO
ALTER DATABASE [JADSVCS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JADSVCS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JADSVCS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JADSVCS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JADSVCS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JADSVCS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JADSVCS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JADSVCS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JADSVCS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JADSVCS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JADSVCS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JADSVCS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JADSVCS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JADSVCS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JADSVCS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JADSVCS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JADSVCS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JADSVCS] SET RECOVERY FULL 
GO
ALTER DATABASE [JADSVCS] SET  MULTI_USER 
GO
ALTER DATABASE [JADSVCS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JADSVCS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JADSVCS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JADSVCS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JADSVCS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JADSVCS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JADSVCS', N'ON'
GO
ALTER DATABASE [JADSVCS] SET QUERY_STORE = OFF
GO
USE [JADSVCS]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Icon] [varchar](250) NULL,
	[Description] [text] NULL,
	[IsALaCarteOnly] [bit] NULL,
	[Price] [decimal](10, 2) NULL,
	[ServiceID] [int] NULL,
	[ServiceLevelID] [int] NULL,
 CONSTRAINT [PK__Features__3214EC2744CE296F] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK__Service__3214EC27869F2FAB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceLevel]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Description] [text] NULL,
	[Price] [decimal](10, 2) NULL,
	[ServiceID] [int] NULL,
 CONSTRAINT [PK__ServiceL__3214EC27F65F73AB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceOrder]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[UserID] [int] NULL,
	[ServiceID] [int] NULL,
	[ServiceLevelID] [int] NULL,
	[FeaturesALC] [varchar](50) NULL,
	[Amount] [decimal](10, 2) NULL,
	[TxnID] [int] NULL,
	[Status] [varchar](50) NULL,
	[FeeAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK__Transact__3214EC2721A02DD7] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceOrderFeatures]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceOrderFeatures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceOrderID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
 CONSTRAINT [PK_ServiceOrderFeatures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StateChanges]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateChanges](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ActionType] [varchar](50) NULL,
	[ActionDescription] [varchar](255) NULL,
	[ActionDate] [datetime] NULL,
 CONSTRAINT [PK__StateCha__3214EC27FD424D4F] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NULL,
	[CurrentServiceLevelID] [int] NULL,
	[ServiceID] [int] NULL,
 CONSTRAINT [PK__User__3214EC27FC8F6B99] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFeatures]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFeatures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[FeatureID] [int] NULL,
	[ServiceID] [int] NULL,
 CONSTRAINT [PK__UserFeat__3214EC270CBE3647] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Features] ON 

INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (1, N'F1', N'F1', N'F1', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (2, N'F2', N'F2', N'F2', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (3, N'F3', N'F3', N'F3', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (4, N'F4', N'F4', N'F4', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (5, N'F1', N'F1', N'F1', 0, CAST(1.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (6, N'F2', N'F2', N'F2', 0, CAST(1.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (7, N'F3', N'F3', N'F3', 0, CAST(1.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (8, N'F4', N'F4', N'F4', 0, CAST(1.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (9, N'F5', N'F5', N'F5', 0, CAST(1.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (10, N'F6', N'F6', N'F6', 0, CAST(1.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (12, N'FALC1', N'FALC1', N'FALC1', 1, CAST(1.00 AS Decimal(10, 2)), 1, NULL)
INSERT [dbo].[Features] ([ID], [Name], [Icon], [Description], [IsALaCarteOnly], [Price], [ServiceID], [ServiceLevelID]) VALUES (13, N'FALC2', N'FALC2', N'FALC2', 1, CAST(1.00 AS Decimal(10, 2)), 1, NULL)
SET IDENTITY_INSERT [dbo].[Features] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ID], [Name], [Description]) VALUES (1, N'JADEvents', N'JADEvents')
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceLevel] ON 

INSERT [dbo].[ServiceLevel] ([ID], [Name], [Description], [Price], [ServiceID]) VALUES (1, N'Basic', N'Basic', CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[ServiceLevel] ([ID], [Name], [Description], [Price], [ServiceID]) VALUES (2, N'Plus', N'Plus', CAST(2.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[ServiceLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceOrder] ON 

INSERT [dbo].[ServiceOrder] ([ID], [DateAdded], [UserID], [ServiceID], [ServiceLevelID], [FeaturesALC], [Amount], [TxnID], [Status], [FeeAmount]) VALUES (1, CAST(N'2023-10-30T00:00:00.000' AS DateTime), 1, 1, 2, NULL, CAST(1.00 AS Decimal(10, 2)), 1, N'1', NULL)
INSERT [dbo].[ServiceOrder] ([ID], [DateAdded], [UserID], [ServiceID], [ServiceLevelID], [FeaturesALC], [Amount], [TxnID], [Status], [FeeAmount]) VALUES (2, CAST(N'2023-11-01T00:00:00.000' AS DateTime), 1, 1, 1, NULL, CAST(1.00 AS Decimal(10, 2)), 2, N'1', NULL)
INSERT [dbo].[ServiceOrder] ([ID], [DateAdded], [UserID], [ServiceID], [ServiceLevelID], [FeaturesALC], [Amount], [TxnID], [Status], [FeeAmount]) VALUES (3, CAST(N'2023-10-30T00:00:00.000' AS DateTime), 2, 1, 1, NULL, CAST(1.00 AS Decimal(10, 2)), 3, N'1', NULL)
INSERT [dbo].[ServiceOrder] ([ID], [DateAdded], [UserID], [ServiceID], [ServiceLevelID], [FeaturesALC], [Amount], [TxnID], [Status], [FeeAmount]) VALUES (4, CAST(N'2023-11-01T00:00:00.000' AS DateTime), 2, 1, 2, NULL, CAST(1.00 AS Decimal(10, 2)), 4, N'1', NULL)
INSERT [dbo].[ServiceOrder] ([ID], [DateAdded], [UserID], [ServiceID], [ServiceLevelID], [FeaturesALC], [Amount], [TxnID], [Status], [FeeAmount]) VALUES (5, CAST(N'2023-11-10T16:24:29.683' AS DateTime), 1, 1, 1, N'test', CAST(20.00 AS Decimal(10, 2)), 20, N'1', CAST(10.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ServiceOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceOrderFeatures] ON 

INSERT [dbo].[ServiceOrderFeatures] ([ID], [ServiceOrderID], [FeatureID]) VALUES (1, 4, 12)
INSERT [dbo].[ServiceOrderFeatures] ([ID], [ServiceOrderID], [FeatureID]) VALUES (2, 4, 13)
INSERT [dbo].[ServiceOrderFeatures] ([ID], [ServiceOrderID], [FeatureID]) VALUES (3, 5, 1)
INSERT [dbo].[ServiceOrderFeatures] ([ID], [ServiceOrderID], [FeatureID]) VALUES (4, 5, 2)
SET IDENTITY_INSERT [dbo].[ServiceOrderFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Email], [CurrentServiceLevelID], [ServiceID]) VALUES (1, N'luis', 1, 1)
INSERT [dbo].[User] ([ID], [Email], [CurrentServiceLevelID], [ServiceID]) VALUES (2, N'Jose', 2, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserFeatures] ON 

INSERT [dbo].[UserFeatures] ([ID], [UserID], [FeatureID], [ServiceID]) VALUES (1, 1, 1, 1)
INSERT [dbo].[UserFeatures] ([ID], [UserID], [FeatureID], [ServiceID]) VALUES (2, 1, 2, 1)
INSERT [dbo].[UserFeatures] ([ID], [UserID], [FeatureID], [ServiceID]) VALUES (3, 1, 3, 1)
INSERT [dbo].[UserFeatures] ([ID], [UserID], [FeatureID], [ServiceID]) VALUES (4, 1, 4, 1)
INSERT [dbo].[UserFeatures] ([ID], [UserID], [FeatureID], [ServiceID]) VALUES (5, 1, 12, 1)
SET IDENTITY_INSERT [dbo].[UserFeatures] OFF
GO
ALTER TABLE [dbo].[Features]  WITH CHECK ADD  CONSTRAINT [FK__Features__Servic__2C3393D0] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[Features] CHECK CONSTRAINT [FK__Features__Servic__2C3393D0]
GO
ALTER TABLE [dbo].[Features]  WITH CHECK ADD  CONSTRAINT [FK__Features__Servic__2D27B809] FOREIGN KEY([ServiceLevelID])
REFERENCES [dbo].[ServiceLevel] ([ID])
GO
ALTER TABLE [dbo].[Features] CHECK CONSTRAINT [FK__Features__Servic__2D27B809]
GO
ALTER TABLE [dbo].[ServiceLevel]  WITH CHECK ADD  CONSTRAINT [FK__ServiceLe__Servi__46E78A0C] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[ServiceLevel] CHECK CONSTRAINT [FK__ServiceLe__Servi__46E78A0C]
GO
ALTER TABLE [dbo].[ServiceLevel]  WITH CHECK ADD  CONSTRAINT [FK__ServiceLe__Servi__5CD6CB2B] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[ServiceLevel] CHECK CONSTRAINT [FK__ServiceLe__Servi__5CD6CB2B]
GO
ALTER TABLE [dbo].[ServiceOrder]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__FromS__36B12243] FOREIGN KEY([ServiceLevelID])
REFERENCES [dbo].[ServiceLevel] ([ID])
GO
ALTER TABLE [dbo].[ServiceOrder] CHECK CONSTRAINT [FK__Transacti__FromS__36B12243]
GO
ALTER TABLE [dbo].[ServiceOrder]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__Servi__38996AB5] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[ServiceOrder] CHECK CONSTRAINT [FK__Transacti__Servi__38996AB5]
GO
ALTER TABLE [dbo].[ServiceOrder]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__UserI__35BCFE0A] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ServiceOrder] CHECK CONSTRAINT [FK__Transacti__UserI__35BCFE0A]
GO
ALTER TABLE [dbo].[ServiceOrderFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOrderFeatures_Features] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([ID])
GO
ALTER TABLE [dbo].[ServiceOrderFeatures] CHECK CONSTRAINT [FK_ServiceOrderFeatures_Features]
GO
ALTER TABLE [dbo].[ServiceOrderFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOrderFeatures_ServiceOrder] FOREIGN KEY([ServiceOrderID])
REFERENCES [dbo].[ServiceOrder] ([ID])
GO
ALTER TABLE [dbo].[ServiceOrderFeatures] CHECK CONSTRAINT [FK_ServiceOrderFeatures_ServiceOrder]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__ServiceID__4CA06362] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__ServiceID__4CA06362]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__ServiceID__5DCAEF64] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__ServiceID__5DCAEF64]
GO
ALTER TABLE [dbo].[UserFeatures]  WITH CHECK ADD  CONSTRAINT [FK__UserFeatu__Featu__30F848ED] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([ID])
GO
ALTER TABLE [dbo].[UserFeatures] CHECK CONSTRAINT [FK__UserFeatu__Featu__30F848ED]
GO
ALTER TABLE [dbo].[UserFeatures]  WITH CHECK ADD  CONSTRAINT [FK__UserFeatu__Servi__4E88ABD4] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[UserFeatures] CHECK CONSTRAINT [FK__UserFeatu__Servi__4E88ABD4]
GO
ALTER TABLE [dbo].[UserFeatures]  WITH CHECK ADD  CONSTRAINT [FK__UserFeatu__Servi__5EBF139D] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[UserFeatures] CHECK CONSTRAINT [FK__UserFeatu__Servi__5EBF139D]
GO
ALTER TABLE [dbo].[UserFeatures]  WITH CHECK ADD  CONSTRAINT [FK__UserFeatu__UserI__4F7CD00D] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserFeatures] CHECK CONSTRAINT [FK__UserFeatu__UserI__4F7CD00D]
GO
ALTER TABLE [dbo].[UserFeatures]  WITH CHECK ADD  CONSTRAINT [FK__UserFeatu__UserI__5FB337D6] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserFeatures] CHECK CONSTRAINT [FK__UserFeatu__UserI__5FB337D6]
GO
/****** Object:  StoredProcedure [dbo].[GetChurnAnalysisReport]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetChurnAnalysisReport]
AS
BEGIN
    SELECT UserID, COUNT(*) AS ChurnCount
    FROM Transactions
    GROUP BY UserID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUpgradeAnalysisReport]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUpgradeAnalysisReport]
AS
BEGIN
    SELECT UserID, FromServiceLevelID, ToServiceLevelID, TransactionDate
    FROM Transactions;
END;
GO
/****** Object:  StoredProcedure [dbo].[PurchaseServiceAndServiceLevel]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseServiceAndServiceLevel]
    @UserID INT,
    @ServiceLevelID INT,
    @ServiceID INT
AS
BEGIN
    -- Insert logic to handle the purchase of a service and service level for a user
    INSERT INTO [User] (ID, CurrentServiceLevelID, ServiceID)
    VALUES (@UserID, @ServiceLevelID, @ServiceID);
END;
GO
/****** Object:  StoredProcedure [dbo].[PurchaseUpgrade]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseUpgrade]
    @UserID INT,
    @FromServiceLevelID INT,
    @ToServiceLevelID INT,
    @Amount DECIMAL,
    @TransactionDate DATE,
    @ServiceID INT
AS
BEGIN
    -- Insert logic to handle the purchase of an upgrade from one service level to the next for a user
    INSERT INTO Transactions (UserID, FromServiceLevelID, ToServiceLevelID, Amount, TransactionDate, ServiceID)
    VALUES (@UserID, @FromServiceLevelID, @ToServiceLevelID, @Amount, @TransactionDate, @ServiceID);
    
    -- Update the user's current service level
    UPDATE [User]
    SET CurrentServiceLevelID = @ToServiceLevelID
    WHERE ID = @UserID;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllUsers]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPGetAllUsers] 
as 
begin 
	select * from [dbo].[User] 
end
GO
/****** Object:  StoredProcedure [dbo].[spGetFeatureByIdUser]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetFeatureByIdUser]  
(
@iduser int
)
as begin
select
sl.ServiceID, 
s.[Name] ServiceName, 
s.[Description] ServiceDescription,
f.ServiceLevelID, 
sl.[Name] LevelName, 
sl.[Description] LevelDescription,
sl.Price LevelPrice ,
f.ID FeatureID,
f.[Name] FeatureName,
f.[Description] FeatureDescription,
f.Price FeaturePrice,
u.ID UsuarioID,
u.Email
from dbo.[User] u
inner join dbo.UserFeatures uf on uf.UserID = u.ID
inner join dbo.ServiceLevel sl on sl.ID = u.CurrentServiceLevelID
INNER JOIN dbo.Features f on f.ServiceLevelID = sl.ID and  f.ID = uf.FeatureID
inner join dbo.[Service] s on s.ID = sl.ServiceID
where u.ID = @iduser
union all
select 
0 ServiceID, 
'ALaCarte' ServiceName, 
'ALaCarte' ServiceDescription, 
0 ServiceLevelID,
'ALaCarte' LevelName,
'ALaCarte' LevelDescription,
0 LevelPrice,
f.ID FeatureID,
f.[Name] FeatureName,
f.[Description] FeatureDescription,
f.Price FeaturePrice,
u.ID UsuarioID,
u.Email
from dbo.[User] u
inner join dbo.UserFeatures uf on uf.UserID = u.ID
inner join dbo.Features f on f.ID = uf.FeatureID

where f.IsALaCarteOnly = 1 and u.ID = @iduser
end


GO
/****** Object:  StoredProcedure [dbo].[spgetLevelsandFeatures]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spgetLevelsandFeatures]
as
begin
select 
sl.ServiceID, 
s.[Name] ServiceName, 
s.[Description] ServiceDescription,
f.ServiceLevelID, 
sl.[Name] LevelName, 
sl.[Description] LevelDescription,
sl.Price LevelPrice ,
f.ID FeatureID,
f.[Name] FeatureName,
f.[Description] FeatureDescription,
f.Price FeaturePrice
from dbo.Service s
inner join dbo.ServiceLevel sl on sl.ServiceID = s.ID
INNER JOIN dbo.Features f on f.ServiceLevelID = sl.ID

union all
select 
0 ServiceID, 
'ALaCarte' ServiceName, 
'ALaCarte' ServiceDescription, 
0 ServiceLevelID,
'ALaCarte' LevelName,
'ALaCarte' LevelDescription,
0 LevelPrice,
f.ID FeatureID,
f.[Name] FeatureName,
f.[Description] FeatureDescription,
f.Price FeaturePrice
from dbo.Features f
where f.IsALaCarteOnly = 1

end


GO
/****** Object:  StoredProcedure [dbo].[spGetServiceOrderByIdUser]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetServiceOrderByIdUser]  
(
@id int
)
AS BEGIN
SELECT 
u.ID IdUser, 
Email, 
so.ID IdOrder, 
DateAdded, 
so.ServiceID, 
ServiceLevelID,
Amount,
TxnID, 
S.[Name] ServiceName, 
sl.[Name] ServiceLevelName,
[Status],
FeeAmount
FROM dbo.[User] u
INNER JOIN dbo.ServiceOrder so ON so.UserID = u.ID
inner join dbo.[Service] s on s.ID = so.ServiceID
inner join dbo.ServiceLevel sl on sl.ID = so.ServiceLevelID
WHERE u.ID = @id AND so.ID IN (
    SELECT ID
    FROM (
        SELECT MAX(DateAdded) DateAdded, so.ID
        FROM dbo.[User] u
        INNER JOIN dbo.ServiceOrder so ON so.UserID = u.ID
        WHERE u.ID = @id
        GROUP BY so.ID
    ) filtered
)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUser]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUser] (
@Id int
)
as 
begin 
	select * from [dbo].[User] where Id = @Id
end


GO
/****** Object:  StoredProcedure [dbo].[TrackStateChange]    Script Date: 11/10/2023 10:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TrackStateChange]
    @UserID INT,
    @ActionType VARCHAR(50),
    @ActionDescription VARCHAR(255)
AS
BEGIN
    INSERT INTO StateChanges (UserID, ActionType, ActionDescription, ActionDate)
    VALUES (@UserID, @ActionType, @ActionDescription, GETDATE());
END;
GO
USE [master]
GO
ALTER DATABASE [JADSVCS] SET  READ_WRITE 
GO
