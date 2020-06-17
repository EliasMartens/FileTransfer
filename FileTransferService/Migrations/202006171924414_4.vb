Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _4
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.FileHeaders", "PartCount", Function(c) c.Int(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.FileHeaders", "PartCount")
        End Sub
    End Class
End Namespace
