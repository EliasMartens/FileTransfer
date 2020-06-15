Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ServiceFiles",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FullName = c.String(),
                        .Content = c.Binary()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            DropTable("dbo.TransferFiles")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.TransferFiles",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .File = c.Binary()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            DropTable("dbo.ServiceFiles")
        End Sub
    End Class
End Namespace
