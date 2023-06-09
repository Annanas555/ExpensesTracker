USE [ExpenditureTracker]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 05.05.2023 18:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 05.05.2023 18:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[ExpenseId] [int] IDENTITY(1,1) NOT NULL,
	[ExpenseAmount] [decimal](18, 2) NOT NULL,
	[ExpenseDate] [datetime] NOT NULL,
	[ExpenseDescription] [nvarchar](500) NOT NULL,
	[UserId] [int] NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK__Expenses__1445CFD36D00890C] PRIMARY KEY CLUSTERED 
(
	[ExpenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05.05.2023 18:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [varbinary](max) NOT NULL,
 CONSTRAINT [PK__Users__1788CC4C79841144] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [UserId]) VALUES (1, N'Транспорт', 2)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [UserId]) VALUES (2, N'Продукты', 2)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [UserId]) VALUES (3, N'Стипендия', 2)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Expenses] ON 

INSERT [dbo].[Expenses] ([ExpenseId], [ExpenseAmount], [ExpenseDate], [ExpenseDescription], [UserId], [CategoryId]) VALUES (1, CAST(-70.00 AS Decimal(18, 2)), CAST(N'2023-05-05T17:42:26.240' AS DateTime), N'Проезд на автобусе', 2, 1)
INSERT [dbo].[Expenses] ([ExpenseId], [ExpenseAmount], [ExpenseDate], [ExpenseDescription], [UserId], [CategoryId]) VALUES (2, CAST(-264.00 AS Decimal(18, 2)), CAST(N'2023-05-05T17:42:47.420' AS DateTime), N'Покупка сладостей к чаю', 2, 2)
SET IDENTITY_INSERT [dbo].[Expenses] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password]) VALUES (2, N'Anna', 0x5AF8DF54191C02842835FF8714D7A1F4)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK__Categorie__UserI__267ABA7A] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK__Categorie__UserI__267ABA7A]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK__Expenses__Catego__29572725] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK__Expenses__Catego__29572725]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Users]
GO
