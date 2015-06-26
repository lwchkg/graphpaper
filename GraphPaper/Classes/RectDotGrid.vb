Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class RectDotGrid
    Inherits DotGrid

    Public Overrides Function plot(fstream As System.IO.Stream) As Metafile

        Dim img As Metafile = Me._createMetafile(fstream, -1, -1, intervalWidth * Size.Width + 2,
                                                 intervalWidth * Size.Height + 2)

        Dim grfx As Graphics = Graphics.FromImage(img)

        Dim i, j As Single

        Dim brush1 As Brush = New SolidBrush(colorMajor)
        Dim brush2 As Brush = New SolidBrush(colorMinor)

        Dim c As Single = grfx.DpiX / 25.4

        For j = 0 To Size.Height
            For i = 0 To intervalSize * numDotsMajor * Size.Width
                grfx.FillEllipse(brush1, c * (i * intervalWidth / intervalSize / numDotsMajor - lineWidthMajor / 2),
                                 c * (j * intervalWidth - lineWidthMajor / 2), c * lineWidthMajor, c * lineWidthMajor)
            Next
        Next

        For j = 0 To Size.Width
            For i = 0 To intervalSize * numDotsMajor * Size.Height
                If i Mod intervalSize * numDotsMajor Then
                    grfx.FillEllipse(brush1, c * (j * intervalWidth - lineWidthMajor / 2),
                                     c * (i * intervalWidth / intervalSize / numDotsMajor - lineWidthMajor / 2),
                                     c * lineWidthMajor, c * lineWidthMajor)
                End If
            Next
        Next

        For j = 0 To Size.Height * intervalSize
            For i = 0 To intervalSize * numDotsMinor * Size.Width
                If j Mod intervalSize AndAlso i Mod intervalSize * numDotsMinor Then
                    grfx.FillEllipse(brush2, c * (i * intervalWidth / intervalSize / numDotsMinor - lineWidthMinor / 2),
                                     c * (j * intervalWidth / intervalSize - lineWidthMinor / 2), c * lineWidthMinor, c * lineWidthMinor)
                End If
            Next
        Next

        For j = 0 To Size.Width * intervalSize
            For i = 0 To intervalSize * numDotsMinor * Size.Height
                If j Mod intervalSize AndAlso i Mod numDotsMinor Then
                    grfx.FillEllipse(brush2, c * (j * intervalWidth / intervalSize - lineWidthMinor / 2),
                                     c * (i * intervalWidth / intervalSize / numDotsMinor - lineWidthMinor / 2),
                                     c * lineWidthMinor, c * lineWidthMinor)
                End If
            Next
        Next

        grfx.Dispose()
        'img.Dispose()  ' Do not dispose image. Only close the stream.
        fstream.Close()

        Return img

    End Function
End Class
