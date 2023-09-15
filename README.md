# SearchApp
1. First Change the database or Create Datatabase named "DemoSearch" in the AppSettings.json file
2. create Stored procedure in the same database with the followinf codes
--CREATE PROCEDURE sp_Search
--    @ProductName NVARCHAR(255),
--    @Size NVARCHAR(255),
--    @Category NVARCHAR(255)
--AS
--BEGIN
--    SELECT *
--    FROM tblProduct
--    WHERE
--        (ISNULL(@ProductName, '') = '' OR ProductName LIKE '%' + @ProductName + '%')
--        AND (ISNULL(@Size, '') = '' OR Size LIKE '%' + @Size + '%')
--        AND (ISNULL(@Category, '') = '' OR Category LIKE '%' + @Category + '%');
--END;

3.Run these command in the Visual Studio CLI
--dotnet tool install --global dotnet-ef
--dotnet ef migrations add InitialCreate
--dotnet ef database update

