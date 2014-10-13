<%@ Page Title="Artist2Dealer - Artists" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Artists.aspx.cs" Inherits="A2DWebRole1.Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style347 {
            width: 100%;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <div class="breadCrumbB">
        <span class="BonW">&nbsp;/&nbsp;ARTIST SEARCH</span>     
        
</div>  

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div align="center"> 


            <asp:Label ID="lblFilter" runat="server">
                <span class="Red">*</span>&nbsp;CLICK INSIDE A FILTER BOX TO VIEW ARTISTS
                <br />
            </asp:Label>
            
        <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">


            <table class="auto-style347">
                <tr>
                    <td style="width: 50%">
                        
                        <asp:Button ID="btnReset" runat="server" Text="Click here to clear the filters" OnClick="btnReset_Click" CssClass="button" />
            
                    </td>
                    <td style="text-align: right;">

                        <table class="table">
                            <tr>
                                <td colspan="3">
                                    Get email alerts for new <strong>&quot;<asp:Label ID="lblQueryResults" runat="server" />&quot;</strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 1px;">
                                    <asp:Label ID="lblFrequency" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblFrequency" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="daily" Text="Daily" />
                                        <asp:ListItem Value="weekly" Text="Weekly" />
                                    </asp:RadioButtonList>
                                </td>

                                <td>

                                    <asp:LoginView ID="LoginView1" runat="server">
                                        <AnonymousTemplate>
                                            <a href="Login">Login</a>
                                        </AnonymousTemplate>
                                        <LoggedInTemplate>
                                            <asp:Button ID="btnSubscribe" runat="server" CssClass="button" Text="Subscribe" OnClick="btnSubscribe_Click" />
                                        </LoggedInTemplate>
                                    </asp:LoginView>

                                </td>
                            </tr>
                        </table>
            

            
                    </td>
                </tr>
            </table>
    

            </asp:PlaceHolder>

                    
            
            <hr />

            

    <table style="width: 95%;">
        <tr>
            <td style="vertical-align: top; text-align: center; width: 20%;">
            <div class="categorySection">Artists by City</div>
            <div class="example">* Scroll and Click</div>

            <br />

                <asp:ListBox ID="lbxCity" runat="server" OnSelectedIndexChanged="lbxCity_SelectedIndexChanged" AutoPostBack="True" CssClass="textbox" Rows="10" />

            </td>
            <td style="vertical-align: top; text-align: center; width: 20%;">
            <div class="categorySection">Artists by Genre</div>
            <div class="example">* Scroll and Click</div>  
                <br />

                <asp:ListBox ID="lbxGenres" runat="server" OnSelectedIndexChanged="lbxGenres_SelectedIndexChanged" AutoPostBack="True" CssClass="textbox" Rows="10" />

            </td>
            <td style="vertical-align: top; text-align: center; width: 20%;">
            <div class="categorySection">Artists by Medium</div>
            <div class="example">* Scroll and Click</div>
                <br />

                <asp:ListBox ID="lbxMediums" runat="server" OnSelectedIndexChanged="lbxMediums_SelectedIndexChanged" CssClass="textbox" AutoPostBack="True" Rows="10" />

            </td>
            <td style="vertical-align: top; text-align: center; width: 20%;">
            <div class="categorySection">Artists by Style</div>
            <div class="example">* Scroll and Click</div>
                <br /> 

                <asp:ListBox ID="lbxStyles" runat="server" OnSelectedIndexChanged="lbxStyles_SelectedIndexChanged" CssClass="textbox" AutoPostBack="True" Rows="10" />

            </td>
            <td style="vertical-align: top; text-align: center; width: 20%;">
            <div class="categorySection">Visual Search</div>       
            <div class="example">* Enter a Keyword</div>
                <br />
                <table class="searchTBXWrap" style="width: 100%;">
                    <tr>
                        <td>
                            <asp:TextBox ID="tbxSearchKeywords" runat="server" CssClass="keywordTBX" />   
                        </td>
                        <td>
                            <asp:ImageButton ID="imgBtn_Keywords" runat="server" ImageUrl="Graphics/MagnifyingGlass.gif" OnClick="imgBtn_Keywords_Click" />
                        </td>
                    </tr>
                </table>

                <br />

                <div class="example">
                    * Artists names, bio info, artwork titles or visual descriptions.<br />
                    Ex: still life, realism, water...<br /><br />
                    * Try variations Ex: nude, nudes</div>

            </td>
        </tr>
    </table>
    

            <hr />
    


        <asp:Label ID="lblInfo" runat="server" />

      <br />

        <asp:ListView ID="lvKeywordsResults" runat="server" GroupItemCount="4" Visible="false">

            <LayoutTemplate>

                <table id="tblArtists" runat="server">
                    <tr runat="server" id="groupPlaceholder" />
                </table>
                
            </LayoutTemplate>

            <ItemTemplate>
                <td style="padding: 0px 25px 35px 25px; text-align: left; vertical-align: bottom;">

                    <div class="profile">
                        <a href="Artist.aspx?id=<%# Eval("ArtistID") %>">
                            <img src="http://artist2dealer.blob.core.windows.net/uploadedartworks/<%# Eval("ArtworkGUIDSmall") %>" alt="<%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %>" border="0" />
                            <br />
                            <%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %></a></div>
                    <div class="profileSM">
                        <%# Eval("City") %>
                    </div>

                </td>
            </ItemTemplate>

            <GroupTemplate>
                <tr runat="server" id="ContactsRow">
                    <td runat="server" id="itemPlaceholder" />
                </tr>
            </GroupTemplate>

            <ItemSeparatorTemplate>
                <td id="Td4" runat="server">&nbsp;</td>
            </ItemSeparatorTemplate>

        </asp:ListView>

        <asp:ListView ID="lvResults" runat="server" GroupItemCount="4">

            <LayoutTemplate>

                <table id="tblArtists" runat="server">
                    <tr runat="server" id="groupPlaceholder" />
                </table>
                
            </LayoutTemplate>

            <ItemTemplate>
                <td style="padding: 0px 25px 35px 25px; text-align: left; vertical-align: bottom;">

                    <div class="profile">
                        <a href="Artist.aspx?id=<%# Eval("ArtistID") %>">
                            <img src="http://artist2dealer.blob.core.windows.net/uploadedartworks/<%# Eval("ProfileArtworkGUIDSmall") %>" alt="<%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %>" border="0" />
                            <br />
                            <%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %></a></div>
                    <div class="profileSM">
                        <%# Eval("City") %>
                    </div>

                </td>
            </ItemTemplate>

            <GroupTemplate>
                <tr runat="server" id="ContactsRow">
                    <td runat="server" id="itemPlaceholder" />
                </tr>
            </GroupTemplate>

            <ItemSeparatorTemplate>
                <td id="Td4" runat="server">&nbsp;</td>
            </ItemSeparatorTemplate>

        </asp:ListView>

        
        </div>

    <div style="text-align: justify;">
        <asp:Label ID="lblMessage" runat="server" />
    </div>

</asp:Content>
