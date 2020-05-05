
CREATE DATABASE PhoneStoreDB
GO

USE PhoneStoreDB
GO

CREATE TABLE [dbo].[PhoneBook] (
    [PhoneBookId]   INT         IDENTITY (1, 1) NOT NULL,
    [PhoneBookName] NVARCHAR (MAX) NULL
);

GO
ALTER TABLE [dbo].[PhoneBook]
    ADD CONSTRAINT [PK_PhoneBook] PRIMARY KEY CLUSTERED ([PhoneBookId] ASC);

GO
CREATE TABLE [dbo].[Entries] (
    [EntryId]     INT            IDENTITY (1, 1) NOT NULL,
    [PhoneBookId] INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [PhoneNumber] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Entries_PhoneBookId]
    ON [dbo].[Entries]([PhoneBookId] ASC);


GO
ALTER TABLE [dbo].[Entries]
    ADD CONSTRAINT [PK_Entries] PRIMARY KEY CLUSTERED ([EntryId] ASC);


GO
ALTER TABLE [dbo].[Entries]
    ADD CONSTRAINT [FK_Entries_PhoneBook_PhoneBookId] FOREIGN KEY ([PhoneBookId]) REFERENCES [dbo].[PhoneBook] ([PhoneBookId]) ON DELETE CASCADE;


