CREATE TABLE [dbo].[Ocorrencia] (
	codigo INT IDENTITY(1, 1) NOT NULL,
	dataEnvio  DATETIME        NULL,
	status  VARCHAR(255)   NULL,
	dataImportacao  DATETIME        NULL,
	numeroTentativasEnvio INT NULL,
	orderNumber VARCHAR(10)   NULL,
	carrierCode VARCHAR(10)   NULL,
	sellerId VARCHAR(10)   NULL,
	carrierDocumentNumber VARCHAR(14)   NULL,
	vehicleRegistrationPlate VARCHAR(8)   NULL,
	driverName VARCHAR(40)   NULL,
	driverPhone VARCHAR(12)   NULL,
	extraInfo VARCHAR(60)   NULL,
	eventDateTime VARCHAR(28)   NULL,
	trackingSource VARCHAR(1)   NULL,
	eventType VARCHAR(4)   NULL,
	recipientName VARCHAR(40)   NULL,
	recipientRelationship VARCHAR(40)   NULL,
	vendorDocumentNumber VARCHAR(14)   NULL,
	invoiceNumber VARCHAR(9)   NULL,
	invoiceSerialNumber VARCHAR(3)   NULL,
	invoiceControlNumber VARCHAR(3)   NULL,
	isDeliveryAddressFound INT NULL,
	isBestPhoneUsed INT NULL,
	latitude  VARCHAR(14)   NULL,
	longitude  VARCHAR(14)   NULL,
	media TEXT NULL,
	extraPhone  VARCHAR(12)   NULL,
	carrierEventCode  VARCHAR(8)   NULL,
	carrierEventDescription  VARCHAR(40)   NULL,
	PRIMARY KEY CLUSTERED ([codigo] ASC)
);


CREATE TABLE [dbo].[Fatura] (
	codigo INT IDENTITY (1, 1) NOT NULL,
	dataEnvio  DATETIME        NULL,
	status  VARCHAR (255)   NULL,
	dataImportacao  DATETIME        NULL,
	numeroTentativasEnvio INT NULL,
	numeroPreFatura VARCHAR (50)    NULL,
	dataPreFatura  DATETIME        NULL,
	numeroFatura VARCHAR (50)    NULL,
	dataVencFatura  DATETIME        NULL,
	dataFatura  DATETIME        NULL,
	codTranspMatriz  DATETIME        NULL,
	codTranspEmit  DATETIME        NULL,
	modeloDocFiscal  INT             NULL,
	numeroDocFiscal  INT             NULL,
	serieDocFiscal  INT             NULL,
	dataDocFiscal  DATETIME        NULL,
	chaveCTe VARCHAR (50)    NULL,
	docTransporte VARCHAR (50)    NULL,
	valorFrete DECIMAL (15, 3) NULL,
	difValorFrete DECIMAL (15, 3) NULL,
	aliquotaICMS DECIMAL (15, 3) NULL,
	baseICMS DECIMAL (15, 3) NULL,
	valorICMS DECIMAL (15, 3) NULL,
	aliquotaICMSST DECIMAL (15, 3) NULL,
	baseICMSST DECIMAL (15, 3) NULL,
	valorICMSST DECIMAL (15, 3) NULL,
	aliquotaPIS DECIMAL (15, 3) NULL,
	basePIS DECIMAL (15, 3) NULL,
	valorPIS DECIMAL (15, 3) NULL,
	aliquotaCOFINS DECIMAL (15, 3) NULL,
	baseCOFINS DECIMAL (15, 3) NULL,
	valorCOFINS DECIMAL (15, 3) NULL,
	aliquotaISS DECIMAL (15, 3) NULL,
	baseISS DECIMAL (15, 3) NULL,
	valorISS DECIMAL (15, 3) NULL,
	modelo  INT             NULL,
	numero  INT             NULL,
	serie  INT             NULL,
	dataEmissao  DATETIME        NULL,
	chaveNFeCTe VARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([codigo] ASC)
);



CREATE TABLE [dbo].[Cte] (
    [codigo]           INT             IDENTITY (1, 1) NOT NULL,
	[dataEnvio]        DATETIME        NULL,
    [status]           VARCHAR (255)   NULL,
	[dataImportacao]  DATETIME        NULL,
	 numeroTentativasEnvio INT NULL,
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

--Procedimento para Preenchimento de EntityModel

CREATE PROCEDURE EntidadeModel --- Declarando o nome da procedure
@Tabela VARCHAR (50) --- Declarando variável (note que utilizamos o @ antes do nome da variável)
AS
SELECT 
 CASE   
      WHEN DATA_TYPE LIKE 'int' THEN 'public int?'   
      WHEN DATA_TYPE LIKE 'varchar' THEN 'public string'
	  WHEN DATA_TYPE LIKE 'datetime' THEN 'public DateTime?'
	  WHEN DATA_TYPE LIKE 'date' THEN 'public DateTime?'
	  WHEN DATA_TYPE LIKE 'decimal' THEN 'public decimal?'
	  WHEN DATA_TYPE LIKE 'text' THEN 'public DateTime?'
 END  as s,
 COLUMN_NAME as coluna,
  '{ get; set; }' as get
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @Tabela