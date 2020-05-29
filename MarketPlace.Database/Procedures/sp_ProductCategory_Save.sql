CREATE PROCEDURE [dbo].[sp_ProductCategory_Save]
	@ProductCategoryId UNIQUEIDENTIFIER, 
    @Code VARCHAR(50), 
    @Name VARCHAR(100)
AS
BEGIN
    
    SET NOCOUNT ON;

    SET XACT_ABORT ON

	INSERT INTO ProductCategories(ProductCategoryId,Code,Name)
    VALUES (@ProductCategoryId,@Code,@Name)   

END
