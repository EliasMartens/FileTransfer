Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.TransferFiles",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .File = c.Binary()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.TransferFiles")
        End Sub
    End Class
End Namespace
