namespace Stok_Programı
{
    partial class uretimcikis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uretimcikis));
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.Parameter Tarih;
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Kodlar = new DevExpress.XtraReports.Parameters.Parameter();
            Tarih = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "StokTakip_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "UrunID";
            table1.Name = "UretimCikis";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "FirmaAdi";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "UrunKodu";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "CikisTarihi";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "UrunAdet";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Name = "UretimCikis";
            selectQuery1.Tables.Add(table1);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.Expanded = false;
            this.Detail.HeightF = 30.20833F;
            this.Detail.Name = "Detail";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.GroupHeader1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 33.33333F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            this.GroupHeader1.StylePriority.UseBackColor = false;
            this.GroupHeader1.StylePriority.UseFont = false;
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(650F, 25F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBorders = false;
            this.xrTableRow1.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell1.Text = "Ürün Kodu";
            this.xrTableCell1.Weight = 0.4D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell2.Text = "Firma Adı";
            this.xrTableCell2.Weight = 0.4D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Ürün Adet";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell3.Weight = 0.4D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell4.Text = "Çıkış Tarihi";
            this.xrTableCell4.Weight = 0.4D;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(650F, 25F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8});
            this.xrTableRow2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.Weight = 11.5D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UrunKodu]")});
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 0.4D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FirmaAdi]")});
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.Weight = 0.4D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UrunAdet]")});
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell7.Weight = 0.4D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CikisTarihi]")});
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.Weight = 0.4D;
            // 
            // Kodlar
            // 
            this.Kodlar.Description = "Kod:";
            dynamicListLookUpSettings1.DataMember = "UretimCikis";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "UrunKodu";
            dynamicListLookUpSettings1.SortMember = null;
            dynamicListLookUpSettings1.ValueMember = "UrunKodu";
            this.Kodlar.LookUpSettings = dynamicListLookUpSettings1;
            this.Kodlar.Name = "Kodlar";
            this.Kodlar.ValueInfo = "0";
            // 
            // Tarih
            // 
            Tarih.Description = "Tarih:";
            Tarih.Name = "Tarih";
            Tarih.Type = typeof(System.DateTime);
            // 
            // uretimcikis
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "UretimCikis";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "StartsWith([UrunKodu], ?Kodlar) And StartsWith([CikisTarihi], ?Tarih)";
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Kodlar,
            Tarih});
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.Parameters.Parameter Kodlar;

    }
}
