using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);
            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };

            if (isHeightValid && isWeightValid)
            {
                height /= 100;

                double bmi = weight / (height * height);

                string strResult = "";
                Color colorResult = Color.Black;
                int resultIndex = 0;
                if (bmi < 18.5)
                {
                    resultIndex = 0;
                }
                else if (bmi < 24)
                {
                    resultIndex = 1;
                }
                else if (bmi < 27)
                {
                    resultIndex = 2;
                }
                else if (bmi < 30)
                {
                    resultIndex = 3;
                }
                else if (bmi < 35)
                {
                    resultIndex = 4;
                }
                else
                {
                    resultIndex = 5;
                }
                strResult = strResultList[resultIndex];
                colorResult = colorList[resultIndex];

                lblResult.Text = $"{bmi:F2} ({strResult})";
                lblResult.BackColor = colorResult;

            }
            else
            {
                MessageBox.Show("請輸入有效的數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
