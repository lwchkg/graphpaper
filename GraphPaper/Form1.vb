Imports System.IO
Imports System.Drawing.Imaging

Structure gridType
    Sub New(p1 As String, p2 As Type)
        name = p1
        type = p2
    End Sub

    Public Property name As String
    Public Property type As Type
End Structure

Public Class Form1
    Dim grapher As Object

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = ApplicationTitle

        Dim a As IList = {
            New gridType("Rectangular Grid (Dot)", GetType(RectDotGrid)),
            New gridType("Isometric Grid (Dot)", GetType(IsoDotGrid)),
            New gridType("Oblique Grid (Dot)", GetType(ObliqueDotGrid)),
            New gridType("Rectangular Grid (Line)", GetType(RectLineGrid)),
            New gridType("Isometric Grid (Line)", GetType(IsoLineGrid)),
            New gridType("Oblique Grid (Line)", GetType(ObliqueLineGrid))
        }

        ComboBox1.DisplayMember = "name"
        ComboBox1.ValueMember = "type"
        ComboBox1.DataSource = a

    End Sub

    Private Sub ButtonSaveFile_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSaveFile.Click
        If SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim s As Stream = SaveFileDialog1.OpenFile()
        grapher.Plot(s)
    End Sub

    Private Sub ButtonSaveClipboard_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSaveClipboard.Click
        Dim s As MemoryStream = New MemoryStream()
        Dim m As Metafile = grapher.Plot(s)
        ClipboardMetafileHelper.PutEnhMetafileOnClipboard(Me.Handle, m)
    End Sub

    Private Sub ButtonAbout_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAbout.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If ComboBox1.SelectedIndex <> -1 Then
            grapher = CType(ComboBox1.SelectedValue, Type).GetConstructor({}).Invoke({})
            PropertyGrid1.SelectedObject = grapher
        End If
    End Sub

End Class
