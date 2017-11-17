DROP TABLE [Knowledge];
CREATE TABLE [dbo].[Knowledge] (
    [IDstate] INT         NOT NULL,
    [Layout]  NCHAR (17)  NOT NULL,
    [Pins]    NCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IDstate] ASC)
);

