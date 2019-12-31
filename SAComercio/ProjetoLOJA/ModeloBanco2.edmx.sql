
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/09/2018 18:18:45
-- Generated from EDMX file: C:\Users\wesle\source\Workspaces\ProjetoLoja\ProjetoLOJA\ModeloBanco.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjetoMercado2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Pedidos_fk0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_Pedidos_fk0];
GO
IF OBJECT_ID(N'[dbo].[FK_ItensPedidos_fk0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensPedidos] DROP CONSTRAINT [FK_ItensPedidos_fk0];
GO
IF OBJECT_ID(N'[dbo].[FK_ItensPedidos_fk1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensPedidos] DROP CONSTRAINT [FK_ItensPedidos_fk1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Funcionarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Funcionarios];
GO
IF OBJECT_ID(N'[dbo].[ItensPedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItensPedidos];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Produtos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produtos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [ID] bigint  NOT NULL,
    [Nome] varchar(64)  NOT NULL,
    [Sobrenome] varchar(256)  NOT NULL,
    [CPF] varchar(11)  NOT NULL,
    [Endereço] varchar(128)  NOT NULL,
    [Número] varchar(16)  NOT NULL,
    [CEP] varchar(8)  NOT NULL,
    [Cidade] varchar(128)  NOT NULL,
    [Estado] varchar(18)  NOT NULL,
    [DataNascimento] datetime  NOT NULL,
    [Telefone] varchar(11)  NOT NULL,
    [Sexo] varchar(1)  NOT NULL,
    [Fidelidade] decimal(19,4)  NULL,
    [QntFidelidade] bigint  NULL
);
GO

-- Creating table 'Funcionarios'
CREATE TABLE [dbo].[Funcionarios] (
    [ID] bigint  NOT NULL,
    [Nome] varchar(64)  NOT NULL,
    [Sobrenome] varchar(256)  NOT NULL,
    [CPF] varchar(11)  NOT NULL,
    [Senha] varchar(32)  NOT NULL,
    [Admin] bit  NOT NULL
);
GO

-- Creating table 'ItensPedidos'
CREATE TABLE [dbo].[ItensPedidos] (
    [ID] bigint  NOT NULL,
    [Produto] bigint  NOT NULL,
    [Quantidade] bigint  NOT NULL,
    [Valor] decimal(19,4)  NOT NULL,
    [Códigopedido] bigint  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [ID] bigint  NOT NULL,
    [Data] datetime  NOT NULL,
    [CodigoFuncionario] bigint  NOT NULL
);
GO

-- Creating table 'Produtos'
CREATE TABLE [dbo].[Produtos] (
    [ID] bigint  NOT NULL,
    [Nome] varchar(256)  NOT NULL,
    [Marca] varchar(128)  NOT NULL,
    [Preço] decimal(19,4)  NOT NULL,
    [Quantidade] bigint  NOT NULL,
    [Codigo] varchar(16)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Funcionarios'
ALTER TABLE [dbo].[Funcionarios]
ADD CONSTRAINT [PK_Funcionarios]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ItensPedidos'
ALTER TABLE [dbo].[ItensPedidos]
ADD CONSTRAINT [PK_ItensPedidos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Produtos'
ALTER TABLE [dbo].[Produtos]
ADD CONSTRAINT [PK_Produtos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CodigoFuncionario] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_Pedidos_fk0]
    FOREIGN KEY ([CodigoFuncionario])
    REFERENCES [dbo].[Funcionarios]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pedidos_fk0'
CREATE INDEX [IX_FK_Pedidos_fk0]
ON [dbo].[Pedidos]
    ([CodigoFuncionario]);
GO

-- Creating foreign key on [Produto] in table 'ItensPedidos'
ALTER TABLE [dbo].[ItensPedidos]
ADD CONSTRAINT [FK_ItensPedidos_fk0]
    FOREIGN KEY ([Produto])
    REFERENCES [dbo].[Produtos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItensPedidos_fk0'
CREATE INDEX [IX_FK_ItensPedidos_fk0]
ON [dbo].[ItensPedidos]
    ([Produto]);
GO

-- Creating foreign key on [Códigopedido] in table 'ItensPedidos'
ALTER TABLE [dbo].[ItensPedidos]
ADD CONSTRAINT [FK_ItensPedidos_fk1]
    FOREIGN KEY ([Códigopedido])
    REFERENCES [dbo].[Pedidos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItensPedidos_fk1'
CREATE INDEX [IX_FK_ItensPedidos_fk1]
ON [dbo].[ItensPedidos]
    ([Códigopedido]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------