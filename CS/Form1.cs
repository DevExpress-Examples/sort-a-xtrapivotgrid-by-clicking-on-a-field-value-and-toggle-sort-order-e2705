using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using System.Reflection;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.Utils.Drawing;

namespace Q205054 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.ProductReports' table. You can move, or remove it, as needed.
            this.productReportsTableAdapter.Fill(this.nwindDataSet.ProductReports);

        }

        private void pivotGridControl1_MouseClick(object sender, MouseEventArgs e) {
            PivotGridHitInfo hInfo = pivotGridControl1.CalcHitInfo(e.Location);
            if(hInfo.HitTest == PivotGridHitTest.Value)
                HandleValueMouseClick(hInfo.ValueInfo);
        }

        private void HandleValueMouseClick(PivotFieldValueEventArgs e) {
            PivotGridField[] higherFields = e.GetHigherLevelFields();
            object[] higherValues = new object[higherFields.Length];
            for(int i = 0; i < higherFields.Length; i++)
                higherValues[i] = e.GetHigherLevelFieldValue(higherFields[i]);

            pivotGridControl1.BeginUpdate();
            PivotArea otherArea = GetOtherArea(e.IsColumn);
            List<PivotGridField> otherFields = pivotGridControl1.GetFieldsByArea(otherArea);
            PivotSortOrder? sortOrder = GetSummarySortOrder(e.Item);
            for(int i = 0; i < otherFields.Count; i++) {
                if(!sortOrder.HasValue || sortOrder.Value == PivotSortOrder.Descending)
                    otherFields[i].SortOrder = PivotSortOrder.Ascending;
                else
                    otherFields[i].SortOrder = PivotSortOrder.Descending;
                otherFields[i].SortBySummaryInfo.Field = e.DataField;
                otherFields[i].SortBySummaryInfo.Conditions.Clear();
                for(int j = 0; j < higherFields.Length; j++) {
                    otherFields[i].SortBySummaryInfo.Conditions.Add(new PivotGridFieldSortCondition(higherFields[j], higherValues[j]));
                }
                if(e.Field != null && e.Field.Area != PivotArea.DataArea)
                    otherFields[i].SortBySummaryInfo.Conditions.Add(new PivotGridFieldSortCondition(e.Field, e.Value));                
            }
            pivotGridControl1.EndUpdate();
        }

        private PivotArea GetOtherArea(bool isColumn) {
            return isColumn ? PivotArea.RowArea : PivotArea.ColumnArea;
        }

        PropertyInfo viewInfoPI = null;
        PivotFieldValueItem GetItem(PivotCustomDrawFieldValueEventArgs e) {
            if(viewInfoPI == null)
                viewInfoPI = e.GetType().GetProperty("FieldCellViewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            PivotFieldsAreaCellViewInfo viewInfo = (PivotFieldsAreaCellViewInfo)viewInfoPI.GetValue(e, null);
            return viewInfo.Item;
        }

        private PivotSortOrder? GetSummarySortOrder(PivotFieldValueItem valueItem) {
            if(!valueItem.IsLastFieldLevel)
                return null;
            List<PivotGridFieldPair> pairs = valueItem.Data.VisualItems.GetSortedBySummaryFields(valueItem.IsColumn, valueItem.Index);
            if(pairs == null)
                return null;
            PivotSortOrder? sortOrder = null;
            foreach(PivotGridFieldPair pair in pairs) {
                if(pair.DataFieldItem != valueItem.DataField) continue;
                if(sortOrder != null) {
                    if(sortOrder.Value != pair.Field.SortOrder) {
                        sortOrder = null;
                        break;
                    }
                }
                sortOrder = pair.Field.SortOrder;
            }
            return sortOrder;
        }

        private void pivotGridControl1_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e) {
            PivotFieldValueItem valueItem = GetItem(e);            
            PivotSortOrder? sortOrder = GetSummarySortOrder(valueItem);           
            if(sortOrder == null) 
                return; // proceed to standard drawing
            PivotGridViewInfoData data = (PivotGridViewInfoData)valueItem.Data;
            data.ActiveLookAndFeel.Painter.Header.DrawObject(e.Info);


            SortedShapeObjectInfoArgs sortInfo = new SortedShapeObjectInfoArgs();
            sortInfo.Ascending = sortOrder == PivotSortOrder.Ascending;
            sortInfo.Graphics = e.Graphics;
            Rectangle sortBounds = data.ActiveLookAndFeel.Painter.SortedShape.CalcObjectMinBounds(sortInfo);
            sortBounds.X = e.Info.CaptionRect.Right + 2;
            sortBounds.Y = e.Info.CaptionRect.Y + (int)Math.Round((double)(e.Info.CaptionRect.Height - sortBounds.Height) / 2);
            sortInfo.Bounds = sortBounds;
            data.ActiveLookAndFeel.Painter.SortedShape.DrawObject(sortInfo);
            e.Handled = true;
        }
    }
}