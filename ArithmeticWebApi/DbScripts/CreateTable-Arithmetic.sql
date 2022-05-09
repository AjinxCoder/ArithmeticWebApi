SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Arithmetic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstNumber] [decimal](18, 2) NULL,
	[SecondNumber] [decimal](18, 2) NULL,
	[Operator] [nvarchar](20) NULL,
	[Result] [decimal](18, 2) NULL,
	[CalculatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Arithmetic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Arithmetic] ADD  CONSTRAINT [DF_Arithmetic_CalculatedAt]  DEFAULT (getdate()) FOR [CalculatedOn]
GO