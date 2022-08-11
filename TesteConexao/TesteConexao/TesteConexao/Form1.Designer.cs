
namespace TesteConexao
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxTipoBanco = new System.Windows.Forms.ComboBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtBaseDados = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkWindowsAutenticator = new System.Windows.Forms.CheckBox();
            this.txtConnectString = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxTipoBanco
            // 
            this.cbxTipoBanco.FormattingEnabled = true;
            this.cbxTipoBanco.Location = new System.Drawing.Point(130, 37);
            this.cbxTipoBanco.Name = "cbxTipoBanco";
            this.cbxTipoBanco.Size = new System.Drawing.Size(121, 23);
            this.cbxTipoBanco.TabIndex = 0;
            this.cbxTipoBanco.SelectedValueChanged += new System.EventHandler(this.cbxTipoBanco_SelectedValueChanged);
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(130, 89);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(100, 23);
            this.txtServidor.TabIndex = 1;
            // 
            // txtBaseDados
            // 
            this.txtBaseDados.Location = new System.Drawing.Point(130, 139);
            this.txtBaseDados.Name = "txtBaseDados";
            this.txtBaseDados.Size = new System.Drawing.Size(100, 23);
            this.txtBaseDados.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(130, 191);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 23);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(130, 243);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(100, 23);
            this.txtSenha.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Servidor : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Base de Dados : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Usuário : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Senha : ";
            // 
            // txtResultado
            // 
            this.txtResultado.ForeColor = System.Drawing.Color.Red;
            this.txtResultado.Location = new System.Drawing.Point(65, 347);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(610, 65);
            this.txtResultado.TabIndex = 9;
            this.txtResultado.Text = "Resultado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Resultado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo do Banco : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Testar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkWindowsAutenticator
            // 
            this.chkWindowsAutenticator.AutoSize = true;
            this.chkWindowsAutenticator.Location = new System.Drawing.Point(270, 39);
            this.chkWindowsAutenticator.Name = "chkWindowsAutenticator";
            this.chkWindowsAutenticator.Size = new System.Drawing.Size(144, 19);
            this.chkWindowsAutenticator.TabIndex = 13;
            this.chkWindowsAutenticator.Text = "Windows Autenticator";
            this.chkWindowsAutenticator.UseVisualStyleBackColor = true;
            this.chkWindowsAutenticator.Visible = false;
            // 
            // txtConnectString
            // 
            this.txtConnectString.ForeColor = System.Drawing.Color.Red;
            this.txtConnectString.Location = new System.Drawing.Point(68, 462);
            this.txtConnectString.Multiline = true;
            this.txtConnectString.Name = "txtConnectString";
            this.txtConnectString.Size = new System.Drawing.Size(607, 65);
            this.txtConnectString.TabIndex = 14;
            this.txtConnectString.Text = "Resultado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Connectstring";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 624);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtConnectString);
            this.Controls.Add(this.chkWindowsAutenticator);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtBaseDados);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.cbxTipoBanco);
            this.Name = "Form1";
            this.Text = "Teste de Conexao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTipoBanco;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtBaseDados;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkWindowsAutenticator;
        private System.Windows.Forms.TextBox txtConnectString;
        private System.Windows.Forms.Label label7;
    }
}

