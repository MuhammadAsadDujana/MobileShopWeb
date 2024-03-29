USE [dbMobileShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalProducts]    Script Date: 4/2/2023 5:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[sp_GetTotalProducts]
  as 

  select b.Id, b.BrandName, Count(p.Id) TotalProducts from Products p 
  right join Brands b on p.BrandId = b.Id
  Group by b.Id, b.BrandName
  order by BrandName

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/2/2023 5:08:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Brands]    Script Date: 4/2/2023 5:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Colors]    Script Date: 4/2/2023 5:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductColors]    Script Date: 4/2/2023 5:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColors](
	[ProductId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
 CONSTRAINT [PK_ProductColors] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/2/2023 5:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230207231834_NewDB', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230209225709_Some_Changes_in_DB', N'6.0.10')
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1, N'Samsung')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (3, N'Apple')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (13, N'Sony')
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1, N'Green')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (2, N'Black')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (3, N'White')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (4, N'Red')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (5, N'Golden')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (6, N'Pink')
SET IDENTITY_INSERT [dbo].[Colors] OFF
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (16, 1)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (10, 2)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (11, 2)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (10, 3)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (11, 4)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (13, 4)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (14, 4)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (16, 4)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (18, 4)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (13, 5)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (14, 5)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (16, 5)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (18, 5)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (14, 6)
INSERT [dbo].[ProductColors] ([ProductId], [ColorId]) VALUES (18, 6)
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Price], [BrandId]) VALUES (10, N'Iphone 7', CAST(50000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [BrandId]) VALUES (11, N'Galaxy A13 SM-A137F', CAST(140000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [BrandId]) VALUES (13, N'Iphone X', CAST(120000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [BrandId]) VALUES (14, N'Note 12', CAST(50000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [BrandId]) VALUES (16, N'Galaxy S10', CAST(50000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [BrandId]) VALUES (18, N'Iphone 12', CAST(200000.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[ProductColors]  WITH CHECK ADD  CONSTRAINT [FK_ProductColors_Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductColors] CHECK CONSTRAINT [FK_ProductColors_Colors_ColorId]
GO
ALTER TABLE [dbo].[ProductColors]  WITH CHECK ADD  CONSTRAINT [FK_ProductColors_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductColors] CHECK CONSTRAINT [FK_ProductColors_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
