<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Devansh = New System.Windows.Forms.Button()
        Me.Aiden = New System.Windows.Forms.Button()
        Me.Pranav = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(343, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Devansh
        '
        Me.Devansh.Location = New System.Drawing.Point(164, 273)
        Me.Devansh.Name = "Devansh"
        Me.Devansh.Size = New System.Drawing.Size(94, 29)
        Me.Devansh.TabIndex = 1
        Me.Devansh.Text = "Devansh"
        Me.Devansh.UseVisualStyleBackColor = True
        '
        'Aiden
        '
        Me.Aiden.Location = New System.Drawing.Point(343, 273)
        Me.Aiden.Name = "Aiden"
        Me.Aiden.Size = New System.Drawing.Size(94, 29)
        Me.Aiden.TabIndex = 2
        Me.Aiden.Text = "Aiden"
        Me.Aiden.UseVisualStyleBackColor = True
        '
        'Pranav
        '
        Me.Pranav.Location = New System.Drawing.Point(514, 273)
        Me.Pranav.Name = "Pranav"
        Me.Pranav.Size = New System.Drawing.Size(94, 29)
        Me.Pranav.TabIndex = 3
        Me.Pranav.Text = "Pranav"
        Me.Pranav.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Pranav)
        Me.Controls.Add(Me.Aiden)
        Me.Controls.Add(Me.Devansh)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainMenu"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Devansh As Button
    Friend WithEvents Aiden As Button
    Friend WithEvents Pranav As Button
End Class
