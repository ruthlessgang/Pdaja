USE [WebProbiz]
GO

/****** Object:  Table [dbo].[LoanRequest]    Script Date: 08/06/2021 18:16:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE [dbo].[LoanRequest] ADD [FullName] [varchar] (100) NULL
	,[Email] [varchar] (100) NULL
	,[Handphone] [varchar] (20) NULL
	,[ReferralCode] [varchar] (20) NULL
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RFWHATSAPP] (
	[ID] [uniqueidentifier] NOT NULL
	,[PhoneName] [varchar](20) NOT NULL
	,[PhoneNumber] [varchar](20) NOT NULL
	,[BodyText] [text] NOT NULL
	,[CreatedDate] [datetime] NOT NULL
	,[CreatedBy] [varchar](20) NOT NULL
	,[IsActive] [bit] NOT NULL
	,CONSTRAINT [PK_RFWHATSAPP] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (
		PAD_INDEX = OFF
		,STATISTICS_NORECOMPUTE = OFF
		,IGNORE_DUP_KEY = OFF
		,ALLOW_ROW_LOCKS = ON
		,ALLOW_PAGE_LOCKS = ON
		) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[RFWHATSAPP] (
	[ID]
	,[PhoneName]
	,[PhoneNumber]
	,[BodyText]
	,[CreatedDate]
	,[CreatedBy]
	,[IsActive]
	)
VALUES (
	N'5af1f81a-6d05-4d35-b8cd-82dd7d7413c1'
	,N'Agent LC/PDaja'
	,N'6281295884217'
	,N'Halo%20Admin%20PDaja.'
	,getdate()
	,N'system'
	,1
	)
GO

ALTER TABLE [dbo].[RFWHATSAPP] ADD CONSTRAINT [DF_RFWHATSAPP_ID] DEFAULT(newid())
FOR [ID]
GO

ALTER TABLE [dbo].[RFWHATSAPP] ADD CONSTRAINT [DF_RFWHATSAPP_CreatedDate] DEFAULT(getdate())
FOR [CreatedDate]
GO


