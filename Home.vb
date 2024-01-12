Public Class Form1
    Dim Counter As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
        Form2.Picker()
        Form2.PictureBox1.Image = My.Resources.ClosedDoor
        Form2.PictureBox1.BorderStyle = BorderStyle.None
        Form2.PictureBox2.Image = My.Resources.ClosedDoor
        Form2.PictureBox2.BorderStyle = BorderStyle.None
        Form2.PictureBox3.Image = My.Resources.ClosedDoor
        Form2.PictureBox3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub HowToPlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowToPlayToolStripMenuItem.Click
        Label1.Top = 40
        Button1.Visible = False
        If Counter = 0 Then
            SeparatorToolStrip.Visible = True
            ExitToolStripMenuItem.Visible = True
            Counter += 1
        End If
        PictureBox1.Image = My.Resources.How_to_Play
        PictureBox1.Visible = True
    End Sub

    Private Sub ExplanationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExplanationToolStripMenuItem.Click
        Label1.Top = 40
        Button1.Visible = False
        If Counter = 0 Then
            SeparatorToolStrip.Visible = True
            ExitToolStripMenuItem.Visible = True
            Counter += 1
        End If
        PictureBox1.Image = My.Resources.Explanation
        PictureBox1.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        PictureBox1.Visible = False
        Label1.Top = 120
        Button1.Visible = True
        SeparatorToolStrip.Visible = False
        ExitToolStripMenuItem.Visible = False
        Counter -= 1
    End Sub
End Class
