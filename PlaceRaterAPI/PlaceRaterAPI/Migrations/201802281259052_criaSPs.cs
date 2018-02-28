namespace PlaceRaterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criaSPs : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "CalcAvgRate",
                p => new
                {
                    Name = p.String(),
                    City = p.String(),
                    State = p.String(),
                },
                body:
                        @"SELECT AVG(Stars) AS AvgStars, AVG(Price) AS AvgPrice  
                        FROM Rates
                        WHERE Name = [Name] AND City = [City] AND State = [State]"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("CalcAvgRate");
        }
    }
}
