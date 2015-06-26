Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class RectLineGrid
    Inherits LineGrid

    Public Overrides Function plot(fstream As System.IO.Stream) As Metafile

        Dim img As Metafile = Me._createMetafile(fstream, -1, -1, intervalWidth * Size.Width + 2,
                                                 intervalWidth * Size.Height + 2)

        Dim grfx As Graphics = Graphics.FromImage(img)

        Dim i As Integer
        Dim j As Single

        Dim c As Single = grfx.DpiX / 25.4

        Dim penMajor As Pen = New Pen(colorMajor, c * lineWidthMajor)
        Dim penMinor As Pen = New Pen(colorMinor, c * lineWidthMinor)

        Dim xmax As Single = c * Size.Width * intervalWidth
        Dim ymax As Single = c * Size.Height * intervalWidth

        For i = 0 To Size.Height * intervalSize
            If i Mod intervalSize Then
                j = c * i * intervalWidth / intervalSize
                grfx.DrawLine(penMinor, 0, j, xmax, j)
            End If
        Next

        For i = 0 To Size.Width * intervalSize
            If i Mod intervalSize Then
                j = c * i * intervalWidth / intervalSize
                grfx.DrawLine(penMinor, j, 0, j, ymax)
            End If
        Next

        For i = 1 To Size.Height - 1
            j = c * i * intervalWidth
            grfx.DrawLine(penMajor, 0, j, xmax, j)
        Next

        For i = 1 To Size.Width - 1
            j = c * i * intervalWidth
            grfx.DrawLine(penMajor, j, 0, j, ymax)
        Next

        grfx.DrawRectangle(penMajor, 0, 0, xmax, ymax)

        grfx.Dispose()
        'img.Dispose()  ' Do not dispose image. Only close the stream.
        fstream.Close()

        Return img

    End Function
End Class
