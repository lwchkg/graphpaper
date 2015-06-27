Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class IsoLineGrid
    Inherits LineGrid

    <BrowsableAttribute(False)> Overrides Property intervalSize As Integer
    <BrowsableAttribute(False)> Overrides Property colorMinor As Color
    <BrowsableAttribute(False)> Overrides Property lineWidthMinor As Single

    Overrides Property Size As Size
    <DefaultValueAttribute(7.0F)> Overrides Property intervalWidth As Single = 7

    Public Overrides Function plot(fstream As System.IO.Stream) As Metafile

        Dim s60 As Single = Math.Sqrt(3) / 2
        Dim s30 As Single = 1 / 2

        Dim img As Metafile = Me._createMetafile(fstream, -1, -1, intervalWidth * Size.Width * s60 + 2,
                                                 intervalWidth * Size.Height + 2)

        Dim grfx As Graphics = Graphics.FromImage(img)

        Dim i As Integer
        Dim j, st As Single
        Dim l As Integer

        Dim c As Single = grfx.DpiX / 25.4

        Dim pen1 As Pen = New Pen(colorMajor, c * lineWidthMajor)

        For i = 1 To Size.Width - 1     '0 To Size.Width
            j = c * i * s60 * intervalWidth
            l = Size.Height     ' - i Mod 2
            st = 0              '(i Mod 2) / 2
            grfx.DrawLine(pen1, j, c * st * intervalWidth, j, c * (st + l) * intervalWidth)
        Next

        For i = (1 - Size.Width) \ 2 To Size.Height - 1
            l = (Size.Height - i) * 2
            If l > Size.Width Then l = Size.Width
            If i >= 0 Then st = 0 Else st = -2 * i : l -= st
            grfx.DrawLine(pen1, c * st * s60 * intervalWidth, c * (i + st * s30) * intervalWidth,
                          c * (st + l) * s60 * intervalWidth, c * (i + (st + l) * s30) * intervalWidth)
        Next

        For i = 1 To Size.Height + (Size.Width - 1) \ 2
            l = i * 2
            If l > Size.Width Then l = Size.Width
            If i <= Size.Height Then st = 0 Else st = (i - Size.Height) * 2 : l -= st
            grfx.DrawLine(pen1, c * st * s60 * intervalWidth, c * (i - st * s30) * intervalWidth,
                          c * (st + l) * s60 * intervalWidth, c * (i - (st + l) * s30) * intervalWidth)
        Next

        grfx.DrawRectangle(pen1, 0, 0, c * Size.Width * s60 * intervalWidth, c * Size.Height * intervalWidth)

        grfx.Dispose()
        'img.Dispose()  ' Do not dispose image. Only close the stream.
        fstream.Close()

        Return img

    End Function

End Class
