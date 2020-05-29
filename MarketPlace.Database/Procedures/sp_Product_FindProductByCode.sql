CREATE PROCEDURE [dbo].[sp_Product_FindProductByCode]
	@Code VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.ProductId
		,p.Code
		,p.Name
		,p.Description
		,p.UnitPrice
		,p.CategoryId
	FROM Products p 
	WHERE p.Code = @Code
END
