CREATE TABLE [dbo].[Player] (
    [PlayerRef]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [TeamRef]    UNIQUEIDENTIFIER NOT NULL,
    [PlayerName] NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([PlayerRef] ASC),
    CONSTRAINT [FK_Player_Team] FOREIGN KEY ([TeamRef]) REFERENCES [dbo].[Team] ([TeamRef])
);

