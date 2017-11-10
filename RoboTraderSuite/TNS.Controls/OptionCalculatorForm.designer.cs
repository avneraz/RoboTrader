namespace TNS.Controls
{
    partial class OptionCalculatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionCalculatorForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSigma = new System.Windows.Forms.TextBox();
            this.txtExpireDays = new System.Windows.Forms.TextBox();
            this.txtStockPrice = new System.Windows.Forms.TextBox();
            this.txtStrikePrice = new System.Windows.Forms.TextBox();
            this.txtRiskFreeInterestRate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPutRow = new System.Windows.Forms.Label();
            this.lblPutOmega = new System.Windows.Forms.Label();
            this.lblCallRow = new System.Windows.Forms.Label();
            this.lblCallOmega = new System.Windows.Forms.Label();
            this.lblPutTheta = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCallTheta = new System.Windows.Forms.Label();
            this.lblPutVega = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCallVega = new System.Windows.Forms.Label();
            this.lblPutGama = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCallGama = new System.Windows.Forms.Label();
            this.lblPutDelta = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCallDelta = new System.Windows.Forms.Label();
            this.lblPutB_SValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCallB_SValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculateIV = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpOptionType = new DevExpress.XtraEditors.RadioGroup();
            this.txtIterationCounter = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBNSBisections = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOptionPrice = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOptionType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSigma);
            this.groupBox1.Controls.Add(this.txtExpireDays);
            this.groupBox1.Controls.Add(this.txtStockPrice);
            this.groupBox1.Controls.Add(this.txtStrikePrice);
            this.groupBox1.Controls.Add(this.txtRiskFreeInterestRate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option Base Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Interest Rate (%):";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(14, 235);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "IV (%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Expire Days:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Underlined LastPrice:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Strike:";
            // 
            // txtSigma
            // 
            this.txtSigma.Location = new System.Drawing.Point(99, 151);
            this.txtSigma.Name = "txtSigma";
            this.txtSigma.Size = new System.Drawing.Size(69, 20);
            this.txtSigma.TabIndex = 3;
            this.txtSigma.Text = "Enter...";
            // 
            // txtExpireDays
            // 
            this.txtExpireDays.Location = new System.Drawing.Point(99, 116);
            this.txtExpireDays.Name = "txtExpireDays";
            this.txtExpireDays.Size = new System.Drawing.Size(69, 20);
            this.txtExpireDays.TabIndex = 2;
            this.txtExpireDays.Text = "Enter...";
            // 
            // txtStockPrice
            // 
            this.txtStockPrice.Location = new System.Drawing.Point(99, 46);
            this.txtStockPrice.Name = "txtStockPrice";
            this.txtStockPrice.Size = new System.Drawing.Size(69, 20);
            this.txtStockPrice.TabIndex = 0;
            this.txtStockPrice.Text = "130";
            // 
            // txtStrikePrice
            // 
            this.txtStrikePrice.Location = new System.Drawing.Point(99, 81);
            this.txtStrikePrice.Name = "txtStrikePrice";
            this.txtStrikePrice.Size = new System.Drawing.Size(69, 20);
            this.txtStrikePrice.TabIndex = 1;
            this.txtStrikePrice.Text = "130";
            // 
            // txtRiskFreeInterestRate
            // 
            this.txtRiskFreeInterestRate.Location = new System.Drawing.Point(99, 186);
            this.txtRiskFreeInterestRate.Name = "txtRiskFreeInterestRate";
            this.txtRiskFreeInterestRate.Size = new System.Drawing.Size(69, 20);
            this.txtRiskFreeInterestRate.TabIndex = 4;
            this.txtRiskFreeInterestRate.Text = "0.001";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblPutRow);
            this.groupBox2.Controls.Add(this.lblPutOmega);
            this.groupBox2.Controls.Add(this.lblCallRow);
            this.groupBox2.Controls.Add(this.lblCallOmega);
            this.groupBox2.Controls.Add(this.lblPutTheta);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblCallTheta);
            this.groupBox2.Controls.Add(this.lblPutVega);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblCallVega);
            this.groupBox2.Controls.Add(this.lblPutGama);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblCallGama);
            this.groupBox2.Controls.Add(this.lblPutDelta);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblCallDelta);
            this.groupBox2.Controls.Add(this.lblPutB_SValue);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblCallB_SValue);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(251, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculate Values";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(170, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 180);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(91, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 2);
            this.panel1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(200, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Put";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(109, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Call";
            // 
            // lblPutRow
            // 
            this.lblPutRow.AutoSize = true;
            this.lblPutRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutRow.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutRow.Location = new System.Drawing.Point(192, 192);
            this.lblPutRow.Name = "lblPutRow";
            this.lblPutRow.Size = new System.Drawing.Size(14, 13);
            this.lblPutRow.TabIndex = 9;
            this.lblPutRow.Text = "0";
            // 
            // lblPutOmega
            // 
            this.lblPutOmega.AutoSize = true;
            this.lblPutOmega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutOmega.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutOmega.Location = new System.Drawing.Point(192, 168);
            this.lblPutOmega.Name = "lblPutOmega";
            this.lblPutOmega.Size = new System.Drawing.Size(14, 13);
            this.lblPutOmega.TabIndex = 9;
            this.lblPutOmega.Text = "0";
            // 
            // lblCallRow
            // 
            this.lblCallRow.AutoSize = true;
            this.lblCallRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallRow.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallRow.Location = new System.Drawing.Point(106, 192);
            this.lblCallRow.Name = "lblCallRow";
            this.lblCallRow.Size = new System.Drawing.Size(14, 13);
            this.lblCallRow.TabIndex = 9;
            this.lblCallRow.Text = "0";
            // 
            // lblCallOmega
            // 
            this.lblCallOmega.AutoSize = true;
            this.lblCallOmega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallOmega.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallOmega.Location = new System.Drawing.Point(106, 168);
            this.lblCallOmega.Name = "lblCallOmega";
            this.lblCallOmega.Size = new System.Drawing.Size(14, 13);
            this.lblCallOmega.TabIndex = 9;
            this.lblCallOmega.Text = "0";
            // 
            // lblPutTheta
            // 
            this.lblPutTheta.AutoSize = true;
            this.lblPutTheta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutTheta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutTheta.Location = new System.Drawing.Point(192, 144);
            this.lblPutTheta.Name = "lblPutTheta";
            this.lblPutTheta.Size = new System.Drawing.Size(14, 13);
            this.lblPutTheta.TabIndex = 9;
            this.lblPutTheta.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Row:";
            // 
            // lblCallTheta
            // 
            this.lblCallTheta.AutoSize = true;
            this.lblCallTheta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallTheta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallTheta.Location = new System.Drawing.Point(106, 144);
            this.lblCallTheta.Name = "lblCallTheta";
            this.lblCallTheta.Size = new System.Drawing.Size(14, 13);
            this.lblCallTheta.TabIndex = 9;
            this.lblCallTheta.Text = "0";
            // 
            // lblPutVega
            // 
            this.lblPutVega.AutoSize = true;
            this.lblPutVega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutVega.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutVega.Location = new System.Drawing.Point(192, 120);
            this.lblPutVega.Name = "lblPutVega";
            this.lblPutVega.Size = new System.Drawing.Size(14, 13);
            this.lblPutVega.TabIndex = 9;
            this.lblPutVega.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Omega:";
            // 
            // lblCallVega
            // 
            this.lblCallVega.AutoSize = true;
            this.lblCallVega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallVega.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallVega.Location = new System.Drawing.Point(106, 120);
            this.lblCallVega.Name = "lblCallVega";
            this.lblCallVega.Size = new System.Drawing.Size(14, 13);
            this.lblCallVega.TabIndex = 9;
            this.lblCallVega.Text = "0";
            // 
            // lblPutGama
            // 
            this.lblPutGama.AutoSize = true;
            this.lblPutGama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutGama.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutGama.Location = new System.Drawing.Point(192, 96);
            this.lblPutGama.Name = "lblPutGama";
            this.lblPutGama.Size = new System.Drawing.Size(14, 13);
            this.lblPutGama.TabIndex = 9;
            this.lblPutGama.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Theta:";
            // 
            // lblCallGama
            // 
            this.lblCallGama.AutoSize = true;
            this.lblCallGama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallGama.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallGama.Location = new System.Drawing.Point(106, 96);
            this.lblCallGama.Name = "lblCallGama";
            this.lblCallGama.Size = new System.Drawing.Size(14, 13);
            this.lblCallGama.TabIndex = 9;
            this.lblCallGama.Text = "0";
            // 
            // lblPutDelta
            // 
            this.lblPutDelta.AutoSize = true;
            this.lblPutDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutDelta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutDelta.Location = new System.Drawing.Point(192, 72);
            this.lblPutDelta.Name = "lblPutDelta";
            this.lblPutDelta.Size = new System.Drawing.Size(14, 13);
            this.lblPutDelta.TabIndex = 9;
            this.lblPutDelta.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Vega:";
            // 
            // lblCallDelta
            // 
            this.lblCallDelta.AutoSize = true;
            this.lblCallDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallDelta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallDelta.Location = new System.Drawing.Point(106, 72);
            this.lblCallDelta.Name = "lblCallDelta";
            this.lblCallDelta.Size = new System.Drawing.Size(14, 13);
            this.lblCallDelta.TabIndex = 9;
            this.lblCallDelta.Text = "0";
            // 
            // lblPutB_SValue
            // 
            this.lblPutB_SValue.AutoSize = true;
            this.lblPutB_SValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPutB_SValue.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPutB_SValue.Location = new System.Drawing.Point(192, 48);
            this.lblPutB_SValue.Name = "lblPutB_SValue";
            this.lblPutB_SValue.Size = new System.Drawing.Size(14, 13);
            this.lblPutB_SValue.TabIndex = 9;
            this.lblPutB_SValue.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Gama:";
            // 
            // lblCallB_SValue
            // 
            this.lblCallB_SValue.AutoSize = true;
            this.lblCallB_SValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCallB_SValue.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCallB_SValue.Location = new System.Drawing.Point(106, 48);
            this.lblCallB_SValue.Name = "lblCallB_SValue";
            this.lblCallB_SValue.Size = new System.Drawing.Size(14, 13);
            this.lblCallB_SValue.TabIndex = 9;
            this.lblCallB_SValue.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "DeltaTotal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "B&S Value:";
            // 
            // btnCalculateIV
            // 
            this.btnCalculateIV.Location = new System.Drawing.Point(12, 81);
            this.btnCalculateIV.Name = "btnCalculateIV";
            this.btnCalculateIV.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateIV.TabIndex = 2;
            this.btnCalculateIV.Text = "Calculate IV";
            this.btnCalculateIV.UseVisualStyleBackColor = true;
            this.btnCalculateIV.Click += new System.EventHandler(this.btnCalculateIV_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grpOptionType);
            this.groupBox3.Controls.Add(this.btnCalculateIV);
            this.groupBox3.Controls.Add(this.txtIterationCounter);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtBNSBisections);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtOptionPrice);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(538, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 273);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calculate IV";
            // 
            // grpOptionType
            // 
            this.grpOptionType.EditValue = 0;
            this.grpOptionType.Location = new System.Drawing.Point(12, 115);
            this.grpOptionType.Name = "grpOptionType";
            this.grpOptionType.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpOptionType.Properties.Appearance.Options.UseBackColor = true;
            this.grpOptionType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpOptionType.Properties.Columns = 2;
            this.grpOptionType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Call"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Put")});
            this.grpOptionType.Size = new System.Drawing.Size(144, 41);
            this.grpOptionType.TabIndex = 11;
            this.grpOptionType.EditValueChanged += new System.EventHandler(this.grpOptionType_EditValueChanged);
            // 
            // txtIterationCounter
            // 
            this.txtIterationCounter.Location = new System.Drawing.Point(103, 165);
            this.txtIterationCounter.Name = "txtIterationCounter";
            this.txtIterationCounter.Size = new System.Drawing.Size(53, 20);
            this.txtIterationCounter.TabIndex = 1;
            this.txtIterationCounter.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 168);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Iteration Counter:";
            // 
            // txtBNSBisections
            // 
            this.txtBNSBisections.Location = new System.Drawing.Point(98, 203);
            this.txtBNSBisections.Name = "txtBNSBisections";
            this.txtBNSBisections.Size = new System.Drawing.Size(58, 20);
            this.txtBNSBisections.TabIndex = 1;
            this.txtBNSBisections.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 206);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "BNS Bisections:";
            // 
            // txtOptionPrice
            // 
            this.txtOptionPrice.Location = new System.Drawing.Point(98, 48);
            this.txtOptionPrice.Name = "txtOptionPrice";
            this.txtOptionPrice.Size = new System.Drawing.Size(58, 20);
            this.txtOptionPrice.TabIndex = 1;
            this.txtOptionPrice.Text = "4.56";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Option LastPrice:";
            // 
            // OptionCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 304);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionCalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option Calculator";
            this.Load += new System.EventHandler(this.OptionCalc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOptionType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRiskFreeInterestRate;
        private System.Windows.Forms.TextBox txtSigma;
        private System.Windows.Forms.TextBox txtExpireDays;
        private System.Windows.Forms.TextBox txtStockPrice;
        private System.Windows.Forms.TextBox txtStrikePrice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCallRow;
        private System.Windows.Forms.Label lblCallOmega;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCallTheta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCallVega;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCallGama;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCallDelta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCallB_SValue;
        private System.Windows.Forms.Label lblPutRow;
        private System.Windows.Forms.Label lblPutOmega;
        private System.Windows.Forms.Label lblPutTheta;
        private System.Windows.Forms.Label lblPutVega;
        private System.Windows.Forms.Label lblPutGama;
        private System.Windows.Forms.Label lblPutDelta;
        private System.Windows.Forms.Label lblPutB_SValue;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCalculateIV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOptionPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBNSBisections;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtIterationCounter;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.RadioGroup grpOptionType;
    }
}