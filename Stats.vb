Public Class Form3
    Dim Games, Won, Lost, Kept, Changed, Percentage1, Percentage2 As Integer
    Private Const Correct As String = "X"
    Private ReadOnly NumberOfGames As Integer = Form2.Games

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            ListView1.Clear()
            ListView1.Columns.Add("", 0)
            ListView1.Columns.Add("Game", 79, HorizontalAlignment.Center)
            ListView1.Columns.Add("Kept Won", 125, HorizontalAlignment.Center)
            ListView1.Columns.Add("Kept Lost", 125, HorizontalAlignment.Center)
            ListView1.Columns.Add("Changed Won", 125, HorizontalAlignment.Center)
            ListView1.Columns.Add("Changed Lost", 125, HorizontalAlignment.Center)
            Label2.Text = "Number Of Games: " + NumberOfGames.ToString()
            All_Games()
            Label3.Text = Nothing
            Label4.Text = Nothing
        End If
        If ComboBox1.SelectedIndex = 1 Then
            ListView1.Clear()
            ListView1.Columns.Add("", 0)
            ListView1.Columns.Add("Game", 79, HorizontalAlignment.Center)
            ListView1.Columns.Add("Kept", 250, HorizontalAlignment.Center)
            ListView1.Columns.Add("Changed", 250, HorizontalAlignment.Center)
            Won_Games()
            Label2.Text = "Games Won: " + Games.ToString()
            If Games = 0 Then
                Label3.Text = Nothing
                Label4.Text = Nothing
                Return
            End If
            Label3.Text = $"{Percentage1} %"
            Label4.Text = $"{Percentage2} %"
        End If
        If ComboBox1.SelectedIndex = 2 Then
            ListView1.Clear()
            ListView1.Columns.Add("", 0)
            ListView1.Columns.Add("Game", 79, HorizontalAlignment.Center)
            ListView1.Columns.Add("Kept", 250, HorizontalAlignment.Center)
            ListView1.Columns.Add("Changed", 250, HorizontalAlignment.Center)
            Lost_Games()
            Label2.Text = "Games Lost: " + Games.ToString()
            If Games = 0 Then
                Label3.Text = Nothing
                Label4.Text = Nothing
                Return
            End If
            Label3.Text = $"{Percentage1} %"
            Label4.Text = $"{Percentage2} %"
        End If
        If ComboBox1.SelectedIndex = 3 Then
            ListView1.Clear()
            ListView1.Columns.Add("", 0)
            ListView1.Columns.Add("Game", 79, HorizontalAlignment.Center)
            ListView1.Columns.Add("Won", 250, HorizontalAlignment.Center)
            ListView1.Columns.Add("Lost", 250, HorizontalAlignment.Center)
            Kept_Door()
            Label2.Text = If(Games = 1, $"Kept Door In 1 Game", $"Kept Door In {Games} Games")
            If Games = 0 Then
                Label3.Text = Nothing
                Label4.Text = Nothing
                Return
            End If
            Label3.Text = $"{Percentage1} %"
            Label4.Text = $"{Percentage2} %"
        End If
        If ComboBox1.SelectedIndex = 4 Then
            ListView1.Clear()
            ListView1.Columns.Add("", 0)
            ListView1.Columns.Add("Game", 79, HorizontalAlignment.Center)
            ListView1.Columns.Add("Won", 250, HorizontalAlignment.Center)
            ListView1.Columns.Add("Lost", 250, HorizontalAlignment.Center)
            Changed_Door()
            Label2.Text = If(Games = 1, $"Changed Door In 1 Game", $"Changed Door In {Games} Games")
            If Games = 0 Then
                Label3.Text = Nothing
                Label4.Text = Nothing
                Return
            End If
            Label3.Text = $"{Percentage1} %"
            Label4.Text = $"{Percentage2} %"
        End If
    End Sub

    Sub All_Games()
        For i As Integer = 0 To NumberOfGames - 1
            Dim Stats As ListViewItem
            Stats = ListView1.Items.Add("")
            Stats.SubItems.Add(i + 1)
            Stats.SubItems.Add("")
            Stats.SubItems.Add("")
            Stats.SubItems.Add("")
            Stats.SubItems.Add("")
            For j As Integer = 1 To 4
                If Form2.Stats(j, i) = 1 Then
                    ListView1.Items(i).SubItems(j + 1).Text = Correct
                End If
            Next
        Next
    End Sub

    Sub Won_Games()
        Games = 0
        Kept = 0
        Changed = 0
        For i As Integer = 0 To NumberOfGames - 1
            If Form2.Stats(1, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add(Correct)
                Stats.SubItems.Add("")
                Games += 1
                Kept += 1
            ElseIf Form2.Stats(3, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add("")
                Stats.SubItems.Add(Correct)
                Games += 1
                Changed += 1
            End If
        Next
        If Games = 0 Then
            Return
        End If
        Percentage1 = (Games - Changed) / Games * 100
        Percentage2 = (Games - Kept) / Games * 100
    End Sub

    Sub Lost_Games()
        Games = 0
        Kept = 0
        Changed = 0
        For i As Integer = 0 To NumberOfGames - 1
            If Form2.Stats(2, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add(Correct)
                Stats.SubItems.Add("")
                Games += 1
                Kept += 1
            ElseIf Form2.Stats(4, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add("")
                Stats.SubItems.Add(Correct)
                Games += 1
                Changed += 1
            End If
        Next
        If Games = 0 Then
            Return
        End If
        Percentage1 = (Games - Changed) / Games * 100
        Percentage2 = (Games - Kept) / Games * 100
    End Sub

    Sub Kept_Door()
        Games = 0
        Won = 0
        Lost = 0
        For i As Integer = 0 To NumberOfGames - 1
            If Form2.Stats(1, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add(Correct)
                Stats.SubItems.Add("")
                Games += 1
                Won += 1
            ElseIf Form2.Stats(2, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add("")
                Stats.SubItems.Add(Correct)
                Games += 1
                Lost += 1
            End If
        Next
        If Games = 0 Then
            Return
        End If
        Percentage1 = (Games - Lost) / Games * 100
        Percentage2 = (Games - Won) / Games * 100
    End Sub

    Sub Changed_Door()
        Games = 0
        Won = 0
        Lost = 0
        For i As Integer = 0 To NumberOfGames - 1
            If Form2.Stats(3, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add(Correct)
                Stats.SubItems.Add("")
                Games += 1
                Won += 1
            ElseIf Form2.Stats(4, i) = 1 Then
                Dim Stats As ListViewItem
                Stats = ListView1.Items.Add("")
                Stats.SubItems.Add(i + 1)
                Stats.SubItems.Add("")
                Stats.SubItems.Add(Correct)
                Games += 1
                Lost += 1
            End If
        Next
        If Games = 0 Then
            Return
        End If
        Percentage1 = (Games - Lost) / Games * 100
        Percentage2 = (Games - Won) / Games * 100
    End Sub
End Class