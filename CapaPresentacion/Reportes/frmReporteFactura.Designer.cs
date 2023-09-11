
namespace CapaPresentacion
{
    partial class frmReporteFactura
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spreporte_fechaTableAdapter1 = new CapaPresentacion.dsPrincipalTableAdapters.spreporte_fechaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.spreporte_fechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spreporte_fechaTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spreporte_fechaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporte_fechaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spreporte_fechaTableAdapter1
            // 
            this.spreporte_fechaTableAdapter1.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spreporte_fechaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptComprobanteFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spreporte_fechaBindingSource
            // 
            this.spreporte_fechaBindingSource.DataMember = "spreporte_fecha";
            this.spreporte_fechaBindingSource.DataSource = this.dsPrincipal;
            // 
            // spreporte_fechaTableAdapter
            // 
            this.spreporte_fechaTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteFactura";
            this.Text = "frmReporteFactura";
            this.Load += new System.EventHandler(this.frmReporteFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporte_fechaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dsPrincipalTableAdapters.spreporte_fechaTableAdapter spreporte_fechaTableAdapter1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spreporte_fechaBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.spreporte_fechaTableAdapter spreporte_fechaTableAdapter;
    }
}