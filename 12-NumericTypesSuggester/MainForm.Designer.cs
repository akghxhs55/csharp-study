namespace _12_NumericTypesSuggester;

partial class MainForm
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
        MinValueLabel = new Label();
        MaxValueLabel = new Label();
        MinValueInput = new TextBox();
        MaxValueInput = new TextBox();
        IntegralOnlyLabel = new Label();
        IntegralOnlyCheckBox = new CheckBox();
        MustBePreciseLabel = new Label();
        MustBePreciseCheckBox = new CheckBox();
        SuggestedTypeLabel = new Label();
        SuggestedTypeValueLabel = new Label();
        SuspendLayout();
        // 
        // MinValueLabel
        // 
        MinValueLabel.AutoSize = true;
        MinValueLabel.Font = new Font("Pretendard JP Variable Light", 20F, FontStyle.Regular, GraphicsUnit.Point, 128);
        MinValueLabel.Location = new Point(122, 60);
        MinValueLabel.Name = "MinValueLabel";
        MinValueLabel.Size = new Size(170, 40);
        MinValueLabel.TabIndex = 0;
        MinValueLabel.Text = "Min value:";
        // 
        // MaxValueLabel
        // 
        MaxValueLabel.AutoSize = true;
        MaxValueLabel.Font = new Font("Pretendard JP Variable Light", 20F, FontStyle.Regular, GraphicsUnit.Point, 128);
        MaxValueLabel.Location = new Point(113, 112);
        MaxValueLabel.Name = "MaxValueLabel";
        MaxValueLabel.Size = new Size(179, 40);
        MaxValueLabel.TabIndex = 1;
        MaxValueLabel.Text = "Max value:";
        // 
        // MinValueInput
        // 
        MinValueInput.Font = new Font("Pretendard JP Variable Light", 20F, FontStyle.Regular, GraphicsUnit.Point, 128);
        MinValueInput.Location = new Point(298, 53);
        MinValueInput.Name = "MinValueInput";
        MinValueInput.Size = new Size(448, 47);
        MinValueInput.TabIndex = 2;
        MinValueInput.TextChanged += TextBox_TextChanged;
        MinValueInput.KeyPress += MinValueInput_KeyPress;
        // 
        // MaxValueInput
        // 
        MaxValueInput.Font = new Font("Pretendard JP Variable Light", 20F, FontStyle.Regular, GraphicsUnit.Point, 128);
        MaxValueInput.Location = new Point(298, 112);
        MaxValueInput.Name = "MaxValueInput";
        MaxValueInput.Size = new Size(448, 47);
        MaxValueInput.TabIndex = 3;
        MaxValueInput.TextChanged += TextBox_TextChanged;
        MaxValueInput.KeyPress += MaxValueInput_KeyPress;
        // 
        // IntegralOnlyLabel
        // 
        IntegralOnlyLabel.AutoSize = true;
        IntegralOnlyLabel.Font = new Font("Pretendard JP Variable Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
        IntegralOnlyLabel.Location = new Point(97, 189);
        IntegralOnlyLabel.Name = "IntegralOnlyLabel";
        IntegralOnlyLabel.Size = new Size(195, 36);
        IntegralOnlyLabel.TabIndex = 4;
        IntegralOnlyLabel.Text = "Integral only?";
        // 
        // IntegralOnlyCheckBox
        // 
        IntegralOnlyCheckBox.AutoSize = true;
        IntegralOnlyCheckBox.Checked = true;
        IntegralOnlyCheckBox.CheckState = CheckState.Checked;
        IntegralOnlyCheckBox.Location = new Point(298, 203);
        IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
        IntegralOnlyCheckBox.Size = new Size(18, 17);
        IntegralOnlyCheckBox.TabIndex = 5;
        IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
        IntegralOnlyCheckBox.CheckedChanged += IntegralOnlyCheckBox_CheckedChanged;
        // 
        // MustBePreciseLabel
        // 
        MustBePreciseLabel.AutoSize = true;
        MustBePreciseLabel.Font = new Font("Pretendard JP Variable Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
        MustBePreciseLabel.Location = new Point(46, 235);
        MustBePreciseLabel.Name = "MustBePreciseLabel";
        MustBePreciseLabel.Size = new Size(246, 36);
        MustBePreciseLabel.TabIndex = 6;
        MustBePreciseLabel.Text = "Must be precise?";
        MustBePreciseLabel.Visible = false;
        // 
        // MustBePreciseCheckBox
        // 
        MustBePreciseCheckBox.AutoSize = true;
        MustBePreciseCheckBox.Location = new Point(298, 252);
        MustBePreciseCheckBox.Name = "MustBePreciseCheckBox";
        MustBePreciseCheckBox.Size = new Size(18, 17);
        MustBePreciseCheckBox.TabIndex = 7;
        MustBePreciseCheckBox.UseVisualStyleBackColor = true;
        MustBePreciseCheckBox.Visible = false;
        MustBePreciseCheckBox.CheckedChanged += MustBePreciseCheckBox_CheckedChanged;
        // 
        // SuggestedTypeLabel
        // 
        SuggestedTypeLabel.AutoSize = true;
        SuggestedTypeLabel.Font = new Font("Pretendard JP Variable Light", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
        SuggestedTypeLabel.Location = new Point(34, 326);
        SuggestedTypeLabel.Name = "SuggestedTypeLabel";
        SuggestedTypeLabel.Size = new Size(258, 36);
        SuggestedTypeLabel.TabIndex = 8;
        SuggestedTypeLabel.Text = "Suggested Type:";
        // 
        // SuggestedTypeValueLabel
        // 
        SuggestedTypeValueLabel.AutoSize = true;
        SuggestedTypeValueLabel.Font = new Font("Pretendard JP Variable Light", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
        SuggestedTypeValueLabel.Location = new Point(298, 326);
        SuggestedTypeValueLabel.Name = "SuggestedTypeValueLabel";
        SuggestedTypeValueLabel.Size = new Size(252, 36);
        SuggestedTypeValueLabel.TabIndex = 9;
        SuggestedTypeValueLabel.Text = "not enough data";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(9F, 18F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(800, 408);
        Controls.Add(SuggestedTypeValueLabel);
        Controls.Add(SuggestedTypeLabel);
        Controls.Add(MustBePreciseCheckBox);
        Controls.Add(MustBePreciseLabel);
        Controls.Add(IntegralOnlyCheckBox);
        Controls.Add(IntegralOnlyLabel);
        Controls.Add(MaxValueInput);
        Controls.Add(MinValueInput);
        Controls.Add(MaxValueLabel);
        Controls.Add(MinValueLabel);
        Name = "MainForm";
        Text = "C# numeric types";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label MinValueLabel;
    private Label MaxValueLabel;
    private TextBox MinValueInput;
    private TextBox MaxValueInput;
    private Label IntegralOnlyLabel;
    private CheckBox IntegralOnlyCheckBox;
    private Label MustBePreciseLabel;
    private CheckBox MustBePreciseCheckBox;
    private Label SuggestedTypeLabel;
    private Label SuggestedTypeValueLabel;
}
