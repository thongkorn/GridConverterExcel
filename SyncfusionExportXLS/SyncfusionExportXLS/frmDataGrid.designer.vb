<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataGrid
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
        Me.components = New System.ComponentModel.Container()
        Me.GGC = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.btnExportXLS = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnExit = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lblTimer = New System.Windows.Forms.Label()
        CType(Me.GGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GGC
        '
        Me.GGC.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GGC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GGC.BackColor = System.Drawing.SystemColors.Window
        Me.GGC.Location = New System.Drawing.Point(0, 61)
        Me.GGC.Name = "GGC"
        Me.GGC.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GGC.Size = New System.Drawing.Size(716, 499)
        Me.GGC.TabIndex = 0
        Me.GGC.TableOptions.GroupHeaderSectionHeight = 20
        Me.GGC.Text = "GridGroupingControl1"
        Me.GGC.UseRightToLeftCompatibleTextBox = True
        Me.GGC.VersionInfo = "15.1400.0.33"
        '
        'btnExportXLS
        '
        Me.btnExportXLS.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnExportXLS.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.btnExportXLS.BeforeTouchSize = New System.Drawing.Size(104, 33)
        Me.btnExportXLS.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Dashed
        Me.btnExportXLS.ComboEditBackColor = System.Drawing.Color.Silver
        Me.btnExportXLS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportXLS.ForeColor = System.Drawing.Color.Black
        Me.btnExportXLS.KeepFocusRectangle = False
        Me.btnExportXLS.Location = New System.Drawing.Point(12, 10)
        Me.btnExportXLS.Name = "btnExportXLS"
        Me.btnExportXLS.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed
        Me.btnExportXLS.Size = New System.Drawing.Size(104, 33)
        Me.btnExportXLS.TabIndex = 41
        Me.btnExportXLS.Text = "Export To Excel"
        Me.btnExportXLS.ThemeName = "Metro"
        Me.btnExportXLS.UseVisualStyle = True
        '
        'btnExit
        '
        Me.btnExit.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.btnExit.BeforeTouchSize = New System.Drawing.Size(104, 33)
        Me.btnExit.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Dashed
        Me.btnExit.ComboEditBackColor = System.Drawing.Color.Silver
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.KeepFocusRectangle = False
        Me.btnExit.Location = New System.Drawing.Point(122, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed
        Me.btnExit.Size = New System.Drawing.Size(104, 33)
        Me.btnExit.TabIndex = 42
        Me.btnExit.Text = "Exit"
        Me.btnExit.ThemeName = "Metro"
        Me.btnExit.UseVisualStyle = True
        '
        'lblTimer
        '
        Me.lblTimer.AutoSize = True
        Me.lblTimer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTimer.Location = New System.Drawing.Point(232, 20)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(47, 16)
        Me.lblTimer.TabIndex = 43
        Me.lblTimer.Text = "Timer:"
        '
        'frmDataGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 564)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnExportXLS)
        Me.Controls.Add(Me.GGC)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Name = "frmDataGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test GridGroupControl - Syncfusion Community License Free bY Thongkorn Tubtimkrob" & _
    ""
        CType(Me.GGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GGC As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents btnExportXLS As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents btnExit As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lblTimer As System.Windows.Forms.Label

End Class
