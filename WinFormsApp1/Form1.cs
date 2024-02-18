using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public delegate void ButtonClickDelegate(object sender, EventArgs e);

    public partial class Form1 : Form
    {
        private double defaultOpacity;
        private Color defaultBackColor;

        public Form1()
        {
            InitializeComponent();

            // «берегти початков≥ значенн€ параметр≥в форми
            defaultOpacity = this.Opacity;
            defaultBackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ѕерев≥р€Їмо, чи поточне значенн€ прозорост≥ вже Ї початковим
            if (this.Opacity == defaultOpacity)
            {
                // якщо так, зм≥нюЇмо прозор≥сть на 0.5
                this.Opacity = 0.5;
            }
            else
            {
                // якщо н≥, в≥дновлюЇмо початкове значенн€ прозорост≥
                this.Opacity = defaultOpacity;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ѕерев≥р€Їмо, чи поточний кол≥р тла вже Ї початковим
            if (this.BackColor == defaultBackColor)
            {
                // якщо так, зм≥нюЇмо кол≥р тла на червоний
                this.BackColor = Color.Red;
            }
            else
            {
                // якщо н≥, в≥дновлюЇмо початковий кол≥р тла
                this.BackColor = defaultBackColor;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!"); // виводить пов≥домленн€
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("÷е пов≥домленн€ кнопки —упермегакнопка."); // виводить своЇ пов≥домленн€

            // ѕерев≥рка галочок ≥ виконанн€ обов'€зк≥в ≥нших кнопок
            if (checkBox1.Checked)
            {
                ButtonClickDelegate button1Delegate = new ButtonClickDelegate(button1_Click);
                button1Delegate.Invoke(sender, e);
            }
            if (checkBox2.Checked)
            {
                ButtonClickDelegate button2Delegate = new ButtonClickDelegate(button2_Click);
                button2Delegate.Invoke(sender, e);
            }
            if (checkBox3.Checked)
            {
                ButtonClickDelegate button3Delegate = new ButtonClickDelegate(button3_Click);
                button3Delegate.Invoke(sender, e);
            }
        }
    }
}
