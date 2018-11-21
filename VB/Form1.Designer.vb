Imports Microsoft.VisualBasic
Imports System
Namespace Q205054
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.pivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
			Me.productReportsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.nwindDataSet = New nwindDataSet()
			Me.fieldCategoryName = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldProductName = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldProductSales = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldShippedDate = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.productReportsTableAdapter = New nwindDataSetTableAdapters.ProductReportsTableAdapter()
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.productReportsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pivotGridControl1
			' 
			Me.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default
			Me.pivotGridControl1.DataSource = Me.productReportsBindingSource
			Me.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { Me.fieldCategoryName, Me.fieldProductName, Me.fieldProductSales, Me.fieldShippedDate})
			Me.pivotGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.pivotGridControl1.Name = "pivotGridControl1"
			Me.pivotGridControl1.OptionsView.ShowColumnTotals = False
			Me.pivotGridControl1.OptionsView.ShowRowTotals = False
			Me.pivotGridControl1.OptionsView.ShowTotalsForSingleValues = True
			Me.pivotGridControl1.Size = New System.Drawing.Size(727, 453)
			Me.pivotGridControl1.TabIndex = 0
'			Me.pivotGridControl1.MouseClick += New System.Windows.Forms.MouseEventHandler(Me.pivotGridControl1_MouseClick);
'			Me.pivotGridControl1.CustomDrawFieldValue += New DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventHandler(Me.pivotGridControl1_CustomDrawFieldValue);
			' 
			' productReportsBindingSource
			' 
			Me.productReportsBindingSource.DataMember = "ProductReports"
			Me.productReportsBindingSource.DataSource = Me.nwindDataSet
			' 
			' nwindDataSet
			' 
			Me.nwindDataSet.DataSetName = "nwindDataSet"
			Me.nwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' fieldCategoryName
			' 
			Me.fieldCategoryName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldCategoryName.AreaIndex = 0
			Me.fieldCategoryName.Caption = "Category Name"
			Me.fieldCategoryName.FieldName = "CategoryName"
			Me.fieldCategoryName.Name = "fieldCategoryName"
			' 
			' fieldProductName
			' 
			Me.fieldProductName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldProductName.AreaIndex = 1
			Me.fieldProductName.Caption = "Product Name"
			Me.fieldProductName.FieldName = "ProductName"
			Me.fieldProductName.Name = "fieldProductName"
			' 
			' fieldProductSales
			' 
			Me.fieldProductSales.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			Me.fieldProductSales.AreaIndex = 0
			Me.fieldProductSales.Caption = "Product Sales"
			Me.fieldProductSales.FieldName = "ProductSales"
			Me.fieldProductSales.Name = "fieldProductSales"
			' 
			' fieldShippedDate
			' 
			Me.fieldShippedDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldShippedDate.AreaIndex = 0
			Me.fieldShippedDate.Caption = "Shipped Date"
			Me.fieldShippedDate.FieldName = "ShippedDate"
			Me.fieldShippedDate.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear
			Me.fieldShippedDate.Name = "fieldShippedDate"
			Me.fieldShippedDate.UnboundFieldName = "fieldShippedDate"
			' 
			' productReportsTableAdapter
			' 
			Me.productReportsTableAdapter.ClearBeforeFill = True
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(727, 453)
			Me.Controls.Add(Me.pivotGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.productReportsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents pivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
		Private nwindDataSet As nwindDataSet
		Private productReportsBindingSource As System.Windows.Forms.BindingSource
		Private productReportsTableAdapter As nwindDataSetTableAdapters.ProductReportsTableAdapter
		Private fieldCategoryName As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldProductName As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldProductSales As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldShippedDate As DevExpress.XtraPivotGrid.PivotGridField
	End Class
End Namespace

