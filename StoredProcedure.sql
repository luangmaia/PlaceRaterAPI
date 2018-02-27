CREATE PROCEDURE CalcAvgRate   
    @Name nvarchar(128),
	@City nvarchar(128),
	@State nvarchar(128)
AS   
    SELECT AVG(Stars) AS AvgStars, AVG(Price) AS AvgPrice  
    FROM Rates
    WHERE Name = @Name AND City = @City AND State = @State;

CalcAvgRate @Name = N'Cristo Redentor', @City = N'Rio de Janeiro', @State = N'RJ'