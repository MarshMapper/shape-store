CREATE TABLE [dbo].[Category] (
    [CategoryId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [IconId]      INT            NULL,
    [Description] NVARCHAR (256) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_Category_Icon] FOREIGN KEY ([IconId]) REFERENCES [dbo].[Icon] ([IconId])
);

