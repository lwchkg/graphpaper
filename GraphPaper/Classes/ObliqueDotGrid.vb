Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class ObliqueDotGrid
    Inherits DotGrid

    <BrowsableAttribute(False)> Overrides Property intervalSize As Integer
    <BrowsableAttribute(False)> Overrides Property colorMinor As Color
    <BrowsableAttribute(False)> Overrides Property numDotsMinor As Integer
    <BrowsableAttribute(False)> Overrides Property lineWidthMinor As Single

    Overrides Property Size As Size
    <DefaultValueAttribute(7.0F)> Overrides Property intervalWidth As Single = 7
    <DefaultValueAttribute(8), DescriptionAttribute("Number of dots in a horizontal or vertical interval.")>
    Overrides Property numDotsMajor As Integer = 8

    Public Overrides Function plot(fstream As System.IO.Stream) As Metafile

        Dim img As Metafile = Me._createMetafile(fstream, -1, -1, intervalWidth * Size.Width + 2,
                                                 intervalWidth * Size.Height + 2)

        Dim grfx As Graphics = Graphics.FromImage(img)

        Dim i, j As Single
        Dim l, st As Integer
        Dim numDotsOblique As Integer = Math.Round(numDotsMajor * Math.Sqrt(2))

        Dim brush1 As Brush = New SolidBrush(colorMajor)

        Dim c As Single = grfx.DpiX / 25.4

        For j = 0 To Size.Height
            For i = 0 To numDotsMajor * Size.Width
                grfx.FillEllipse(brush1, c * (i * intervalWidth / numDotsMajor - lineWidthMajor / 2),
                                 c * (j * intervalWidth - lineWidthMajor / 2), c * lineWidthMajor, c * lineWidthMajor)
            Next
        Next

        For j = 0 To Size.Width
            For i = 0 To numDotsMajor * Size.Height
                If i Mod numDotsMajor Then
                    grfx.FillEllipse(brush1, c * (j * intervalWidth - lineWidthMajor / 2),
                                     c * (i * intervalWidth / numDotsMajor - lineWidthMajor / 2),
                                     c * lineWidthMajor, c * lineWidthMajor)
                End If
            Next
        Next

        For j = 1 To Size.Height + Size.Width - 1
            l = j
            If l > Size.Width Then l = Size.Width
            If j <= Size.Height Then st = 0 Else st = j - Size.Height : l -= st

            For i = 0 To numDotsOblique * l
                If i Mod numDotsOblique Then
                    grfx.FillEllipse(brush1, c * ((st + i / numDotsOblique) * intervalWidth - lineWidthMajor / 2),
                                     c * ((j - (st + i / numDotsOblique)) * intervalWidth - lineWidthMajor / 2),
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
