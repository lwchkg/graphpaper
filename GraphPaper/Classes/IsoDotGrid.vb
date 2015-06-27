Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class IsoDotGrid
    Inherits DotGrid

    <BrowsableAttribute(False)> Overrides Property intervalSize As Integer
    <BrowsableAttribute(False)> Overrides Property colorMinor As Color
    <BrowsableAttribute(False)> Overrides Property numDotsMinor As Integer
    <BrowsableAttribute(False)> Overrides Property lineWidthMinor As Single

    Overrides Property Size As Size
    <DefaultValueAttribute(7.0F)> Overrides Property intervalWidth As Single = 7
    <DefaultValueAttribute(8), DescriptionAttribute("Number of dots in an interval.")>
    Overrides Property numDotsMajor As Integer = 8

    Public Overrides Function plot(fstream As System.IO.Stream) As Metafile

        Dim s60 As Single = Math.Sqrt(3) / 2
        Dim s30 As Single = 1 / 2

        Dim img As Metafile = Me._createMetafile(fstream, -1, -1, intervalWidth * Size.Width * s60 + 2,
                                                 intervalWidth * Size.Height + 2)

        Dim grfx As Graphics = Graphics.FromImage(img)

        Dim i, j, st As Single
        Dim l As Integer

        Dim brush1 As Brush = New SolidBrush(colorMajor)

        Dim c As Single = grfx.DpiX / 25.4

        For j = 0 To Size.Width
            l = Size.Height - j Mod 2
            st = (j Mod 2) / 2
            For i = 0 To numDotsMajor * l
                grfx.FillEllipse(brush1, c * (j * intervalWidth * s60 - lineWidthMajor / 2),
                                 c * ((st + i / numDotsMajor) * intervalWidth - lineWidthMajor / 2),
                                 c * lineWidthMajor, c * lineWidthMajor)
            Next
        Next

        For j = (1 - Size.Width) \ 2 To Size.Height - 1
            l = (Size.Height - j) * 2
            If l > Size.Width Then l = Size.Width
            If j >= 0 Then st = 0 Else st = -2 * j : l -= st

            For i = 0 To numDotsMajor * l
                If i Mod numDotsMajor Then
                    grfx.FillEllipse(brush1, c * ((st + i / numDotsMajor) * s60 * intervalWidth - lineWidthMajor / 2),
                                     c * ((j + (st + i / numDotsMajor) * s30) * intervalWidth - lineWidthMajor / 2),
                                     c * lineWidthMajor, c * lineWidthMajor)
                End If
            Next
        Next

        For j = 1 To Size.Height + (Size.Width - 1) \ 2
            l = j * 2
            If l > Size.Width Then l = Size.Width
            If j <= Size.Height Then st = 0 Else st = (j - Size.Height) * 2 : l -= st

            For i = 0 To numDotsMajor * l
                If i Mod numDotsMajor Then
                    grfx.FillEllipse(brush1, c * ((st + i / numDotsMajor) * s60 * intervalWidth - lineWidthMajor / 2),
                                     c * ((j - (st + i / numDotsMajor) * s30) * intervalWidth - lineWidthMajor / 2),
                                     c * lineWidthMajor, c * lineWidthMajor)
                End If
            Next
        Next

        grfx.Dispose()
        'img.Dispose()  ' Do not dispose image. Only close the stream.
        fstream.Close()

        Return img

    End Function

End Class
