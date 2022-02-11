'
''Titre: TP2Mastermind_Statistiques
'
'DESCRIPTION: Ce programme affiche les statistiques des joueurs qui ont réussi à trouver la combinaison. 
'
'Les statistiques montrent également, pour chaque partie jouée, la date, 
'le temps et le nombre d'essais qu’il ont eu besoin.
'
'Fait par: Alex Morissette
'Le : 26 mai 2021
'Révisé le : 3 juin 2021
'
Imports System.IO

Public Class frmStatistiques

    Private Sub frmStatistiques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AfficherStatistiques()
    End Sub


    ''' <summary>
    '''   procédure qui permet de faire afficher les résultats des joueurs
    ''' </summary>
    Private Sub AfficherStatistiques()
        Try

            'Vider la liste
            lvStats.Clear()

            ' Faire les en-têtes de colonnes
            lvStats.Columns.Add("Nom du joueur", 140, HorizontalAlignment.Center)
            lvStats.Columns.Add("No de partie", 120, HorizontalAlignment.Center)
            lvStats.Columns.Add("Date et heure", 180, HorizontalAlignment.Center)
            lvStats.Columns.Add("Temps", 100, HorizontalAlignment.Center)
            lvStats.Columns.Add("Réussi", 80, HorizontalAlignment.Center)
            lvStats.Columns.Add("Nombre d'essais", 140, HorizontalAlignment.Center)

            ' Ouvrir le fichier des stats
            Dim fs As New FileStream(frmMastermind.NomFichier, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None)
            Dim br As New BinaryReader(fs)

            ' Ajouter les infos d'une partie
            Dim parties(5) As String ' 6 Éléments -> Nom Joueur, No partie, date et heure, Temps, Combine découverte, Nbr essais

            'Ajouter un item au listView
            Dim item As ListViewItem


            Do
                If br.PeekChar() = -1 Then Return

                parties(0) = br.ReadString().Trim() ' nom du joueur
                parties(1) = br.ReadInt32() ' No partie
                parties(2) = br.ReadString() ' Date et heure
                parties(3) = br.ReadString() ' Temps
                parties(4) = br.ReadString() ' Réussi
                parties(5) = br.ReadInt32() ' Nbr essais

                'Dim sep() As Char = {":"}
                'Dim temps As String
                'temps = Split(parties(3), ":").ToString()

                If parties(4) = "Oui" Then
                    'Ajouter au listview
                    item = New ListViewItem(parties)
                    lvStats.Items.Add(item)
                End If
            Loop

            br.Close()
            fs.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdQuitter_Click(sender As Object, e As EventArgs) Handles cmdQuitter.Click

        Me.Hide()

    End Sub
End Class