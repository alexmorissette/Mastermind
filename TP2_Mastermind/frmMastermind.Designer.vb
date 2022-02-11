<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMastermind
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
        Me.components = New System.ComponentModel.Container()
        Me.grpSymboles = New System.Windows.Forms.GroupBox()
        Me.optLettres = New System.Windows.Forms.RadioButton()
        Me.optChiffres = New System.Windows.Forms.RadioButton()
        Me.optCouleurs = New System.Windows.Forms.RadioButton()
        Me.cmdQuitter = New System.Windows.Forms.Button()
        Me.grpNombreChoix = New System.Windows.Forms.GroupBox()
        Me.optSix = New System.Windows.Forms.RadioButton()
        Me.optCinq = New System.Windows.Forms.RadioButton()
        Me.optQuatre = New System.Windows.Forms.RadioButton()
        Me.cmdNouvellePartie = New System.Windows.Forms.Button()
        Me.cmdLancerPartie = New System.Windows.Forms.Button()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.lblCombineAdecouvrir = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.lblNomJoueur = New System.Windows.Forms.Label()
        Me.cmdAfficherStatistiques = New System.Windows.Forms.Button()
        Me.cmdApropos = New System.Windows.Forms.Button()
        Me.cmdRegles = New System.Windows.Forms.Button()
        Me.lblDateHeure = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.grpSymboles.SuspendLayout()
        Me.grpNombreChoix.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSymboles
        '
        Me.grpSymboles.Controls.Add(Me.optLettres)
        Me.grpSymboles.Controls.Add(Me.optChiffres)
        Me.grpSymboles.Controls.Add(Me.optCouleurs)
        Me.grpSymboles.Location = New System.Drawing.Point(18, 21)
        Me.grpSymboles.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpSymboles.Name = "grpSymboles"
        Me.grpSymboles.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpSymboles.Size = New System.Drawing.Size(233, 116)
        Me.grpSymboles.TabIndex = 0
        Me.grpSymboles.TabStop = False
        Me.grpSymboles.Text = "Symboles"
        '
        'optLettres
        '
        Me.optLettres.AutoSize = True
        Me.optLettres.Location = New System.Drawing.Point(8, 82)
        Me.optLettres.Name = "optLettres"
        Me.optLettres.Size = New System.Drawing.Size(119, 24)
        Me.optLettres.TabIndex = 2
        Me.optLettres.Text = "Lettres (A à F)"
        Me.optLettres.UseVisualStyleBackColor = True
        '
        'optChiffres
        '
        Me.optChiffres.AutoSize = True
        Me.optChiffres.Location = New System.Drawing.Point(8, 54)
        Me.optChiffres.Name = "optChiffres"
        Me.optChiffres.Size = New System.Drawing.Size(126, 24)
        Me.optChiffres.TabIndex = 1
        Me.optChiffres.Text = "Chiffres (1 à 6)"
        Me.optChiffres.UseVisualStyleBackColor = True
        '
        'optCouleurs
        '
        Me.optCouleurs.AutoSize = True
        Me.optCouleurs.Checked = True
        Me.optCouleurs.Location = New System.Drawing.Point(8, 28)
        Me.optCouleurs.Name = "optCouleurs"
        Me.optCouleurs.Size = New System.Drawing.Size(198, 24)
        Me.optCouleurs.TabIndex = 0
        Me.optCouleurs.TabStop = True
        Me.optCouleurs.Text = "Couleurs (B, V, R, J, O, M)"
        Me.optCouleurs.UseVisualStyleBackColor = True
        '
        'cmdQuitter
        '
        Me.cmdQuitter.BackColor = System.Drawing.Color.PapayaWhip
        Me.cmdQuitter.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdQuitter.Location = New System.Drawing.Point(729, 687)
        Me.cmdQuitter.Name = "cmdQuitter"
        Me.cmdQuitter.Size = New System.Drawing.Size(84, 64)
        Me.cmdQuitter.TabIndex = 4
        Me.cmdQuitter.Text = "Quitter"
        Me.cmdQuitter.UseVisualStyleBackColor = False
        '
        'grpNombreChoix
        '
        Me.grpNombreChoix.Controls.Add(Me.optSix)
        Me.grpNombreChoix.Controls.Add(Me.optCinq)
        Me.grpNombreChoix.Controls.Add(Me.optQuatre)
        Me.grpNombreChoix.Location = New System.Drawing.Point(258, 21)
        Me.grpNombreChoix.Name = "grpNombreChoix"
        Me.grpNombreChoix.Size = New System.Drawing.Size(183, 116)
        Me.grpNombreChoix.TabIndex = 2
        Me.grpNombreChoix.TabStop = False
        Me.grpNombreChoix.Text = "Nombre de choix"
        '
        'optSix
        '
        Me.optSix.AutoSize = True
        Me.optSix.Location = New System.Drawing.Point(6, 82)
        Me.optSix.Name = "optSix"
        Me.optSix.Size = New System.Drawing.Size(78, 24)
        Me.optSix.TabIndex = 2
        Me.optSix.Text = "6 (tous)"
        Me.optSix.UseVisualStyleBackColor = True
        '
        'optCinq
        '
        Me.optCinq.AutoSize = True
        Me.optCinq.Location = New System.Drawing.Point(6, 54)
        Me.optCinq.Name = "optCinq"
        Me.optCinq.Size = New System.Drawing.Size(172, 24)
        Me.optCinq.TabIndex = 1
        Me.optCinq.Text = "5 premiers symboles"
        Me.optCinq.UseVisualStyleBackColor = True
        '
        'optQuatre
        '
        Me.optQuatre.AutoSize = True
        Me.optQuatre.Checked = True
        Me.optQuatre.Location = New System.Drawing.Point(6, 27)
        Me.optQuatre.Name = "optQuatre"
        Me.optQuatre.Size = New System.Drawing.Size(172, 24)
        Me.optQuatre.TabIndex = 0
        Me.optQuatre.TabStop = True
        Me.optQuatre.Text = "4 premiers symboles"
        Me.optQuatre.UseVisualStyleBackColor = True
        '
        'cmdNouvellePartie
        '
        Me.cmdNouvellePartie.BackColor = System.Drawing.Color.PapayaWhip
        Me.cmdNouvellePartie.Location = New System.Drawing.Point(12, 687)
        Me.cmdNouvellePartie.Name = "cmdNouvellePartie"
        Me.cmdNouvellePartie.Size = New System.Drawing.Size(89, 64)
        Me.cmdNouvellePartie.TabIndex = 6
        Me.cmdNouvellePartie.Text = "Nouvelle partie"
        Me.cmdNouvellePartie.UseVisualStyleBackColor = False
        '
        'cmdLancerPartie
        '
        Me.cmdLancerPartie.BackColor = System.Drawing.Color.LightGreen
        Me.cmdLancerPartie.Location = New System.Drawing.Point(107, 687)
        Me.cmdLancerPartie.Name = "cmdLancerPartie"
        Me.cmdLancerPartie.Size = New System.Drawing.Size(155, 64)
        Me.cmdLancerPartie.TabIndex = 7
        Me.cmdLancerPartie.Text = "Lancer partie"
        Me.cmdLancerPartie.UseVisualStyleBackColor = False
        '
        'lblTitre
        '
        Me.lblTitre.Font = New System.Drawing.Font("Open Sans", 21.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTitre.Location = New System.Drawing.Point(448, 9)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(365, 42)
        Me.lblTitre.TabIndex = 8
        Me.lblTitre.Text = "*** MASTERMIND ***"
        Me.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCombineAdecouvrir
        '
        Me.lblCombineAdecouvrir.AutoSize = True
        Me.lblCombineAdecouvrir.Font = New System.Drawing.Font("Open Sans Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCombineAdecouvrir.Location = New System.Drawing.Point(332, 669)
        Me.lblCombineAdecouvrir.Name = "lblCombineAdecouvrir"
        Me.lblCombineAdecouvrir.Size = New System.Drawing.Size(219, 22)
        Me.lblCombineAdecouvrir.TabIndex = 9
        Me.lblCombineAdecouvrir.Text = "- Combinaison à découvrir -"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'lblTimer
        '
        Me.lblTimer.BackColor = System.Drawing.Color.Tan
        Me.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTimer.Font = New System.Drawing.Font("Open Sans Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.Location = New System.Drawing.Point(455, 104)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(104, 33)
        Me.lblTimer.TabIndex = 10
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNomJoueur
        '
        Me.lblNomJoueur.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomJoueur.ForeColor = System.Drawing.Color.White
        Me.lblNomJoueur.Location = New System.Drawing.Point(448, 57)
        Me.lblNomJoueur.Name = "lblNomJoueur"
        Me.lblNomJoueur.Size = New System.Drawing.Size(365, 42)
        Me.lblNomJoueur.TabIndex = 11
        Me.lblNomJoueur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAfficherStatistiques
        '
        Me.cmdAfficherStatistiques.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmdAfficherStatistiques.Location = New System.Drawing.Point(619, 687)
        Me.cmdAfficherStatistiques.Name = "cmdAfficherStatistiques"
        Me.cmdAfficherStatistiques.Size = New System.Drawing.Size(104, 64)
        Me.cmdAfficherStatistiques.TabIndex = 12
        Me.cmdAfficherStatistiques.Text = "Statistiques"
        Me.cmdAfficherStatistiques.UseVisualStyleBackColor = False
        '
        'cmdApropos
        '
        Me.cmdApropos.BackColor = System.Drawing.Color.Linen
        Me.cmdApropos.Location = New System.Drawing.Point(729, 104)
        Me.cmdApropos.Name = "cmdApropos"
        Me.cmdApropos.Size = New System.Drawing.Size(83, 36)
        Me.cmdApropos.TabIndex = 13
        Me.cmdApropos.Text = "À propos"
        Me.cmdApropos.UseVisualStyleBackColor = False
        '
        'cmdRegles
        '
        Me.cmdRegles.BackColor = System.Drawing.Color.Linen
        Me.cmdRegles.Location = New System.Drawing.Point(565, 104)
        Me.cmdRegles.Name = "cmdRegles"
        Me.cmdRegles.Size = New System.Drawing.Size(158, 36)
        Me.cmdRegles.TabIndex = 14
        Me.cmdRegles.Text = "Règles du jeu"
        Me.cmdRegles.UseVisualStyleBackColor = False
        '
        'lblDateHeure
        '
        Me.lblDateHeure.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateHeure.Location = New System.Drawing.Point(3, 2)
        Me.lblDateHeure.Name = "lblDateHeure"
        Me.lblDateHeure.Size = New System.Drawing.Size(201, 16)
        Me.lblDateHeure.TabIndex = 15
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'frmMastermind
        '
        Me.AcceptButton = Me.cmdLancerPartie
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.CancelButton = Me.cmdQuitter
        Me.ClientSize = New System.Drawing.Size(824, 769)
        Me.Controls.Add(Me.lblDateHeure)
        Me.Controls.Add(Me.cmdRegles)
        Me.Controls.Add(Me.cmdApropos)
        Me.Controls.Add(Me.cmdAfficherStatistiques)
        Me.Controls.Add(Me.lblNomJoueur)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lblCombineAdecouvrir)
        Me.Controls.Add(Me.lblTitre)
        Me.Controls.Add(Me.cmdLancerPartie)
        Me.Controls.Add(Me.cmdNouvellePartie)
        Me.Controls.Add(Me.cmdQuitter)
        Me.Controls.Add(Me.grpNombreChoix)
        Me.Controls.Add(Me.grpSymboles)
        Me.Font = New System.Drawing.Font("Open Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMastermind"
        Me.Text = "TP2 - Mastermind"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.grpSymboles.ResumeLayout(False)
        Me.grpSymboles.PerformLayout()
        Me.grpNombreChoix.ResumeLayout(False)
        Me.grpNombreChoix.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpSymboles As GroupBox
    Friend WithEvents cmdQuitter As Button
    Friend WithEvents optCouleurs As RadioButton
    Friend WithEvents optLettres As RadioButton
    Friend WithEvents optChiffres As RadioButton
    Friend WithEvents grpNombreChoix As GroupBox
    Friend WithEvents optSix As RadioButton
    Friend WithEvents optCinq As RadioButton
    Friend WithEvents optQuatre As RadioButton
    Friend WithEvents cmdNouvellePartie As Button
    Friend WithEvents cmdLancerPartie As Button
    Friend WithEvents lblTitre As Label
    Friend WithEvents lblCombineAdecouvrir As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblTimer As Label
    Friend WithEvents lblNomJoueur As Label
    Friend WithEvents cmdAfficherStatistiques As Button
    Friend WithEvents cmdApropos As Button
    Friend WithEvents cmdRegles As Button
    Friend WithEvents lblDateHeure As Label
    Friend WithEvents Timer2 As Timer
End Class
