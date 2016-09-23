CREATE TABLE [dbo].[Team] (
    [TeamRef]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [TeamName] NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([TeamRef] ASC)
);

