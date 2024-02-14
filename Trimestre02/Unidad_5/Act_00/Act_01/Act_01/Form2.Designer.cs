namespace Act_01
{
    partial class Form2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.agenciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tuViajeFindeCursoDataSet = new Act_01.TuViajeFindeCursoDataSet();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.destinosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agenciasTableAdapter = new Act_01.TuViajeFindeCursoDataSetTableAdapters.agenciasTableAdapter();
            this.clientesTableAdapter = new Act_01.TuViajeFindeCursoDataSetTableAdapters.clientesTableAdapter();
            this.destinosTableAdapter = new Act_01.TuViajeFindeCursoDataSetTableAdapters.destinosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.agenciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuViajeFindeCursoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ViajesAgencias";
            reportDataSource1.Value = this.agenciasBindingSource;
            reportDataSource2.Name = "ViajesClientes";
            reportDataSource2.Value = this.clientesBindingSource;
            reportDataSource3.Name = "ViajesDestinos";
            reportDataSource3.Value = this.destinosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Act_01.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // agenciasBindingSource
            // 
            this.agenciasBindingSource.DataMember = "agencias";
            this.agenciasBindingSource.DataSource = this.tuViajeFindeCursoDataSet;
            // 
            // tuViajeFindeCursoDataSet
            // 
            this.tuViajeFindeCursoDataSet.DataSetName = "TuViajeFindeCursoDataSet";
            this.tuViajeFindeCursoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "clientes";
            this.clientesBindingSource.DataSource = this.tuViajeFindeCursoDataSet;
            // 
            // destinosBindingSource
            // 
            this.destinosBindingSource.DataMember = "destinos";
            this.destinosBindingSource.DataSource = this.tuViajeFindeCursoDataSet;
            // 
            // agenciasTableAdapter
            // 
            this.agenciasTableAdapter.ClearBeforeFill = true;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // destinosTableAdapter
            // 
            this.destinosTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.agenciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuViajeFindeCursoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TuViajeFindeCursoDataSet tuViajeFindeCursoDataSet;
        private System.Windows.Forms.BindingSource agenciasBindingSource;
        private TuViajeFindeCursoDataSetTableAdapters.agenciasTableAdapter agenciasTableAdapter;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private TuViajeFindeCursoDataSetTableAdapters.clientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.BindingSource destinosBindingSource;
        private TuViajeFindeCursoDataSetTableAdapters.destinosTableAdapter destinosTableAdapter;
    }
}