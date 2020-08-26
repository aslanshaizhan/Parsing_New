using MySql.Data.MySqlClient;
using Parser.Core;
using Parser.Core.Search;
using System;
using System.Data;
using System.Windows.Forms;

namespace Parser
{
    public partial class FormMain : Form
    {
        ParserWorker<string[]> parser;

        public FormMain()
        {
            InitializeComponent();

            parser = new ParserWorker<string[]>(
                    new SearchParser()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All data are collected!");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new SearchSettings((int)NumericStart.Value, (int)NumericEnd.Value);
            parser.Start();

            DB db = new DB();
            SearchParser searchParser = new SearchParser();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM 'prisoners' WHERE 'lastname' = @lt AND 'firstname' = @ft AND 'middlename' = @md AND 'birthday' = @bd AND 'org' = @org AND 'phone' = @ph");
            command.Parameters.Add("@lt", MySqlDbType.VarChar).Value = searchParser.Equals(searchParser.item1 lastname);
            command.Parameters.Add("@ft", MySqlDbType.VarChar).Value = searchParser.Equals(searchParser.item2 firstname);
            command.Parameters.Add("@md", MySqlDbType.VarChar).Value = searchParser.Equals(searchParser.item3 middlename);
            command.Parameters.Add("@bd", MySqlDbType.VarChar).Value = searchParser.Equals(searchParser.item4 birthday);
            command.Parameters.Add("@org", MySqlDbType.VarChar).Value = searchParser.Equals(searchParser.item5 org);
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = searchParser.Equals(searchParser.item6 phone);

            adapter.SelectCommand = command; 
            adapter.Fill(table);
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
