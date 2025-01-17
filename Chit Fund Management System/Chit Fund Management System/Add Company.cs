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
    public partial class Add_Company : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Chit-Fund-Management-System\ChitFundDB.accdb");
        OleDbCommand cmd;
        public Add_Company()
        {
            InitializeComponent();
        }

        private void bt_add_add_company_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new OleDbCommand("insert into CompanyTB(CIN_no, Company_name, Address, City, Owner, No_of_branches, Date_of_registration) values(@cinno, @companyname, @address, @city, @owner, @noofbranches, @dateofregistration)", con);
                cmd.Parameters.AddWithValue("@cinno", tb_cinno_add_company.Text);
                cmd.Parameters.AddWithValue("@companyname", tb_companyname_add_company.Text);
                cmd.Parameters.AddWithValue("@address", tb_address_add_company.Text);
                cmd.Parameters.AddWithValue("@city", tb_city_add_company.Text);
                cmd.Parameters.AddWithValue("@owner", tb_owner_add_company.Text);
                cmd.Parameters.AddWithValue("@noofbranches", tb_noofbranches_add_company.Text);
                cmd.Parameters.AddWithValue("@dateofregistration", dtp_date_of_registration_add_company.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Company details saved successfully....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_cinno_add_company_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bt_close_add_company_Click(object sender, EventArgs e)
        {
            f_chit_fund_dash_board f_Chit_Fund_Dash_Board = new f_chit_fund_dash_board();
            f_Chit_Fund_Dash_Board.Show();
            this.Hide();
        }

        private void tb_owner_add_company_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_owner_add_company.Text, "[^A-Za-z ]"))
                {
                    MessageBox.Show("Please enter valid name.");
                    tb_owner_add_company.Text = tb_owner_add_company.Text.Remove(tb_owner_add_company.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_noofbranches_add_company_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_noofbranches_add_company.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter valid branch count.");
                    tb_noofbranches_add_company.Text = tb_noofbranches_add_company.Text.Remove(tb_noofbranches_add_company.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tb_city_add_company_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_city_add_company.Text, "[^a-zA-Z ]"))
                {
                    MessageBox.Show("Please enter valid city.");
                    tb_city_add_company.Text = tb_city_add_company.Text.Remove(tb_city_add_company.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_search_add_company_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataReader dr;
                DataTable dt = new DataTable();
                con.Open();
                cmd = new OleDbCommand("select [Company_name], [Address], [City], [Owner], [No_of_branches], [Date_of_registration] from CompanyTB where [CIN_no]=@cinno", con);
                cmd.Parameters.AddWithValue("@cinno", tb_cinno_add_company.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tb_companyname_add_company.Text = (dr["Company_name"].ToString());
                    tb_address_add_company.Text = (dr["Address"].ToString());
                    tb_city_add_company.Text = (dr["City"].ToString());
                    tb_owner_add_company.Text = (dr["Owner"].ToString());
                    tb_noofbranches_add_company.Text = (dr["No_of_branches"].ToString());
                    dtp_date_of_registration_add_company.Text = (dr["Date_of_registration"].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_clear_add_company_Click(object sender, EventArgs e)
        {
            tb_cinno_add_company.Clear();
            tb_companyname_add_company.Clear();
            tb_address_add_company.Clear();
            tb_city_add_company.Clear();
            tb_owner_add_company.Clear();
            tb_noofbranches_add_company.Clear();
        }
    }
}
