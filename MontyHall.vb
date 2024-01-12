Public Class Form2
    Dim CorrectDoor, FirstDoor, SecondDoor, RevealedDoor As Integer
    Dim Lock1, Lock2, Lock3, Second, Ready As Boolean
    Public Stats(,) As Object
    Public Games As Integer = 0
    Private ReadOnly Possible = New Integer(1) {1, 3}

    Public Sub Picker()
        Label2.Text = "Choose One Door"
        Ready = False
        Button1.Visible = False
        Button2.Visible = False
        Randomize()
        CorrectDoor = Int((3 * Rnd()) + 1)
        ReDim Preserve Stats(5, Games)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Ready Then
            PictureBox1.Image = My.Resources.ClosedDoor
            PictureBox1.BorderStyle = BorderStyle.None
            PictureBox2.Image = My.Resources.ClosedDoor
            PictureBox2.BorderStyle = BorderStyle.None
            PictureBox3.Image = My.Resources.ClosedDoor
            PictureBox3.BorderStyle = BorderStyle.None
            CorrectDoor = 0
            FirstDoor = 0
            SecondDoor = 0
            RevealedDoor = 0
            Lock1 = False
            Lock2 = False
            Lock3 = False
            Second = False
            Picker()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Ready Then
            Me.Hide()
            Form3.Show()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Lock1 = False And Second = False Then
            FirstDoor = 1
            PictureBox1.BorderStyle = BorderStyle.Fixed3D
            First()
        ElseIf Lock1 = False And Second Then
            SecondDoor = 1
            PictureBox2.BorderStyle = BorderStyle.None
            PictureBox3.BorderStyle = BorderStyle.None
            Main()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If Lock2 = False And Second = False Then
            FirstDoor = 2
            PictureBox2.BorderStyle = BorderStyle.Fixed3D
            First()
        ElseIf Lock2 = False And Second Then
            SecondDoor = 2
            PictureBox1.BorderStyle = BorderStyle.None
            PictureBox3.BorderStyle = BorderStyle.None
            Main()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Lock3 = False And Second = False Then
            FirstDoor = 3
            PictureBox3.BorderStyle = BorderStyle.Fixed3D
            First()
        ElseIf Lock3 = False And Second Then
            SecondDoor = 3
            PictureBox1.BorderStyle = BorderStyle.None
            PictureBox2.BorderStyle = BorderStyle.None
            Main()
        End If
    End Sub

    Sub First()
        If FirstDoor = CorrectDoor Then
            If CorrectDoor = 1 Then
                RevealedDoor = Int(2 * Rnd() + 2)
                If RevealedDoor = 2 Then
                    PictureBox2.Image = My.Resources.WrongDoor
                    Lock2 = True
                ElseIf RevealedDoor = 3 Then
                    PictureBox3.Image = My.Resources.WrongDoor
                    Lock3 = True
                End If
            ElseIf CorrectDoor = 2 Then
                Randomize()
                RevealedDoor = Possible(Int(2 * Rnd()))
                If RevealedDoor = 1 Then
                    PictureBox1.Image = My.Resources.WrongDoor
                    Lock1 = True
                ElseIf RevealedDoor = 3 Then
                    PictureBox3.Image = My.Resources.WrongDoor
                    Lock3 = True
                End If
            ElseIf CorrectDoor = 3 Then
                RevealedDoor = Int(2 * Rnd() + 1)
                If RevealedDoor = 1 Then
                    PictureBox1.Image = My.Resources.WrongDoor
                    Lock1 = True
                ElseIf RevealedDoor = 2 Then
                    PictureBox2.Image = My.Resources.WrongDoor
                    Lock2 = True
                End If
            End If
        ElseIf Not FirstDoor = CorrectDoor Then
            If CorrectDoor = 1 Then
                If FirstDoor = 2 Then
                    RevealedDoor = 3
                    Lock3 = True
                    PictureBox3.Image = My.Resources.WrongDoor
                ElseIf FirstDoor = 3 Then
                    RevealedDoor = 2
                    Lock2 = True
                    PictureBox2.Image = My.Resources.WrongDoor
                End If
            ElseIf CorrectDoor = 2 Then
                If FirstDoor = 1 Then
                    RevealedDoor = 3
                    Lock3 = True
                    PictureBox3.Image = My.Resources.WrongDoor
                ElseIf FirstDoor = 3 Then
                    RevealedDoor = 1
                    Lock1 = True
                    PictureBox1.Image = My.Resources.WrongDoor
                End If
            ElseIf CorrectDoor = 3 Then
                If FirstDoor = 1 Then
                    RevealedDoor = 2
                    Lock2 = True
                    PictureBox2.Image = My.Resources.WrongDoor
                ElseIf FirstDoor = 2 Then
                    RevealedDoor = 1
                    Lock1 = True
                    PictureBox1.Image = My.Resources.WrongDoor
                End If
            End If
        End If
        Second = True
        Label2.Text = "Make Your Final Choice"
    End Sub

    Sub Main()
        If SecondDoor = 1 Then
            PictureBox1.BorderStyle = BorderStyle.Fixed3D
            If CorrectDoor = 1 Then
                PictureBox1.Image = My.Resources.PrizeDoor
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 1
                    Stats(2, Games) = 0
                Else
                    Stats(3, Games) = 1
                    Stats(4, Games) = 0
                End If
                If RevealedDoor = 2 Then
                    PictureBox3.Image = My.Resources.WrongDoor
                ElseIf RevealedDoor = 3 Then
                    PictureBox2.Image = My.Resources.WrongDoor
                End If
            ElseIf CorrectDoor = 2 Then
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 0
                    Stats(2, Games) = 1
                Else
                    Stats(3, Games) = 0
                    Stats(4, Games) = 1
                End If
                PictureBox2.Image = My.Resources.PrizeDoor
                PictureBox1.Image = My.Resources.WrongDoor
            ElseIf CorrectDoor = 3 Then
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 0
                    Stats(2, Games) = 1
                Else
                    Stats(3, Games) = 0
                    Stats(4, Games) = 1
                End If
                PictureBox3.Image = My.Resources.PrizeDoor
                PictureBox1.Image = My.Resources.WrongDoor
            End If
        ElseIf SecondDoor = 2 Then
            PictureBox2.BorderStyle = BorderStyle.Fixed3D
            If CorrectDoor = 1 Then
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 0
                    Stats(2, Games) = 1
                Else
                    Stats(3, Games) = 0
                    Stats(4, Games) = 1
                End If
                PictureBox1.Image = My.Resources.PrizeDoor
                PictureBox2.Image = My.Resources.WrongDoor
            ElseIf CorrectDoor = 2 Then
                PictureBox2.Image = My.Resources.PrizeDoor
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 1
                    Stats(2, Games) = 0
                Else
                    Stats(3, Games) = 1
                    Stats(4, Games) = 0
                End If
                If RevealedDoor = 1 Then
                    PictureBox3.Image = My.Resources.WrongDoor
                ElseIf RevealedDoor = 3 Then
                    PictureBox1.Image = My.Resources.WrongDoor
                End If
            ElseIf CorrectDoor = 3 Then
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 0
                    Stats(2, Games) = 1
                Else
                    Stats(3, Games) = 0
                    Stats(4, Games) = 1
                End If
                PictureBox3.Image = My.Resources.PrizeDoor
                PictureBox2.Image = My.Resources.WrongDoor
            End If
        ElseIf SecondDoor = 3 Then
            PictureBox3.BorderStyle = BorderStyle.Fixed3D
            If CorrectDoor = 1 Then
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 0
                    Stats(2, Games) = 1
                Else
                    Stats(3, Games) = 0
                    Stats(4, Games) = 1
                End If
                PictureBox1.Image = My.Resources.PrizeDoor
                PictureBox3.Image = My.Resources.WrongDoor
            ElseIf CorrectDoor = 2 Then
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 0
                    Stats(2, Games) = 1
                Else
                    Stats(3, Games) = 0
                    Stats(4, Games) = 1
                End If
                PictureBox2.Image = My.Resources.PrizeDoor
                PictureBox3.Image = My.Resources.WrongDoor
            ElseIf CorrectDoor = 3 Then
                PictureBox3.Image = My.Resources.PrizeDoor
                If FirstDoor = SecondDoor Then
                    Stats(1, Games) = 1
                    Stats(2, Games) = 0
                Else
                    Stats(3, Games) = 1
                    Stats(4, Games) = 0
                End If
                If RevealedDoor = 1 Then
                    PictureBox2.Image = My.Resources.WrongDoor
                ElseIf RevealedDoor = 2 Then
                    PictureBox1.Image = My.Resources.WrongDoor
                End If
            End If
        End If
        Label2.Text = If(SecondDoor <> CorrectDoor, "You Lost", "You Won")
        Button1.Visible = True
        Button2.Visible = True
        Lock1 = True
        Lock2 = True
        Lock3 = True
        Ready = True
        Games += 1
        ReDim Preserve Stats(5, Games)
        Stats(0, (Games - 1)) = Games
    End Sub
End Class