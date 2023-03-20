USE [KSMT]
GO
/****** Object:  Table [dbo].[AnswerResult]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnswerResult](
	[IdRegistratedUser] [int] NOT NULL,
	[CompetitionId] [int] NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[Mark] [float] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_AnswerResult_1] PRIMARY KEY CLUSTERED 
(
	[IdRegistratedUser] ASC,
	[CompetitionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[BirthDate] [date] NOT NULL,
	[isResigned] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competitions]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competitions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](250) NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Question] [nvarchar](max) NULL,
	[RightAnswer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Competitions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[ClassName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[JoinDate] [date] NULL,
	[Specification] [nvarchar](50) NULL,
	[Section] [nvarchar](50) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supports]    Script Date: 3/20/2023 9:09:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Position] [nvarchar](150) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Supports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AnswerResult] ADD  CONSTRAINT [DF_AnswerResult_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[AnswerResult]  WITH CHECK ADD  CONSTRAINT [FK_AnswerResult_Competitions1] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competitions] ([Id])
GO
ALTER TABLE [dbo].[AnswerResult] CHECK CONSTRAINT [FK_AnswerResult_Competitions1]
GO
ALTER TABLE [dbo].[AnswerResult]  WITH CHECK ADD  CONSTRAINT [FK_AnswerResult_Registration] FOREIGN KEY([IdRegistratedUser])
REFERENCES [dbo].[Registration] ([Id])
GO
ALTER TABLE [dbo].[AnswerResult] CHECK CONSTRAINT [FK_AnswerResult_Registration]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_AspNetUsers1] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_AspNetUsers1]
GO


/****** data test ******/
insert into AspNetRoles values('role1', 'Admin')
insert into AspNetRoles values('role2', 'Employee')
insert into AspNetRoles values('role3', 'Student')
insert into AspNetUsers values('AdminId','admin@admin.vn', 'True' ,	'AJ2xZaz2NewNq39o4ba+OBqgCCrbDJNkfI7cMrhzAXm/P3cqcbURxONhiR5H4RzoBA==',	'eb99fc5e-9689-4976-aa83-13d0fe090bd3',	'0123456789',	'False',	'False',	'1999-01-01' , 'True'	,0	,'admin@admin.vn',	'ADMIN A'	,'a',	'1970-01-01'	,'False',	NULL)
insert into AspNetUsers values('StudentId','student@student.vn', 'True' ,	'AJ2xZaz2NewNq39o4ba+OBqgCCrbDJNkfI7cMrhzAXm/P3cqcbURxONhiR5H4RzoBA==',	'eb99fc5e-9689-4976-aa83-13d0fe090bd3',	'0123456789',	'False',	'False',	'1999-01-01' , 'True'	,0	,'student@student.vn',	N'Lê Đức An'	,'avatar2',	'2000-01-02'	,'False',	NULL)
insert into AspNetUsers values('EmployeeId','employee@employee.vn', 'True' ,	'AJ2xZaz2NewNq39o4ba+OBqgCCrbDJNkfI7cMrhzAXm/P3cqcbURxONhiR5H4RzoBA==',	'eb99fc5e-9689-4976-aa83-13d0fe090bd3',	'0123456789',	'False',	'False',	'1999-01-01' , 'True'	,0	,'employee@employee.vn',	N'Nguyễn Thị Hoa'	,'avatar2',	'2000-01-02'	,'False',	NULL)
GO
insert into AspNetUserRoles values('role1','AdminId')
insert into AspNetUserRoles values('role2','StudentId')
insert into AspNetUserRoles values('role3','EmployeeId')
go 
insert into Competitions(Title,Description,StartDate,EndDate,Question,RightAnswer) values( 'Titile',	'Description',	'2023-03-08'	,'2023-03-24'	,N'Tại sao bảo vệ môi trường là vấn đề quan trọng đối với cuộc sống của chúng ta?',N'Chỉ ra tầm quan trọng của việc bảo vệ môi trường đối với sức khỏe của con người. Liên kết việc bảo vệ môi trường với an sinh xã hội và kinh tế của con người. Nêu rõ tầm quan trọng của bảo vệ môi trường đối với các thế hệ tương lai. Cung cấp ví dụ về hành động cụ thể mà mỗi người có thể làm để đóng góp vào việc bảo vệ môi trường. Tùy vào độ chi tiết và phong cách trả lời của học sinh, các ý trên có thể được bổ sung hoặc cụ thể hơn.')
insert into Competitions(Title,Description,StartDate,EndDate,Question,RightAnswer) values( 'Titile',	'Description',	'2023-03-08'	,'2023-03-24'	,N'Tại sao sử dụng năng lượng xanh là cần thiết cho việc bảo vệ môi trường và phát triển bền vững ?',N'Giải thích tầm quan trọng của việc sử dụng năng lượng xanh trong giảm thiểu ô nhiễm môi trường và biến đổi khí hậu. Liên kết sử dụng năng lượng xanh với việc tăng cường an sinh xã hội và kinh tế bền vững. Nêu rõ tầm quan trọng của năng lượng xanh trong việc bảo vệ tài nguyên thiên nhiên và đảm bảo sức khỏe cho các thế hệ tương lai. Cung cấp ví dụ về các nguồn năng lượng xanh hiệu quả và hành động cụ thể mà mỗi người có thể thực hiện để sử dụng năng lượng xanh.')
	


	


