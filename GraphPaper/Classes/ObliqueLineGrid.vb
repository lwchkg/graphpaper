Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class ObliqueLineGrid
    Inherits LineGrid

    <BrowsableAttribute(False)> Overrides Property intervalSize As Integer
    <BrowsableAttribute(False)> Overrides Property colorMinor As Color
    <BrowsableAttribute(False)> Overrides Property lineWidthMinor As Single

    Overrides Property size As Size
    <DefaultValueAttribute(7.0F)> Overrides Property intervalWidth As Single = 7

    Public Overrides Function plot(fstream As System.IO.Stream) As Metafile

        Dim img As Metafile = Me._createMetafile(fstream, -1, -1, intervalWidth * Size.Width + 2,
                                                 intervalWidth * Size.Height + 2)

        Dim grfx As Graphics = Graphics.FromImage(img)

        Dim i As Integer, j As Single
        Dim l, st As Integer

        Dim c As Single = grfx.DpiX / 25.4

        Dim pen1 As Pen = New Pen(colorMajor, c * lineWidthMajor)

        Dim xmax As Single = c * Size.Width * intervalWidth
        Dim ymax As Single = c * Size.Height * intervalWidth

        For i = 1 To Size.Height + Size.Width - 1
            l = i
            If l > Size.Width Then l = Size.Width
            If i <= Size.Height Then st = 0 Else st = i - Size.Height : l -= st
            grfx.DrawLine(pen1, c * st * intervalWidth, c * (i - st) * intervalWidth,
                          c * (st + l) * intervalWidth, c * (i - (st + l)) * intervalWidth)
        Next

        For i = 1 To Size.Height - 1
            j = c * i * intervalWidth
            grfx.DrawLine(pen1, 0, j, xmax, j)
        Next

        For i = 1 To Size.Width - 1
            j = c * i * intervalWidth
            grfx.DrawLine(pen1, j, 0, j, ymax)
        Next

        grfx.DrawRectangle(pen1, 0, 0, xmax, ymax)

        grfx.Dispose()
        'img.Dispose()  ' Do not dispose image. Only close the stream.
        fstream.Close()

        Return img

    End Function

End Class
