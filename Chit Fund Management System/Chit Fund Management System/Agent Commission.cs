﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Chit_Fund_Management_System
{
    public partial class Agent_Commission : Form
    {
        public static string agent_id = " ";
        public static string agent_name = " ";
        public static string agent_mob_no = " ";
        public static string group_id = " ";
        public static string chit_amt = " ";
        public static string commission_amt = " ";
        public static string paid_date = " ";
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Chit-Fund-Management-System\ChitFundDB.accdb");
        OleDbCommand cmd;
        public Agent_Commission()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bt_commission_calculate_Click(object sender, EventArgs e)
        {
            double commission_amount, chit_amount;
            chit_amount = double.Parse(tb_commission_chit_amount.Text);
            commission_amount = 0.02 * chit_amount;
            tb_commission_amount.Text = commission_amount.ToString();
        }

        private void bt_commission_save_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_commission_search_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataReader dr;
                DataTable dt = new DataTable();
                con.Open();
                cmd = new OleDbCommand("select * from AgentTB where [Aid]=@Aid", con);
                cmd.Parameters.AddWithValue("@agentid", tb_agent_id.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tb_commission_agent_name.Text = (dr["Aname"].ToString());
                    tb_commission_agent_mob.Text = (dr["Amob"].ToString());
                    
                }
                con.Close();
                con.Open();
                cmd = new OleDbCommand("select * from MemberTB where [gid]=@gid", con);
                cmd.Parameters.AddWithValue("@agentid", tb_commission_group_id.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tb_commission_chit_amount.Text = (dr["camt"].ToString());

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_commission_clear_Click(object sender, EventArgs e)
        {
            tb_agent_id.Clear();
            tb_commission_agent_name.Clear();
            tb_commission_agent_mob.Clear();
            tb_commission_amount.Clear();
            tb_commission_group_id.Clear();
            tb_commission_chit_amount.Clear();
            dtp_commission_received_date.Value = DateTime.Today;
        }

        private void bt_commission_close_Click(object sender, EventArgs e)
        {
            f_chit_fund_dash_board f_Chit_Fund_Dash_Board = new f_chit_fund_dash_board();
            f_Chit_Fund_Dash_Board.Show();
            this.Hide();
        }

        private void bt_commission_receipt_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_commission_pay_Click(object sender, EventArgs e)
        {
            try
            {
                agent_id = tb_agent_id.Text;
                agent_name = tb_commission_agent_name.Text;
                agent_mob_no = tb_commission_agent_mob.Text;
                group_id = tb_commission_group_id.Text;
                chit_amt = tb_commission_chit_amount.Text;
                commission_amt = tb_commission_amount.Text;
                paid_date = dtp_commission_received_date.Value.ToString("d-M-yyyy");

                Agent_Payment agent_Payment = new Agent_Payment();
                agent_Payment.Show();
                this.Hide();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.ToString());
            }
        }

        private void bt_commission_log_Click(object sender, EventArgs e)
        {
            Agent_Commission_Log_Repo agent_Commission_Log_Repo = new Agent_Commission_Log_Repo();
            agent_Commission_Log_Repo.Show();
        }

        private void tb_agent_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_agent_id.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter valid id.");
                    tb_agent_id.Text = tb_agent_id.Text.Remove(tb_agent_id.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_commission_agent_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_commission_agent_name.Text, "[^a-zA-Z ]"))
                {
                    MessageBox.Show("Please enter valid name.");
                    tb_commission_agent_name.Text = tb_commission_agent_name.Text.Remove(tb_commission_agent_name.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_commission_agent_mob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_commission_agent_mob.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter valid mobile number.");
                    tb_commission_agent_mob.Text = tb_commission_agent_mob.Text.Remove(tb_commission_agent_mob.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_commission_group_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_commission_group_id.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter valid id.");
                    tb_commission_group_id.Text = tb_commission_group_id.Text.Remove(tb_commission_group_id.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_commission_chit_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_commission_chit_amount.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter valid amount.");
                    tb_commission_chit_amount.Text = tb_commission_chit_amount.Text.Remove(tb_commission_chit_amount.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_commission_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_commission_amount.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter valid amount.");
                    tb_commission_amount.Text = tb_commission_amount.Text.Remove(tb_commission_amount.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
