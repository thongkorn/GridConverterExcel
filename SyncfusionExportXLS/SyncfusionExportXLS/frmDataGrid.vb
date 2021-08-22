#Region "About"
' / --------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gnet.com/webboard
' /
' / Purpose: Export to Excel with SyncFusion Community License.
' / Microsoft Visual Basic .NET (2010) & MS Access 2007+
' /
' / This is open source code under @CopyLeft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------------
#End Region

Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
'
Imports System.Data.OleDb
'// Addition
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.GridExcelConverter

Public Class frmDataGrid

    Private Sub frmDataGrid_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Me.Dispose()
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub
    ' / --------------------------------------------------------------------------------
    Private Sub frmDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ConnectDataBase()
        '//
        Call RetrieveData()
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Select show all records.
    Private Sub RetrieveData()
        strSQL = _
            " SELECT tblSample.PrimaryKey, tblSample.ID, tblSample.NumberField, tblSample.DoubleField, " & _
            " tblSample.DateField, tblGroup.GroupName " & _
            " FROM tblSample INNER JOIN tblGroup ON tblSample.GroupFK = tblGroup.GroupPK " & _
            " ORDER BY PrimaryKey "
        '//
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Try
            DS = New DataSet
            DA = New OleDbDataAdapter(strSQL, Conn)
            DA.Fill(DS, "Sample") '/ Change items to your database name
            Me.GGC.DataSource = DS.Tables(0)
            DA.Dispose()
            DS.Dispose()
            Conn.Close()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
        '//
        Call InitGridGroup()
    End Sub

    ' / --------------------------------------------------------------------------------
    Private Sub InitGridGroup()
        '// Initialize normal GridGroup
        With Me.GGC
            '// Styles
            .GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            ' Disables editing in GridGroupingControl
            .ActivateCurrentCellBehavior = GridCellActivateAction.None
            ' Allows GroupDropArea to be visible
            .ShowGroupDropArea = False 'True
            '// Disable Add New
            .TableDescriptor.AllowNew = False
            '// Autofit Columns
            .AllowProportionalColumnSizing = True
            '// Autofit Rows (No wrap)
            '.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
            .Table.DefaultRecordRowHeight = 25
            '// Selection
            .TableOptions.ListBoxSelectionMode = SelectionMode.One
            'Selection Back color
            .TableOptions.SelectionBackColor = Color.Firebrick
            '//
            .Appearance.ColumnHeaderCell.TextColor = Color.DarkCyan
            .Appearance.ColumnHeaderCell.Font.Bold = True
        End With
        For i As Byte = 1 To 5
            With Me.GGC.TableDescriptor
                .Columns(i).Appearance.AnyRecordFieldCell.VerticalAlignment = GridVerticalAlignment.Middle
                .Columns(i).AllowGroupByColumn = False
                ' // Set Font any Columns.
                .Columns(i).Appearance.AnyRecordFieldCell.Font = New Syncfusion.Windows.Forms.Grid.GridFontInfo(New Font("Tahoma", 11.0F, FontStyle.Regular))
            End With
        Next
        '// Initialize Columns GridGroup
        With Me.GGC.TableDescriptor
            '// Hidden Primary Key Column
            .VisibleColumns.Remove("PrimaryKey")
            'Using Column Name
            .Columns("ID").HeaderText = "ID"
            With .Columns("NumberField")
                .HeaderText = "Number Value"
                .Appearance.AnyRecordFieldCell.CellValueType = GetType(Int32)
                .Appearance.AnyRecordFieldCell.Format = "N0"
            End With
            .Columns("DoubleField").HeaderText = "Double Value"
            .Columns("DateField").HeaderText = "Date"
            .Columns("DateField").Appearance.AnyRecordFieldCell.Format = "dd/MM/yyyy"
            .Columns("DateField").Appearance.AnyRecordFieldCell.Clickable = False
            .Columns("GroupName").HeaderText = "Group Name"
            '.VisibleColumns.Remove("GroupName")
        End With
        '//
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Double click event for show PrimaryKey which hidden in Column(0)
    Private Sub GridGroupingControl1_TableControlCellDoubleClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GGC.TableControlCellDoubleClick
        ' Notify the double click performed in a cell
        Dim rec As Record = Me.GGC.Table.DisplayElements(e.TableControl.CurrentCell.RowIndex).ParentRecord
        If (rec) IsNot Nothing Then MessageBoxAdv.Show("Primary key = " & rec.GetValue("PrimaryKey").ToString, "MessageBoxAdv Syncfusion.")
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Full Select Row
    Private Sub gridGroupingControl1_TableControlCurrentCellActivating(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCurrentCellActivatingEventArgs) Handles GGC.TableControlCurrentCellActivating
        e.Inner.ColIndex = 0
    End Sub

    Private Sub btnExportXLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportXLS.Click
        Dim excelConverter As New GroupingGridExcelConverterControl()
        excelConverter.ExportStyle = True
        '/ Start-Stop Timer
        Dim sWatch As New Stopwatch()
        ' Declare Save File Dialog Control @Run Time 
        Dim dlgExcelFile As SaveFileDialog = New SaveFileDialog
        ' / Initialize Open File Dialog
        With dlgExcelFile
            .InitialDirectory = MyPath(Application.StartupPath)
            .Title = "Save As Excel File"
            .Filter = "Save Excel (2003)|*.xls|Save Excel (2007+)|*.xlsx"
            .FilterIndex = 2
            .RestoreDirectory = True
        End With
        ' Select OK
        If dlgExcelFile.ShowDialog() = DialogResult.OK Then
            '// เริ่มจับเวลา
            sWatch.Reset()
            sWatch.Start()
            Cursor = Cursors.WaitCursor
            ' / --------------------------------------------------------------------------------
            excelConverter.GroupingGridToExcel(GGC, dlgExcelFile.FileName, ConverterOptions.[Default])
            ' / --------------------------------------------------------------------------------
            Cursor = Cursors.Default
            sWatch.Stop()
            lblTimer.Text = "[Timer: " & sWatch.ElapsedMilliseconds * 0.001 & "]"
            '// Tips for used MessageBoxAdv from Syncfusion.
            MessageBoxAdv.DropShadow = True
            MessageBoxAdv.MessageFont = New System.Drawing.Font("Tahoma", 11, System.Drawing.FontStyle.Regular)
            MessageBoxAdv.CanResize = True
            MessageBoxAdv.Show("Export to Excel Complete.", "MessageBoxAdv Syncfusion.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
