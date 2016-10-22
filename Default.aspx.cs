using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ParsingCode : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddDefaultFirstRecord();
            date.Text = DateTime.Now.ToString("yyyy");
        }
    }
    // Define a handler for the button click.
    protected void Parsing_OnClick(object sender, EventArgs e)
    {
        Parsing();
    }

    protected void AddDefaultFirstRecord()
    {
        //creating dataTable 

        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "ParsingTable";
        dt.Columns.Add(new DataColumn("colID", typeof(int)));
        dt.Columns.Add(new DataColumn("colString", typeof(string)));
        dt.Columns.Add(new DataColumn("colType", typeof(string)));
        dt.Columns.Add(new DataColumn("colToken", typeof(string)));
        dt.Columns.Add(new DataColumn("colKeterangan", typeof(string)));
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate   
        ViewState["ParsingTable"] = dt;
        //bind Gridview  
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    protected void AddNewRecordRowToGrid()
    {


        // check view state is not null  
        if (ViewState["ParsingTable"] != null)
        {
            //get datatable from view state   
            DataTable dtCurrentTable = (DataTable)ViewState["ParsingTable"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //add each row into data table  
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["colString"] = TextBox_InputString.Text;

                    drCurrentRow["colType"] = "";
                    drCurrentRow["colToken"] = "";
                    drCurrentRow["colKeterangan"] = "";


                }
                //menghapus initial 
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();


                }

                //membuat row ke data table
                dtCurrentTable.Rows.Add(drCurrentRow);
                //menyimpan data tabel ke view state setelah membuat setiap row
                ViewState["ParsingTable"] = dtCurrentTable;
                //Bind Gridview dengan row terakhir
                GridView1.DataSource = dtCurrentTable;
                GridView1.DataBind();

            }
        }


    }

    private void Clear()
    {
        try
        {
            

        }
        catch (DataException e)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.",
                e.GetType());
        }

    }

    public void Parsing()
    {
        int ci = 0;                   // membuat current integer(posisi karakter yang ditunjuk)
        char cc;                      // membuat current character
        
        bool notDead = true;         //membuat penanda dead state

        string input = TextBox_InputString.Text; // mendapatkan input string dari textbox
        



        int state = 0;  // memulai Finite State Machine
        string type = ""; // buat penyimpan tipe
        string tokens = ""; // buat penyimpan token
        cc = input[ci];
        while (ci <= input.Length && notDead)
        {
            // masuk state
            switch (state)
            {
                case 0:
                    if (cc == 'p' || cc == 'q' || cc == 'r' || cc == 's') { // preposisi
                        state = 1;
                    } else if (cc == 'n') { // not
                        state = 2;
                    } else if (cc == 'a'){ // and
                        state = 5;
                    } else if (cc == 'o'){ // or
                        state = 8;
                    } else if (cc == 'x'){ // xor
                        state = 10;
                    } else if (cc == 'i'){ // if dan iff
                        state = 13;
                    } else if (cc == 't'){ // then
                        state = 16;
                    } else if (cc == '('){ // (
                        state = 20;
                    }else if (cc == ')'){ // )
                        state = 21;
                    } else{
                        notDead = false;
                    }
                    break;

                case 1:
                    tokens += "1 ";
                    type += "Operand ";
                    if (cc == ' '){
                        state = 0;
                    } else {
                        notDead = false;
                    }
                    break;

                case 2:
                    if (cc == 'o'){
                        state = 3;
                    }else{
                        notDead = false;
                    }
                    break;

                case 3:
                    if (cc == 't')
                    {
                        state = 4;
                    }
                    else{
                        notDead = false;
                    }
                    break;

                case 4: // acc state 2
                        // tambah token 2
                    tokens += "2 ";
                    type += "Operator ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 5:
                    if (cc == 'n'){
                        state = 6;
                    }else{
                        notDead = false;
                    }
                    break;

                case 6:
                    if (cc == 'd'){
                        state = 7;
                    }else{
                        notDead = false;
                    }
                    break;

                case 7: // acc state 3
                        // tambah token 3
                    tokens += "3 ";
                    type += "Operator ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 8:
                    if (cc == 'r'){
                        state = 9;
                    }else{
                        notDead = false;
                    }
                    break;

                case 9: // acc state 4
                        // tambah token 4
                    tokens += "4 ";
                    type += "Operator ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 10:
                    if (cc == 'o'){
                        state = 11;
                    }else{
                        notDead = false;
                    }
                    break;

                case 11:
                    if (cc == 'r'){
                        state = 12;
                    }else{
                        notDead = false;
                    }
                    break;

                case 12: // acc state 5
                         // tambah token 5
                    tokens += "5 ";
                    type += "Operator ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 13:
                    if (cc == 'f'){
                        state = 14;
                    }else{
                        notDead = false;
                    }
                    break;

                case 14: // acc state 6
                         // tambah token 6
                    tokens += "6 ";
                    type += "Operator ";
                    if (cc == 'f'){
                        state = 15;
                    } else if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 15: // acc state 8
                         // hapus token sebelumnya
                    tokens = tokens.Substring(0, tokens.Length - 1);
                    // tambah token 8
                    tokens += "8 ";
                    type += "Operator ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 16:
                    if (cc == 'h'){
                        state = 17;
                    }else{
                        notDead = false;
                    }
                    break;

                case 17:
                    if (cc == 'e'){
                        state = 18;
                    }else{
                        notDead = false;
                    }
                    break;

                case 18:
                    if (cc == 'n'){
                        state = 19;    
                    }else{
                        notDead = false;
                    }
                    break;

                case 19: // acc state 7
                         // tambah token 7
                    tokens += "7 ";
                    type += "Operator ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 20: // acc state 9
                         // tambah token 9
                    tokens += "9 ";
                    type += "Grouping ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;

                case 21: // acc state 10
                         // tambah token 10
                    tokens += "10 ";
                    type += "Grouping ";
                    if (cc == ' '){
                        state = 0;
                    }else{
                        notDead = false;
                    }
                    break;
                }
            

            // baca char selanjutnya
            ci++;
            if (ci < input.Length)
            {
                cc = input[ci];
            }
            
        }


        // penanganan jika tidak sampai final state Output "error"
        if (state != 1 && state != 4 && state != 7 && state != 9 && state != 12 && state != 14
           && state != 15 && state != 19 && state != 20 && state != 21)
        {
            tokens += "Error ";
            type += "Error ";
        }


        // output yang dihasilkan
        //inputan.Text = (("Inputan               : ") + input + ("<br />"));
        //tipe.Text =    (("Tipe                  : ") + type + ("<br />"));
        //token.Text =   (("Token                 : ") + tokens + ("<br />"));


        //deklarasi parsing
        char[] delimiters = new char[] { ' ', '\n' };
        string[] substrings = Regex.Split(input, @" ");
        string[] subtype = type.Split(delimiters,
             StringSplitOptions.None);
        string[] subtoken = tokens.Split(delimiters,
             StringSplitOptions.None);

        //deklarasi tabel
        DataTable table = new DataTable();
        //DataColumn colID = table.Columns.Add("colID", typeof(int));
        DataColumn colString = table.Columns.Add("colString", typeof(string));
        DataColumn colType = table.Columns.Add("colType", typeof(string));
        DataColumn colToken = table.Columns.Add("colToken", typeof(string));
        DataColumn colKeterangan = table.Columns.Add("colKeterangan", typeof(string));

        //Menampilkan Ke Data Table
        for (int ctr = 0; ctr < subtoken.Length; ctr++)
        {
            DataRow row = table.NewRow();
             
            try
            {
                //row.SetField(colID)=
                row.SetField(colString, substrings[ctr]);
                row.SetField(colType, subtype[ctr]);
                row.SetField(colToken, subtoken[ctr]);
                row.SetField(colKeterangan, " ");

                if (ctr < subtoken.Length - 1)
                    table.Rows.Add(row);
            }
            catch (Exception)
            {
                row.SetField(colString, " ");
                row.SetField(colToken, " ");
                row.SetField(colType, " ");
            }

        }

        //Bind Gridview dengan row terakhir 
        AddDefaultFirstRecord();
        ViewState["ParsingTable"] = table;
        GridView1.DataSource = table;
        GridView1.DataBind();

    }


}


