using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace A2DWebRole1
{
    public class BusinessLogic
    {

        #region - CREATE - 
        
        
        internal bool Create_SavedSearch_JobHistory(
                    int ArtistID
                    , Guid ArtistGUID
                    , string Frequency
                    , string QueryString
                    , Guid SavedSearchGUID
                    , string SearchType
                    , Guid UserGUID
                    , string UserName
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO [SavedSearches_JobHistory] " +
                                    "(" +
                                      "[ArtistID] " +
                                      ", [ArtistGUID] " +
                                      ", [Frequency] " +
                                      ", [QueryString] " +
                                      ", [SavedSearchGUID] " +
                                      ", [SearchType] " +
                                      ", [UserGUID] " +
                                      ", [UserName] " +
                                    ") " +
                                "VALUES " +
                                    "(" +
                                       "@ArtistID " +
                                       ", @ArtistGUID " +
                                       ", @Frequency " +
                                       ", @QueryString " +
                                       ", @SavedSearchGUID " +
                                       ", @SearchType " +
                                       ", @UserGUID " +
                                       ", @UserName " +
                                    ")";
            #endregion

            #region --- Parameters ---
            
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ArtistGUID", ArtistGUID);
            cmd.Parameters.AddWithValue("@Frequency", Frequency);
            cmd.Parameters.AddWithValue("@QueryString", QueryString);
            cmd.Parameters.AddWithValue("@SavedSearchGUID", SavedSearchGUID);
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }


        internal bool Create_SavedSearch(
                    string Frequency
                    , string IPAddress
                    , string QueryString
                    , Guid SavedSearchGUID
                    , string SearchType
                    , Guid UserGUID
                    , string UserName
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO [SavedSearches] " +
                                    "(" +
                                       "[Frequency] " +
                                       ",[IPAddress] " +
                                       ",[QueryString] " +
                                       ",[SavedSearchGUID] " +
                                       ",[SearchType] " +
                                       ",[UserGUID] " +
                                       ",[UserName] " +
                                    ") " +
                                "VALUES " +
                                    "(" +
                                       "@Frequency " +
                                       ",@IPAddress " +
                                       ",@QueryString " +
                                       ",@SavedSearchGUID " +
                                       ",@SearchType " +
                                       ",@UserGUID " +
                                       ",@UserName " +
                                    ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@Frequency", Frequency);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.Parameters.AddWithValue("@QueryString", QueryString);
            cmd.Parameters.AddWithValue("@SavedSearchGUID", SavedSearchGUID);
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }


        


        internal bool Create_QNA_Dealer_Answer(
                                Guid UserGUID
                                , int DealerID
                                , int QuestionID
                                , int AnswerID
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO [QNA_Dealer_Answers] " +
                                    "(" +
                                       "[UserGUID] " +
                                       ",[DealerID] " +
                                       ",[QuestionID] " +
                                       ",[AnswerID] " +
                                    ") " +
                                "VALUES " +
                                    "(" +
                                       "@UserGUID " +
                                       ",@DealerID " +
                                       ",@QuestionID " +
                                       ",@AnswerID " +
                                    ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@DealerID", DealerID);
            cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
            cmd.Parameters.AddWithValue("@AnswerID", AnswerID);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        
        internal bool Create_QNA_Artist_Answer(
                                Guid UserGUID
                                , int ArtistID
                                , int QuestionID
                                , int AnswerID
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO [QNA_Artist_Answers] " +
                                    "(" +
                                       "[UserGUID] " +
                                       ",[ArtistID] " +
                                       ",[QuestionID] " +
                                       ",[AnswerID] " +
                                    ") " +
                                "VALUES " +
                                    "(" +
                                       "@UserGUID " +
                                       ",@ArtistID " +
                                       ",@QuestionID " +
                                       ",@AnswerID " +
                                    ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
            cmd.Parameters.AddWithValue("@AnswerID", AnswerID);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }





        
        internal bool Create_User_Dealer(
                                string DealerName
                                , string Address01
                                //, string Address02
                                , string City
                                , string State
                                , string PostalCode
                                , string Country
                                , string Phone01
                                , string Email
                                , string IPAddress
                                , Guid UserGUID
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO [Dealers] " +
                                    "(" +
                                       "[DealerName] " +
                                       ",[Address01] " +
                                       //",[Address02] " +
                                       ",[City] " +
                                       ",[State] " +
                                       ",[PostalCode] " +
                                       ",[Country] " +
                                       ",[Phone01] " +
                                       ",[Email] " +
                                       ",[IPAddress] " +
                                       ",[UserGUID] " +
                                    ") " +
                                "VALUES " +
                                    "(" +
                                       "@DealerName " +
                                       ",@Address01 " +
                                       //",@Address02 " +
                                       ",@City " +
                                       ",@State " +
                                       ",@PostalCode " +
                                       ",@Country " +
                                       ",@Phone01 " +
                                       ",@Email " +
                                       ",@IPAddress " +
                                       ",@UserGUID " +
                                    ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@DealerName", DealerName);
            cmd.Parameters.AddWithValue("@Address01", Address01);
            //cmd.Parameters.AddWithValue("@Address02", Address02);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Phone01", Phone01);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        internal bool Create_User_Artist(
            string LastName
            , string FirstName
            , string City
            , string Country
            , string IPAddress
            , string Gender
            , string Birthdate
            , string Email
            , Guid UserGUID
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO [Artists] " +
                                    "(" +
                                        "[LastName]" +
                                        ", [FirstName]" +
                                        ", [City]" +
                                        ", [Country]" +
                                        ", [IPAddress]" +
                                        ", [Gender]" +
                                        ", [Birthdate]" +
                                        ", [Email]" +
                                        ", [UserGUID]" +
                                    ") " +
                                "VALUES " +
                                    "(" +
                                        "@LastName" +
                                        ", @FirstName" +
                                        ", @City " +
                                        ", @Country " +
                                        ", @IPAddress" +
                                        ", @Gender" +
                                        ", @Birthdate" +
                                        ", @Email" +
                                        ", @UserGUID" +
                                    ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Birthdate", Birthdate);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        internal bool Create_Artwork(
            int ArtistID
            , string Title
            , string Description
            , int MediumID
            , string Year
            , string IPAddress
            , Guid ArtworkGUIDXSmall
            , Guid ArtworkGUIDSmall
            , Guid ArtworkGUIDMedium
            , Guid ArtworkGUIDLarge
            , Guid UserGUID
            , int StyleID
            , int GenreID
            , string Height_Feet
            , string Height_Inches
            , string Width_Feet
            , string Width_Inches
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Artworks " +
                                "(" +
                                "[ArtistID] " +
                                ",[Title] " +
                                ",[Description] " +
                                ",[MediumID] " +
                                ",[Year] " +
                                ",[IPAddress] " +
                                ",[ArtworkGUIDXSmall]" +
                                ",[ArtworkGUIDSmall]" +
                                ",[ArtworkGUIDMedium]" +
                                ",[ArtworkGUIDLarge]" +
                                ",[UserGUID]" +
                                ",[StyleID]" +
                                ",[GenreID]" +
                                ",[Height_Feet]" +
                                ",[Height_Inches]" +
                                ",[Width_Feet]" +
                                ",[Width_Inches]" +
                                ") " +
                                "VALUES " +
                                "(" +
                                "@ArtistID " +
                                ",@Title " +
                                ",@Description " +
                                ",@MediumID " +
                                ",@Year " +
                                ",@IPAddress " +
                                ",@ArtworkGUIDXSmall " +
                                ",@ArtworkGUIDSmall " +
                                ",@ArtworkGUIDMedium " +
                                ",@ArtworkGUIDLarge " +
                                ",@UserGUID " +
                                ",@StyleID " +
                                ",@GenreID " +
                                ",@Height_Feet " +
                                ",@Height_Inches " +
                                ",@Width_Feet " +
                                ",@Width_Inches " +
                            ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.Parameters.AddWithValue("@ArtworkGUIDXSmall", ArtworkGUIDXSmall);
            cmd.Parameters.AddWithValue("@ArtworkGUIDSmall", ArtworkGUIDSmall);
            cmd.Parameters.AddWithValue("@ArtworkGUIDMedium", ArtworkGUIDMedium);
            cmd.Parameters.AddWithValue("@ArtworkGUIDLarge", ArtworkGUIDLarge);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            cmd.Parameters.AddWithValue("@Height_Feet", Height_Feet);
            cmd.Parameters.AddWithValue("@Height_Inches", Height_Inches);
            cmd.Parameters.AddWithValue("@Width_Feet", Width_Feet);
            cmd.Parameters.AddWithValue("@Width_Inches", Width_Inches);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        // Inches Only
        internal bool Create_Artwork_v02(
            int ArtistID
            , string Title
            , string Description
            , int MediumID
            , string Year
            , string IPAddress
            , Guid ArtworkGUIDXSmall
            , Guid ArtworkGUIDSmall
            , Guid ArtworkGUIDMedium
            , Guid ArtworkGUIDLarge
            , Guid UserGUID
            , int StyleID
            , int GenreID
            , string Height_Inches
            , string Width_Inches
            )
        {
            bool status;

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Artworks " +
                                "(" +
                                "[ArtistID] " +
                                ",[Title] " +
                                ",[Description] " +
                                ",[MediumID] " +
                                ",[Year] " +
                                ",[IPAddress] " +
                                ",[ArtworkGUIDXSmall]" +
                                ",[ArtworkGUIDSmall]" +
                                ",[ArtworkGUIDMedium]" +
                                ",[ArtworkGUIDLarge]" +
                                ",[UserGUID]" +
                                ",[StyleID]" +
                                ",[GenreID]" +
                                ",[Height_Inches]" +
                                ",[Width_Inches]" +
                                ") " +
                                "VALUES " +
                                "(" +
                                "@ArtistID " +
                                ",@Title " +
                                ",@Description " +
                                ",@MediumID " +
                                ",@Year " +
                                ",@IPAddress " +
                                ",@ArtworkGUIDXSmall " +
                                ",@ArtworkGUIDSmall " +
                                ",@ArtworkGUIDMedium " +
                                ",@ArtworkGUIDLarge " +
                                ",@UserGUID " +
                                ",@StyleID " +
                                ",@GenreID " +
                                ",@Height_Inches " +
                                ",@Width_Inches " +
                            ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.Parameters.AddWithValue("@ArtworkGUIDXSmall", ArtworkGUIDXSmall);
            cmd.Parameters.AddWithValue("@ArtworkGUIDSmall", ArtworkGUIDSmall);
            cmd.Parameters.AddWithValue("@ArtworkGUIDMedium", ArtworkGUIDMedium);
            cmd.Parameters.AddWithValue("@ArtworkGUIDLarge", ArtworkGUIDLarge);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            cmd.Parameters.AddWithValue("@Height_Inches", Height_Inches);
            cmd.Parameters.AddWithValue("@Width_Inches", Width_Inches);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        internal bool Create_FollowArtist01(Guid UserGUID, int ArtistID, string IPAddress)
        {
            bool status;

            // Do a SELECT to see if this relationship already exists. 
            // If it does, the prevent the INSERT and still return status=true

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Notebook " +
                                "(" +
                                "[UserGUID] " +
                                ",[ArtistID]" +
                                ",[IPAddress] " +
                                ") " +
                                "VALUES " +
                                "(" +
                                "@UserGUID " +
                                ",@ArtistID" +
                                ",@IPAddress" +
                                ")";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        internal bool Create_FollowArtist(Guid UserGUID, int ArtistID, string IPAddress)
        {
            bool status;

            // Do a SELECT to see if this relationship already exists. 
            // If it does, the prevent the INSERT and still return status=true

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_Follow_Artist", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        internal bool Create_FollowDealer(Guid UserGUID, int DealerID, string IPAddress)
        {
            bool status;

            // Do a SELECT to see if this relationship already exists. 
            // If it does, the prevent the INSERT and still return status=true

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_Follow_Dealer", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@DealerID", DealerID);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

            #endregion

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        #endregion




        #region - READ - 

        

        #region --- Saved Search Processing ---

        internal DataTable Get_SavedSearches_DT()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[SSID] " +
                ",[CreatedOn] " +
                ",[Frequency] " +
                ",[IPAddress] " +
                ",[IsActive] " +
                ",[QueryString] " +
                ",[SavedSearchGUID] " +
                ",[SearchType] " +
                ",[UserGUID] " +
                ",[UserName] " +
                "FROM [dbo].[SavedSearches]";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        //internal DataTable Get_SavedSearchParams(Guid savedSearchGUID)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = AppConfig.DbConnectionString;
        //    SqlCommand cmd = cn.CreateCommand();
        //    cmd.CommandText = "SELECT " +
        //        "[SSID] " +
        //        ",[CreatedOn] " +
        //        ",[Frequency] " +
        //        ",[IPAddress] " +
        //        ",[IsActive] " +
        //        ",[QueryString] " +
        //        ",[SavedSearchGUID] " +
        //        ",[SearchType] " +
        //        ",[UserGUID] " +
        //        ",[UserName] " +
        //        "FROM [dbo].[SavedSearches] " +
        //        "WHERE (SavedSearchGUID = @SavedSearchGUID)";
        //    cmd.Parameters.AddWithValue("@SavedSearchGUID", savedSearchGUID);
        //    DataTable table = DataAccess.ExecuteSelectCommand(cmd);
        //    return table;
        //}

        internal DateTime Get_LastProcessedOn(Guid SavedSearchGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT TOP(1) " +
                "CreatedOn " +
                "FROM SavedSearches_JobHistory " +
                "WHERE SavedSearchGUID = @SavedSearchGUID " +
                "ORDER BY SSJHID DESC";
            cmd.Parameters.AddWithValue("@SavedSearchGUID", SavedSearchGUID);
            cn.Open();
            DateTime retVal = (DateTime)cmd.ExecuteScalar();
            //string retValSpacesStripped = StripSpaces(retVal);
            cn.Close();
            //return retValSpacesStripped;
            return retVal;
        }

        internal DataTable Get_SavedSearches_ForUserGUID(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[SSID] " +
                ",[CreatedOn] " +
                ",[Frequency] " +
                ",[IPAddress] " +
                ",[IsActive] " +
                ",[QueryString] " +
                ",[SavedSearchGUID] " +
                ",[SearchType] " +
                ",[UserGUID] " +
                ",[UserName] " +
                "FROM [dbo].[SavedSearches] " +
                "WHERE (UserGUID = @UserGUID)";
            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        #endregion


        #region - Filtering -


        internal DataTable Get_CitiesWithArtistsCount()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_ArtistFilter_Cities", cn); // Change to v03 after IsAcctSetupComplate is deployed
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        // Get all Genres
        internal DataTable Get_Genres()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                //"Artists.ArtistID " +
                //", Artists.City , " +
                "Artwork_Genres.GenreID " +
                ", Artwork_Genres.Genre " +
                "FROM Artwork_Genres " +
                "INNER JOIN Artworks ON Artwork_Genres.GenreID = Artworks.GenreID " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "ORDER BY (Artwork_Genres.Genre)";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        // Get all Genres in a given City
        internal DataTable Get_GenresInCity(string City)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                //"Artists.ArtistID " +
                //", Artists.City , " +
                "Artwork_Genres.GenreID " +
                ", Artwork_Genres.Genre " +
                "FROM Artwork_Genres " +
                "INNER JOIN Artworks ON Artwork_Genres.GenreID = Artworks.GenreID " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artists.City = @City) " +
                "ORDER BY (Artwork_Genres.Genre)";
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }



        // Get all Mediums
        internal DataTable Get_Mediums()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                //"Artists.ArtistID " +
                //", Artists.City , " +
                "Artwork_Mediums.MediumID " +
                ", Artwork_Mediums.Medium " +
                "FROM Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID INNER JOIN " +
                "Artwork_Mediums ON Artworks.MediumID = Artwork_Mediums.MediumID " +
                "ORDER BY (Artwork_Mediums.Medium)";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        // Get all Mediums in a given City
        internal DataTable Get_MediumsInCity(string City)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                //"Artists.ArtistID " +
                //", Artists.City , " +
                "Artwork_Mediums.MediumID " +
                ", Artwork_Mediums.Medium " +
                "FROM Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID INNER JOIN " +
                "Artwork_Mediums ON Artworks.MediumID = Artwork_Mediums.MediumID " +
                "WHERE (Artists.City = @City) " +
                "ORDER BY (Artwork_Mediums.Medium)";
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        // Get all Styles
        internal DataTable Get_Styles()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                //"Artists.ArtistID " +
                //", Artists.City , " +
                "Artwork_Styles.StyleID " +
                ", Artwork_Styles.Style " +
                "FROM  Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID INNER JOIN " +
                "Artwork_Styles ON Artworks.StyleID = Artwork_Styles.StyleID " +
                "ORDER BY (Artwork_Styles.Style)";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        // Get all Styles in a given City
        internal DataTable Get_StylesInCity(string City)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                //"Artists.ArtistID " +
                //", Artists.City , " +
                "Artwork_Styles.StyleID " +
                ", Artwork_Styles.Style " +
                "FROM  Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID INNER JOIN " +
                "Artwork_Styles ON Artworks.StyleID = Artwork_Styles.StyleID " +
                "WHERE (Artists.City = @City) " +
                "ORDER BY (Artwork_Styles.Style)";
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        // Bind the ListView after Clicking a City using "Get_CitiesWithArtistsCount()" above
        internal DataTable Get_ArtistsInCity(string City)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "ArtistID " +
                ", LastName " +
                ", FirstName " +
                ", City " +
                ", ProfileArtworkGUIDSmall " +
                ", UserGUID " +
                "FROM Artists " +
                "WHERE (City = @City) " +
                "AND (IsAcctSetupComplete = 1) " +
                "AND (IsProfileUploadImage = 1) " +
                "ORDER BY NEWID()";
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }



        #endregion


        #region - Resources - 

        
        internal DataTable Get_Resource(string ResourceType)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ResourceID] " +
                ",[ResourceType] " +
                ",[ResourceName] " +
                ",[Description] " +
                ",[Address01] " +
                ",[Address02] " +
                ",[City] " +
                ",[State] " +
                ",[PostalCode] " +
                ",[Country] " +
                ",[Phone01] " +
                ",[Email] " +
                ",[WebsiteURL] " +
                "FROM [dbo].[Resources] " +
                "WHERE (ResourceType = @ResourceType) " +
                "AND IsActive = 1 " +
                "AND IsLocked = 0 " +
                "AND IsBanned = 0";
            cmd.Parameters.AddWithValue("@ResourceType", ResourceType);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }
        

        #endregion

        internal DataTable Get_Forums()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "ForumID " +
                ", ForumName " +
                "FROM Forums " +
                "WHERE IsActive = 1 " +
                "AND IsVisible = 1 " +
                "ORDER BY ForumName";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Topics(int ForumID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "Forums.ForumID " + // 0
                ", Forums.ForumGUID " + // 1
                ", Forums.ForumName " + // 2
                ", Topics.TopicID " + // 3
                ", Topics.TopicGUID " + // 4 
                ", Topics.TopicName " + // 5
                "FROM Forums  " +
                "INNER JOIN Topics ON Forums.ForumID = Topics.ForumID " +
                "WHERE (Topics.IsActive = 1)  " +
                "AND (Topics.IsVisible = 1)  " +
                "AND (Forums.IsActive = 1)  " +
                "AND (Forums.IsVisible = 1)  " +
                "AND (Forums.ForumID = @ForumID) " +
                "ORDER BY Topics.TopicName";

            cmd.Parameters.AddWithValue("@ForumID", ForumID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Topic(string TopicGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "TopicID " +
                ", TopicGUID " + 
                ", TopicName " + 
                "FROM Topics " +
                "WHERE (TopicGUID = @TopicGUID)";

            cmd.Parameters.AddWithValue("@TopicGUID", TopicGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Forums(int ForumID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "ForumID " +
                ", ForumName " +
                "FROM Forums";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        
        internal DataTable Get_Featured_Artist()
        {
            int artistID = (int)Convert.ToInt32(ConfigurationManager.AppSettings["FeaturedArtistID"]);
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                " [ArtistID] " +
                ",[LastName] " +
                ",[FirstName] " +
                ",[City] " +
                ",[ArtistBio] " +
                ",[ProfileArtworkGUIDSmall] " +
                ",[ProfileArtworkGUIDMedium] " +
                "FROM Artists WHERE ArtistID = @ArtistID";

            cmd.Parameters.AddWithValue("@ArtistID", artistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Matches_For_Dealer(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "Dealers.DealerID " +
                ", Dealers.DealerName " +
                ", Dealers.City AS DealerCity " +
                ", Dealers.UserGUID " +
                ", Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City AS ArtistCity " +
                ", QNA_Matches.CreatedOn " +
                "FROM QNA_Matches " +
                "INNER JOIN Dealers ON QNA_Matches.DealerID = Dealers.DealerID  " +
                "INNER JOIN Artists ON QNA_Matches.ArtistID = Artists.ArtistID " +
                "WHERE (Dealers.UserGUID = @UserGUID) " +
                "ORDER BY QNA_Matches.MatchID DESC";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Get_Matches_For_Artist(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City AS ArtistCity " +
                ", Artists.UserGUID " +
                ", Dealers.DealerID " +
                ", Dealers.DealerName " +
                ", Dealers.City AS DealerCity " +
                ", QNA_Matches.CreatedOn " +
                "FROM QNA_Matches " +
                "INNER JOIN Dealers ON QNA_Matches.DealerID = Dealers.DealerID " +
                "INNER JOIN Artists ON QNA_Matches.ArtistID = Artists.ArtistID " +
                "WHERE (Artists.UserGUID = @UserGUID) " +
                "ORDER BY QNA_Matches.MatchID DESC";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }





        internal String Get_GenreName(int GenreID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "Genre " +
                "FROM Artwork_Genres " +
                "WHERE (GenreID = @GenreID)";
            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            cn.Open();
            string gender = (string)cmd.ExecuteScalar();
            string genderSpacesStripped = StripSpaces(gender);
            cn.Close();
            return genderSpacesStripped;
        }

        internal String Get_MediumName(int MediumID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "Medium " +
                "FROM Artwork_Mediums " +
                "WHERE (MediumID = @MediumID)";
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            cn.Open();
            string gender = (string)cmd.ExecuteScalar();
            string genderSpacesStripped = StripSpaces(gender);
            cn.Close();
            return genderSpacesStripped;
        }

        internal String Get_StyleName(int StyleID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "Style " +
                "FROM Artwork_Styles " +
                "WHERE (StyleID = @StyleID)";
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            cn.Open();
            string gender = (string)cmd.ExecuteScalar();
            string genderSpacesStripped = StripSpaces(gender);
            cn.Close();
            return genderSpacesStripped;
        }



        internal DataTable Get_Genres_All()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "GenreID, Genre " +
                "FROM Artwork_Genres " +
                "WHERE (IsVisible = 1) " +
                "ORDER BY Genre";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Mediums_All()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "MediumID, Medium " +
                "FROM Artwork_Mediums " +
                "WHERE (IsVisible = 1) " +
                "ORDER BY Medium";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Styles_All()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "StyleID, Style " +
                "FROM Artwork_Styles " +
                "WHERE (IsVisible = 1) " +
                "ORDER BY Style";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }




        internal DataTable Get_ArtistsIAmFollowing(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.Country " +
                ", Artists.ProfileArtworkGUIDSmall " +
                "FROM Follows " +
                "INNER JOIN Artists ON Follows.ArtistID = Artists.ArtistID " +
                "WHERE (Follows.UserGUID = @UserGUID)";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_DealersIAmFollowing(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "Dealers.DealerID " +
                ", Dealers.DealerName " +
                ", Dealers.City " +
                ", Dealers.Country " +
                "FROM Follows " +
                "INNER JOIN Dealers ON Follows.DealerID = Dealers.DealerID " +
                "WHERE (Follows.UserGUID = @UserGUID)";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }





        internal DataTable Get_ArtistsFollowingMe_Artist(int ArtistID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_Get_ArtistsFollowingMe_Artist", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_ArtistsFollowingMe_Dealer(int DealerID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_Get_ArtistsFollowingMe_Dealer", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DealerID", DealerID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }




        internal DataTable Get_DealersFollowingMe_Artist(int ArtistID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;

            SqlCommand cmd = new SqlCommand("sp_Get_DealersFollowingMe_Artist", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_DealersFollowingMe_Dealer(int DealerID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;

            SqlCommand cmd = new SqlCommand("sp_Get_DealersFollowingMe_Dealer", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DealerID", DealerID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }












        internal DataTable Get_DealerID(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "DealerID " + // 0
                "FROM Dealers " +
                "WHERE (UserGUID = @UserGUID)";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Get_ArtistID(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "ArtistID, ProfileArtworkGUIDSmall, ProfileArtworkGUIDMedium " + // 0
                "FROM Artists " +
                "WHERE (UserGUID = @UserGUID)";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Get_Artwork_Details(Guid UserGUID, string ArtworkGUIDMedium)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ArtworkID] " + // 0
                ",[ArtistID] " + // 1
                ",[Title] " + // 2
                ",[Description] " + // 3
                ",[Height] " + // 4
                ",[Width] " + // 5
                ",[MediumID] " + // 6
                ",[Year] " + // 7
                ",[StyleID] " + // 8
                ",[GenreID] " + // 9
                ",[Height_Feet] " + // 10
                ",[Height_Inches] " + // 11
                ",[Width_Feet] " + // 12
                ",[Width_Inches] " + // 13
                "FROM Artworks " +
                "WHERE ArtworkGUIDMedium = @ArtworkGUIDMedium " +
                "AND UserGUID = @UserGUID";
            cmd.Parameters.AddWithValue("@ArtworkGUIDMedium", ArtworkGUIDMedium);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }
        
        internal DataTable Get_FullName(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_GetFullNameForUserGUID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Get_AllGUIDsForArtwork(Guid ArtworkGUIDMedium)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ArtworkGUIDXSmall] " +
                ",[ArtworkGUIDSmall] " +
                ",[ArtworkGUIDMedium] " +
                ",[ArtworkGUIDLarge] " +
                "FROM Artworks " +
                "WHERE (ArtworkGUIDMedium = @ArtworkGUIDMedium)";
            cmd.Parameters.AddWithValue("@ArtworkGUIDMedium", ArtworkGUIDMedium);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_AllGUIDsForArtwork(int ArtworkID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ArtworkGUIDXSmall] " +
                ",[ArtworkGUIDSmall] " +
                ",[ArtworkGUIDMedium] " +
                ",[ArtworkGUIDLarge] " +
                "FROM Artworks " +
                "WHERE (ArtworkID = @ArtworkID)";
            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }







        internal DataTable Get_AnswersToQuestions_Dealer(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "QNA_Dealer_Answers.DealerID " + // 0
                ", QNA_Dealer_Answers.QuestionID " + // 1
                ", QNA_Questions.Question_Dealer " + // 2
                ", QNA_Dealer_Answers.AnswerID " + // 3
                ", QNA_Answers.Answer_Dealer " + // 4
                "FROM QNA_Dealer_Answers " +
                "INNER JOIN QNA_Questions ON QNA_Dealer_Answers.QuestionID = QNA_Questions.QuestionID " +
                "INNER JOIN QNA_Answers ON QNA_Dealer_Answers.AnswerID = QNA_Answers.AnswerID " +
                "AND QNA_Questions.QuestionID = QNA_Answers.QuestionID " +
                "WHERE (QNA_Dealer_Answers.UserGUID = @UserGUID) " +
                "ORDER BY QNA_Dealer_Answers.QuestionID";
            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_AnswersToQuestions_Artist(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT " +
                "QNA_Artist_Answers.ArtistID " + // 0
                ", QNA_Artist_Answers.QuestionID " + // 1
                ", QNA_Questions.Question_Artist " + // 2
                ", QNA_Artist_Answers.AnswerID " + // 3
                ", QNA_Answers.Answer_Artist " + // 4
                "FROM QNA_Artist_Answers " +
                "INNER JOIN QNA_Questions ON QNA_Artist_Answers.QuestionID = QNA_Questions.QuestionID " +
                "INNER JOIN QNA_Answers ON QNA_Artist_Answers.AnswerID = QNA_Answers.AnswerID " +
                "AND QNA_Questions.QuestionID = QNA_Answers.QuestionID " +
                "WHERE (QNA_Artist_Answers.UserGUID = @UserGUID) " +
                "ORDER BY QNA_Artist_Answers.QuestionID";

            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Get_Artwork_Years() // NBU
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[YearID] " +
                ",[Year] " +
                "FROM Artwork_Years " +
                "WHERE IsVisible = 1 " +
                "ORDER BY Year";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Artwork_Mediums()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            //cmd.CommandText = "SELECT " +
            //    "[MediumID] " +
            //    ",[Medium] " +
            //    "FROM Artwork_Mediums " +
            //    "WHERE IsVisible = 1 " +
            //    "ORDER BY Medium";
            cmd.CommandText = "SELECT DISTINCT " + 
                    "Artwork_Mediums.MediumID " + 
                    ", Artwork_Mediums.Medium " + 
                    "FROM  Artworks " + 
                    "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                    "INNER JOIN Artwork_Mediums ON Artworks.MediumID = Artwork_Mediums.MediumID " +
                    "WHERE (Artists.IsAcctSetupComplete = 1) " +
                    "AND (Artists.IsProfileUploadImage = 1) " +
                    "ORDER BY Artwork_Mediums.Medium";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }
        
        internal DataTable Get_Artwork_Styles()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            //cmd.CommandText = "SELECT " +
            //    "[StyleID] " +
            //    ",[Style] " +
            //    "FROM Artwork_Styles " +
            //    "WHERE IsVisible = 1 " +
            //    "ORDER BY Style";

            cmd.CommandText = "SELECT DISTINCT " +
                "Artwork_Styles.StyleID " +
                ", Artwork_Styles.Style " +
                "FROM Artworks " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "INNER JOIN Artwork_Styles ON Artworks.StyleID = Artwork_Styles.StyleID " +
                "WHERE (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1) " +
                "ORDER BY Artwork_Styles.Style";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Artwork_Genres()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            //cmd.CommandText = "SELECT " +
            //    "[GenreID] " +
            //    ",[Genre] " +
            //    "FROM Artwork_Genres " +
            //    "WHERE IsVisible = 1 " +
            //    "ORDER BY Genre";
            cmd.CommandText = "SELECT DISTINCT " +
                "Artwork_Genres.GenreID " +
                ", Artwork_Genres.Genre " +
                "FROM Artwork_Genres " +
                "INNER JOIN Artworks ON Artwork_Genres.GenreID = Artworks.GenreID " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1) " +
                "ORDER BY Artwork_Genres.Genre";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }



        //internal DataTable Get_Artwork_Genre(int GenreID)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = AppConfig.DbConnectionString;
        //    SqlCommand cmd = cn.CreateCommand();
        //    cmd.CommandText = "SELECT " +
        //        "[GenreID] " +
        //        ",[Genre] " +
        //        "FROM Artwork_Genres " +
        //        "WHERE GenreID = @GenreID";
        //    cmd.Parameters.AddWithValue("@GenreID", GenreID);
        //    DataTable table = DataAccess.ExecuteSelectCommand(cmd);
        //    return table;
        //}



        internal DataTable Search_Artists_By_Genre(int GenreID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.ProfileArtworkGUIDSmall " +
                ", Artists.UserGUID " +
                "FROM Artworks " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artworks.GenreID = @GenreID) " +
                "AND (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1)";
            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Search_Artists_By_Genre(int GenreID, string City) 
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.ProfileArtworkGUIDSmall " +
                ", Artists.UserGUID " +
                "FROM Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artworks.GenreID = @GenreID) " +
                "AND (Artists.City = @City) " +
                "AND (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1)";

            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Search_Artists_By_Medium(int MediumID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.ProfileArtworkGUIDSmall " +
                ", Artists.UserGUID " +
                "FROM Artworks " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artworks.MediumID = @MediumID) " +
                "AND (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1)";
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Search_Artists_By_Medium(int MediumID, string City) 
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.ProfileArtworkGUIDSmall " +
                ", Artists.UserGUID " +
                "FROM Artworks " +
                "INNER JOIN Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artworks.MediumID = @MediumID) " +
                "AND (Artists.City = @City) " +
                "AND (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1)";
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Search_Artists_By_Style(int StyleID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.ProfileArtworkGUIDSmall " +
                ", Artists.UserGUID " +
                "FROM Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artworks.StyleID = @StyleID) " +
                "AND (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1)";
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Search_Artists_By_Style(int StyleID, string City) 
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT " +
                "Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.ProfileArtworkGUIDSmall " +
                ", Artists.UserGUID " +
                "FROM Artworks INNER JOIN " +
                "Artists ON Artworks.ArtistID = Artists.ArtistID " +
                "WHERE (Artworks.StyleID = @StyleID) " +
                "AND (Artists.City = @City) " +
                "AND (Artists.IsAcctSetupComplete = 1) " +
                "AND (Artists.IsProfileUploadImage = 1)";
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            cmd.Parameters.AddWithValue("@City", City);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }



        internal DataTable Search_Artists_Location(string searchTerm)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_ParamSearch_Artists_Location", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SearchString", searchTerm);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Search_Artworks_Keywords(string searchTerm)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_ParamSearch_Keywords", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SearchString", searchTerm);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Search_Dealers(string searchTerm)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = new SqlCommand("sp_ParamSearch_Dealers", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SearchString", searchTerm);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }








        internal DataTable Get_Artists()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT TOP 100 " +
                "[ArtistID] " +
                ",[LastName] " +
                ",[FirstName] " +
                ",[CreatedOn] " +
                ",[IPAddress] " +
                ",[IsActive] " +
                ",[IsVisible] " +
                ",[IsFunded] " +
                ",[IsFunedNotes] " +
                ",[IsLocked] " +
                ",[IsLockedNotes] " +
                ",[IsBanned] " +
                ",[IsBannedNotes] " +
                ",[ArtistBio] " +
                "FROM Artists";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_ArtistDetails_ByArtistID(int ArtistID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ArtistID] " + // 0 
                ",[LastName] " + // 1
                ",[FirstName] " + // 2
                ",[City] " + // 3
                ",[Country] " + // 4
                ",[CreatedOn] " + // 5
                ",[ArtistBio] " + // 6
                ",[Gender] " + // 7
                ",[Birthdate] " + // 8
                ",[Email] " + // 9
                ",[Phone] " + // 10
                ",[UserGUID] " + // 11
                ",[WebsiteURL] " + // 12
                "FROM [dbo].[Artists] " +
                "WHERE (ArtistID = @ArtistID)";
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_ArtistDetails(Guid userGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ArtistID] " +
                ",[LastName] " +
                ",[FirstName] " +
                ",[City] " +
                ",[Country] " +
                ",[CreatedOn] " +
                ",[ArtistBio] " +
                ",[Gender] " +
                ",[Birthdate] " +
                ",[Email] " +
                ",[Phone] " + // 10
                ",[UserGUID] " + // 11
                ",[ProfilePhotoGUIDSmall] " + // 12
                ",[WebsiteURL] " + // 13
                "FROM [dbo].[Artists] " +
                "WHERE (UserGUID = @UserGUID)";
            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }
        

        internal DataTable Get_Artists_TOPn_Rand()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = "SELECT TOP 12 " +
                "ArtistID " +
                ", LastName " +
                ", FirstName " +
                ", City " +
                ", ProfilePhotoGUIDSmall " +
                ", ProfileArtworkGUIDSmall " +
                ", UserGUID " +
                "FROM Artists " +
                "WHERE (HasUploadedArtwork = 1) " +
                "AND (IsAcctSetupComplete = 1) " +
                "ORDER BY NEWID()";

            //cmd.CommandText = "SELECT TOP 50 " +
            //    "[ArtistID] " +
            //    ",[LastName] " +
            //    ",[FirstName] " +
            //    "FROM Artists " +
            //    "WHERE HasUploadedArtwork = 1 " +
            //    "ORDER BY NEWID()";

            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_Dealers_TOP50_Rand()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT TOP 50 " +
                "[DealerID] " +
                ",[DealerName] " +
                ",[City] " +
                "FROM Dealers " +
                "WHERE IsAcctSetupComplete = 1 " +
                "ORDER BY NEWID()";
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        #region - POC Images - 

        internal DataTable Get_ArtworksByArtist(int artistID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "Artists.ArtistID " + 
                ", Artists.LastName " + 
                ", Artists.FirstName " +
                ", Artworks.ArtworkID " +
                //", Artworks.Media_Filename400 " +
                //", Artworks.Media_Filename175 " +
                ", Artworks.ArtworkGUIDSmall " +
                ", Artworks.ArtworkGUIDLarge " +
                ", Artists.City " + // 6
                ", Artists.Email " +
                ", Artists.Phone " +
                "FROM Artists INNER JOIN " +
                "Artworks ON Artists.ArtistID = Artworks.ArtistID " +
                "WHERE (Artists.ArtistID = @ArtistID)";
            cmd.Parameters.AddWithValue("@ArtistID", artistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_ArtworkByArtist(int artistID, int artworkID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
            "Artworks.ArtworkID " + // 0
            ", Artworks.Title " + // 1
            ", Artworks.Description " + // 2
            ", Artwork_Mediums.Medium " + // 3
            ", Artwork_Styles.Style " + // 4
            ", Artwork_Genres.Genre " + // 5
            ", Artworks.Year " + // 6
            ", Artworks.ArtworkGUIDSmall " + // 7
            ", Artworks.ArtworkGUIDMedium " + // 8
            ", Artists.ArtistID " + // 9
            ", Artists.LastName " + // 10
            ", Artists.FirstName " + // 11
            ", Artists.City " + // 12
            ", Artists.Email " + // 13
            ", Artists.Phone " + // 14
            ", Artworks.Height_Feet " + // 15
            ", Artworks.Height_Inches " + // 16
            ", Artworks.Width_Feet " + // 17
            ", Artworks.Width_Inches " + // 18
            "FROM Artworks " +
            "INNER JOIN  Artists ON Artworks.ArtistID = Artists.ArtistID " +
            "INNER JOIN Artwork_Genres ON Artworks.GenreID = Artwork_Genres.GenreID " +
            "INNER JOIN Artwork_Mediums ON Artworks.MediumID = Artwork_Mediums.MediumID " +
            "INNER JOIN Artwork_Styles ON Artworks.StyleID = Artwork_Styles.StyleID " +
            "WHERE (Artists.ArtistID = @ArtistID) AND (Artworks.ArtworkID = @ArtworkID)";

            //cmd.CommandText = "SELECT " +
            //    "Artists.ArtistID " +
            //    ", Artists.LastName " +
            //    ", Artists.FirstName " +
            //    ", Artworks.ArtworkID " +
            //    ", Artworks.Title " +
            //    ", Artworks.Description " +
            //    ", Artworks.Height " +
            //    ", Artworks.Width " +
            //    ", Artworks.MediumID " +
            //    ", Artworks.Year " +
            //    ", Artworks.ArtworkGUIDMedium " +
            //    ", Artworks.ArtworkGUIDSmall " + 
            //    //", Artworks.Media_Filename400 " +
            //    //", Artworks.Media_Filename175 " +
            //    ", Artists.City " + // 6
            //    ", Artists.Email " +
            //    ", Artists.Phone " +
            //    "FROM Artists INNER JOIN " +
            //    "Artworks ON Artists.ArtistID = Artworks.ArtistID " +
            //    "WHERE (Artists.ArtistID = @ArtistID) AND (Artworks.ArtworkID = @ArtworkID)";

            cmd.Parameters.AddWithValue("@ArtistID", artistID);
            cmd.Parameters.AddWithValue("@ArtworkID", artworkID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        #endregion


        internal DataTable Get_ArtworksByArtist_UploadPage(int artistID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[ArtworkID] " + // 0
                ",[ArtistID] " + // 1
                ",[Title] " + // 2
                ",[Description] " + // 3
                ",[Height] " + // 4
                ",[Width] " + // 5
                ",[MediumID] " + // 6
                ",[Year] " + // 7
                ",[CreatedOn] " + // 8
                ",[IsVisible] " + // 9
                ",[IsFunded] " + // 10
                ",[IsFunedNotes] " + // 11
                ",[IsBanned] " + // 12
                ",[IsBannedNotes] " + // 13
                ",[Media_Filename400] " + // 14
                ",[Media_Filename175] " + // 15
                ",[IsDeletedByArtist] " + // 16
                ",[Dimensions] " + // 17
                ",[IPAddress] " + // 18
                ",[IsProfileImage] " + // 19
                ",[ArtworkGUIDXSmall] " + // 20
                ",[ArtworkGUIDSmall] " + // 21
                ",[ArtworkGUIDMedium] " + // 22
                ",[ArtworkGUIDLarge] " + // 23
                ",[UserGUID] " + // 24
                "FROM [Artworks] " +
                "WHERE (ArtistID = @ArtistID) " +
                "ORDER BY CreatedOn DESC"; 
            cmd.Parameters.AddWithValue("@ArtistID", artistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }




        internal DataTable Get_SimilarArtists(int artistID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT TOP (4) " + // <<<<<<<<<<< ----------------- TOP (4)
                "TargetArtistFullName " +
                ", VotedArtistID " +
                ", VotedArtistFullName " +
                ", COUNT(VotedArtistID) AS Votes " +
                "FROM Artwork_Assoc_Submitted " +
                "WHERE (TargetArtistID = @ArtistID) " +
                "GROUP BY VotedArtistID, TargetArtistFullName, VotedArtistFullName " +
                "ORDER BY Votes DESC";
            cmd.Parameters.AddWithValue("@ArtistID", artistID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_ExhibitedArtists(int dealerID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " + 
                "ArtistsInDealers.DealerID " +
                ", Artists.ArtistID " +
                ", Artists.LastName " +
                ", Artists.FirstName " +
                ", Artists.City " +
                ", Artists.Country " +
                "FROM ArtistsInDealers " + 
                "INNER JOIN Artists ON ArtistsInDealers.ArtistID = Artists.ArtistID " +
                "WHERE (ArtistsInDealers.DealerID = @DealerID) " +
                "ORDER BY Artists.FirstName";
            cmd.Parameters.AddWithValue("@DealerID", dealerID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }


        internal DataTable Get_DealerDetails(int dealerID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[DealerID] " + // 0
                ",[DealerName] " + // 1
                ",[Description_Short] " + // 2
                ",[Description_Full] " + // 3
                ",[Address01] " + // 4
                ",[Address02] " + // 5
                ",[City] " + // 6
                ",[State] " + // 7
                ",[PostalCode] " + // 8
                ",[Country] " + // 9
                ",[Phone01] " + // 10
                ",[Phone02] " + // 11
                ",[Email] " + // 12
                ",[Contact01_FirstName] " + // 13
                ",[Contact01_LastName] " + // 14
                ",[Contact01_Email] " + // 15
                ",[Contact01_Phone] " + // 16
                ",[Contact02_FirstName] " +  // 17
                ",[Contact02_LastName] " + // 18
                ",[Contact02_Email] " + // 19
                ",[Contact02_Phone] " + // 20
                ",[WebsiteURL] " + // 21
                "FROM [Dealers] " +
                "WHERE (DealerID = @DealerID)";
            cmd.Parameters.AddWithValue("@DealerID", dealerID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        internal DataTable Get_DealerDetails(Guid UserGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                "[DealerID] " + // 0
                ",[DealerName] " + // 1
                ",[Address01] " + // 2
                ",[Address02] " + // 3
                ",[City] " + // 4
                ",[State] " + // 5
                ",[PostalCode] " + // 6
                ",[Country] " + // 7
                ",[Phone01] " + // 8
                ",[Phone02] " + // 9
                ",[Email] " + // 10
                ",[Contact01_FirstName] " + // 11
                ",[Contact01_LastName] " + // 12
                ",[Contact01_Email] " + // 13
                ",[Contact01_Phone] " + // 14
                ",[Contact02_FirstName] " + // 15
                ",[Contact02_LastName] " + // 16
                ",[Contact02_Email] " + // 17
                ",[Contact02_Phone] " + // 18
                ",[WebsiteURL] " + // 19
                ",[Description_Short] " + // 20
                ",[Description_Full] " + // 21
                "FROM [Dealers] " +
                "WHERE (UserGUID = @UserGUID)";
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }

        #endregion




        #region - UPDATE - 



        




        internal bool Update_QNA_Artist_Answer(
            Guid UserGUID
            , int ArtistID
            , int QuestionID
            , int AnswerID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE QNA_Artist_Answers " +
                                "SET AnswerID = @AnswerID " +
                                "WHERE (UserGUID = @UserGUID) " +
                                "AND (ArtistID = @ArtistID) " +
                                "AND (ArtistAnswerID = @ArtistAnswerID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@AnswerID", AnswerID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Update_Profile_Proxy_Artwork(int ArtistID, int ArtworkID)
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE Artworks " +
                                "SET IsProfileImage = 0 " +
                                "WHERE (ArtistID = @ArtistID) " +
                                "UPDATE Artworks " +
                                "SET IsProfileImage = 1 " +
                                "WHERE (ArtistID = @ArtistID) " +
                                "AND (ArtworkID = @ArtworkID)";
            #endregion

            #region --- Parameters ---

            //cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }




        internal DataTable Get_Small_And_Med_ArtworkGUIDs_For_PofileMaster(int ArtistID, int ArtworkID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT " +
                                "[ArtworkGUIDSmall] " +
                                ",[ArtworkGUIDMedium] " +
                                "FROM Artworks " +
                                "WHERE (ArtistID = @ArtistID) " +
                                "AND (ArtworkID = @ArtworkID)";
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);
            DataTable table = DataAccess.ExecuteSelectCommand(cmd);
            return table;
        }
        internal bool Update_Profile_Proxy_Artists_2(int ArtistID, int ArtworkID)
        {
            DataTable dt = this.Get_Small_And_Med_ArtworkGUIDs_For_PofileMaster(ArtistID, ArtworkID);
            Guid ProfileArtworkGUIDSmall = new Guid(dt.Rows[0][0].ToString());
            Guid ProfileArtworkGUIDMedium = new Guid(dt.Rows[0][1].ToString());

            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            string ArtworkGUIDSmall = 
            cmd.CommandText = "UPDATE Artists " +
                                "SET ProfileArtworkGUIDSmall = @ProfileArtworkGUIDSmall " +
                                ", ProfileArtworkGUIDMedium = @ProfileArtworkGUIDMedium " +
                                ", HasUploadedArtwork = 1 " +
                                "WHERE (ArtistID = @ArtistID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);
            cmd.Parameters.AddWithValue("@ProfileArtworkGUIDSmall", ProfileArtworkGUIDSmall);
            cmd.Parameters.AddWithValue("@ProfileArtworkGUIDMedium", ProfileArtworkGUIDMedium);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Update_Profile_Proxy_Artists(int ArtistID, string ProfileArtworkGUIDSmall, string ProfileArtworkGUIDMedium)
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE Artists " +
                                "SET ProfileArtworkGUIDSmall = @ProfileArtworkGUIDSmall " +
                                ", ProfileArtworkGUIDMedium = @ProfileArtworkGUIDMedium " +
                                ", HasUploadedArtwork = 1 " + 
                                ", IsProfileUploadImage = 1 " +
                                "WHERE (ArtistID = @ArtistID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ProfileArtworkGUIDSmall", ProfileArtworkGUIDSmall);
            cmd.Parameters.AddWithValue("@ProfileArtworkGUIDMedium", ProfileArtworkGUIDMedium);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }


        // Inches only
        internal bool Update_Artwork_Details_v02(
            int ArtworkID
            //, int ArtistID
            , Guid UserGUID
            , string Title
            , string Description
            , int MediumID
            , string Year
            , int StyleID
            , int GenreID
            , string Height_Inches
            , string Width_Inches
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Artworks] " +
                                    "SET " +
                                    "Title = @Title " +
                                    ", Description = @Description " +
                                    ", MediumID = @MediumID " +
                                    ", Year = @Year " +
                                    ", StyleID = @StyleID " +
                                    ", GenreID = @GenreID " +
                                    ", Height_Inches = @Height_Inches " +
                                    ", Width_Inches = @Width_Inches " +
                                    "WHERE (UserGUID = @UserGUID) " +
                                    "AND (ArtworkID = @ArtworkID)";
            #endregion

            #region --- Parameters ---

            //cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            cmd.Parameters.AddWithValue("@Height_Inches", Height_Inches);
            cmd.Parameters.AddWithValue("@Width_Inches", Width_Inches);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }




        internal bool Update_Artwork_Details(
            int ArtworkID
            //, int ArtistID
            , Guid UserGUID
            , string Title
            , string Description
            , int MediumID
            , string Year
            , int StyleID
            , int GenreID
            , string Height_Feet
            , string Height_Inches
            , string Width_Feet
            , string Width_Inches
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Artworks] " +
                                    "SET " +
                                    "Title = @Title " +
                                    ", Description = @Description " +
                                    ", MediumID = @MediumID " +
                                    ", Year = @Year " +
                                    ", StyleID = @StyleID " +
                                    ", GenreID = @GenreID " +
                                    ", Height_Feet = @Height_Feet " +
                                    ", Height_Inches = @Height_Inches " +
                                    ", Width_Feet = @Width_Feet " +
                                    ", Width_Inches = @Width_Inches " +
                                    "WHERE (UserGUID = @UserGUID) " +
                                    "AND (ArtworkID = @ArtworkID)";
            #endregion

            #region --- Parameters ---

            //cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@MediumID", MediumID);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@StyleID", StyleID);
            cmd.Parameters.AddWithValue("@GenreID", GenreID);
            cmd.Parameters.AddWithValue("@Height_Feet", Height_Feet);
            cmd.Parameters.AddWithValue("@Height_Inches", Height_Inches);
            cmd.Parameters.AddWithValue("@Width_Feet", Width_Feet);
            cmd.Parameters.AddWithValue("@Width_Inches", Width_Inches);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        


        internal bool Update_Artist_ContactInfoX(
            string Email
            , string LastName
            , string FirstName
            , string City
            , string Country
            , string Phone
            , Guid UserGUID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "sp_TRANS_UPDATE_Username_Email";
            cmd.CommandType = CommandType.StoredProcedure;

            #endregion

            #region --- Parameters ---
            
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Update_Artist_ContactInfo(
            string LastName
            , string FirstName
            , string City
            , string Country
            , string Phone
            , Guid UserGUID
            , string WebsiteURL
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Artists] " +
                                    "SET " +
                                    "LastName = @LastName " +
                                    ", FirstName = @FirstName " +
                                    ", City = @City " +
                                    ", Country = @Country " +
                                    ", Phone = @Phone " +
                                    ", WebsiteURL = @WebsiteURL " +
                                    ", IsProfileContactInfo = 1 " +
                                    "WHERE (UserGUID = @UserGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@WebsiteURL", WebsiteURL);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }

        
        
        internal bool Update_Artist_Bio(
            string ArtistBio
            , Guid UserGUID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Artists] " +
                                    "SET ArtistBio = @ArtistBio, IsProfileBio = 1 WHERE (UserGUID = @UserGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@ArtistBio", ArtistBio);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Update_Dealer_ContactInfo(
            string DealerName
            //, string Description_Short
            , string Description_Full
            , string Address01
            //, string Address02
            , string City
            , string State
            , string PostalCode
            , string Country
            , string Phone01
            , string Phone02
            , string Contact01_FirstName
            , string Contact01_LastName
            , string Contact01_Email
            , string Contact01_Phone
            , string Contact02_FirstName
            , string Contact02_LastName
            , string Contact02_Email
            , string Contact02_Phone
            , string WebsiteURL
            , Guid UserGUID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Dealers] " +
                    "SET " +
                    "DealerName = @DealerName " +
                    //", Description_Short = @Description_Short " +
                    ", Description_Full = @Description_Full " +
                    ", Address01 = @Address01 " +
                    //", Address02 = @Address02 " +
                    ", City = @City " +
                    ", State = @State " +
                    ", PostalCode = @PostalCode " +
                    ", Country = @Country " +
                    ", Phone01 = @Phone01 " +
                    ", Phone02 = @Phone02 " +
                    ", Contact01_FirstName = @Contact01_FirstName " +
                    ", Contact01_LastName = @Contact01_LastName " +
                    ", Contact01_Email = @Contact01_Email " +
                    ", Contact01_Phone = @Contact01_Phone " +
                    ", Contact02_FirstName = @Contact02_FirstName " +
                    ", Contact02_LastName = @Contact02_LastName " +
                    ", Contact02_Email = @Contact02_Email " +
                    ", Contact02_Phone = @Contact02_Phone " +
                    ", WebsiteURL = @WebsiteURL " +
                    "WHERE (UserGUID = @UserGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@DealerName", DealerName);
            //cmd.Parameters.AddWithValue("@Description_Short", Description_Short);
            cmd.Parameters.AddWithValue("@Description_Full", Description_Full);
            cmd.Parameters.AddWithValue("@Address01", Address01);
            //cmd.Parameters.AddWithValue("@Address02", Address02);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Phone01", Phone01);
            cmd.Parameters.AddWithValue("@Phone02", Phone02);
            cmd.Parameters.AddWithValue("@Contact01_FirstName", Contact01_FirstName);
            cmd.Parameters.AddWithValue("@Contact01_LastName", Contact01_LastName);
            cmd.Parameters.AddWithValue("@Contact01_Email", Contact01_Email);
            cmd.Parameters.AddWithValue("@Contact01_Phone", Contact01_Phone);
            cmd.Parameters.AddWithValue("@Contact02_FirstName", Contact02_FirstName);
            cmd.Parameters.AddWithValue("@Contact02_LastName", Contact02_LastName);
            cmd.Parameters.AddWithValue("@Contact02_Email", Contact02_Email);
            cmd.Parameters.AddWithValue("@Contact02_Phone", Contact02_Phone);
            cmd.Parameters.AddWithValue("@WebsiteURL", WebsiteURL);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Update_Dealer_Bio(
            string Description_Full
            , Guid UserGUID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Dealers] " +
                                    "SET Description_Full = @Description_Full, IsProfileBio = 1 " + 
                                    "WHERE (UserGUID = @UserGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@Description_Full", Description_Full);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }


        internal bool Update_Dealer_Bio(
            string Description_Short
            , string Description_Full
            , Guid UserGUID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE [Dealers] " +
                                    "SET Description_Short = @Description_Short " +
                                    ", Description_Full = @Description_Full " +
                                    "WHERE (UserGUID = @UserGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@Description_Short", Description_Short);
            cmd.Parameters.AddWithValue("@Description_Full", Description_Full);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        #endregion




        #region - DELETE -


        internal bool Delete_SavedSearch(Guid SavedSearchGUID)
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM SavedSearches " +
                              "WHERE (SavedSearchGUID = @SavedSearchGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@SavedSearchGUID", SavedSearchGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Delete_ArtistsIAmFollowing(
            Guid UserGUID
            , int ArtistID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Follows " +
                                "WHERE (UserGUID = @UserGUID) " +
                                "AND (ArtistID = @ArtistID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }



        internal bool Delete_DealersIAmFollowing(
            Guid UserGUID
            , int DealerID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Follows " +
                                "WHERE (UserGUID = @UserGUID) " +
                                "AND (DealerID = @DealerID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@DealerID", DealerID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }




        internal bool Delete_QNA_Dealer_Answers(
            Guid UserGUID
            , int DealerID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM QNA_Dealer_Answers " +
                                "WHERE (UserGUID = @UserGUID) " +
                                "AND (DealerID = @DealerID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@DealerID", DealerID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }




        internal bool Delete_QNA_Artist_Answers(
            Guid UserGUID
            , int ArtistID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM QNA_Artist_Answers " +
                                "WHERE (UserGUID = @UserGUID) " +
                                "AND (ArtistID = @ArtistID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);
            cmd.Parameters.AddWithValue("@ArtistID", ArtistID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }





        internal bool Delete_Artwork(
            int ArtworkID
            , Guid UserGUID
            )
        {
            #region --- SQL Command ---

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Artworks " +
                "WHERE (ArtworkID = @ArtworkID) AND (UserGUID = @UserGUID)";
            #endregion

            #region --- Parameters ---

            cmd.Parameters.AddWithValue("@ArtworkID", ArtworkID);
            cmd.Parameters.AddWithValue("@UserGUID", UserGUID);

            #endregion

            bool status;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }


        internal bool Delete_Artwork(Guid ArtworkGUID)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Artworks " +
                "WHERE (ArtworkGUIDMedium = @ArtworkGUID)";
            cmd.Parameters.AddWithValue("@ArtworkGUID", ArtworkGUID);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            finally
            {
                cn.Close();
            }
            return status;
        }


        #endregion




        #region - UTILITY -

        internal bool TestForValidEmailAddress(string emailAddress)
        {
            string pattern = @"[\w*.]+@[\w.]+\.\w+";
            bool test = Regex.IsMatch(emailAddress, pattern);
            return test;
        }

        internal bool TestSearchStringForSQLInjection(string searchTerm)
        {
            string pattern = ConfigurationManager.AppSettings["REGEX_Injection"].ToString();
            bool test = Regex.IsMatch(searchTerm, pattern);
            return test;
        }

        internal bool TestForSQLInjection(string input)
        {
            string pattern = ConfigurationManager.AppSettings["REGEX_Injection"].ToString();
            bool test = Regex.IsMatch(input, pattern);
            return test;
        }

        internal bool IsValid_PageVisitor(Guid userGUID, Guid identityGUID)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = AppConfig.DbConnectionString;
            SqlCommand cmd = cn.CreateCommand();

            #region - SELECT -
            cmd.CommandText = "SELECT " +
                "COUNT(IdentityGUID) " +
                "FROM Identities " +
                "WHERE (UserGUID = @UserGUID) AND (IdentityGUID = @IdentityGUID)";
            cmd.Parameters.AddWithValue("@UserGUID", userGUID);
            cmd.Parameters.AddWithValue("@IdentityGUID", identityGUID);
            #endregion

            cn.Open();

            bool status = false;
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            if (count > 0) status = true;
            else status = false;
            return status;
        }

        Random random = new Random();

        public static int GetRand()
        {
            Random random = new Random();
            int x = random.Next(100000000);
            return x;
        }

        internal static void Sleep()
        {
            TimeSpan waitTime = new TimeSpan(0, 0, 1); // 1 second
            Thread.Sleep(waitTime);
        }

        internal static String CleanPhoneNumber(string strIn)
        {
            return Regex.Replace(strIn, @"\D", "");
        }

        internal static String StripDashes(string strIn)
        {
            return Regex.Replace(strIn, @"-", " ");
        }

        internal static String StripSpaces(string strIn)
        {
            return Regex.Replace(strIn, @" ", "-");
        }

        internal static string GetIpAddress()
        {
            string strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                strIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return strIpAddress;
        }

        #endregion
    }
}