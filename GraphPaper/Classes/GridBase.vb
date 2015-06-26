Imports System.Drawing.Imaging
Imports System.IO
Imports System.ComponentModel

Public MustInherit Class GridBase

    <CategoryAttribute("Basic Settings"), DefaultValueAttribute(GetType(Size), "10, 10"),
    DescriptionAttribute("Size of the graph paper, in number of big intervals.")>
    Public Overridable Property Size As Size = New Size(10, 10)

    <CategoryAttribute("Basic Settings"), DefaultValueAttribute(5),
    DescriptionAttribute("Size of a big interval (in number of small intervals).")>
    Public Overridable Property intervalSize As Integer = 5

    <CategoryAttribute("Basic Settings"), DefaultValueAttribute(10.0F),
    DescriptionAttribute("Size of a big interval (in millimeters).")>
    Public Overridable Property intervalWidth As Single = 10

    <CategoryAttribute("Appearance"), DefaultValueAttribute(GetType(Color), "Black"),
    DescriptionAttribute("Color of major lines.")>
    Public Overridable Property colorMajor As Color = Color.Black

    <CategoryAttribute("Appearance"), DefaultValueAttribute(GetType(Color), "Black"),
    DescriptionAttribute("Color of minor lines.")>
    Public Overridable Property colorMinor As Color = Color.Black

    <CategoryAttribute("Appearance"), DefaultValueAttribute(0.25F),
    DescriptionAttribute("Width of major lines (in millimeters).")>
    Public Overridable Property lineWidthMajor As Single = 0.25

    <CategoryAttribute("Appearance"), DefaultValueAttribute(0.15F),
    DescriptionAttribute("Width of minor lines (in millimeters).")>
    Public Overridable Property lineWidthMinor As Single = 0.15

    Private emfT As EmfType = EmfType.EmfPlusOnly

    Protected Function _createMetafile(fstream As Stream, ByVal left As Single, ByVal top As Single,
                                       ByVal width As Single, ByVal height As Single,
                                       Optional dpi As Single = 25.4) As Metafile

        Dim g As Graphics = New System.Windows.Forms.Control().CreateGraphics() ' get a graphics object
        Dim c As Single = g.DpiX / dpi

        Dim img As Metafile = New Metafile(fstream, g.GetHdc(),
                                           New Rectangle(Math.Floor(c * left), Math.Floor(c * top),
                                                         Math.Ceiling(c * width), Math.Ceiling(c * height)),
                                           MetafileFrameUnit.Pixel, Me.emfT) ' file is created here
        ' Testing shows that only MetafileFrameUnit.Pixel works without bugs
        g.ReleaseHdc()
        g.Dispose()

        Return img

    End Function

    Public MustOverride Function plot(fstream As System.IO.Stream) As System.Drawing.Imaging.Metafile

End Class
