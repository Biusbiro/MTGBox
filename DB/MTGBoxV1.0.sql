CREATE TABLE [dbo].[configurations]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [version] NCHAR(10) NOT NULL
)
GO

insert into [dbo].[configurations] (version) values  ('1.0.0');

CREATE TABLE [dbo].[users] (
    [Id]       INT           NOT NULL IDENTITY,
    [name]     VARCHAR (50)  NOT NULL,
    [login]    VARCHAR (50)  NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[decks] (
    [Id]          INT           NOT NULL IDENTITY,
    [name]        NCHAR (200)   NOT NULL,
    [description] VARCHAR (500) NOT NULL,
    [id_user]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_decks_1_user] FOREIGN KEY ([id_user]) REFERENCES [dbo].[users] ([Id])
);

alter table [dbo].[decks] add CONSTRAINT [FK_decks_1_user] FOREIGN KEY (id_user) REFERENCES [dbo].[users](id);
GO