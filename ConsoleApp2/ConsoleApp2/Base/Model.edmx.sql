
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2019 16:09:13
-- Generated from EDMX file: C:\Projects\Entity-DataBaseManager\ConsoleApp2\ConsoleApp2\Base\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VacancySet'
CREATE TABLE [dbo].[VacancySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vakancy] nvarchar(max)  NOT NULL,
    [RegionName] nvarchar(max)  NOT NULL,
    [Salary] nvarchar(max)  NOT NULL,
    [OrganizationName] nvarchar(max)  NOT NULL,
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
    [AverageSalary] nvarchar(max)  NOT NULL,
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