CREATE PROCEDURE [dbo].[sp_Product_Save]
	@ProductId UNIQUEIDENTIFIER, 
    @Code VARCHAR(50), 
    @Name VARCHAR(100),
    @Description VARCHAR(100), 
    @UnitPrice DECIMAL(19,5), 
    @CategoryId UNIQUEIDENTIFIER = NULL,
    @Image VARCHAR(MAX) = NULL
AS
BEGIN
    
    SET NOCOUNT ON;

    SET XACT_ABORT ON

	INSERT INTO Products(ProductId,Code,Name,Description,UnitPrice,CategoryId,Image)
    VALUES (@ProductId,@Code,@Name,@Description,@UnitPrice,@CategoryId,@Image)   

END
