CREATE TABLE [dbo].[Cte] (
    [codigo]           INT             IDENTITY (1, 1) NOT NULL,
	[dataEnvio]        DATETIME        NULL,
    [status]           VARCHAR (255)   NULL,
    [numeroCte]        VARCHAR (50)    NOT NULL,
    [NumeroTransporte] VARCHAR (50)    NULL,
    [codTranspMatriz]  VARCHAR (50)    NULL,
    [codTranspFilial]  VARCHAR (50)    NULL,
    [cnpjEmitente]     VARCHAR (50)    NULL,
    [cnpjTomador]      VARCHAR (50)    NULL,
    [serieCte]         INT             NULL,
    [modeloCte]        INT             NULL,
    [dtEmissaoCte]     DATE            NULL,
    [cdIbgeOrigem]     INT             NULL,
    [cdIbgeDestino]    INT             NULL,
    [tipoDoc]          VARCHAR (1)     NULL,
    [valorFrete]       DECIMAL (15, 3) NULL,
    [valorImposto]     DECIMAL (15, 3) NULL,
    [chaveCTE]         VARCHAR (50)    NULL,
    [xmlCte]           TEXT            NULL,
    [chaveNfe]         VARCHAR (50)    NULL,
    [DtEmissaoNf]      DATE            NULL,
    PRIMARY KEY CLUSTERED ([codigo] ASC)
);

CREATE TABLE [dbo].[Historico] (
    [codigo]         INT           IDENTITY (1, 1) NOT NULL,
    [tipoEnvio]      VARCHAR (50)  NOT NULL,
    [usuario]        VARCHAR (50)  NOT NULL,
    [status]         VARCHAR (255) NOT NULL,
    [dataTarefa]     DATETIME      NULL,
    [codigoRegistro] INT           NULL,
    PRIMARY KEY CLUSTERED ([codigo] ASC)
);
CREATE TABLE [dbo].[Usuarios] (
    [UserId]     INT          IDENTITY (1, 1) NOT NULL,
    [UserName]   VARCHAR (50) NOT NULL,
    [LoginName]  VARCHAR (50) NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NULL,
    [ContactNo]  VARCHAR (15) NULL,
    [Address]    VARCHAR (50) NULL,
    [IsApporved] INT          NULL,
    [Status]     INT          NULL,
    [TotalCnt]   INT          NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);