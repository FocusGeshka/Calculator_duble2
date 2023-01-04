using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator_duble2
{
    public partial class Form1 : Form
    {
        bool znak = true;
        string expression = "";
        public Form1()
        {
            InitializeComponent();
        }
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setNum("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setNum("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setNum("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setNum("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setNum("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setNum("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setNum("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setNum("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setNum("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            setNum("0");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            expression = textBox1.Text;
            label1.Visible= false;
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
            
            
        }
        private void setSign(string sign)
        {
            if (expression == "" && sign == "_")
            {
                label1.Visible=!label1.Visible;
            }
            else
            {
                if(expression != "")
                {
                    if (int.TryParse(expression[expression.Length - 1].ToString(), out var number))
                    {
                        expression += sign;
                    }
                    else
                    {
                        expression = expression.Substring(0, expression.Length - 1).Insert(expression.Length - 1, sign);
                    }
                }
            }
        }
        private void checkExpression()
        {
            string result;
            Regex regex = new Regex(@"[+, -]?\d+[+, \-, *, /]\d+");
            if (regex.IsMatch(expression))
            {
                if (label1.Visible)
                {
                    result = new Calc().Option("-" + expression);
                }
                else
                {
                    result = new Calc().Option(expression);
                }
                if (int.TryParse(result, out var num))
                {
                    checkNum(int.Parse(result));
                }
                else
                {
                    textBox1.Text = result;
                }
            }
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("+");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("/");
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            string result;
            if (expression != "")
            {
                if (!int.TryParse(expression[expression.Length - 1].ToString(), out var number))
                {
                    expression = expression.Substring(0, expression.Length - 1);
                }
                if (label1.Visible)
                {
                    result = new Calc().Option("-" + expression);
                }
                else
                {
                    result = new Calc().Option(expression);
                }
                if (int.TryParse(result, out var num))
                {
                    checkNum(int.Parse(result));
                }
                else
                {
                    textBox1.Text = result;
                }
            }
        }
        private void checkNum(int result)
        {
            if (result < 0)
            {
                textBox1.Text = (result * -1).ToString();
                label1.Visible = true;
                expression = "-" + textBox1.Text;
            }
            else
            {
                textBox1.Text = result.ToString();
                label1.Visible = false;
                expression = textBox1.Text;
            }
        }
        private void setNum(string num)
        {
            if (textBox1.Text.Length <= 8)
            {
                if (expression != "" && int.TryParse(expression[expression.Length - 1].ToString(), out var number))
                {
                    textBox1.Text += num;
                }
                else
                {
                    textBox1.Text = num;
                }
                expression += num;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                    }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

