USE [mytestdb]
GO

/****** Object:  Table [dbo].[pendaftarantable]    Script Date: 2025-01-26 07:37:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pendaftarantable](
	[companyName] [varchar](50) NOT NULL,
	[npwp] [varchar](50) NOT NULL,
	[directorName] [varchar](50) NULL,
	[picName] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[phoneNumber] [varchar](50) NULL,
	[npwpFile] [varchar](250) NULL,
	[powerOfAttorneyFile] [varchar](250) NULL,
 CONSTRAINT [PK_pendaftarantable] PRIMARY KEY CLUSTERED 
(
	[npwp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

