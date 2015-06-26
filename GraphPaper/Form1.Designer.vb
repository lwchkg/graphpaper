<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonSaveFile = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.ButtonSaveClipboard = New System.Windows.Forms.Button()
        Me.ButtonAbout = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonSaveFile
        '
        Me.ButtonSaveFile.Location = New System.Drawing.Point(408, 100)
        Me.ButtonSaveFile.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSaveFile.Name = "ButtonSaveFile"
        Me.ButtonSaveFile.Size = New System.Drawing.Size(146, 30)
        Me.ButtonSaveFile.TabIndex = 3
        Me.ButtonSaveFile.Text = "&Save File"
        Me.ButtonSaveFile.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(132, 14)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(252, 24)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Type of Paper:"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Enhanced Metafiles (*.emf)|*.emf"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(25, 65)
        Me.PropertyGrid1.Margin = New System.Windows.Forms.Padding(4)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PropertyGrid1.Size = New System.Drawing.Size(359, 270)
        Me.PropertyGrid1.TabIndex = 2
        Me.PropertyGrid1.ToolbarVisible = False
        '
        'ButtonSaveClipboard
        '
        Me.ButtonSaveClipboard.Location = New System.Drawing.Point(408, 138)
        Me.ButtonSaveClipboard.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSaveClipboard.Name = "ButtonSaveClipboard"
        Me.ButtonSaveClipboard.Size = New System.Drawing.Size(146, 30)
        Me.ButtonSaveClipboard.TabIndex = 4
        Me.ButtonSaveClipboard.Text = "Save to &Clipboard"
        Me.ButtonSaveClipboard.UseVisualStyleBackColor = True
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Location = New System.Drawing.Point(408, 217)
        Me.ButtonAbout.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(146, 30)
        Me.ButtonAbout.TabIndex = 5
        Me.ButtonAbout.Text = "About"
        Me.ButtonAbout.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 354)
        Me.Controls.Add(Me.ButtonAbout)
        Me.Controls.Add(Me.ButtonSaveClipboard)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ButtonSaveFile)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSaveFile As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents ButtonSaveClipboard As System.Windows.Forms.Button
    Friend WithEvents ButtonAbout As System.Windows.Forms.Button

End Class
