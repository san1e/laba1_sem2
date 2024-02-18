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

            // �������� �������� �������� ��������� �����
            defaultOpacity = this.Opacity;
            defaultBackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ����������, �� ������� �������� ��������� ��� � ����������
            if (this.Opacity == defaultOpacity)
            {
                // ���� ���, ������� ��������� �� 0.5
                this.Opacity = 0.5;
            }
            else
            {
                // ���� �, ���������� ��������� �������� ���������
                this.Opacity = defaultOpacity;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ����������, �� �������� ���� ��� ��� � ����������
            if (this.BackColor == defaultBackColor)
            {
                // ���� ���, ������� ���� ��� �� ��������
                this.BackColor = Color.Red;
            }
            else
            {
                // ���� �, ���������� ���������� ���� ���
                this.BackColor = defaultBackColor;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!"); // �������� �����������
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�� ����������� ������ ���������������."); // �������� ��� �����������

            // �������� ������� � ��������� ����'���� ����� ������
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
