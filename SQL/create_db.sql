USE [master]
GO

----CREATE databse--------------
CREATE DATABASE [Library]
GO

---create tables------------------

USE [Library]
GO

---------------------------------[Authors]-------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-----------------------------------[Users]--------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

----------------------------------[Books]-----------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[TotalCount] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_TotalCount]  DEFAULT ((10)) FOR [TotalCount]
GO

ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors_AuthorId]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--------------------------------[BookCopy]------------------------------------------------

CREATE TABLE [dbo].[BookCopy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bookId] [int] NOT NULL,
	[isbn] [varchar](20) NULL,
	[publicationDate] [date] NOT NULL,
	[publicationPlace] [varchar](50) NOT NULL,
	[isActive] [bit] NOT NULL,
	[activeFrom] [date] NOT NULL,
	[activeTo] [date] NULL,
	[BorroweById] [int] NULL,
 CONSTRAINT [PK_BookCopy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BookCopy] ADD  CONSTRAINT [DF_BookCopy_isActive]  DEFAULT ((1)) FOR [isActive]
GO

ALTER TABLE [dbo].[BookCopy] ADD  CONSTRAINT [DF_BookCopy_activeFrom]  DEFAULT (getdate()) FOR [activeFrom]
GO

ALTER TABLE [dbo].[BookCopy]  WITH CHECK ADD  CONSTRAINT [FK_BookCopy_Books] FOREIGN KEY([BorroweById])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[BookCopy] CHECK CONSTRAINT [FK_BookCopy_Books]
GO

ALTER TABLE [dbo].[BookCopy]  WITH CHECK ADD  CONSTRAINT [FK_BookCopy_Users] FOREIGN KEY([BorroweById])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[BookCopy] CHECK CONSTRAINT [FK_BookCopy_Users]
GO

----------------------------------[Register]--------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Register](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BookCopyId] [int] NOT NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_BookCopy] FOREIGN KEY([BookCopyId])
REFERENCES [dbo].[BookCopy] ([id])
GO

ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_BookCopy]
GO

ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Users_UserId]
GO

------------------------[UsersWishlist ]------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersWishlist ](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[bookId] [int] NOT NULL,
 CONSTRAINT [PK_UsersWhishlist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsersWishlist ]  WITH CHECK ADD  CONSTRAINT [FK_UsersWhishlist_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[UsersWishlist ] CHECK CONSTRAINT [FK_UsersWhishlist_Users]
GO

ALTER TABLE [dbo].[UsersWishlist ]  WITH CHECK ADD  CONSTRAINT [FK_UsersWhishlist_UsersWhishlist] FOREIGN KEY([bookId])
REFERENCES [dbo].[Books] ([Id])
GO

ALTER TABLE [dbo].[UsersWishlist ] CHECK CONSTRAINT [FK_UsersWhishlist_UsersWhishlist]
GO


