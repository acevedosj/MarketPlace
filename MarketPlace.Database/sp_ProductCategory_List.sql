CREATE PROCEDURE [dbo].[sp_ProductCategory_List]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pc.ProductCategoryId
		,pc.Code 
		,pc.Name
	FROM ProductCategories pc 
	ORDER BY pc.Name
	
END
