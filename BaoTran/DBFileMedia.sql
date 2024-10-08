USE [DBFileMedia]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/08/2024 8:32:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileTypes]    Script Date: 29/08/2024 8:32:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileTypes](
	[IdFileType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FileTypes] PRIMARY KEY CLUSTERED 
(
	[IdFileType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaFiles]    Script Date: 29/08/2024 8:32:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaFiles](
	[IdMediaFile] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Singer] [nvarchar](max) NOT NULL,
	[Musician] [nvarchar](max) NOT NULL,
	[FileFormat] [nvarchar](max) NOT NULL,
	[Duration] [nvarchar](max) NOT NULL,
	[File] [nvarchar](max) NOT NULL,
	[IdFileType] [int] NOT NULL,
 CONSTRAINT [PK_MediaFiles] PRIMARY KEY CLUSTERED 
(
	[IdMediaFile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayScheduals]    Script Date: 29/08/2024 8:32:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayScheduals](
	[IdPlaySchedual] [int] IDENTITY(1,1) NOT NULL,
	[DaysOfWeek] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[IdMediaFile] [int] NOT NULL,
 CONSTRAINT [PK_PlayScheduals] PRIMARY KEY CLUSTERED 
(
	[IdPlaySchedual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240829094828_DbNew', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240829105640_DbUpdate', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240829133118_DbUpdate2', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[FileTypes] ON 

INSERT [dbo].[FileTypes] ([IdFileType], [Name]) VALUES (1, N'POP')
INSERT [dbo].[FileTypes] ([IdFileType], [Name]) VALUES (2, N'Cải Lương')
SET IDENTITY_INSERT [dbo].[FileTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[MediaFiles] ON 

INSERT [dbo].[MediaFiles] ([IdMediaFile], [Title], [Singer], [Musician], [FileFormat], [Duration], [File], [IdFileType]) VALUES (2, N'Lạc trôi', N'Sơn Tùng', N'Sơn Tùng', N'Video', N'03:00', N'File/abs', 1)
SET IDENTITY_INSERT [dbo].[MediaFiles] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayScheduals] ON 

INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (1, 1, CAST(N'06:00:00' AS Time), CAST(N'08:00:00' AS Time), CAST(N'2024-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (4, 1, CAST(N'07:00:00' AS Time), CAST(N'08:00:00' AS Time), CAST(N'2024-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (5, 1, CAST(N'06:30:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'2024-09-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-29T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (6, 1, CAST(N'05:30:00' AS Time), CAST(N'06:00:00' AS Time), CAST(N'2024-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (7, 1, CAST(N'05:30:00' AS Time), CAST(N'06:00:00' AS Time), CAST(N'2024-09-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-29T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (10, 1, CAST(N'06:00:00' AS Time), CAST(N'08:00:00' AS Time), CAST(N'2024-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-24T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (11, 1, CAST(N'20:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'2024-09-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[PlayScheduals] ([IdPlaySchedual], [DaysOfWeek], [StartTime], [EndTime], [StartDate], [EndDate], [IdMediaFile]) VALUES (12, 2, CAST(N'20:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'2024-09-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[PlayScheduals] OFF
GO
ALTER TABLE [dbo].[MediaFiles]  WITH CHECK ADD  CONSTRAINT [FK_MediaFiles_FileTypes_IdFileType] FOREIGN KEY([IdFileType])
REFERENCES [dbo].[FileTypes] ([IdFileType])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MediaFiles] CHECK CONSTRAINT [FK_MediaFiles_FileTypes_IdFileType]
GO
ALTER TABLE [dbo].[PlayScheduals]  WITH CHECK ADD  CONSTRAINT [FK_PlayScheduals_MediaFiles_IdMediaFile] FOREIGN KEY([IdMediaFile])
REFERENCES [dbo].[MediaFiles] ([IdMediaFile])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayScheduals] CHECK CONSTRAINT [FK_PlayScheduals_MediaFiles_IdMediaFile]
GO
