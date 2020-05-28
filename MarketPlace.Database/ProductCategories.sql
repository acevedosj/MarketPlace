CREATE TABLE [dbo].[ProductCategories]
(
	ProductCategoryId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	Code              VARCHAR (50) NOT NULL,
	Name              VARCHAR (100) NOT NULL
)
