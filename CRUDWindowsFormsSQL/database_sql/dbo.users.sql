CREATE TABLE [dbo].[users] (
    [user_id]  INT           IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (250) NULL,
    [password] VARCHAR (250) NULL,
    [email]    VARCHAR (250) NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([user_id] ASC)
);

