using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeCalc
{
    public partial class MainGui : Form
    {
        private Week week;
        public MainGui()
        {
            InitializeComponent();
            Text = "Time Calculator";
            foreach (Label l in Controls.OfType<Label>())
            {
                l.TabIndex = 0;
            }
        }
        private List<int> inStrings = new List<int>();
        private List<int> outStrings = new List<int>();
        private void Calc_Click(object sender, EventArgs e)
        {
            week = new Week();
            inStrings.Clear();
            outStrings.Clear();
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text))
                    tb.Text = "0";

                if(tb.Name.Contains("in"))
                {
                    if (int.TryParse(tb.Text, out int temp))
                        inStrings.Add(temp);
                }else if(tb.Name.Contains("out"))
                {
                    if (int.TryParse(tb.Text, out int temp))
                        outStrings.Add(temp);
                }
            }
            week.AddWeek(inStrings.ToArray(), outStrings.ToArray());
            try
            {
                var a = week.CalculateWeek();
                if(double.TryParse(textBox1.Text, out double d))
                {

                    var check = (a*d);
                    answer.Text = $"Total Hours: {a}  TotalCheck: ${check}";
                }
                else
                {
                    answer.Text = $"Total Hours: {a}";
                }
            }catch(ArgumentNullException ane)
            {
                answer.Text = ane.Message;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                tb.Text = "";
                inStrings.Clear();
                outStrings.Clear();
                answer.Text = $"Total Hours: 0";
            }
        }
    }
}
