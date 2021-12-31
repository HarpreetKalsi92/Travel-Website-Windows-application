namespace TravelExperts_Winforms
{
    partial class EditPackage
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
            this.dtpPkgStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPkgEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtPkgAgencyCommission = new System.Windows.Forms.TextBox();
            this.lblPkgAgencyCommission = new System.Windows.Forms.Label();
            this.txtPkgBasePrice = new System.Windows.Forms.TextBox();
            this.lblPkgBasePrice = new System.Windows.Forms.Label();
            this.txtPkgDesc = new System.Windows.Forms.TextBox();
            this.lblPackageDesc = new System.Windows.Forms.Label();
            this.lblPkgEndDate = new System.Windows.Forms.Label();
            this.lblPkgStartDate = new System.Windows.Forms.Label();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.txtPackageId = new System.Windows.Forms.TextBox();
            this.lblPackageId = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.dgvPackages = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearDates = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpPkgStartDate
            // 
            this.dtpPkgStartDate.Location = new System.Drawing.Point(546, 171);
            this.dtpPkgStartDate.Name = "dtpPkgStartDate";
            this.dtpPkgStartDate.Size = new System.Drawing.Size(201, 20);
            this.dtpPkgStartDate.TabIndex = 28;
            // 
            // dtpPkgEndDate
            // 
            this.dtpPkgEndDate.Location = new System.Drawing.Point(546, 201);
            this.dtpPkgEndDate.Name = "dtpPkgEndDate";
            this.dtpPkgEndDate.Size = new System.Drawing.Size(201, 20);
            this.dtpPkgEndDate.TabIndex = 27;
            // 
            // txtPkgAgencyCommission
            // 
            this.txtPkgAgencyCommission.Location = new System.Drawing.Point(546, 312);
            this.txtPkgAgencyCommission.Name = "txtPkgAgencyCommission";
            this.txtPkgAgencyCommission.Size = new System.Drawing.Size(242, 20);
            this.txtPkgAgencyCommission.TabIndex = 26;
            // 
            // lblPkgAgencyCommission
            // 
            this.lblPkgAgencyCommission.AutoSize = true;
            this.lblPkgAgencyCommission.Location = new System.Drawing.Point(393, 315);
            this.lblPkgAgencyCommission.Name = "lblPkgAgencyCommission";
            this.lblPkgAgencyCommission.Size = new System.Drawing.Size(153, 13);
            this.lblPkgAgencyCommission.TabIndex = 25;
            this.lblPkgAgencyCommission.Text = "Package Agency Commission: ";
            // 
            // txtPkgBasePrice
            // 
            this.txtPkgBasePrice.Location = new System.Drawing.Point(546, 276);
            this.txtPkgBasePrice.Name = "txtPkgBasePrice";
            this.txtPkgBasePrice.Size = new System.Drawing.Size(242, 20);
            this.txtPkgBasePrice.TabIndex = 24;
            // 
            // lblPkgBasePrice
            // 
            this.lblPkgBasePrice.AutoSize = true;
            this.lblPkgBasePrice.Location = new System.Drawing.Point(393, 279);
            this.lblPkgBasePrice.Name = "lblPkgBasePrice";
            this.lblPkgBasePrice.Size = new System.Drawing.Size(110, 13);
            this.lblPkgBasePrice.TabIndex = 23;
            this.lblPkgBasePrice.Text = "Package Base Price: ";
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.Location = new System.Drawing.Point(546, 241);
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(242, 20);
            this.txtPkgDesc.TabIndex = 22;
            // 
            // lblPackageDesc
            // 
            this.lblPackageDesc.AutoSize = true;
            this.lblPackageDesc.Location = new System.Drawing.Point(396, 244);
            this.lblPackageDesc.Name = "lblPackageDesc";
            this.lblPackageDesc.Size = new System.Drawing.Size(112, 13);
            this.lblPackageDesc.TabIndex = 21;
            this.lblPackageDesc.Text = "Package Description: ";
            // 
            // lblPkgEndDate
            // 
            this.lblPkgEndDate.AutoSize = true;
            this.lblPkgEndDate.Location = new System.Drawing.Point(396, 201);
            this.lblPkgEndDate.Name = "lblPkgEndDate";
            this.lblPkgEndDate.Size = new System.Drawing.Size(104, 13);
            this.lblPkgEndDate.TabIndex = 20;
            this.lblPkgEndDate.Text = "Package End Date: ";
            // 
            // lblPkgStartDate
            // 
            this.lblPkgStartDate.AutoSize = true;
            this.lblPkgStartDate.Location = new System.Drawing.Point(396, 171);
            this.lblPkgStartDate.Name = "lblPkgStartDate";
            this.lblPkgStartDate.Size = new System.Drawing.Size(107, 13);
            this.lblPkgStartDate.TabIndex = 19;
            this.lblPkgStartDate.Text = "Package Start Date: ";
            // 
            // txtPkgName
            // 
            this.txtPkgName.Location = new System.Drawing.Point(546, 144);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(242, 20);
            this.txtPkgName.TabIndex = 18;
            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Location = new System.Drawing.Point(396, 147);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(87, 13);
            this.lblPackageName.TabIndex = 17;
            this.lblPackageName.Text = "Package Name: ";
            // 
            // txtPackageId
            // 
            this.txtPackageId.Location = new System.Drawing.Point(592, 106);
            this.txtPackageId.Name = "txtPackageId";
            this.txtPackageId.ReadOnly = true;
            this.txtPackageId.Size = new System.Drawing.Size(155, 20);
            this.txtPackageId.TabIndex = 16;
            // 
            // lblPackageId
            // 
            this.lblPackageId.AutoSize = true;
            this.lblPackageId.Location = new System.Drawing.Point(396, 108);
            this.lblPackageId.Name = "lblPackageId";
            this.lblPackageId.Size = new System.Drawing.Size(67, 13);
            this.lblPackageId.TabIndex = 15;
            this.lblPackageId.Text = "Package ID:";
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(546, 106);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 23);
            this.btnLeft.TabIndex = 29;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(753, 104);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(41, 23);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // dgvPackages
            // 
            this.dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackages.Location = new System.Drawing.Point(12, 106);
            this.dgvPackages.Name = "dgvPackages";
            this.dgvPackages.Size = new System.Drawing.Size(358, 150);
            this.dgvPackages.TabIndex = 30;
            this.dgvPackages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackages_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(628, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearDates
            // 
            this.btnClearDates.Location = new System.Drawing.Point(753, 172);
            this.btnClearDates.Name = "btnClearDates";
            this.btnClearDates.Size = new System.Drawing.Size(41, 23);
            this.btnClearDates.TabIndex = 32;
            this.btnClearDates.Text = "Clear";
            this.btnClearDates.Click += new System.EventHandler(this.btnClearDates_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(753, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Enter";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClearDates);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPackages);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.dtpPkgStartDate);
            this.Controls.Add(this.dtpPkgEndDate);
            this.Controls.Add(this.txtPkgAgencyCommission);
            this.Controls.Add(this.lblPkgAgencyCommission);
            this.Controls.Add(this.txtPkgBasePrice);
            this.Controls.Add(this.lblPkgBasePrice);
            this.Controls.Add(this.txtPkgDesc);
            this.Controls.Add(this.lblPackageDesc);
            this.Controls.Add(this.lblPkgEndDate);
            this.Controls.Add(this.lblPkgStartDate);
            this.Controls.Add(this.txtPkgName);
            this.Controls.Add(this.lblPackageName);
            this.Controls.Add(this.txtPackageId);
            this.Controls.Add(this.lblPackageId);
            this.Name = "EditPackage";
            this.Text = "EditPackage";
            this.Load += new System.EventHandler(this.EditPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpPkgStartDate;
        private System.Windows.Forms.DateTimePicker dtpPkgEndDate;
        private System.Windows.Forms.TextBox txtPkgAgencyCommission;
        private System.Windows.Forms.Label lblPkgAgencyCommission;
        private System.Windows.Forms.TextBox txtPkgBasePrice;
        private System.Windows.Forms.Label lblPkgBasePrice;
        private System.Windows.Forms.TextBox txtPkgDesc;
        private System.Windows.Forms.Label lblPackageDesc;
        private System.Windows.Forms.Label lblPkgEndDate;
        private System.Windows.Forms.Label lblPkgStartDate;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.Label lblPackageName;
        private System.Windows.Forms.TextBox txtPackageId;
        private System.Windows.Forms.Label lblPackageId;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.DataGridView dgvPackages;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearDates;
        private System.Windows.Forms.Button button1;
    }
}