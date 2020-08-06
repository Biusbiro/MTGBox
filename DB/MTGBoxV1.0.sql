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

alter table [dbo].[decks] add CONSTRAINT [FK_decks_1_users] FOREIGN KEY (id_user) REFERENCES [dbo].[users](id);
GO

CREATE TABLE [dbo].[image_uris]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [small] NVARCHAR(300) NULL, 
    [normal] NVARCHAR(300) NULL, 
    [large] NVARCHAR(300) NULL, 
    [png] NVARCHAR(300) NULL, 
    [art_crop] NVARCHAR(300) NULL, 
    [border_crop] NVARCHAR(300) NULL, 
    [id_card] INT NOT NULL
)

alter table [dbo].[image_uris] add CONSTRAINT [FK_image_uris_1_cards] FOREIGN KEY (id_card) REFERENCES [dbo].[cards](id_card);
GO

CREATE TABLE [dbo].[prices]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [usd] NCHAR(10) NULL, 
    [usd_foil] NCHAR(10) NULL, 
    [eur] NCHAR(10) NULL, 
    [tix] NCHAR(10) NULL, 
    [id_card] INT NOT NULL
)

alter table [dbo].[prices] add CONSTRAINT [FK_prices_1_cards] FOREIGN KEY (id_card) REFERENCES [dbo].[cards](id_card);
GO

CREATE TABLE [dbo].[purchase_uris]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tcgplayer] NVARCHAR(300) NULL, 
    [cardmarket] NVARCHAR(300) NULL, 
    [cardhoarder] NVARCHAR(300) NULL, 
    [id_card] INT NOT NULL
)

alter table [dbo].[purchase_uris] add CONSTRAINT [FK_purchase_uris_1_cards] FOREIGN KEY (id_card) REFERENCES [dbo].[cards](id_card);
GO

CREATE TABLE [dbo].[related_uris]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [gatherer] NVARCHAR(300) NULL, 
    [tcgplayer_decks] NVARCHAR(300) NULL, 
    [edhrec] NVARCHAR(300) NULL, 
    [mtgtop8] NVARCHAR(300) NULL, 
    [id_card] NCHAR(10) NOT NULL
)

alter table [dbo].[related_uris] add CONSTRAINT [FK_related_uris_1_cards] FOREIGN KEY (id_card) REFERENCES [dbo].[cards](id_card);
GO

CREATE TABLE [dbo].[legalities]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [standard] NVARCHAR(20) NULL, 
    [future] NVARCHAR(20) NULL, 
    [historic] NVARCHAR(20) NULL, 
    [pioneer] NVARCHAR(20) NULL, 
    [legacy] NVARCHAR(20) NULL, 
    [pauper] NVARCHAR(20) NULL, 
    [vintage] NVARCHAR(20) NULL, 
    [penny] NVARCHAR(20) NULL, 
    [commander] NVARCHAR(20) NULL, 
    [brawl] NVARCHAR(20) NULL, 
    [duel] NVARCHAR(20) NULL, 
    [oldschool] NVARCHAR(20) NULL, 
    [id_card] INT NOT NULL
)

alter table [dbo].[legalities] add CONSTRAINT [FK_legalities_1_cards] FOREIGN KEY (id_card) REFERENCES [dbo].[cards](id_card);
GO

CREATE TABLE [dbo].[catalogs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [object] NVARCHAR(300) NULL, 
    [uri] NVARCHAR(300) NULL, 
    [total_values] NVARCHAR(300) NULL, 
    [data] NVARCHAR(300) NULL
)