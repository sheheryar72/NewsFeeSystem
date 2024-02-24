USE [NewsFeeSystem]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2/24/2024 5:48:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Comment_ID] [int] NOT NULL,
	[Post_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Comment] [nvarchar](1000) NOT NULL,
	[Created_At] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Comment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 2/24/2024 5:48:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[follower_ID] [int] NOT NULL,
	[following_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[follower_ID] ASC,
	[following_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 2/24/2024 5:48:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Post_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Title] [nvarchar](300) NULL,
	[Description] [nvarchar](1000) NULL,
	[Image_Url] [nvarchar](255) NOT NULL,
	[Created_At] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Post_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shares]    Script Date: 2/24/2024 5:48:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shares](
	[Share_ID] [int] NOT NULL,
	[Post_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Created_At] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Share_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/24/2024 5:48:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] NOT NULL,
	[Username] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Created_At] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([Post_ID])
REFERENCES [dbo].[Posts] ([Post_ID])
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD FOREIGN KEY([follower_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD FOREIGN KEY([following_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Shares]  WITH CHECK ADD FOREIGN KEY([Post_ID])
REFERENCES [dbo].[Posts] ([Post_ID])
GO
ALTER TABLE [dbo].[Shares]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
