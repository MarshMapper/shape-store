CREATE TABLE [dbo].[Location] (
    [LocationId]  INT               IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (256)    NULL,
    [Address1]    NVARCHAR (256)    NULL,
    [Address2]    NVARCHAR (256)    NULL,
    [City]        NVARCHAR (96)     NULL,
    [State]       NVARCHAR (50)     NULL,
    [PostalCode]  NVARCHAR (16)     NULL,
    [Phone]       NVARCHAR (20)     NULL,
    [Phone2]      NVARCHAR (50)     NULL,
    [Url]         NVARCHAR (512)    NULL,
    [Coordinates] [sys].[geography] NULL,
    [IsOpen]      BIT               NULL,
    [CategoryId]  INT               NULL,
    [IconId]      INT               NULL,
    [Notes]       NVARCHAR (1024)   NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([LocationId] ASC),
    CONSTRAINT [FK_Location_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

