using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // Завдання №1

        private void btnRun_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(txtX.Text);
            double y = Convert.ToDouble(txtY.Text);
            double result = Math.Pow((x + 1) / (x - 1), x) + 18 * x * Math.Pow(y, 2);
            lblResult.Text = result.ToString();
            listResult.Items.Add(result.ToString());
        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtX.Text != "" && !char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if (txtX.Text.IndexOf(',') != -1) e.Handled = true;
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter) btnRun.Focus();
                return;
            }
            e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtX.Text = "";
            txtY.Clear();
            listResult.Items.Clear();
            lblResult.Text = string.Empty;
        }

        // Завдання №2

        private void txtX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && tb.Text.Contains(",")) e.Handled = true;
            if (e.KeyChar == '-')
            {
                if (tb.SelectionStart != 0 || tb.Text.Contains("-")) e.Handled = true;
            }
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtX1.Text) || txtX1.Text == "-" || txtX1.Text == ",")
            {
                MessageBox.Show("Введіть коректне число", "Помилка");
                return;
            }
            try
            {
                double x = double.Parse(txtX1.Text);
                double x2 = x * x;
                double x3 = x2 * x;
                double res1 = -2 * x + 3 * x2 - 4 * x3;
                double res2 = 1 + 2 * x + 3 * x2 + 4 * x3;
                lblResult1.Text = res1.ToString("F4");
                lblResult2.Text = res2.ToString("F4");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка обчислення: " + ex.Message);
            }
        }

        // Завдання №3

        private void txtTriangleSides_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && tb.Text.Contains(",")) e.Handled = true;

            if (e.KeyChar == '.')
            {
                if (!tb.Text.Contains(",")) e.KeyChar = ',';
                else e.Handled = true;
            }
        }

        private void btnRun2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtA1.Text) || string.IsNullOrWhiteSpace(txtB1.Text) || string.IsNullOrWhiteSpace(txtC1.Text) ||
                string.IsNullOrWhiteSpace(txtA2.Text) || string.IsNullOrWhiteSpace(txtB2.Text) || string.IsNullOrWhiteSpace(txtC2.Text))
            {
                MessageBox.Show("Заповніть усі сторони обох трикутників", "Увага");
                return;
            }

            try
            {
                double a1 = double.Parse(txtA1.Text);
                double b1 = double.Parse(txtB1.Text);
                double c1 = double.Parse(txtC1.Text);

                double a2 = double.Parse(txtA2.Text);
                double b2 = double.Parse(txtB2.Text);
                double c2 = double.Parse(txtC2.Text);

                double p1 = (a1 + b1 + c1) / 2;
                double s1 = Math.Sqrt(p1 * (p1 - a1) * (p1 - b1) * (p1 - c1));

                double p2 = (a2 + b2 + c2) / 2;
                double s2 = Math.Sqrt(p2 * (p2 - a2) * (p2 - b2) * (p2 - c2));

                if (double.IsNaN(s1) || s1 <= 0 || double.IsNaN(s2) || s2 <= 0)
                {
                    lblResult3.Text = "Помилка: Неіснуючий трикутник";
                    return;
                }

                bool areEqual = Math.Abs(s1 - s2) < 0.0001;

                lblResult3.Text = areEqual.ToString().ToLower();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Завдання №4

        private void txtOnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRun3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("Введіть номер квартири");
                return;
            }

            try
            {
                int m = int.Parse(txtNum.Text);

                if (m <= 0)
                {
                    MessageBox.Show("Номер квартири повинен бути більшим за 0");
                    return;
                }

                int actualFloor = (m - 1) / 3 + 1;

                int targetFloor;

                if (actualFloor % 2 != 0)
                {
                    targetFloor = actualFloor;
                }
                else
                {
                    targetFloor = actualFloor - 1;

                    if (targetFloor < 1) targetFloor = 1;
                }

                lblResult4.Text = $"{targetFloor} поверх.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        //Завдання №5

        private void txtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRun4_Click(object sender, EventArgs e)
        {
            listResult1.Items.Clear();

            if (string.IsNullOrWhiteSpace(txtNum1.Text))
            {
                MessageBox.Show("Введіть число n");
                return;
            }

            int n = int.Parse(txtNum1.Text);

            if (n <= 2)
            {
                MessageBox.Show("Число n повинно бути більшим за 2");
                return;
            }

            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    listResult1.Items.Add(i);
                }
            }
        }

        //Завдання №6

        private void txtNumList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void btnRun5_Click(object sender, EventArgs e)
        {
            listResult2.Items.Clear();

            string[] inputStrings = txtNumList.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = inputStrings.Length;
            if (n < 2)
            {
                MessageBox.Show("Послідовність повинна містити мінімум два числа", "Помилка");
                return;
            }

            try
            {
                int[] a = new int[n];
                long sum = 0;

                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(inputStrings[i]);
                    sum += a[i];
                }

                int average = (int)(sum / n);

                int minVal = a[0];
                int minIndex = 0;

                for (int i = 0; i < n; i++)
                {
                    if (a[i] <= minVal)
                    {
                        minVal = a[i];
                        minIndex = i;
                    }
                }

                a[minIndex] = average;

                foreach (int num in a)
                {
                    listResult2.Items.Add(num);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при зчитуванні чисел: " + ex.Message);
            }
        }

        //Завдання №7

        private void btnRun6_Click(object sender, EventArgs e)
        {
            string input = txtRow.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введіть текст");
                return;
            }

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string lastWord = words[words.Length - 1];

            int count = 0;

            for (int i = 0; i < lastWord.Length; i++)
            {
                if (lastWord[i] == 'k' || lastWord[i] == 'K' ||
                    lastWord[i] == 'к' || lastWord[i] == 'К')
                {
                    count++;
                }
            }

            lblResultRow.Text = $"Кількість букв 'k': {count}";
        }
    }
}
