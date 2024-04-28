USE [Paperless v1.0.0]
GO

/****** Object:  Table [dbo].[ColorTimer]    Script Date: 21/04/2024 11:03:53 pm ******/
SET ANSI_NULLS ON
GO

/*** User table ***/

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*** Color Timer table ***/

CREATE TABLE [dbo].[ColorTimer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NULL,
	[ColorHexCode] [nvarchar](7) NULL,
	[TotalTimeElapsed] [bigint] NOT NULL,
	[LastTimeSynced] [datetime2](7) NULL,
	[IsRunning] [bit] NOT NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ColorTimer] ADD  CONSTRAINT [DF_ColorTimer_TotalTimeElapsed]  DEFAULT ((0)) FOR [TotalTimeElapsed]
GO

ALTER TABLE [dbo].[ColorTimer] ADD  CONSTRAINT [DF_ColorTimer_IsRunning]  DEFAULT ((0)) FOR [IsRunning]
GO

ALTER TABLE [dbo].[ColorTimer]  WITH CHECK ADD CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ColorTimer] CHECK CONSTRAINT [FK_UserId]
GO