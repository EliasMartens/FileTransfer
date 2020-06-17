Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _3
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.FileHeaders",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FullName = c.String(),
                        .FirstPartID = c.Int(nullable := False),
                        .LastPartID = c.Int(nullable := False),
                        .Complete = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.FileParts",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Content = c.Binary(),
                        .NextID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            DropTable("dbo.ServiceFiles")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.ServiceFiles",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FullName = c.String(),
                        .Content = c.Binary()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            DropTable("dbo.FileParts")
            DropTable("dbo.FileHeaders")
        End Sub
    End Class
End Namespace
