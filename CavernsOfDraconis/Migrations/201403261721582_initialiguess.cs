namespace CavernsOfDraconis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialiguess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        gameid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        password = c.String(),
                        owner = c.String(),
                        Started = c.DateTime(nullable: false),
                        deckid = c.Int(nullable: false),
                        deck_deck_id = c.Int(),
                    })
                .PrimaryKey(t => t.gameid)
                .ForeignKey("dbo.Decks", t => t.deck_deck_id)
                .Index(t => t.deck_deck_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "deck_deck_id", "dbo.Decks");
            DropIndex("dbo.Games", new[] { "deck_deck_id" });
            DropTable("dbo.Games");
        }
    }
}
