Imports System.ComponentModel

Public MustInherit Class DotGrid

    Inherits GridBase

    <CategoryAttribute("Appearance"), DefaultValueAttribute(3),
    DescriptionAttribute("Major lines - Number of dots in a small interval. 0 = do not plot.")>
    Public Overridable Property numDotsMajor As Integer = 3

    <CategoryAttribute("Appearance"), DefaultValueAttribute(4),
    DescriptionAttribute("Minor lines - Number of dots in a small interval. 0 = do not plot.")>
    Public Overridable Property numDotsMinor As Integer = 4

End Class
