﻿CREATE TABLE [dbo].[SPORTSMENS] (
    [IDSPORTSMEN]      INT           NOT NULL,
    [IDGROUP]          INT           NOT NULL,
    [SPORTSMEN_NAME]   NVARCHAR (20) NULL,
    [SPORTSMEN_FAMIL]  NVARCHAR (20) NULL,
    [SPORTSMEN_MIDDLE] NVARCHAR (20) NULL,
    [BDAY]             DATE          NULL,
    [USERID] INT NOT NULL, 
    CONSTRAINT [PK_SPORTSMEN] PRIMARY KEY CLUSTERED ([IDSPORTSMEN] ASC),
    CONSTRAINT [FK_SPORTSMEN_GROUPS] FOREIGN KEY ([IDGROUP]) REFERENCES [dbo].[GROUPS] ([IDGROUP]),
	CONSTRAINT [FK_SPORTSMEN_USERS] FOREIGN KEY ([USERID]) REFERENCES [dbo].[USERS] ([ID])
);

