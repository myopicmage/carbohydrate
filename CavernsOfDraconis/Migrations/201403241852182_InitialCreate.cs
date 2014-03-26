namespace CavernsOfDraconis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        cardid = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        title = c.String(),
                        Deck_deck_id = c.Int(),
                        Deck_deck_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.cardid)
                .ForeignKey("dbo.Decks", t => t.Deck_deck_id)
                .ForeignKey("dbo.Decks", t => t.Deck_deck_id1)
                .Index(t => t.Deck_deck_id)
                .Index(t => t.Deck_deck_id1);
            
            CreateTable(
                "dbo.Decks",
                c => new
                    {
                        deck_id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.deck_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Deck_deck_id1", "dbo.Decks");
            DropForeignKey("dbo.Cards", "Deck_deck_id", "dbo.Decks");
            DropIndex("dbo.Cards", new[] { "Deck_deck_id1" });
            DropIndex("dbo.Cards", new[] { "Deck_deck_id" });
            DropTable("dbo.Decks");
            DropTable("dbo.Cards");
        }
    }
}
