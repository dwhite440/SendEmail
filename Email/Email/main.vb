Imports System
Imports System.Net.Mail

Public Class main

    Public Sub senderMail()
        Dim cliente As New SmtpClient

        Try
            Dim emailOrirgem As New MailAddress(txtfrom.Text.Trim.ToString)
            Dim emailDestino As New MailAddress(txtto.Text.Trim.ToString)
            Dim mensagem As New MailMessage

            mensagem.To.Add(emailDestino)
            mensagem.From = emailOrirgem
            mensagem.Subject = txtsubject.Text.Trim.ToString
            mensagem.Body = rtxdescription.Text.Trim.ToString
            mensagem.IsBodyHtml = True

            cliente.Host = "smtp.gmail.com"
            cliente.Credentials = New System.Net.NetworkCredential("hugodieb.hd@gmail.com", "APOCALIPSE")
            cliente.Port = 587
            cliente.EnableSsl = True
            cliente.Send(mensagem)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblStatus.Text = "Email enviado.."
            lblStatus.Show()
        End Try
    End Sub

    Private Enum portSMTP As Integer
        gmail = 587

    End Enum

    Public Sub cleanBox()
        txtto.Text = ""
        txtsubject.Text = ""
        rtxdescription.Text = ""

    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        senderMail()
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        cleanBox()
        lblStatus.Hide()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub
  
End Class
