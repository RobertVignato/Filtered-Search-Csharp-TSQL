using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace A2DWebRole1
{
    public partial class Artists : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Email em = new Email();
        Utilities ut = new Utilities();

        #region - Accessors - 
        
        public string _IPAddress { get; set; }
        public string _SearchString { get; set; }

        public string _City { get; set; }

        public int _GenreID { get; set; }
        public string _Genre { get; set; }

        public int _MediumID { get; set; }
        public string _Medium { get; set; }

        public int _StyleID { get; set; }
        public string _Style { get; set; }

        public int _ArtistID { get; set; }
        public Guid _ArtistGUID { get; set; }

        public string _Frequency { get; set; }
        public string _QueryString { get; set; }
        public Guid _SavedSearchGUID { get; set; }
        public string _SearchType { get; set; }
        public Guid _UserGUID { get; set; }
        public string _UserName { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Bind_CitiesWithArtistsCount();
                this.Bind_Genres();
                this.Bind_Mediums();
                this.Bind_Styles();
                btnReset.Visible = false;
                lblFilter.Visible = true;
                lblMessage.Text = this.Info();
            }
        }

        private string Info()
        {
            string info = "Use the Artist Search feature to locate Artists and their Artwork by city, genre, medium, style or keyword.<br />" +
                "Website members have the ability to save their searches and receive automated notifications when similar Artists sign up.<br />" +
                "The Saved Search feature saves you (Dealers) time by automating the search for new Artists that fit your specific criteria(s).<br />" +
                "Let Artist2Dealer work for you!";
            return info;
        }
        
        public DataTable Get_Artists_TOPn_Rand()
        {
            DataTable dt = bl.Get_Artists_TOPn_Rand();
            return dt;
        }

        #region --- Binds ---

        private void Bind_CitiesWithArtistsCount()
        {
            DataTable dt = bl.Get_CitiesWithArtistsCount();
            string city = dt.Rows[0][0].ToString();
            string count = dt.Rows[0][1].ToString();
            lbxCity.DataSource = dt;
            lbxCity.DataValueField = "City";
            lbxCity.DataTextField = "Combo";
            lbxCity.DataBind();     
        }
        
        private void Bind_Genres()
        {
            DataTable dt = bl.Get_Artwork_Genres();
            lbxGenres.DataSource = dt;
            lbxGenres.DataValueField = "GenreID";
            lbxGenres.DataTextField = "Genre";
            lbxGenres.DataBind();
        }
        
        private void Bind_Mediums()
        {
            DataTable dt = bl.Get_Artwork_Mediums();
            lbxMediums.DataSource = dt;
            lbxMediums.DataValueField = "MediumID";
            lbxMediums.DataTextField = "Medium";
            lbxMediums.DataBind();
        }

        private void Bind_Styles()
        {
            DataTable dt = bl.Get_Artwork_Styles();
            lbxStyles.DataSource = dt;
            lbxStyles.DataValueField = "StyleID";
            lbxStyles.DataTextField = "Style";
            lbxStyles.DataBind();
        }



        private void Bind_Genres2()
        {
            DataTable dt = bl.Get_Genres();
            lbxGenres.DataSource = dt;
            lbxGenres.DataValueField = "GenreID";
            lbxGenres.DataTextField = "Genre";
            lbxGenres.DataBind();
        }

        private void Bind_GenresInCity(string city)
        {
            DataTable dt = bl.Get_GenresInCity(city);
            lbxGenres.DataSource = dt;
            lbxGenres.DataValueField = "GenreID";
            lbxGenres.DataTextField = "Genre";
            lbxGenres.DataBind();
        }


        private void Bind_Mediums2()
        {
            DataTable dt = bl.Get_Mediums();
            lbxMediums.DataSource = dt;
            lbxMediums.DataValueField = "MediumID";
            lbxMediums.DataTextField = "Medium";
            lbxMediums.DataBind();
        }

        private void Bind_MediumsInCity(string city)
        {
            DataTable dt = bl.Get_MediumsInCity(city);
            lbxMediums.DataSource = dt;
            lbxMediums.DataValueField = "MediumID";
            lbxMediums.DataTextField = "Medium";
            lbxMediums.DataBind();
        }


        private void Bind_Styles2()
        {
            DataTable dt = bl.Get_Styles();
            lbxStyles.DataSource = dt;
            lbxStyles.DataValueField = "StyleID";
            lbxStyles.DataTextField = "Style";
            lbxStyles.DataBind();
        }

        private void Bind_StylesInCity(string city)
        {
            DataTable dt = bl.Get_StylesInCity(city);
            lbxStyles.DataSource = dt;
            lbxStyles.DataValueField = "StyleID";
            lbxStyles.DataTextField = "Style";
            lbxStyles.DataBind();
        }

        #endregion


        #region --- SelectedIndexChanged ---

        protected void lbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInfo.Text = String.Empty;
            rblFrequency.SelectedIndex = -1;
            PlaceHolder1.Visible = true;
            _City = lbxCity.SelectedValue; ViewState["_City"] = _City;
            lblQueryResults.Text = _City;
            _SearchType = "City";
            this.Setup_SavedSearch(_City, _SearchType);

            DataTable dt = bl.Get_ArtistsInCity(_City);
            ViewState["SavedSearches"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table

            lvKeywordsResults.Visible = false;
            lvResults.Visible = true;
            lvResults.DataSource = dt;
            lvResults.DataBind();
            this.Bind_GenresInCity(_City);
            this.Bind_MediumsInCity(_City);
            this.Bind_StylesInCity(_City);
            btnReset.Visible = true;
            lblFilter.Visible = false;
        }

        protected void lbxGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInfo.Text = String.Empty;
            rblFrequency.SelectedIndex = -1;
            PlaceHolder1.Visible = true;
            lblFilter.Visible = false;
            btnReset.Visible = true;
            _GenreID = (int)Convert.ToInt32(lbxGenres.SelectedValue); //ViewState["_GenreID"] = _GenreID;

            // Get the GenreName and set _Genre
            _Genre = bl.Get_GenreName(_GenreID);
            lblQueryResults.Text = _Genre;
            _SearchType = "Genre";
            this.Setup_SavedSearch(_GenreID.ToString(), _SearchType);

            DataTable dt = new DataTable();
            if (lbxCity.SelectedIndex > 0)
            {
                dt = bl.Search_Artists_By_Genre(_GenreID, ViewState["_City"].ToString());
                ViewState["Artist_Filter_ArtistID"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            }
            else
            {
                dt = bl.Search_Artists_By_Genre(_GenreID);
                ViewState["Artist_Filter_ArtistID"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            }
            if (dt.Rows.Count > 0)
            {
                lvKeywordsResults.Visible = false;
                lvResults.Visible = true;
                lvResults.DataSource = dt;
                lvResults.DataBind();
            }
            else
            {
                lvKeywordsResults.Visible = false;
                lvResults.Visible = false;
                dt.Clear();
                lvResults.DataSource = dt;
                lvResults.DataBind();
            }

            for (int i = 0; i < lbxMediums.Items.Count; i++)
            {
                lbxMediums.Items[i].Selected = false;
            }
            for (int i = 0; i < lbxStyles.Items.Count; i++)
            {
                lbxStyles.Items[i].Selected = false;
            }
        }

        protected void lbxMediums_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInfo.Text = String.Empty;
            rblFrequency.SelectedIndex = -1;
            PlaceHolder1.Visible = true;
            lblFilter.Visible = false;
            btnReset.Visible = true;
            _MediumID = (int)Convert.ToInt32(lbxMediums.SelectedValue); //ViewState["_MediumID"] = _MediumID;

            // Get the MediumName and set _Medium
            _Medium = bl.Get_MediumName(_MediumID);
            lblQueryResults.Text = _Medium;
            _SearchType = "Medium";
            this.Setup_SavedSearch(_MediumID.ToString(), _SearchType);

            DataTable dt = new DataTable();
            if (lbxCity.SelectedIndex > 0)
            {
                dt = bl.Search_Artists_By_Medium(_MediumID, ViewState["_City"].ToString());
                ViewState["Artist_Filter_ArtistID"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            }
            else
            {
                dt = bl.Search_Artists_By_Medium(_MediumID);
                ViewState["Artist_Filter_ArtistID"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            }
            if (dt.Rows.Count > 0)
            {
                lvKeywordsResults.Visible = false;
                lvResults.Visible = true;
                lvResults.DataSource = dt;
                lvResults.DataBind();
            }
            else
            {
                lvKeywordsResults.Visible = false;
                lvResults.Visible = false;
                dt.Clear();
                lvResults.DataSource = dt;
                lvResults.DataBind();
            }

            for (int i = 0; i < lbxGenres.Items.Count; i++)
            {
                lbxGenres.Items[i].Selected = false;
            }
            for (int i = 0; i < lbxStyles.Items.Count; i++)
            {
                lbxStyles.Items[i].Selected = false;
            }
        }

        protected void lbxStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInfo.Text = String.Empty;
            rblFrequency.SelectedIndex = -1;
            PlaceHolder1.Visible = true;
            lblFilter.Visible = false;
            btnReset.Visible = true;
            _StyleID = (int)Convert.ToInt32(lbxStyles.SelectedValue); //ViewState["_StyleID"] = _StyleID;

            // Get the StyleName and set _Style
            _Style = bl.Get_StyleName(_StyleID);
            lblQueryResults.Text = _Style;
            _SearchType = "Style";
            this.Setup_SavedSearch(_StyleID.ToString(), _SearchType);

            DataTable dt = new DataTable();
            if (lbxCity.SelectedIndex > 0)
            {
                dt = bl.Search_Artists_By_Style(_StyleID, ViewState["_City"].ToString());
                ViewState["Artist_Filter_ArtistID"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            }
            else
            {
                dt = bl.Search_Artists_By_Style(_StyleID);
                ViewState["Artist_Filter_ArtistID"] = dt.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                ViewState["Artist_Filter_ArtistGUID"] = dt.Rows[0][5].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
            }
            if (dt.Rows.Count > 0)
            {
                lvKeywordsResults.Visible = false;
                lvResults.Visible = true;
                lvResults.DataSource = dt;
                lvResults.DataBind();
            }
            else
            {
                lvKeywordsResults.Visible = false;
                lvResults.Visible = false;
                dt.Clear();
                lvResults.DataSource = dt;
                lvResults.DataBind();
            }

            for (int i = 0; i < lbxMediums.Items.Count; i++)
            {
                lbxMediums.Items[i].Selected = false;
            }
            for (int i = 0; i < lbxGenres.Items.Count; i++)
            {
                lbxGenres.Items[i].Selected = false;
            }
        }

        #endregion




        //    protected void linkBtnFollowArtist_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    //    {
    //        //lblResults.Text = String.Format("_UserGUID: {0} _ArtistID: {1}", _UserGUID, e.CommandArgument.ToString()); // This is setup in Page_Load()

    //        _IPAddress = this.GetIpAddress();
    //        bool status0 = bl.Create_FollowArtist02(_UserGUID, _ArtistID, _IPAddress); // This is setup in Page_Load()

    //        #region - Turn Off Image and Link Button -

    //        ContentPlaceHolder cp = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder2");
    //        LoginView lv = (LoginView)cp.FindControl("LoginView1");
    //        LinkButton lb = (LinkButton)lv.FindControl("linkBtnFollowArtist");
    //        lb.Enabled = false;
    //        lb.Text = "You are now following this Artist!";
    //        ImageButton ib = (ImageButton)lv.FindControl("imgBtnFollowStar");
    //        ib.Visible = false;

    //        #endregion
            
    //    &nbsp;&nbsp;&nbsp;&nbsp;
        
    //    <asp:LoginView ID="LoginView1" runat="server">
    //        <AnonymousTemplate>
    //        </AnonymousTemplate>
    //        <LoggedInTemplate>
    //            <asp:ImageButton ID="imgBtnFollowStar" runat="server" ImageUrl="Graphics/BookmarkStar_Gold.jpg" />
    //            <asp:LinkButton ID="linkBtnFollowArtist" runat="server"             
    //            Text="Email me when New Artists match this Search"
    //            CausesValidation="False" 
    //            CssClass="favorite" 
    //            CommandName="Follow this Artist" 
    //            CommandArgument='<%# Eval("ArtistID") %>' 
    //            oncommand="linkBtnFollowArtist_Command" />
    //        </LoggedInTemplate>
    //</asp:LoginView>

    //    }


        protected void imgBtn_Keywords_Click(object sender, ImageClickEventArgs e)
        {
            lblInfo.Text = String.Empty;
            rblFrequency.SelectedIndex = -1;
            PlaceHolder1.Visible = true;
            btnReset.Visible = true;
            lblFilter.Visible = false;

            _SearchString = tbxSearchKeywords.Text;
            _SearchType = "Keyword";
            lblQueryResults.Text = _SearchString;
            this.Setup_SavedSearch(_SearchString, _SearchType);

            bool sqlInjectionTest = bl.TestSearchStringForSQLInjection(_SearchString); // Check input with Regex filter
            if (sqlInjectionTest)
            {
                // SQL Injection Detected
                lblInfo.Text = String.Empty;
                lblInfo.Text = String.Format("We apologize. There were no results for {0}", _SearchString);
                lblInfo.CssClass = "Red";

                #region -- Send Email to Admins --

                //em.To = ConfigurationManager.AppSettings["To_Administrator"].ToString();
                //em.From = ConfigurationManager.AppSettings["From_Administrator"].ToString();
                //em.Cc = ConfigurationManager.AppSettings["Cc_Administrator"].ToString();
                //em.Bcc = ConfigurationManager.AppSettings["Bcc_Administrator"].ToString();
                //em.IPAddress = this.GetIpAddress();
                //Uri TheWholeUrl = Request.Url;
                //em.Url = TheWholeUrl.ToString(); // Get the URL of the Webpage where the attack was attempted.
                //em.SearchString = _SearchString;
                //em.SendEmail_ToAdmins("SQLInjectionAttempt");

                em.TestEmail();

                #endregion
            }
            else
            {
                #region --- 11-04-13 mods ---

                DataTable dtTemp = new DataTable();
                DataColumn dcTemp0 = dtTemp.Columns.Add("ArtistID");
                DataColumn dcTemp1 = dtTemp.Columns.Add("LastName");
                DataColumn dcTemp2 = dtTemp.Columns.Add("FirstName");
                DataColumn dcTemp3 = dtTemp.Columns.Add("City");
                DataColumn dcTemp4 = dtTemp.Columns.Add("ProfileArtworkGUIDSmall");
                DataColumn dcTemp5 = dtTemp.Columns.Add("ArtworkGUIDSmall");
                DataColumn dcTemp6 = dtTemp.Columns.Add("UserGUID");

                DataTable dtComposite = new DataTable();
                dtComposite = dtTemp.Clone();

                char[] delimiters = new char[] { ',', '+', ' ', '-' }; // http://www.dotnetperls.com/split
                string[] words = _SearchString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

	            foreach (string word in words)
                {
                    dtTemp = bl.Search_Artworks_Keywords(word); // sp_ParamSearch_Keywords
                    DataView dvTemp = new DataView(dtTemp);
                    foreach (DataRowView row in dvTemp)
                    {
                        dtComposite.ImportRow(row.Row);
                    }
	            }

                if (dtComposite.Rows.Count > 0)
                {
                    ViewState["SavedSearches"] = dtComposite.Rows[0][0].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table
                    ViewState["Artist_Filter_ArtistGUID"] = dtComposite.Rows[0][6].ToString(); // This is just used to pre-populate the SavedSearches_JobHistory Table

                    lvResults.Visible = false;

                    lvKeywordsResults.Visible = true;
                    lvKeywordsResults.DataSource = dtComposite;
                    lvKeywordsResults.DataBind();
                }
                else
                {
                    lvResults.Visible = false;
                    lvKeywordsResults.Visible = false;

                    dtComposite.Clear();
                    lvKeywordsResults.DataSource = dtComposite;
                    lvKeywordsResults.DataBind();

                    lblInfo.Text = "<br />Sorry... There are no results for that." +
                        "<br /><br />Try a variation on your keyword(s) Example: \"nude\" insted of \"nudes\"" +
                    "<br /><br />* If you would like A2D to continue searching for you, " + 
                    "login and use the \"Saved Searches\" feature above for either \"Daily\" or \"Weekly\" notifications that match this criteria.";
                }

                #endregion

            }
        }



        public string GetIpAddress()
        {
            string strIpAddress;
            strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                strIpAddress = HttpContext.Current.Request.UserHostAddress;
            }
            return strIpAddress;
        }

        //protected void LinkBtnReset_Click(object sender, EventArgs e)
        //{
        //    //<asp:LinkButton ID="LinkBtnReset" runat="server" OnClick="LinkBtnReset_Click">Click here to clear the filters</asp:LinkButton>
        //}

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblFilter.Visible = false;
            lbxCity.SelectedIndex = -1;
            lbxMediums.SelectedIndex = -1;
            lbxStyles.SelectedIndex = -1;
            lbxGenres.SelectedIndex = -1;
            tbxSearchKeywords.Text = String.Empty;

            this.Bind_CitiesWithArtistsCount();
            this.Bind_Genres();
            this.Bind_Mediums();
            this.Bind_Styles();

            lvResults.Visible = false;
            lvKeywordsResults.Visible = false;
            btnReset.Visible = false;
            PlaceHolder1.Visible = false;
        }


        private void Setup_SavedSearch(string queryString, string type)
        {
            // Display in Form
            _QueryString = queryString;
            ViewState["Artist_Filter_QueryString"] = _QueryString;
            _SearchType = type;
            ViewState["Artist_Filter_SearchType"] = _SearchType; // City, Genre, Medium, Style, Keyword
        }


        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            lblInfo.Text = String.Empty;
            this.ValidateSavedSearch();
        }



        private void ValidateSavedSearch()
        {
            _IPAddress = this.GetIpAddress();
            _QueryString = ViewState["Artist_Filter_QueryString"].ToString();
            _SavedSearchGUID = Guid.NewGuid();
            _SearchType = ViewState["Artist_Filter_SearchType"].ToString();
            _ArtistID = (int)Convert.ToInt64(ViewState["SavedSearches"].ToString()); // This is just used to pre-populate the SavedSearches_JobHistory Table
            _ArtistGUID = new Guid(ViewState["Artist_Filter_ArtistGUID"].ToString()); // This is just used to pre-populate the SavedSearches_JobHistory Table

            MembershipUser myObject = Membership.GetUser();
            _UserGUID = (Guid)myObject.ProviderUserKey;
            _UserName = myObject.UserName.ToLower();

            bool status0;
            bool status1;
            bool status2;
            int count = 0;

            #region - Form Validation -

            #region - rblFrequency -

            if (rblFrequency.SelectedIndex == -1)
            {
                lblFrequency.Text = "*";
                lblFrequency.CssClass = "Red";
                lblInfo.Text = "Please select either &quot;Daily&quot;  or  &quot;Weekly&quot; notifications";
                lblInfo.CssClass = "Red";
            }
            else
            {
                _Frequency = rblFrequency.SelectedValue.ToString();
                count++;
                lblFrequency.Text = String.Empty;
                lblFrequency.CssClass = String.Empty;
                lblInfo.Text = String.Empty;
                lblInfo.CssClass = String.Empty;
            }

            #endregion

            if (count > 0) status0 = true;
            else
            {
                status0 = false;
                //lblResults.Text = "status0 = false"; // For testing
            }

            #endregion

            #region - (status0) -

            if (status0) // The Form entries are OK. Go ahead and process
            {
                var statusMessage = String.Empty;

                #region - Add to "SavedSearch" Azure Table - NBU -

                // Not using this because down the line I need to query Artists that anre NOT IN the history table.

                //try
                //{
                //    //_Frequency = ViewState["Artist_Filter_Frequency"].ToString(); // Set above
                //    _IPAddress = this.GetIpAddress();
                //    _QueryString = ViewState["Artist_Filter_QueryString"].ToString();
                //    _SavedSearchGUID = Guid.NewGuid();
                //    _SearchType = ViewState["Artist_Filter_SearchType"].ToString();

                //    MembershipUser myObject = Membership.GetUser();
                //    _UserGUID = (Guid)myObject.ProviderUserKey;
                //    _UserName = myObject.UserName.ToLower();


                //    var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                //    var context = new SavedSearchDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);
                //    context.AddSavedSearch(
                //        _Frequency
                //        , _IPAddress
                //        , _QueryString
                //        , _SavedSearchGUID
                //        , _SearchType
                //        , _UserGUID
                //        , _UserName
                //        );

                //    status1 = true;
                //}
                //catch (System.Data.Services.Client.DataServiceRequestException ex)
                //{
                //    statusMessage = "Unable to connect to the table service. Please check that the service is running.<br />"
                //                        + ex.Message;
                //    status1 = false;
                //}
                //finally
                //{
                //}
                //if (status1)
                //{
                //    lblInfo.Text = "This Alert has been scheduled and A2D will send you an email when we find a match.<br />" +
                //                   "<a href=\"My-Account\">Click here to manage your alerts.</a>" +
                //                   "*** Make sure to check your spam folder periodically ***";
                //    lblInfo.CssClass = "Green";
                //}
                //else
                //{
                //    lblInfo.Text = "Something in A2D broke. <a href=\"Contact\">Click and tell us we blew it.</a>";
                //    lblInfo.CssClass = "Red";
                //}

                #endregion

                #region - Add to "SavedSearch" SQL Tables -

                status1 = bl.Create_SavedSearch(
                            _Frequency
                            , _IPAddress
                            , _QueryString // City: "San Francisco", Genre: <GenreID>, Keyword: "Water"
                            , _SavedSearchGUID
                            , _SearchType
                            , _UserGUID
                            , _UserName
                            );

                if (status1)
                {
                    status2 = bl.Create_SavedSearch_JobHistory(
                                _ArtistID
                                , _ArtistGUID
                                , _Frequency
                                , _QueryString // City: "San Francisco", Genre: <GenreID>, Keyword: "Water"
                                , _SavedSearchGUID
                                , _SearchType
                                , _UserGUID
                                , _UserName
                                );

                    if (status2)
                    {
                        lblInfo.Text = "This Alert has been scheduled and A2D will send you an email when we find a match.<br />" +
                                       "<a href=\"SavedSearches\">Click here to manage your alerts.</a>" +
                                       "*** Make sure to check your spam folder periodically ***";
                        lblInfo.CssClass = "Green";
                    }
                    else
                    {
                        lblInfo.Text = "Something in A2D broke (Error #672). <a href=\"Contact\">Click and tell us that we blew it.</a>";
                        lblInfo.CssClass = "Red";
                    }
                }
                else
                {
                    lblInfo.Text = "Something in A2D broke (Error #678). <a href=\"Contact\">Click and tell us that we blew it.</a>";
                    lblInfo.CssClass = "Red";
                }

                #endregion
            }
            else
            {
                //lblResults.Text += "<br />(status0) else - The form is bad " + DateTime.Now.ToString();
            }

            #endregion
        }


    }
}