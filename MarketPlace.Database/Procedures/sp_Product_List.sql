CREATE PROCEDURE [dbo].[sp_Product_List]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.ProductId
		,p.Code
		,p.Name
		,p.Description
		,p.UnitPrice
		,p.CategoryId
		,p.Image
		,pc.Code CategoryCode
		,pc.Name CategoryName		
	FROM Products p
		INNER JOIN ProductCategories pc ON pc.ProductCategoryId = p.CategoryId
	ORDER BY pc.Name,p.Name
	
END
