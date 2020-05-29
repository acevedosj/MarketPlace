CREATE PROCEDURE [dbo].[sp_Product_FindCategorytByCode]
	@Code VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pc.ProductCategoryId
		,pc.Code
		,pc.Name		
	FROM ProductCategories pc 
	WHERE pc.Code = @Code
END

