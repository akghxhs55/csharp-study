using System.Numerics;

namespace _12_NumericTypesSuggester;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MinValueInput_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!ValidateInputValueCharacter(e.KeyChar, MinValueInput))
        {
            e.Handled = true;
        }
    }

    private void MaxValueInput_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!ValidateInputValueCharacter(e.KeyChar, MaxValueInput))
        {
            e.Handled = true;
        }
    }

    private static bool ValidateInputValueCharacter(char c, TextBox textbox)
    {
        return (char.IsControl(c) ||
            char.IsDigit(c) ||
            (c == '-' && textbox.SelectionStart == 0));
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        RecalculateSuggestedType();
        SetBackColorOfMaxValueInputTextBox();
    }

    private void MinValueInput_TextChanged(object sender, EventArgs e)
    {
        RecalculateSuggestedType();
    }

    private void MaxValueInput_TextChanged(object sender, EventArgs e)
    {
        RecalculateSuggestedType();
    }

    private void SetBackColorOfMaxValueInputTextBox()
    {
        bool IsValid = true;
        
        if (IsInputComplete())
        {
            BigInteger minValue = BigInteger.Parse(MinValueInput.Text);
            BigInteger maxValue = BigInteger.Parse(MaxValueInput.Text);

            if (minValue > maxValue)
            {
                IsValid = false;
            }
        }

        if (IsValid)
        {
            ChangeBackColorDefault(MaxValueInput);
        }
        else
        {
            ChangeBackColorError(MaxValueInput);
        }
    }

    private void RecalculateSuggestedType()
    {
        if (IsInputComplete())
        {
            BigInteger minValue = BigInteger.Parse(MinValueInput.Text);
            BigInteger maxValue = BigInteger.Parse(MaxValueInput.Text);

            if (minValue > maxValue)
            {
                SetText(SuggestedTypeValueLabel,
                     "not enough data");
            }
            else
            {
                SetText(SuggestedTypeValueLabel,
                    NumericTypeSuggester.GetName(minValue, maxValue, IntegralOnlyCheckBox.Checked, MustBePreciseCheckBox.Checked));
            }
        }
        else
        {
            SetText(SuggestedTypeValueLabel,
                "not enough data");
        }
    }

    private bool IsInputComplete()
    {
        return MinValueInput.Text.Length > 0 && MaxValueInput.Text.Length > 0 && MinValueInput.Text != "-" && MaxValueInput.Text != "-";
    }

    private void SetText(Control target, string text)
    {
        target.Text = text;
    }

    private void ChangeBackColorError(Control target)
    {
        target.BackColor = Color.IndianRed;
    }

    private void ChangeBackColorDefault(Control target)
    {
        target.BackColor = default;
    }

    private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        ToggleVisibility(MustBePreciseLabel);
        ToggleVisibility(MustBePreciseCheckBox);

        RecalculateSuggestedType();
    }

    private void ToggleVisibility(Control target)
    {
        target.Visible = !target.Visible;
    }

    private void MustBePreciseCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        RecalculateSuggestedType();
    }
}
