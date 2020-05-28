CREATE TABLE [dbo].[Products]
(
	ProductId   UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	Code        VARCHAR (50) NOT NULL,
	Name        VARCHAR (100) NOT NULL,
	UnitPrice   DECIMAL (19, 5) NOT NULL,
	CategoryId  UNIQUEIDENTIFIER NULL,
	Description VARCHAR (500) NULL,
	[Image]     VARCHAR (max) NULL,
)
