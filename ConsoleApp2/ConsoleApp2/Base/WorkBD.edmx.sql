
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/30/2019 16:26:20
-- Generated from EDMX file: C:\Users\Павел\Downloads\3 (1)\ConsoleApp2\ConsoleApp2\Base\WorkBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VacancyRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VacancySet] DROP CONSTRAINT [FK_VacancyRegion];
GO
IF OBJECT_ID(N'[dbo].[FK_VacancyOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VacancySet] DROP CONSTRAINT [FK_VacancyOrganization];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[VacancySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VacancySet];
GO
IF OBJECT_ID(N'[dbo].[RegionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionSet];
GO
IF OBJECT_ID(N'[dbo].[OrganizationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VacancySet'
CREATE TABLE [dbo].[VacancySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vakancy] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [Salary] nvarchar(max)  NOT NULL,
    [Organization] nvarchar(max)  NOT NULL,
    [Person] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [RegionId] int  NOT NULL,
    [OrganizationId] int  NOT NULL
);
GO

-- Creating table 'RegionSet'
CREATE TABLE [dbo].[RegionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Average_salary] nvarchar(max)  NOT NULL,
    [Complexity] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrganizationSet'
CREATE TABLE [dbo].[OrganizationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Employees] int  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VacancySet'
ALTER TABLE [dbo].[VacancySet]
ADD CONSTRAINT [PK_VacancySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegionSet'
ALTER TABLE [dbo].[RegionSet]
ADD CONSTRAINT [PK_RegionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizationSet'
ALTER TABLE [dbo].[OrganizationSet]
ADD CONSTRAINT [PK_OrganizationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RegionId] in table 'VacancySet'
ALTER TABLE [dbo].[VacancySet]
ADD CONSTRAINT [FK_VacancyRegion]
    FOREIGN KEY ([RegionId])
    REFERENCES [dbo].[RegionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacancyRegion'
CREATE INDEX [IX_FK_VacancyRegion]
ON [dbo].[VacancySet]
    ([RegionId]);
GO

-- Creating foreign key on [OrganizationId] in table 'VacancySet'
ALTER TABLE [dbo].[VacancySet]
ADD CONSTRAINT [FK_VacancyOrganization]
    FOREIGN KEY ([OrganizationId])
    REFERENCES [dbo].[OrganizationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacancyOrganization'
CREATE INDEX [IX_FK_VacancyOrganization]
ON [dbo].[VacancySet]
    ([OrganizationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------