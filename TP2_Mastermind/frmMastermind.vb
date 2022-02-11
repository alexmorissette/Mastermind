'Titre: TP2Mastermind
'
'DESCRIPTION: Ce programme est un jeu qui consiste à trouver une combinaison cachée.  
'Cette combinaison consiste en 4 symboles sur une possibilité de 4 à 6 symboles au choix du joueur;
'ces symboles peuvent être des lettres, des chiffres ou des couleurs.

'Le joueur a 20 essais pour être en mesure de trouver la combinaison. 
'Après chaque essai est incrit le nombre de symboles bien placés et le nombre de symboles bons mais mal placé. 
'Après 20 essais infructueux, la combinaison cachée s'affiche et le joueur est invité à recommencer.
'
'Fait par: Alex Morissette
'Le : 14 mai 2021
'Révisé le : 3 juin 2021
'

Imports System.IO

Public Class frmMastermind
    ' Tableaux des options (Couleurs, Chiffres, Lettres)
    Dim Couleurs() As Char = {"B", "V", "R", "J", "O", "M"}
    Dim Chiffres() As Char = {"1", "2", "3", "4", "5", "6"}
    Dim Lettres() As Char = {"A", "B", "C", "D", "E", "F"}

    ' Tableaux pour la matrice de jeu
    Dim Tab_ZoneTxt(19, 3) As TextBox
    Dim Tab_ChkBox(19) As CheckBox
    Dim Tab_lbl(19) As Label
    Dim Tab_lbl_BP(19) As Label
    Dim Tab_lbl_MP(19) As Label
    Dim GrpBox(1) As GroupBox
    Dim EnTetes(5) As Label
    Dim Tab_CombineCachee(0, 3) As Label ' Avec des ? au départ

    ' Tableau de la combine à découvrir
    Dim Tab_Combine(0, 3) As Char

    ' Compteurs
    Dim Essai As Integer
    Dim cptParties As Integer = 0
    Dim nbrJoueurs As Integer = 0
    Dim nbrSymboles As Integer

    ' Variables pour le Timer
    Dim stopwatch As New Stopwatch

    'Identification de l'utilisateur
    Dim strNom As String

    'Formulaire de statistiques
    Dim frmStatistiques As New frmStatistiques

    'Pour l'enregistrement des statistiques au fichier
    Public Const LongueurEnr As Integer = 92
    Public Const NomFichier As String = "Statistiques_Mastermind.dta"
    Dim pos As Integer = -1

    Dim trouve As Boolean = False

    Private Sub TP2Mastermind_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            CreerEnTetes()
            CreerTab_Labels()
            CreerTab_ZoneTexte()
            CreerTab_ChkBox()
            CreerTab_BP()
            CreerTab_MP()
            CreerTabCombineCachee()

            'Demander le nom du joueur
            strNom = InputBox("BIENVENUE DANS MASTERMIND ! " & vbCrLf & vbCrLf & "Entrez votre nom de joueur : ", "Identification du joueur", "Joueur")
            lblNomJoueur.Text = "Bonjour " & UCase(strNom).Replace(" ", "") & " !"

            ' Aller chercher le nbr de joueurs dans le fichier
            Dim fs As FileStream = New FileStream(NomFichier, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None)
            nbrJoueurs = CInt(fs.Length / LongueurEnr)
            fs.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau de la combinaison cachée à découvrir 
    ''' </summary>
    Private Sub CreerTabCombineCachee()

        Try
            ' Tableau avec des ??
            Dim i, j As Integer
            For j = 0 To Tab_CombineCachee.GetUpperBound(0)
                For i = 0 To Tab_CombineCachee.GetUpperBound(1)
                    Tab_CombineCachee(j, i) = New Label
                    With Tab_CombineCachee(j, i)
                        .Visible = True
                        .AutoSize = False
                        .BorderStyle = BorderStyle.Fixed3D
                        .TextAlign = ContentAlignment.MiddleCenter
                        .Width = 45
                        .Height = 45
                        .Text = "?"
                        .Enabled = False
                        .Top = 700
                        .Left = 340 + i * 50
                    End With
                    Me.Controls.Add(Tab_CombineCachee(j, i))
                Next

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau des en-têtes des 2 tableau des essais 
    ''' </summary>
    Private Sub CreerEnTetes()

        Try
            Dim i As Integer
            For i = 0 To 5
                EnTetes(i) = New Label
                With EnTetes(i)
                    .AutoSize = False
                    .BorderStyle = BorderStyle.Fixed3D
                    .Height = 35
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Top = 190
                    Select Case i
                        Case 0
                            .Text = "Essai"
                            .Width = 155
                            .Left = 90
                        Case 1
                            .Text = "BP"
                            .BackColor = Color.LightGreen
                            .Width = 45
                            .Left = 285
                        Case 2
                            .Text = "MP"
                            .BackColor = Color.LightYellow
                            .Width = 45
                            .Left = 335
                        Case 3
                            .Text = "Essai"
                            .Width = 155
                            .Left = 480
                        Case 4
                            .Text = "BP"
                            .BackColor = Color.LightGreen
                            .Width = 45
                            .Left = 677
                        Case 5
                            .Text = "MP"
                            .BackColor = Color.LightYellow
                            .Width = 45
                            .Left = 728
                    End Select

                End With
                Me.Controls.Add(EnTetes(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau des labels de chaque essai
    ''' </summary>
    Private Sub CreerTab_Labels()
        Try
            Dim i As Integer
            For i = 0 To 19
                Tab_lbl(i) = New Label
                With Tab_lbl(i)
                    .AutoSize = False
                    .BorderStyle = BorderStyle.Fixed3D
                    .Text = i + 1
                    .Width = 35
                    .Height = 35
                    .TextAlign = ContentAlignment.MiddleCenter
                    ' Bouger la position pour la matrice de droite (10)
                    If i > 9 Then
                        .Top = 230 + (i - 10) * 40
                        .Left = 440
                    Else
                        .Top = 230 + i * 40
                        .Left = 50
                    End If
                End With
                Me.Controls.Add(Tab_lbl(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau 2 dimensions des zones de texte
    ''' </summary>
    Private Sub CreerTab_ZoneTexte()
        Try
            Dim L, C As Integer
            For L = 0 To 19
                For C = 0 To 3
                    Tab_ZoneTxt(L, C) = New TextBox
                    With Tab_ZoneTxt(L, C)
                        .MaxLength = 1
                        .Visible = True
                        .Width = 35
                        .Height = 35
                        .BackColor = Color.White
                        .TextAlign = HorizontalAlignment.Center
                        .CharacterCasing = CharacterCasing.Upper
                        If L > 9 Then
                            .Top = 230 + (L - 10) * 40
                            .Left = 480 + C * 40
                        Else
                            .Top = 230 + L * 40
                            .Left = 90 + C * 40
                        End If
                        .Multiline = True
                        .Enabled = False
                        .Tag = C + 1
                    End With
                    Me.Controls.Add(Tab_ZoneTxt(L, C))
                    AddHandler Tab_ZoneTxt(L, C).KeyPress, AddressOf Valider_Caractere
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau ddes cases à cocher. 
    ''' </summary>
    Private Sub CreerTab_ChkBox()
        Try
            Dim i As Integer
            For i = 0 To 19
                Tab_ChkBox(i) = New CheckBox
                With Tab_ChkBox(i)
                    .Visible = True
                    If i > 9 Then
                        .Top = 234 + (i - 10) * 40
                        .Left = 650
                    Else
                        .Top = 234 + i * 40
                        .Left = 260
                    End If
                    .Enabled = False
                    .Width = 16
                End With
                Me.Controls.Add(Tab_ChkBox(i))
                AddHandler Tab_ChkBox(i).Click, AddressOf Case_Click
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau des zones de BP (Bonnes Places)
    ''' </summary>
    Private Sub CreerTab_BP()

        Try
            Dim i As Integer
            For i = 0 To 19
                Tab_lbl_BP(i) = New Label
                With Tab_lbl_BP(i)
                    .AutoSize = False
                    .BorderStyle = BorderStyle.Fixed3D
                    .BackColor = Color.LightGreen
                    .Width = 45
                    .Height = 35
                    .TextAlign = ContentAlignment.MiddleCenter
                    ' Bouger la position pour la matrice de droite (10)
                    If i > 9 Then
                        .Top = 230 + (i - 10) * 40
                        .Left = 677
                    Else
                        .Top = 230 + i * 40
                        .Left = 285
                    End If
                End With
                Me.Controls.Add(Tab_lbl_BP(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Cette procédure génère le tableau des zones de MP (Bons mais Mal Placés)
    ''' </summary>
    Private Sub CreerTab_MP()

        Try
            Dim i As Integer
            For i = 0 To 19
                Tab_lbl_MP(i) = New Label
                With Tab_lbl_MP(i)
                    .AutoSize = False
                    .BorderStyle = BorderStyle.Fixed3D
                    .BackColor = Color.LightYellow
                    .Width = 45
                    .Height = 35
                    .TextAlign = ContentAlignment.MiddleCenter
                    ' Bouger la position pour la matrice de droite (10)
                    If i > 9 Then
                        .Top = 230 + (i - 10) * 40
                        .Left = 728
                    Else
                        .Top = 230 + i * 40
                        .Left = 335
                    End If
                End With
                Me.Controls.Add(Tab_lbl_MP(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Cette procédure valide la présence de case vide dans l'essai 
    ''' et redonne le focus à la case vide.
    ''' </summary>
    Private Function ValiderCaseVide() As Boolean
        Try
            Dim caseVide As Boolean = False
            Dim i As Integer
            For i = 0 To Tab_ZoneTxt.GetUpperBound(1)
                If Tab_ZoneTxt(Essai, i).Text = "" Then
                    caseVide = True
                    MsgBox("Veuillez compléter la case " & i + 1 & " de l'essai.", MsgBoxStyle.Information)
                    Tab_ZoneTxt(0, i).Focus()

                End If
            Next
            Return caseVide
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Cette procédure Click() permet de comparer les 2 combinaisons (Joueur avec programme)
    ''' </summary>
    Private Sub Case_Click()
        Try
            ' Valider s'il n'y a pas de case vide dans l'essai avant de comparer, s'il y en a minimum une, on décoche.
            If ValiderCaseVide() = True Then
                Tab_ChkBox(Essai).Checked = False
                Tab_ChkBox(Essai).Enabled = True
                Exit Sub
            Else BarrerEssai(Essai)
            End If

            ' Déclaration des variables
            Dim encoreCaches(3) As String
            Dim reste_A_essayer(3) As String
            Dim sortieBP(3) As String
            Dim mp, bp, i As Integer
            mp = 0
            bp = 0

            'Vérifier et compter les correspondances exactes
            For i = 0 To Tab_ZoneTxt.GetUpperBound(1)
                If Tab_Combine(0, i) = Tab_ZoneTxt(Essai, i).Text Then
                    bp += 1
                    If sortieBP.Contains(Tab_ZoneTxt(Essai, i).Text) = False Then
                        sortieBP(i) = Tab_ZoneTxt(Essai, i).Text
                    End If
                Else
                    reste_A_essayer(i) = Tab_ZoneTxt(Essai, i).Text
                    encoreCaches(i) = Tab_Combine(0, i)
                End If
            Next

            Dim pos As Integer
            Dim n As Integer
            ' Vérifier et compter les bons essais aux mauvaises places
            For i = 0 To Tab_ZoneTxt.GetUpperBound(1)
                If reste_A_essayer(i) <> Nothing And encoreCaches.Contains(reste_A_essayer(i)) Then
                    mp += 1
                    pos = Array.IndexOf(encoreCaches, reste_A_essayer(i))
                    encoreCaches(pos) = ""
                End If
            Next

            ' Incrire le résultat de l'essai
            Tab_lbl_BP(Essai).Text = bp
            Tab_lbl_MP(Essai).Text = mp

            AfficherResultatEssais()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Procédure qui permet d'afficher le résultat des essais
    ''' </summary>
    Private Sub AfficherResultatEssais()
        Try
            'Mettre la combine dans une string
            Dim j As Integer
            Dim combine As String = ""
            For j = 0 To Tab_Combine.GetUpperBound(1)
                combine += Tab_Combine(0, j).ToString() & " "
            Next

            ' Si la combine est trouvé...
            If Tab_lbl_BP(Essai).Text = "4" Then
                AfficherPartieGagnee(combine)
            ElseIf Essai = 19 Then
                ' Si partie perdue
                AfficherPartiePerdue(combine)
            Else ' Si on continue
                Essai += 1
                DebarrerEssai(Essai)
                Tab_ZoneTxt(Essai, 0).Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure qui permet d'afficher un message au joueur si le nombre d'essai est épuisé.
    ''' </summary>
    Private Sub AfficherPartiePerdue(combine As String)

        trouve = False
        stopwatch.Stop()
        EnregistrerPartie()
        lblNomJoueur.Text = "Partie terminée..."

        AfficherCombineCachee()

        Dim rep As MsgBoxResult
        rep = MsgBox("La partie est terminé, vous avez épuisé tous les essais." & vbCrLf & vbCrLf _
                     & "La combinaison à découvrir était : " & combine & vbCrLf & vbCrLf _
                     & "Voulez-vous faire une autre partie avec les mêmes options ?",
                     MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Partie terminée")
        If rep = MsgBoxResult.Yes Then
            cmdNouvellePartie.PerformClick()
            cmdLancerPartie.PerformClick()
        Else
            cmdAfficherStatistiques.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' Procédure qui permet d'afficher un message au joueur si la combinaison a été trouvée.
    ''' </summary>
    Private Sub AfficherPartieGagnee(combine As String)

        Try

            AfficherCombineCachee()

            trouve = True
            stopwatch.Stop()
            EnregistrerPartie()
            lblNomJoueur.Text = "TROUVÉ!!!"

            Dim rep As MsgBoxResult
            rep = MsgBox("TROUVÉ, " & strNom & "!! VOUS ÊTES UN MAÎTRE DU MASTERMIND !!" & vbCrLf & vbCrLf _
                         & "La combinaison est bel et bien : " & combine & vbCrLf & vbCrLf &
                         "Voulez-vous rejouer avec les mêmes options?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "PARTIE GAGNÉE !!")
            If rep = MsgBoxResult.Yes Then
                cmdNouvellePartie.PerformClick()
                cmdLancerPartie.PerformClick()
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' Procédure qui permet d'afficher la combinaison à découvrir à la place des ?
    ''' </summary>
    Private Sub AfficherCombineCachee()

        Try
            Dim i As Integer
            For i = 0 To Tab_CombineCachee.GetUpperBound(1)

                Tab_CombineCachee(0, i).Text = Tab_Combine(0, i) ' Affiche la combine 

                ' Pour afficher les couleurs, si l'option Couleurs est choisie
                If optCouleurs.Checked Then
                    If Tab_Combine(0, i) = "B" Then
                        Tab_CombineCachee(0, i).BackColor = Color.Blue
                    ElseIf Tab_Combine(0, i) = "V" Then
                        Tab_CombineCachee(0, i).BackColor = Color.Green
                    ElseIf Tab_Combine(0, i) = "R" Then
                        Tab_CombineCachee(0, i).BackColor = Color.Red
                    ElseIf Tab_Combine(0, i) = "J" Then
                        Tab_CombineCachee(0, i).BackColor = Color.Yellow
                    ElseIf Tab_Combine(0, i) = "O" Then
                        Tab_CombineCachee(0, i).BackColor = Color.Orange
                    ElseIf Tab_Combine(0, i) = "M" Then
                        Tab_CombineCachee(0, i).BackColor = Color.Purple
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure qui permet de quitter le programme
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdQuitter_Click(sender As Object, e As EventArgs) Handles cmdQuitter.Click
        ' Demander une confirmation
        Dim rep As DialogResult
        rep = MessageBox.Show("Voulez-vous vraiment quitter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (rep = DialogResult.Yes) Then
            Me.Close()
        End If

    End Sub


    ''' <summary>
    ''' Procédure qui permet de donner le focus à la zone de texte suivante lors des essais.
    ''' </summary>
    ''' <param name="n"></param>
    Private Sub DonnerFocusSuivant(n As Integer)
        Try
            If n = 4 Then
                DebarrerCTRL(Tab_ChkBox(Essai))
                Tab_ChkBox(Essai).Focus()

            Else
                Tab_ZoneTxt(Essai, n).Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Procédure qui permet de valider le caractère tapé dans la zone des essais
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Valider_Caractere(sender As Object, e As KeyPressEventArgs)

        Try
            Dim tbox As TextBox = sender
            Dim caractere As Char = UCase(e.KeyChar)

            If optCouleurs.Checked Then
                If e.KeyChar = Chr(8) Then
                    tbox.BackColor = Color.White
                    Exit Sub
                End If
                If Couleurs.Contains(caractere) Then
                    If caractere = "B" Then
                        tbox.BackColor = Color.Blue
                    ElseIf caractere = "V" Then
                        tbox.BackColor = Color.Green
                    ElseIf caractere = "R" Then
                        tbox.BackColor = Color.Red
                    ElseIf caractere = "J" Then
                        tbox.BackColor = Color.Yellow
                    ElseIf caractere = "O" Then
                        tbox.BackColor = Color.Orange
                    ElseIf caractere = "M" Then
                        tbox.BackColor = Color.Purple
                    End If
                    DonnerFocusSuivant(tbox.Tag)
                Else e.Handled = True
                End If

            End If

            If optChiffres.Checked Then
                If e.KeyChar = Chr(8) Then Exit Sub
                If Chiffres.Contains(caractere) Then
                    DonnerFocusSuivant(tbox.Tag)
                Else e.Handled = True
                End If

            End If

            If optLettres.Checked Then
                If e.KeyChar = Chr(8) Then Exit Sub
                If Lettres.Contains(caractere) Then
                    DonnerFocusSuivant(tbox.Tag)
                Else e.Handled = True
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure qui permet de générer la combinaison à découvrir.
    ''' </summary>
    Private Sub GenererTabCombineADecouvrir()
        Try
            Dim hasard As New Random
            Dim no As Integer
            Dim i As Integer
            'COULEURS
            If optCouleurs.Checked Then
                For i = 0 To Tab_Combine.GetUpperBound(1)
                    no = hasard.Next(0, Couleurs.Length)
                    Tab_Combine(0, i) = Couleurs(no)

                Next 'CHIFFRES
            ElseIf optChiffres.Checked Then
                For i = 0 To Tab_Combine.GetUpperBound(1)
                    no = hasard.Next(0, Chiffres.Length)
                    Tab_Combine(0, i) = Chiffres(no)
                Next
            Else 'LETTRES
                For i = 0 To Tab_Combine.GetUpperBound(1)
                    no = hasard.Next(0, Lettres.Length)
                    Tab_Combine(0, i) = Lettres(no)
                Next
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure qui permet de lancer une nouvelle partie 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdLancerPartie_Click(sender As Object, e As EventArgs) Handles cmdLancerPartie.Click
        Try

            ' Redimmensionner les tableaux de symboles selon l'option choisie
            If optCouleurs.Checked Then
                RedimTabSymboles(Couleurs)
            ElseIf optChiffres.Checked Then
                RedimTabSymboles(Chiffres)
            Else
                RedimTabSymboles(Lettres)
            End If

            cptParties += 1
            GenererTabCombineADecouvrir()

            Essai = 0
            DebarrerEssai(Essai)
            Tab_ZoneTxt(Essai, 0).Focus()
            lblNomJoueur.Text = "À vous de jouer " & strNom & " !!"
            BarrerCTRL(cmdLancerPartie, grpNombreChoix, grpSymboles, cmdAfficherStatistiques)

            stopwatch.Start()

            'frmStatistiques.Activate()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Procédure qui permet d'enregistrer les résultats dans un fichier
    ''' </summary>
    Private Sub EnregistrerPartie()
        Try
            'Dim fs As FileStream

            Dim fs = New FileStream(NomFichier, FileMode.Append, FileAccess.Write, FileShare.None)
            Dim bw As New BinaryWriter(fs)

            Dim nomJoueur, temps As String
            Dim DateHeure As String
            Dim noPartie As Integer
            Dim nbrEssais As Integer
            Dim reussi As String

            nomJoueur = strNom.PadRight(15) '41 octets = 10 + (15 * 2) + 1
            noPartie = cptParties ' Integer 4 octets
            DateHeure = DateTime.Now ' Date 8 octets
            temps = lblTimer.Text.ToString() ' 21 octets = 10  + (5 * 2) + 1
            If trouve = False Then ' 10 + 6(oui et non -> 3 lettres) + 1 octet 
                reussi = "Non"
            Else reussi = "Oui"
            End If
            nbrEssais = Essai + 1 ' 4 octets Integer

            ' Écrit dans le fichier
            bw.Write(nomJoueur)
            bw.Write(noPartie)
            bw.Write(DateHeure)
            bw.Write(temps)
            bw.Write(reussi)
            bw.Write(nbrEssais)

            ' Ferme le fichier
            bw.Close()
            fs.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    ''' <summary>
    ''' Procédure permettant de redimmensionner les tableaux 
    ''' </summary>
    ''' <param name="tabSymb"></param>
    Private Sub RedimTabSymboles(ByRef tabSymb() As Char)
        Try

            If optQuatre.Checked Then
                ReDim Preserve tabSymb(3)
            ElseIf optCinq.Checked Then
                ReDim Preserve tabSymb(4)
            Else
                ReDim Preserve tabSymb(5)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Procédure permmettamt de barrer les contrôles spécifiés dans le ParcAttry
    ''' </summary>
    ''' <param name="ctrl"></param>
    Private Sub BarrerCTRL(ParamArray ctrl() As Control)
        For Each c As Control In ctrl
            c.Enabled = False
        Next
    End Sub

    ''' <summary>
    ''' Procédure permmettamt de débarrer les contrôles spécifiés dans le ParcAttry
    ''' </summary>
    Private Sub DebarrerCTRL(ParamArray ctrl() As Control)
        For Each c As Control In ctrl
            c.Enabled = True
        Next
    End Sub

    ''' <summary>
    ''' Procédure permmettamt de débarrer l'essai suivant  
    ''' </summary>
    Private Sub DebarrerEssai(no As Integer)
        Try
            Dim i As Integer

            If no = 20 Then Exit Sub

            For i = 0 To Tab_ZoneTxt.GetUpperBound(1)
                Tab_ZoneTxt(no, i).Enabled = True
            Next
            Tab_ChkBox(no).Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Procédure permmettamt de barrer l'essai en cours  
    ''' </summary>
    Private Sub BarrerEssai(no As Integer)

        Dim i As Integer
        For i = 0 To Tab_ZoneTxt.GetUpperBound(1)
            Tab_ZoneTxt(no, i).Enabled = False
        Next
        Tab_ChkBox(no).Enabled = False

    End Sub

    ''' <summary>
    ''' Procédure permmettamt de débuter une nouvelle partie  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdNouvellePartie_Click(sender As Object, e As EventArgs) Handles cmdNouvellePartie.Click
        Try
            ViderZonesTexte()
            DecocherChkBox()
            ViderBP()
            ViderMP()
            ViderCombine()
            BarrerEssai(Essai)
            DebarrerCTRL(cmdLancerPartie, grpNombreChoix, grpSymboles, cmdAfficherStatistiques)

            stopwatch.Stop()
            stopwatch.Reset()

            lblNomJoueur.Text = "Lancez la partie!!"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    ''' <summary>
    ''' Procédure permettant de vider la combine
    ''' </summary>
    Private Sub ViderCombine()
        Try
            Dim i As Integer
            For i = 0 To Tab_CombineCachee.GetUpperBound(1)
                Tab_CombineCachee(0, i).Text = "?"
                Tab_CombineCachee(0, i).BackColor = Color.Empty
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Procédure permettant de vider les xones de texte(poinçcon)
    ''' </summary>
    Private Sub ViderZonesTexte()
        Try
            Dim i, j As Integer
            For i = 0 To Tab_ZoneTxt.GetUpperBound(0)
                For j = 0 To Tab_ZoneTxt.GetUpperBound(1)
                    Tab_ZoneTxt(i, j).Clear()
                    Tab_ZoneTxt(i, j).BackColor = Color.White
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure permettant de décocher les checkBox
    ''' </summary>
    Private Sub DecocherChkBox()
        Try
            Dim i As Integer
            For i = 0 To Tab_ChkBox.GetUpperBound(0)
                Tab_ChkBox(i).Checked = False
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure permettant de vider la colonne des BP
    ''' </summary>
    Private Sub ViderBP()
        Try

            Dim i As Integer
            For i = 0 To Tab_lbl_BP.GetUpperBound(0)
                Tab_lbl_BP(i).Text = ""
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure permettant de vider la colonne des MP
    ''' </summary>
    Private Sub ViderMP()
        Try
            Dim i As Integer
            For i = 0 To Tab_lbl_MP.GetUpperBound(0)
                Tab_lbl_MP(i).Text = ""
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Procédure qui permet d'Afficher le timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTimer.Text = String.Format("{0}:{1}",
                        stopwatch.Elapsed.Minutes.ToString("00"),
                        stopwatch.Elapsed.Seconds.ToString("00"))
    End Sub


    ''' <summary>
    ''' Procédure qui permet d'ouvrir la fenêtre des statistiques
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdAfficherStatistiques_Click(sender As Object, e As EventArgs) Handles cmdAfficherStatistiques.Click

        Try

            If frmStatistiques Is Nothing Then
                frmStatistiques = New frmStatistiques
            End If
            frmStatistiques.Show()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    ''' <summary>
    ''' Procedure qui permet d'ouvrir le formulaire À propos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdApropos_Click(sender As Object, e As EventArgs) Handles cmdApropos.Click
        Try
            Dim frm = New frmApropos
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdRegles_Click(sender As Object, e As EventArgs) Handles cmdRegles.Click
        MsgBox("Voici les règles du jeu Mastermind: " & vbCrLf & vbCrLf & "Vous devez trouver une combinaison cachée.
Cette combinaison est composée de 4 symboles sur une possibilité de 4 à 6 symboles de votre choix; ces symboles peuvent être des lettres, des chiffres ou des couleurs. " & vbCrLf & vbCrLf &
"Vous avez 20 essais pour être en mesure de trouver la combinaison. Après chaque essai est incrit le nombre de symboles bien placés et le nombre de symboles bons mais mal placé." & vbCrLf & vbCrLf &
"Au jeu !!")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lblDateHeure.Text = Now.ToLongDateString + " " + Now.ToLongTimeString
    End Sub
End Class


