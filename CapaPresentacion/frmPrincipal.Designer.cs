
namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSalirRapido = new System.Windows.Forms.ToolStripButton();
            this.tsCerrarSesionRapido = new System.Windows.Forms.ToolStripButton();
            this.tsVentasRapidas = new System.Windows.Forms.ToolStripButton();
            this.tsIngresosRapidos = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVender = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsArticulos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPresentaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsIngresos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTrabajadores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockDeArtículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.tsSalirRapido,
            this.tsCerrarSesionRapido,
            this.tsVentasRapidas,
            this.tsIngresosRapidos});
            this.toolStrip.Location = new System.Drawing.Point(0, 27);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(812, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSalirRapido
            // 
            this.tsSalirRapido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSalirRapido.Image = global::CapaPresentacion.Properties.Resources.abandonar;
            this.tsSalirRapido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalirRapido.Name = "tsSalirRapido";
            this.tsSalirRapido.Size = new System.Drawing.Size(23, 22);
            this.tsSalirRapido.Text = "TsSalir";
            this.tsSalirRapido.Click += new System.EventHandler(this.tsSalirRapido_Click);
            // 
            // tsCerrarSesionRapido
            // 
            this.tsCerrarSesionRapido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCerrarSesionRapido.Image = global::CapaPresentacion.Properties.Resources.apagar;
            this.tsCerrarSesionRapido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCerrarSesionRapido.Name = "tsCerrarSesionRapido";
            this.tsCerrarSesionRapido.Size = new System.Drawing.Size(23, 22);
            this.tsCerrarSesionRapido.Text = "TsCerrarSesion";
            this.tsCerrarSesionRapido.Click += new System.EventHandler(this.tsCerrarSesionRapido_Click);
            // 
            // tsVentasRapidas
            // 
            this.tsVentasRapidas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVentasRapidas.Image = global::CapaPresentacion.Properties.Resources._038_EDC;
            this.tsVentasRapidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVentasRapidas.Name = "tsVentasRapidas";
            this.tsVentasRapidas.Size = new System.Drawing.Size(23, 22);
            this.tsVentasRapidas.Text = "TsVentas";
            this.tsVentasRapidas.Click += new System.EventHandler(this.tsVentasRapidas_Click);
            // 
            // tsIngresosRapidos
            // 
            this.tsIngresosRapidos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsIngresosRapidos.Image = global::CapaPresentacion.Properties.Resources._016_qr_code;
            this.tsIngresosRapidos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsIngresosRapidos.Name = "tsIngresosRapidos";
            this.tsIngresosRapidos.Size = new System.Drawing.Size(23, 22);
            this.tsIngresosRapidos.Text = "TsCompras";
            this.tsIngresosRapidos.ToolTipText = "TsIngresos";
            this.tsIngresosRapidos.Click += new System.EventHandler(this.tsIngresosRapidos_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(812, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Image = global::CapaPresentacion.Properties.Resources._002_cashbox;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(193, 17);
            this.toolStripStatusLabel.Text = "Sistema de ventas - (Hyperware)";
            // 
            // mnuHerramientas
            // 
            this.mnuHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.mnuHerramientas.Name = "mnuHerramientas";
            this.mnuHerramientas.Size = new System.Drawing.Size(111, 23);
            this.mnuHerramientas.Text = "&Herramientas";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.optionsToolStripMenuItem.Text = "Base de datos";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.backupToolStripMenuItem.Text = "Back-up";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Silver;
            this.menuStrip.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSistema,
            this.mnuVentas,
            this.mnuAlmacen,
            this.mnuMantenimiento,
            this.mnuConsultas,
            this.mnuHerramientas});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(812, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuSistema
            // 
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCerrarSesion,
            this.tsSalir});
            this.mnuSistema.Image = global::CapaPresentacion.Properties.Resources._002_cashbox;
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(88, 23);
            this.mnuSistema.Text = "Sistema";
            // 
            // tsCerrarSesion
            // 
            this.tsCerrarSesion.Image = global::CapaPresentacion.Properties.Resources.apagar;
            this.tsCerrarSesion.Name = "tsCerrarSesion";
            this.tsCerrarSesion.Size = new System.Drawing.Size(180, 24);
            this.tsCerrarSesion.Text = "Cerrar sesión";
            this.tsCerrarSesion.Click += new System.EventHandler(this.tsCerrarSesion_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.Image = global::CapaPresentacion.Properties.Resources.abandonar;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(180, 24);
            this.tsSalir.Text = "Salir";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // mnuVentas
            // 
            this.mnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVender});
            this.mnuVentas.Image = global::CapaPresentacion.Properties.Resources._036_shopping_cart;
            this.mnuVentas.Name = "mnuVentas";
            this.mnuVentas.Size = new System.Drawing.Size(80, 23);
            this.mnuVentas.Text = "Ventas";
            // 
            // tsVender
            // 
            this.tsVender.Image = global::CapaPresentacion.Properties.Resources._038_EDC;
            this.tsVender.Name = "tsVender";
            this.tsVender.Size = new System.Drawing.Size(124, 24);
            this.tsVender.Text = "Vender";
            this.tsVender.Click += new System.EventHandler(this.tsVender_Click);
            // 
            // mnuAlmacen
            // 
            this.mnuAlmacen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsArticulos,
            this.tsCategorias,
            this.tsPresentaciones,
            this.tsIngresos});
            this.mnuAlmacen.Image = global::CapaPresentacion.Properties.Resources._007_packing_list;
            this.mnuAlmacen.Name = "mnuAlmacen";
            this.mnuAlmacen.Size = new System.Drawing.Size(94, 23);
            this.mnuAlmacen.Text = "Almacén";
            // 
            // tsArticulos
            // 
            this.tsArticulos.Image = global::CapaPresentacion.Properties.Resources._050_potato_chips;
            this.tsArticulos.Name = "tsArticulos";
            this.tsArticulos.Size = new System.Drawing.Size(176, 24);
            this.tsArticulos.Text = "Artículos";
            this.tsArticulos.Click += new System.EventHandler(this.tsArticulos_Click);
            // 
            // tsCategorias
            // 
            this.tsCategorias.Image = global::CapaPresentacion.Properties.Resources._040_alcohol;
            this.tsCategorias.Name = "tsCategorias";
            this.tsCategorias.Size = new System.Drawing.Size(176, 24);
            this.tsCategorias.Text = "Categorías";
            this.tsCategorias.Click += new System.EventHandler(this.tsCategorias_Click);
            // 
            // tsPresentaciones
            // 
            this.tsPresentaciones.Image = global::CapaPresentacion.Properties.Resources._031_groceries;
            this.tsPresentaciones.Name = "tsPresentaciones";
            this.tsPresentaciones.Size = new System.Drawing.Size(176, 24);
            this.tsPresentaciones.Text = "Presentaciones";
            this.tsPresentaciones.Click += new System.EventHandler(this.tsPresentaciones_Click);
            // 
            // tsIngresos
            // 
            this.tsIngresos.Image = global::CapaPresentacion.Properties.Resources._016_qr_code;
            this.tsIngresos.Name = "tsIngresos";
            this.tsIngresos.Size = new System.Drawing.Size(176, 24);
            this.tsIngresos.Text = "Ingresos";
            this.tsIngresos.Click += new System.EventHandler(this.tsIngresos_Click);
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsClientes,
            this.tsProveedores,
            this.tsTrabajadores});
            this.mnuMantenimiento.Image = global::CapaPresentacion.Properties.Resources._043_adress_book;
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Size = new System.Drawing.Size(138, 23);
            this.mnuMantenimiento.Text = "Mantenimiento";
            // 
            // tsClientes
            // 
            this.tsClientes.Image = global::CapaPresentacion.Properties.Resources.cliente;
            this.tsClientes.Name = "tsClientes";
            this.tsClientes.Size = new System.Drawing.Size(163, 24);
            this.tsClientes.Text = "Clientes";
            this.tsClientes.Click += new System.EventHandler(this.tsClientes_Click);
            // 
            // tsProveedores
            // 
            this.tsProveedores.Image = global::CapaPresentacion.Properties.Resources._015_mover_truck;
            this.tsProveedores.Name = "tsProveedores";
            this.tsProveedores.Size = new System.Drawing.Size(163, 24);
            this.tsProveedores.Text = "Proveedores";
            this.tsProveedores.Click += new System.EventHandler(this.tsProveedores_Click);
            // 
            // tsTrabajadores
            // 
            this.tsTrabajadores.Image = global::CapaPresentacion.Properties.Resources.obrero;
            this.tsTrabajadores.Name = "tsTrabajadores";
            this.tsTrabajadores.Size = new System.Drawing.Size(163, 24);
            this.tsTrabajadores.Text = "Trabajadores";
            this.tsTrabajadores.Click += new System.EventHandler(this.tsTrabajadores_Click);
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasPorFechasToolStripMenuItem,
            this.comprasPorFechasToolStripMenuItem,
            this.stockDeArtículosToolStripMenuItem});
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Size = new System.Drawing.Size(83, 23);
            this.mnuConsultas.Text = "Consultas";
            // 
            // ventasPorFechasToolStripMenuItem
            // 
            this.ventasPorFechasToolStripMenuItem.Name = "ventasPorFechasToolStripMenuItem";
            this.ventasPorFechasToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.ventasPorFechasToolStripMenuItem.Text = "Ventas por fechas";
            // 
            // comprasPorFechasToolStripMenuItem
            // 
            this.comprasPorFechasToolStripMenuItem.Name = "comprasPorFechasToolStripMenuItem";
            this.comprasPorFechasToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.comprasPorFechasToolStripMenuItem.Text = "Compras por fechas";
            // 
            // stockDeArtículosToolStripMenuItem
            // 
            this.stockDeArtículosToolStripMenuItem.Name = "stockDeArtículosToolStripMenuItem";
            this.stockDeArtículosToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.stockDeArtículosToolStripMenuItem.Text = "Stock de artículos";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 23);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de ventas - (Hyperware)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuHerramientas;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuAlmacen;
        private System.Windows.Forms.ToolStripMenuItem tsArticulos;
        private System.Windows.Forms.ToolStripMenuItem tsCategorias;
        private System.Windows.Forms.ToolStripMenuItem tsPresentaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem tsTrabajadores;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem ventasPorFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasPorFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockDeArtículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsIngresosRapidos;
        private System.Windows.Forms.ToolStripButton tsVentasRapidas;
        private System.Windows.Forms.ToolStripButton tsSalirRapido;
        private System.Windows.Forms.ToolStripMenuItem tsProveedores;
        private System.Windows.Forms.ToolStripMenuItem tsClientes;
        private System.Windows.Forms.ToolStripMenuItem tsIngresos;
        private System.Windows.Forms.ToolStripMenuItem tsVender;
        private System.Windows.Forms.ToolStripButton tsCerrarSesionRapido;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem tsSalir;
        private System.Windows.Forms.ToolStripMenuItem tsCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}



