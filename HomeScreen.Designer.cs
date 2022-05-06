
namespace hospitalmanagement
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.patientsButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.doctorsButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(63, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome back,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(93, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "dr. Smith";
            // 
            // patientsButton
            // 
            this.patientsButton.AllowAnimations = true;
            this.patientsButton.AllowMouseEffects = true;
            this.patientsButton.AllowToggling = false;
            this.patientsButton.AnimationSpeed = 200;
            this.patientsButton.AutoGenerateColors = false;
            this.patientsButton.AutoRoundBorders = false;
            this.patientsButton.AutoSizeLeftIcon = true;
            this.patientsButton.AutoSizeRightIcon = true;
            this.patientsButton.BackColor = System.Drawing.Color.Transparent;
            this.patientsButton.BackColor1 = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("patientsButton.BackgroundImage")));
            this.patientsButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.patientsButton.ButtonText = "Patients";
            this.patientsButton.ButtonTextMarginLeft = 0;
            this.patientsButton.ColorContrastOnClick = 45;
            this.patientsButton.ColorContrastOnHover = 45;
            this.patientsButton.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.patientsButton.CustomizableEdges = borderEdges1;
            this.patientsButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.patientsButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.patientsButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.patientsButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.patientsButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.patientsButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patientsButton.ForeColor = System.Drawing.Color.White;
            this.patientsButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientsButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.patientsButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.patientsButton.IconMarginLeft = 11;
            this.patientsButton.IconPadding = 10;
            this.patientsButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.patientsButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.patientsButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.patientsButton.IconSize = 25;
            this.patientsButton.IdleBorderColor = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.IdleBorderRadius = 1;
            this.patientsButton.IdleBorderThickness = 1;
            this.patientsButton.IdleFillColor = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.IdleIconLeftImage = null;
            this.patientsButton.IdleIconRightImage = null;
            this.patientsButton.IndicateFocus = false;
            this.patientsButton.Location = new System.Drawing.Point(-1, 239);
            this.patientsButton.Name = "patientsButton";
            this.patientsButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.patientsButton.OnDisabledState.BorderRadius = 1;
            this.patientsButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.patientsButton.OnDisabledState.BorderThickness = 1;
            this.patientsButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.patientsButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.patientsButton.OnDisabledState.IconLeftImage = null;
            this.patientsButton.OnDisabledState.IconRightImage = null;
            this.patientsButton.onHoverState.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.patientsButton.onHoverState.BorderRadius = 1;
            this.patientsButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.patientsButton.onHoverState.BorderThickness = 1;
            this.patientsButton.onHoverState.FillColor = System.Drawing.Color.DarkSlateGray;
            this.patientsButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.patientsButton.onHoverState.IconLeftImage = null;
            this.patientsButton.onHoverState.IconRightImage = null;
            this.patientsButton.OnIdleState.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.OnIdleState.BorderRadius = 1;
            this.patientsButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.patientsButton.OnIdleState.BorderThickness = 1;
            this.patientsButton.OnIdleState.FillColor = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.patientsButton.OnIdleState.IconLeftImage = null;
            this.patientsButton.OnIdleState.IconRightImage = null;
            this.patientsButton.OnPressedState.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.OnPressedState.BorderRadius = 1;
            this.patientsButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.patientsButton.OnPressedState.BorderThickness = 1;
            this.patientsButton.OnPressedState.FillColor = System.Drawing.Color.LightSeaGreen;
            this.patientsButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.patientsButton.OnPressedState.IconLeftImage = null;
            this.patientsButton.OnPressedState.IconRightImage = null;
            this.patientsButton.Size = new System.Drawing.Size(273, 56);
            this.patientsButton.TabIndex = 5;
            this.patientsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.patientsButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.patientsButton.TextMarginLeft = 0;
            this.patientsButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.patientsButton.UseDefaultRadiusAndThickness = true;
            // 
            // doctorsButton
            // 
            this.doctorsButton.AllowAnimations = true;
            this.doctorsButton.AllowMouseEffects = true;
            this.doctorsButton.AllowToggling = false;
            this.doctorsButton.AnimationSpeed = 200;
            this.doctorsButton.AutoGenerateColors = false;
            this.doctorsButton.AutoRoundBorders = false;
            this.doctorsButton.AutoSizeLeftIcon = true;
            this.doctorsButton.AutoSizeRightIcon = true;
            this.doctorsButton.BackColor = System.Drawing.Color.Transparent;
            this.doctorsButton.BackColor1 = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("doctorsButton.BackgroundImage")));
            this.doctorsButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.doctorsButton.ButtonText = "Doctors";
            this.doctorsButton.ButtonTextMarginLeft = 0;
            this.doctorsButton.ColorContrastOnClick = 45;
            this.doctorsButton.ColorContrastOnHover = 45;
            this.doctorsButton.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.doctorsButton.CustomizableEdges = borderEdges2;
            this.doctorsButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.doctorsButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.doctorsButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.doctorsButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.doctorsButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.doctorsButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.doctorsButton.ForeColor = System.Drawing.Color.White;
            this.doctorsButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.doctorsButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.doctorsButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.doctorsButton.IconMarginLeft = 11;
            this.doctorsButton.IconPadding = 10;
            this.doctorsButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.doctorsButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.doctorsButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.doctorsButton.IconSize = 25;
            this.doctorsButton.IdleBorderColor = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.IdleBorderRadius = 1;
            this.doctorsButton.IdleBorderThickness = 1;
            this.doctorsButton.IdleFillColor = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.IdleIconLeftImage = null;
            this.doctorsButton.IdleIconRightImage = null;
            this.doctorsButton.IndicateFocus = false;
            this.doctorsButton.Location = new System.Drawing.Point(-1, 177);
            this.doctorsButton.Name = "doctorsButton";
            this.doctorsButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.doctorsButton.OnDisabledState.BorderRadius = 1;
            this.doctorsButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.doctorsButton.OnDisabledState.BorderThickness = 1;
            this.doctorsButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.doctorsButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.doctorsButton.OnDisabledState.IconLeftImage = null;
            this.doctorsButton.OnDisabledState.IconRightImage = null;
            this.doctorsButton.onHoverState.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.doctorsButton.onHoverState.BorderRadius = 1;
            this.doctorsButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.doctorsButton.onHoverState.BorderThickness = 1;
            this.doctorsButton.onHoverState.FillColor = System.Drawing.Color.DarkSlateGray;
            this.doctorsButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.doctorsButton.onHoverState.IconLeftImage = null;
            this.doctorsButton.onHoverState.IconRightImage = null;
            this.doctorsButton.OnIdleState.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.OnIdleState.BorderRadius = 1;
            this.doctorsButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.doctorsButton.OnIdleState.BorderThickness = 1;
            this.doctorsButton.OnIdleState.FillColor = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.doctorsButton.OnIdleState.IconLeftImage = null;
            this.doctorsButton.OnIdleState.IconRightImage = null;
            this.doctorsButton.OnPressedState.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.OnPressedState.BorderRadius = 1;
            this.doctorsButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.doctorsButton.OnPressedState.BorderThickness = 1;
            this.doctorsButton.OnPressedState.FillColor = System.Drawing.Color.LightSeaGreen;
            this.doctorsButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.doctorsButton.OnPressedState.IconLeftImage = null;
            this.doctorsButton.OnPressedState.IconRightImage = null;
            this.doctorsButton.Size = new System.Drawing.Size(273, 56);
            this.doctorsButton.TabIndex = 4;
            this.doctorsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.doctorsButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.doctorsButton.TextMarginLeft = 0;
            this.doctorsButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.doctorsButton.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 50;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(80, 12);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(100, 100);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 1;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 738);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 723);
            this.Controls.Add(this.patientsButton);
            this.Controls.Add(this.doctorsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton doctorsButton;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton patientsButton;
    }
}