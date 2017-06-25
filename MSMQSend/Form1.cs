﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSMQShared;

namespace MSMQSend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            send(TIPO_SERVER.LOCAL);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            send(TIPO_SERVER.REMOTO);
        }

        private void send(TIPO_SERVER tp)
        {
            try
            {
                var mq = FabricaMQ.GetSender(tp);
                mq.Send(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace, "Erro",MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
