--Criação de banco para testes
--Banco TGView - Banco onde fica e View da TGestiona
--Banco TG - Banco novo
CREATE DATABASE TGView;
CREATE DATABASE TG;
--Banco TGView
GO
USE TGView
GO
CREATE TABLE Cte (
    [numeroCte]             VARCHAR (50)    NOT NULL,
    [dataEnvio]             DATETIME        NULL,
    [status]                VARCHAR (255)   NULL,
    [NumeroTransporte]      VARCHAR (50)    NULL,
    [codTranspMatriz]       VARCHAR (50)    NULL,
    [codTranspFilial]       VARCHAR (50)    NULL,
    [cnpjEmitente]          VARCHAR (50)    NULL,
    [cnpjTomador]           VARCHAR (50)    NULL,
    [serieCte]              INT             NULL,
    [modeloCte]             INT             NULL,
    [dtEmissaoCte]          DATE            NULL,
    [cdIbgeOrigem]          VARCHAR (10)    NULL,
    [cdIbgeDestino]         VARCHAR (10)    NULL,
    [tipoDoc]               VARCHAR (1)     NULL,
    [valorFrete]            DECIMAL (15, 3) NULL,
    [valorImposto]          DECIMAL (15, 3) NULL,
    [chaveCTE]              VARCHAR (50)    NULL,
    [xmlCte]                TEXT            NULL,
    [chaveNfe]              VARCHAR (50)    NULL,
    [DtEmissaoNf]           DATE            NULL,
    PRIMARY KEY CLUSTERED ([codigo] ASC)
);
GO
CREATE VIEW V_Cte AS(SELECT * FROM Cte);
--Banco TG
GO
USE TG
GO
CREATE TABLE temp_Cte (
    [chaveRegistro]    VARCHAR (255)   NULL,
-------------------------------------------------------------------------------------------------------------	
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
    [DtEmissaoNf]      DATE            NULL
   
);
GO
CREATE TABLE Cte (
    [codigo]                INT             IDENTITY (1, 1) NOT NULL,
	[dataImportacao]        DATETIME        NULL,
    [chaveRegistro]         VARCHAR (255)   NULL,
    [responseWS]            VARCHAR (255)   NULL,
    [numeroTentativasEnvio] INT             CONSTRAINT [numeroTentativasEnvioDefault] DEFAULT ((0)) NULL,
	[dataEnvio]             DATETIME        NULL,
    [status]                VARCHAR (255)   NULL,
-----------------------------------------------------------------------------------------------------------------	
    [numeroCte]             VARCHAR (50)    NOT NULL,
    [NumeroTransporte]      VARCHAR (50)    NULL,
    [codTranspMatriz]       VARCHAR (50)    NULL,
    [codTranspFilial]       VARCHAR (50)    NULL,
    [cnpjEmitente]          VARCHAR (50)    NULL,
    [cnpjTomador]           VARCHAR (50)    NULL,
    [serieCte]              INT             NULL,
    [modeloCte]             INT             NULL,
    [dtEmissaoCte]          DATE            NULL,
    [cdIbgeOrigem]          VARCHAR (10)    NULL,
    [cdIbgeDestino]         VARCHAR (10)    NULL,
    [tipoDoc]               VARCHAR (1)     NULL,
    [valorFrete]            DECIMAL (15, 3) NULL,
    [valorImposto]          DECIMAL (15, 3) NULL,
    [chaveCTE]              VARCHAR (50)    NULL,
    [xmlCte]                TEXT            NULL,
    [chaveNfe]              VARCHAR (50)    NULL,
    [DtEmissaoNf]           DATE            NULL,
    PRIMARY KEY CLUSTERED ([codigo] ASC)
);
