Public Class Form1

#Region "Snake Stuff"
    Dim snake(1000) As PictureBox
    Dim length_of_snake As Integer = -1
    Dim left_right_mover As Integer = 0
    Dim up_down_mover = 0
    Dim r As New Random
    Private Sub create_head()
        length_of_snake += 1
        snake(length_of_snake) = New PictureBox
        With snake(length_of_snake)
            .Height = 10
            .Width = 10
            .BackColor = Color.Lime
            .Top = (pb_field.Top + pb_field.Bottom) / 2
            .Left = (pb_field.Left + pb_field.Right) / 2

        End With
        Me.Controls.Add(snake(length_of_snake))
        snake(length_of_snake).BringToFront()

        lengthensnake()
        lengthensnake()
    End Sub
#End Region
#Region "Collision"
    Private Sub collide_with_walls()
        If snake(0).Left < pb_field.Left Then
            tm_snakeMover.Stop()
            MsgBox("GAME OVER")
        End If
        If snake(0).Right > pb_field.Right Then
            tm_snakeMover.Stop()
            MsgBox("GAME OVER")
        End If
        If snake(0).Top < pb_field.Top Then
            tm_snakeMover.Stop()
            MsgBox("GAME OVER")
        End If
        If snake(0).Bottom > pb_field.Bottom Then
            tm_snakeMover.Stop()
            MsgBox("GAME OVER")
        End If
    End Sub

    Private Sub collide_with_mouse()
        If snake(0).Bounds.IntersectsWith(mouse.Bounds) Then
            lengthensnake()
            mouse.Top = r.Next
            mouse.Top = r.Next(pb_field.Top, pb_field.Bottom - 10)
            mouse.Left = r.Next(pb_field.Left, pb_field.Right - 10)
        End If
    End Sub
#End Region
#Region "Mouse Movement"
    Dim mouse As PictureBox
    Private Sub create_mouse()
        mouse = New PictureBox
        With mouse
            .Width = 10
            .Height = 10
            .BackColor = Color.Red

            .Top = r.Next(pb_field.Top, pb_field.Bottom - 10)
            .Left = r.Next(pb_field.Left, pb_field.Right - 10)

        End With
        Me.Controls.Add(mouse)
        mouse.BringToFront()
    End Sub
#End Region
    Private Sub lengthensnake()
        length_of_snake += 1
        Label2.Text = length_of_snake - 2
        snake(length_of_snake) = New PictureBox
        With snake(length_of_snake)
            .Height = 10
            .Width = 10
            .BackColor = Color.Lime
            .Top = snake(length_of_snake - 1).Top
            .Left = snake(length_of_snake - 1).Left + 10
        End With
        Me.Controls.Add(snake(length_of_snake))
        snake(length_of_snake).BringToFront()
    End Sub
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case "a"
                left_right_mover = -10
                up_down_mover = 0
            Case "d"
                left_right_mover = 10
                up_down_mover = 0
            Case "w"
                up_down_mover = -10
                left_right_mover = 0
            Case "s"
                up_down_mover = 10
                left_right_mover = 0
        End Select
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tm_snakeMover.Tick

        For i = length_of_snake To 1 Step -1
            snake(i).Top = snake(i - 1).Top
            snake(i).Left = snake(i - 1).Left
        Next

        snake(0).Top += up_down_mover
        snake(0).Left += left_right_mover
        collide_with_walls()
        collide_with_mouse()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        create_head()
        create_mouse()
        tm_snakeMover.Start()
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pb_field_Click(sender As Object, e As EventArgs) Handles pb_field.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
