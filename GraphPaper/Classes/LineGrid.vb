Imports System.ComponentModel

Public MustInherit Class LineGrid
    Inherits GridBase

    <DefaultValueAttribute(GetType(Color), "208, 208, 208")>
    Overrides Property colorMajor As Color = Color.FromArgb(&HFFD0D0D0)

    <DefaultValueAttribute(GetType(Color), "208, 208, 208")>
    Overrides Property colorMinor As Color = Color.FromArgb(&HFFD0D0D0)

    <DefaultValueAttribute(0.5F)> Overrides Property lineWidthMajor As Single = 0.5

    <DefaultValueAttribute(0.25F)> Overrides Property lineWidthMinor As Single = 0.25

End Class
