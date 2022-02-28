USE [NewShore]
GO

/****** Objeto: Table [dbo].[Journey] Fecha del script: 27/02/2022 9:22:07 p. m. ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Flight] (
    [IdFlight]    INT         IDENTITY (1, 1) NOT NULL,
    [IdTransport] INT         NOT NULL,
    [Origin]      VARCHAR (3) NOT NULL,
    [Destination] VARCHAR (3) NOT NULL,
    [Price]       FLOAT (53)  NULL
);



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Journey] (
    [IdJourney]   INT         IDENTITY (1, 1) NOT NULL,
    [Origin]      VARCHAR (3) NULL,
    [Destination] VARCHAR (3) NULL,
    [Price]       FLOAT (53)  NULL
);



/****** Objeto: Table [dbo].[JourneyFlights] Fecha del script: 27/02/2022 9:22:59 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JourneyFlights] (
    [IdJourneyFlights] INT IDENTITY (1, 1) NOT NULL,
    [IdJourney]        INT NOT NULL,
    [IdFlight]         INT NOT NULL
);

/****** Objeto: Table [dbo].[Transport] Fecha del script: 27/02/2022 9:23:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transport] (
    [IdTransport]   INT         IDENTITY (1, 1) NOT NULL,
    [FlightCarrier] VARCHAR (3) NULL,
    [FlightNumber]  VARCHAR (4) NULL
);
