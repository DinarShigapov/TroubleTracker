USE [BugTracherDB]
GO
/****** Object:  Table [dbo].[Issue]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [text] NULL,
	[PriorityId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[AssignedToId] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[SprintId] [int] NULL,
	[ProjectId] [int] NOT NULL,
	[CreatedById] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueAttachment]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueAttachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameAttachment] [varchar](50) NOT NULL,
	[UploadedAt] [datetime] NOT NULL,
	[UploadedById] [int] NOT NULL,
	[Link] [text] NOT NULL,
	[Size] [decimal](10, 2) NOT NULL,
	[FileFormat] [varchar](10) NOT NULL,
	[IssueId] [int] NOT NULL,
 CONSTRAINT [PK_IssueAttachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueComment]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](200) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CommentAuthorId] [int] NOT NULL,
	[IssueId] [int] NOT NULL,
 CONSTRAINT [PK_IssueComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueHistory]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueHistory](
	[Id] [int] NOT NULL,
	[IssueId] [int] NOT NULL,
	[ModifiedElement] [varchar](20) NOT NULL,
	[OldVersion] [varchar](20) NULL,
	[NewVersion] [varchar](20) NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_IssueHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssuePriority]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssuePriority](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NamePriority] [varchar](20) NOT NULL,
 CONSTRAINT [PK_IssuePriority] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueStatus]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameStatus] [varchar](20) NOT NULL,
 CONSTRAINT [PK_IssueStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueType]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameType] [varchar](20) NULL,
 CONSTRAINT [PK_IssueType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Label]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Label](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameLabel] [nvarchar](20) NOT NULL,
	[CreatedById] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Label] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabelIssue]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabelIssue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LabelId] [int] NOT NULL,
	[IssueId] [int] NOT NULL,
 CONSTRAINT [PK_LabelIssue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NamePermission] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[KeyPermission] [varchar](10) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameProject] [varchar](50) NOT NULL,
	[KeyProject] [varchar](8) NOT NULL,
	[Description] [varchar](150) NULL,
	[ProjectManagerId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ActiveSprintId] [int] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectUsers]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [varchar](20) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sprint]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameSprint] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_Sprint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StepsToReproduce]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StepsToReproduce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StepNumber] [int] NOT NULL,
	[StepDescription] [varchar](100) NOT NULL,
	[IssueId] [int] NOT NULL,
 CONSTRAINT [PK_StepsToReproduce] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[Patronymic] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varchar](100) NOT NULL,
	[Phone] [varchar](11) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 31.05.2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Issue] ON 

INSERT [dbo].[Issue] ([Id], [Title], [Description], [PriorityId], [StatusId], [AssignedToId], [CreatedAt], [UpdatedAt], [SprintId], [ProjectId], [CreatedById], [TypeId]) VALUES (12, N'fhghf', NULL, 1, 1, 1, CAST(N'2024-05-28T12:00:30.707' AS DateTime), CAST(N'2024-05-28T12:00:30.707' AS DateTime), 1, 1, 1, 2)
INSERT [dbo].[Issue] ([Id], [Title], [Description], [PriorityId], [StatusId], [AssignedToId], [CreatedAt], [UpdatedAt], [SprintId], [ProjectId], [CreatedById], [TypeId]) VALUES (13, N'hgfhgf', NULL, 2, 1, 2, CAST(N'2024-05-28T13:23:36.583' AS DateTime), CAST(N'2024-05-28T13:23:36.583' AS DateTime), 1, 1, 1, 3)
INSERT [dbo].[Issue] ([Id], [Title], [Description], [PriorityId], [StatusId], [AssignedToId], [CreatedAt], [UpdatedAt], [SprintId], [ProjectId], [CreatedById], [TypeId]) VALUES (15, N'Проверка', NULL, 2, 1, 1, CAST(N'2024-05-28T17:30:32.057' AS DateTime), CAST(N'2024-05-28T17:30:32.057' AS DateTime), 1, 1, 1, 2)
INSERT [dbo].[Issue] ([Id], [Title], [Description], [PriorityId], [StatusId], [AssignedToId], [CreatedAt], [UpdatedAt], [SprintId], [ProjectId], [CreatedById], [TypeId]) VALUES (16, N'Кнопка на главной странице не работает', NULL, 2, 1, 2, CAST(N'2024-05-28T21:57:58.300' AS DateTime), CAST(N'2024-05-28T21:57:58.300' AS DateTime), NULL, 1, 2, 2)
INSERT [dbo].[Issue] ([Id], [Title], [Description], [PriorityId], [StatusId], [AssignedToId], [CreatedAt], [UpdatedAt], [SprintId], [ProjectId], [CreatedById], [TypeId]) VALUES (17, N'Кнопка на главной странице не работает', NULL, 2, 1, 2, CAST(N'2024-05-28T21:58:07.597' AS DateTime), CAST(N'2024-05-28T21:58:07.597' AS DateTime), NULL, 1, 2, 2)
INSERT [dbo].[Issue] ([Id], [Title], [Description], [PriorityId], [StatusId], [AssignedToId], [CreatedAt], [UpdatedAt], [SprintId], [ProjectId], [CreatedById], [TypeId]) VALUES (18, N'Кнопка не работает', NULL, 1, 1, 2, CAST(N'2024-05-28T22:01:49.780' AS DateTime), CAST(N'2024-05-28T22:01:49.780' AS DateTime), NULL, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Issue] OFF
GO
SET IDENTITY_INSERT [dbo].[IssueAttachment] ON 

INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (1, N'78ae4156db656227.png', CAST(N'2024-05-28T12:00:30.767' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\78ae4156db656227.png', CAST(992.00 AS Decimal(10, 2)), N'.png', 12)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (2, N'Screenshot_4.png', CAST(N'2024-05-28T13:23:36.633' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\Screenshot_4.png', CAST(105891.00 AS Decimal(10, 2)), N'.png', 13)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (3, N'аываываыа.png', CAST(N'2024-05-28T13:23:36.650' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\аываываыа.png', CAST(62234.00 AS Decimal(10, 2)), N'.png', 13)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (4, N'SecondTrack.mp3', CAST(N'2024-05-28T17:30:32.110' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\SecondTrack.mp3', CAST(1286218.00 AS Decimal(10, 2)), N'.mp3', 15)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (5, N'1 (4).png', CAST(N'2024-05-28T17:30:32.127' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\1 (4).png', CAST(7304.00 AS Decimal(10, 2)), N'.png', 15)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (6, N'2 (1).png', CAST(N'2024-05-28T17:30:32.130' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\2 (1).png', CAST(8655.00 AS Decimal(10, 2)), N'.png', 15)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (7, N'Screenshot_5.png', CAST(N'2024-05-28T21:57:58.333' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\Screenshot_5.png', CAST(1899.00 AS Decimal(10, 2)), N'.png', 16)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (8, N'Screenshot_5.png', CAST(N'2024-05-28T21:58:07.600' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\Screenshot_5.png', CAST(1899.00 AS Decimal(10, 2)), N'.png', 17)
INSERT [dbo].[IssueAttachment] ([Id], [NameAttachment], [UploadedAt], [UploadedById], [Link], [Size], [FileFormat], [IssueId]) VALUES (9, N'Screenshot_5.png', CAST(N'2024-05-28T22:01:49.833' AS DateTime), 1, N'C:\Users\dinar\source\repos\BugTrackerV1\BugTrackerV1\Uploads\Screenshot_5.png', CAST(1899.00 AS Decimal(10, 2)), N'.png', 18)
SET IDENTITY_INSERT [dbo].[IssueAttachment] OFF
GO
SET IDENTITY_INSERT [dbo].[IssuePriority] ON 

INSERT [dbo].[IssuePriority] ([Id], [NamePriority]) VALUES (1, N'Высокий')
INSERT [dbo].[IssuePriority] ([Id], [NamePriority]) VALUES (2, N'Средний')
INSERT [dbo].[IssuePriority] ([Id], [NamePriority]) VALUES (3, N'Низкий')
SET IDENTITY_INSERT [dbo].[IssuePriority] OFF
GO
SET IDENTITY_INSERT [dbo].[IssueStatus] ON 

INSERT [dbo].[IssueStatus] ([Id], [NameStatus]) VALUES (1, N'В работе')
INSERT [dbo].[IssueStatus] ([Id], [NameStatus]) VALUES (2, N'Готово')
INSERT [dbo].[IssueStatus] ([Id], [NameStatus]) VALUES (3, N'На рассмотрении')
SET IDENTITY_INSERT [dbo].[IssueStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[IssueType] ON 

INSERT [dbo].[IssueType] ([Id], [NameType]) VALUES (1, N'Задача')
INSERT [dbo].[IssueType] ([Id], [NameType]) VALUES (2, N'Баг')
INSERT [dbo].[IssueType] ([Id], [NameType]) VALUES (3, N'История')
SET IDENTITY_INSERT [dbo].[IssueType] OFF
GO
SET IDENTITY_INSERT [dbo].[Label] ON 

INSERT [dbo].[Label] ([Id], [NameLabel], [CreatedById], [CreatedAt]) VALUES (1, N'UI', 1, CAST(N'2024-05-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Label] ([Id], [NameLabel], [CreatedById], [CreatedAt]) VALUES (2, N'UX', 1, CAST(N'2024-05-27T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Label] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (1, N'Просмотр задач', N'Разрешение на просмотр ошибок', N'TracVw')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (2, N'Создание задач', N'Разрешение на создание новых ошибок', N'TracCr')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (3, N'Редактирование задач', N'Разрешение на редактирование существующих ошибок', N'TracEd')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (4, N'Удаление задач', N'Разрешение на удаление ошибок', N'TracDel')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (5, N'Управление спринтами', N'Разрешение на управление спринтами', N'TracMSpr')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (6, N'Управление пользователями', N'Разрешение на управление пользователями', N'TracMUser')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (7, N'Просмотр отчетов', N'Разрешение на просмотр отчетов', N'TracVwRep')
INSERT [dbo].[Permission] ([Id], [NamePermission], [Description], [KeyPermission]) VALUES (8, N'Проверка задач', N'Разрешение на проверку и устранение ошибок', N'TracChTas')
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [NameProject], [KeyProject], [Description], [ProjectManagerId], [CreatedAt], [ActiveSprintId]) VALUES (1, N'ProjectTest', N'PROJ', N'Тестовый проект', 1, CAST(N'2024-05-24T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectUsers] ON 

INSERT [dbo].[ProjectUsers] ([Id], [ProjectId], [UserId]) VALUES (1, 1, 2)
INSERT [dbo].[ProjectUsers] ([Id], [ProjectId], [UserId]) VALUES (2, 1, 2)
SET IDENTITY_INSERT [dbo].[ProjectUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [NameRole], [Description]) VALUES (1, N'Администратор', N'Главный чел')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[RolePermissions] ON 

INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (1, 1, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (2, 1, 2)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (3, 1, 3)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (4, 1, 4)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (5, 1, 5)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (6, 1, 6)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (7, 1, 7)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId]) VALUES (8, 1, 8)
SET IDENTITY_INSERT [dbo].[RolePermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Sprint] ON 

INSERT [dbo].[Sprint] ([Id], [NameSprint], [StartDate], [EndDate], [ProjectId]) VALUES (1, N'Sprint 123', CAST(N'2024-05-29T00:00:00.000' AS DateTime), CAST(N'2024-06-10T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Sprint] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [LastName], [FirstName], [Patronymic], [Email], [PasswordHash], [Phone]) VALUES (1, N'Шигапов', N'Динар', N'Ринатович', N'dinarhertz@gmail.com', N'123', N'892321')
INSERT [dbo].[User] ([Id], [LastName], [FirstName], [Patronymic], [Email], [PasswordHash], [Phone]) VALUES (2, N'Шигапов', N'Айнур', N'Ринатович', N'ainurhertz@gmail.com', N'123', N'324234')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (2, 2, 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_IssuePriority] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[IssuePriority] ([Id])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_IssuePriority]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_IssueStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[IssueStatus] ([Id])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_IssueStatus]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_IssueType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[IssueType] ([Id])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_IssueType]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Project]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_User] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_User]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_User1] FOREIGN KEY([AssignedToId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_User1]
GO
ALTER TABLE [dbo].[IssueAttachment]  WITH CHECK ADD  CONSTRAINT [FK_IssueAttachment_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([Id])
GO
ALTER TABLE [dbo].[IssueAttachment] CHECK CONSTRAINT [FK_IssueAttachment_Issue]
GO
ALTER TABLE [dbo].[IssueAttachment]  WITH CHECK ADD  CONSTRAINT [FK_IssueAttachment_User] FOREIGN KEY([UploadedById])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[IssueAttachment] CHECK CONSTRAINT [FK_IssueAttachment_User]
GO
ALTER TABLE [dbo].[IssueComment]  WITH CHECK ADD  CONSTRAINT [FK_IssueComment_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([Id])
GO
ALTER TABLE [dbo].[IssueComment] CHECK CONSTRAINT [FK_IssueComment_Issue]
GO
ALTER TABLE [dbo].[IssueComment]  WITH CHECK ADD  CONSTRAINT [FK_IssueComment_User] FOREIGN KEY([CommentAuthorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[IssueComment] CHECK CONSTRAINT [FK_IssueComment_User]
GO
ALTER TABLE [dbo].[IssueHistory]  WITH CHECK ADD  CONSTRAINT [FK_IssueHistory_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([Id])
GO
ALTER TABLE [dbo].[IssueHistory] CHECK CONSTRAINT [FK_IssueHistory_Issue]
GO
ALTER TABLE [dbo].[LabelIssue]  WITH CHECK ADD  CONSTRAINT [FK_LabelIssue_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([Id])
GO
ALTER TABLE [dbo].[LabelIssue] CHECK CONSTRAINT [FK_LabelIssue_Issue]
GO
ALTER TABLE [dbo].[LabelIssue]  WITH CHECK ADD  CONSTRAINT [FK_LabelIssue_Label] FOREIGN KEY([LabelId])
REFERENCES [dbo].[Label] ([Id])
GO
ALTER TABLE [dbo].[LabelIssue] CHECK CONSTRAINT [FK_LabelIssue_Label]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Sprint] FOREIGN KEY([ActiveSprintId])
REFERENCES [dbo].[Sprint] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Sprint]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_User] FOREIGN KEY([ProjectManagerId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_User]
GO
ALTER TABLE [dbo].[ProjectUsers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUsers_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectUsers] CHECK CONSTRAINT [FK_ProjectUsers_Project]
GO
ALTER TABLE [dbo].[ProjectUsers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUsers_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ProjectUsers] CHECK CONSTRAINT [FK_ProjectUsers_User]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permission]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Role]
GO
ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_Project]
GO
ALTER TABLE [dbo].[StepsToReproduce]  WITH CHECK ADD  CONSTRAINT [FK_StepsToReproduce_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([Id])
GO
ALTER TABLE [dbo].[StepsToReproduce] CHECK CONSTRAINT [FK_StepsToReproduce_Issue]
GO
ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Permission]
GO
ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_User]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User]
GO
