<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btDescargar = New DevExpress.XtraEditors.SimpleButton()
        Me.pbProgressBar = New DevExpress.XtraEditors.ProgressBarControl()
        Me.lbProgress = New DevExpress.XtraEditors.LabelControl()
        CType(Me.pbProgressBar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btDescargar
        '
        Me.btDescargar.Appearance.Options.UseTextOptions = True
        Me.btDescargar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btDescargar.Location = New System.Drawing.Point(72, 38)
        Me.btDescargar.Name = "btDescargar"
        Me.btDescargar.Size = New System.Drawing.Size(120, 43)
        Me.btDescargar.TabIndex = 0
        Me.btDescargar.Text = "Descargar Ultimo Archivo"
        '
        'pbProgressBar
        '
        Me.pbProgressBar.Location = New System.Drawing.Point(12, 122)
        Me.pbProgressBar.Name = "pbProgressBar"
        Me.pbProgressBar.Size = New System.Drawing.Size(243, 18)
        Me.pbProgressBar.TabIndex = 1
        '
        'lbProgress
        '
        Me.lbProgress.Location = New System.Drawing.Point(12, 103)
        Me.lbProgress.Name = "lbProgress"
        Me.lbProgress.Size = New System.Drawing.Size(0, 13)
        Me.lbProgress.TabIndex = 2
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 161)
        Me.Controls.Add(Me.lbProgress)
        Me.Controls.Add(Me.pbProgressBar)
        Me.Controls.Add(Me.btDescargar)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbProgressBar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btDescargar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pbProgressBar As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents lbProgress As DevExpress.XtraEditors.LabelControl
End Class
