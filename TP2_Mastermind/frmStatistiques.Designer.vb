<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatistiques
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitreStats = New System.Windows.Forms.Label()
        Me.cmdQuitter = New System.Windows.Forms.Button()
        Me.lvStats = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lblTitreStats
        '
        Me.lblTitreStats.Font = New System.Drawing.Font("Open Sans Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitreStats.Location = New System.Drawing.Point(22, 48)
        Me.lblTitreStats.Name = "lblTitreStats"
        Me.lblTitreStats.Size = New System.Drawing.Size(302, 27)
        Me.lblTitreStats.TabIndex = 1
        Me.lblTitreStats.Text = "Statistiques des joueurs"
        '
        'cmdQuitter
        '
        Me.cmdQuitter.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdQuitter.Location = New System.Drawing.Point(680, 567)
        Me.cmdQuitter.Name = "cmdQuitter"
        Me.cmdQuitter.Size = New System.Drawing.Size(155, 53)
        Me.cmdQuitter.TabIndex = 2
        Me.cmdQuitter.Text = "Quitter"
        Me.cmdQuitter.UseVisualStyleBackColor = True
        '
        'lvStats
        '
        Me.lvStats.BackColor = System.Drawing.Color.GhostWhite
        Me.lvStats.FullRowSelect = True
        Me.lvStats.GridLines = True
        Me.lvStats.HideSelection = False
        Me.lvStats.Location = New System.Drawing.Point(27, 91)
        Me.lvStats.Name = "lvStats"
        Me.lvStats.Size = New System.Drawing.Size(808, 447)
        Me.lvStats.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvStats.TabIndex = 0
        Me.lvStats.UseCompatibleStateImageBehavior = False
        Me.lvStats.View = System.Windows.Forms.View.Details
        '
        'frmStatistiques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.CancelButton = Me.cmdQuitter
        Me.ClientSize = New System.Drawing.Size(858, 651)
        Me.Controls.Add(Me.cmdQuitter)
        Me.Controls.Add(Me.lblTitreStats)
        Me.Controls.Add(Me.lvStats)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmStatistiques"
        Me.Text = "Statistiques de jeu - TP2Mastermind"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitreStats As Label
    Friend WithEvents cmdQuitter As Button
    Friend WithEvents lvStats As ListView
End Class
