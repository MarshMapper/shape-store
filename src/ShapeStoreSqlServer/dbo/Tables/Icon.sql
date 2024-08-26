CREATE TABLE [dbo].[Icon] (
    [IconId]      INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (256) NULL,
    CONSTRAINT [PK_Icon] PRIMARY KEY CLUSTERED ([IconId] ASC)
);

