USE [Library]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 
GO
INSERT [dbo].[Authors] ([Id], [Surname], [Name]) VALUES (1, N'Sienkiewicz', N'Henryk')
GO
INSERT [dbo].[Authors] ([Id], [Surname], [Name]) VALUES (2, N'Mickiewicz', N'Adam')
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([Id], [Title], [AuthorId], [TotalCount]) VALUES (1, N'Ogniem i mieczem', 1, 2)
GO
INSERT [dbo].[Books] ([Id], [Title], [AuthorId], [TotalCount]) VALUES (2, N'Potop', 1, 1)
GO
INSERT [dbo].[Books] ([Id], [Title], [AuthorId], [TotalCount]) VALUES (3, N'Pan Wołodyjowski', 1, 1)
GO
INSERT [dbo].[Books] ([Id], [Title], [AuthorId], [TotalCount]) VALUES (4, N'Pan Tadeusz', 2, 4)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Login], [Email], [Surname], [Name], [IsActive]) VALUES (1, N'test', N'test@library.pl', N'Testowy', N'Test', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[BookCopy] ON 
GO
INSERT [dbo].[BookCopy] ([id], [bookId], [isbn], [publicationDate], [publicationPlace], [isActive], [activeFrom], [activeTo], [BorroweById]) VALUES (1, 1, N'000001', CAST(N'2006-02-01' AS Date), N'Warszawa', 1, CAST(N'2020-10-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[BookCopy] ([id], [bookId], [isbn], [publicationDate], [publicationPlace], [isActive], [activeFrom], [activeTo], [BorroweById]) VALUES (3, 2, N'000010', CAST(N'2001-01-01' AS Date), N'Poznan', 1, CAST(N'2020-10-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[BookCopy] ([id], [bookId], [isbn], [publicationDate], [publicationPlace], [isActive], [activeFrom], [activeTo], [BorroweById]) VALUES (4, 3, N'000011', CAST(N'2000-05-06' AS Date), N'Lublin', 1, CAST(N'2020-10-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[BookCopy] ([id], [bookId], [isbn], [publicationDate], [publicationPlace], [isActive], [activeFrom], [activeTo], [BorroweById]) VALUES (5, 1, N'000100', CAST(N'2020-10-13' AS Date), N'Warszawa', 1, CAST(N'2020-10-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[BookCopy] ([id], [bookId], [isbn], [publicationDate], [publicationPlace], [isActive], [activeFrom], [activeTo], [BorroweById]) VALUES (1005, 4, N'000101', CAST(N'2008-08-11' AS Date), N'Warszawa', 1, CAST(N'2020-10-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[BookCopy] ([id], [bookId], [isbn], [publicationDate], [publicationPlace], [isActive], [activeFrom], [activeTo], [BorroweById]) VALUES (1006, 4, N'000110', CAST(N'1997-03-08' AS Date), N'Gdansk', 1, CAST(N'2020-10-15' AS Date), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[BookCopy] OFF
GO
