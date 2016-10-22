<%@ Page Language="C#" CodeFile="Default.aspx.cs" Inherits="ParsingCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!=========================================================
=                   Tugas Besar                         =
=             Teori Bahasa & Automata                   =
=              Tugas Program Tahap 1                    =
=                                                       =
=                        Kelompok 11                    =
= Nama Anggota  :   1.	Arman Dwi Jatmiko	1103110196  =
=                   2.	Arief Luthfiyanto	1301168027  =
=                   3.	Arif Yulianto	    1301168560  =
=                                                       =
= Kelas         : IF 38-04                              =
=========================================================>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>TUBES TBA</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />  
    <link href="Content/StyleSheet.css" rel="stylesheet" />
    <style type="text/css">


        #footer {
            height: 35px;
        }


    </style>
    
</head>
    
<body>

    <form id="form1" runat="server">

    
        <div id="mainContainer" class="container">  
            <div class="shadowBox">  
                <div class="page-container">  
                    <div class="container">  
                        <div class="jumbotron">  
                            <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label1" runat="server" Font-Names="Segoe UI" style="text-align:center" Font-Size="X-Large" Font-Strikeout="False" Text="Tugas Program Tahap 1 | TBA"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Simple Parser for Proposition Logic Formula" Font-Names="Segoe UI"></asp:Label><br />
        <br />

    </div>
    
    
       <table id="table_input">
          <tr>
            <td class="auto-style1"> 
                <asp:Label ID="Label2" runat="server" Font-Names="Segoe UI" Font-Size="Medium" Text="Masukan String : "></asp:Label>
              </td>
            <td> 
                <div id="input[type="search"]">
                <asp:textbox id="TextBox_InputString" runat="server" style="margin-left: 0x" Width="130px"/>
                </div>
                    </td>
          </tr>
          <tr>
             <td class="auto-style1"></td>
              
             <td><asp:button id="Button_Parsing" text="Parsing" onclick="Parsing_OnClick" runat="server" Font-Names="Segoe UI" TabIndex="1"/></td>
             
          </tr>
          
       </table>
                        </div>  
                        <div class="row">  
                            <div class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" EmptyDataText="Tidak ada data yang ditampilkan">  
                                        <Columns>  
                                        <%--<asp:BoundField HeaderStyle-Width="120px" HeaderText="No." DataField="colID" />--%>
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="String" DataField="colString" />  
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Type" DataField="colType" />  
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Token" DataField="colToken" />  
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Keterangan" DataField="colKeterangan" />
                                        </Columns>
                                    </asp:GridView>  
                                </div>  
                            </div>  
                        </div>
                        </div>  
                    </div>  
                </div>  
            </div>  
            <asp:Label ID="inputan" runat="server" Text=""></asp:Label>
            <asp:Label ID="tipe" runat="server" Text=""></asp:Label>
            <asp:Label ID="token" runat="server" Text=""></asp:Label>
    </form>
           


</body>
        <div class ="panel-footer">
       &copy; Created by : Arief, Arman, Arif. | <asp:label ID="date" runat="server" text=""></asp:label>
    </div>
</html>
