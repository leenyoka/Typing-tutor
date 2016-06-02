using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace BussinessLayer
{
    public class DataAccess
    {
        #region Members
        private string connectionString;

        public DataAccess()
        {
            

            //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +  // working
            //        "Data Source=" + Directory.GetCurrentDirectory() + "\\TouchTyping.mdb";

            //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //        "Data Source=" + Directory.GetCurrentDirectory() + "\\TouchTyping.mdb; User Id=admin;Password=" ;


            ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +  // working
                    "Data Source=" + Directory.GetCurrentDirectory() + "\\TouchTyping.mdb";





            //ConnectionString = "Driver={Microsoft Access Driver (*.mdb)};Dbq= "+ Directory.GetCurrentDirectory()+"\\TouchTyping.mdb ;Uid=Admin;Pwd=;" ;




            //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
             //        "Data Source=Database/TouchTyping.mdb";

            //ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TouchTyping.accdb";//not working


            //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //        "Data Source=TouchTyping.mdb";

           // ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\TouchTyping.accdb;Persist Security Info=False;";//not working
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        #endregion Members

        #region insert
        #region Insert User
        public void InsertUser(User user)
        {
            
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO Users ([Username], [Password]) " +
                    "VALUES(@Username, @Password)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert User", ex);
                }
            }
        }
        #endregion Insert User

        #region Insert UserSkill
        public void InsertUserSkill(UserSkill userSkill)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO UserSkills([Username], [SkillID] , [Speed], [Accuracy])" +
                    "VALUES(@Username, @SkillID, @Speed, @Accuracy)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                cmd.Parameters.AddWithValue("@Username", userSkill.UserName);
                cmd.Parameters.AddWithValue("@SkillID", userSkill.SkillID);
                cmd.Parameters.AddWithValue("@Speed", userSkill.Speed);
                cmd.Parameters.AddWithValue("@Accuracy", userSkill.Accuracy);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert User skill", ex);
                }
            }
        }
        #endregion Insert  UserSkill

        #region Insert Skill
        public void InsertSkill(Skill skill)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO Skills([SkillID], [Skillname])" +
                    "VALUES(@SkillID, @Skillname)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                cmd.Parameters.AddWithValue("@Username", skill.SkillID);
                cmd.Parameters.AddWithValue("@SkillID", skill.SkillName);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert skill", ex);
                }
            }
        }
        #endregion Insert Skill

        #region Insert Test
        public void InsertTest(Test test)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO Tests([TestID], [TotalNumberOfKeyStrokes],"+
                " [NumberOfIncorrectKeyStrokes], [Duration], [SkillID], [Testdate], [Testtime], [Username])" +
                    " VALUES(@TestID, @TotalNumberOfKeyStrokes," +
                "@NumberOfIncorrectKeyStrokes, @Duration, @SkillID, @Date, @Time, @Username)";


                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                //cmd.Parameters.AddWithValue("@TestID", test.TestID);
                cmd.Parameters.AddWithValue("@TestID", test.TestID);
                cmd.Parameters.AddWithValue("@TotalNumberOfKeysStrokes", test.TotalNumberOfKeyStrokes);
                cmd.Parameters.AddWithValue("@NumberOfIncorrectKeyStrokes", test.NumberOfinccorrectKeyStrokes);
                cmd.Parameters.AddWithValue("@Duration", test.Duration);
                cmd.Parameters.AddWithValue("@SkillID", test.SkillID);
                cmd.Parameters.AddWithValue("@Date", test.Date);
                cmd.Parameters.AddWithValue("@Time", test.Time);
                cmd.Parameters.AddWithValue("@Username", test.Username);
                

                try
                {
                    con.Open();
                    int m = cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert Test", ex);
                }
            }
        }
        #endregion Insert Test

        #region Insert Mode
        public void InsertMode(Mode mode)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO Modes([ModeID], [Modename])" +
                    "VALUES(@ModeID, @Name)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                cmd.Parameters.AddWithValue("@ModeID", mode.ModeID);
                cmd.Parameters.AddWithValue("@Name", mode.Name);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert Mode", ex);
                }
            }
        }
        #endregion Insert Mode

        #region Insert File
        public void InsertFile(File file)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO Files([Filename], [Location], [SkillID])" +
                    "VALUES(@Name, @Location, @SkillID)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                //cmd.Parameters.AddWithValue("@File", file.FileID);
                cmd.Parameters.AddWithValue("@Name", file.Name);
                cmd.Parameters.AddWithValue("@Location", file.Location);
                cmd.Parameters.AddWithValue("@SkillID", file.SkillID);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert file", ex);
                }
            }
        }
        #endregion Insert File

        #region Insert TestDifficultKey
        public void InsertTestDifficultKey(TestDifficultKeys DifficultKey)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO TestDifficultKeys ([TestID], [Keyname]) " +
                    "VALUES(@Testid, @Keyname)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                cmd.Parameters.AddWithValue("@Testid", DifficultKey.TestID);
                cmd.Parameters.AddWithValue("@Keyname", DifficultKey.Keyname);

                try
                {
                    con.Open();
                    int m = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert difficult key", ex);
                }
            }
        }
        #endregion Insert test difficult key


        #region Insert Practice difficult keys
        public void InsertPracticeDifficultKey(PracticeDifficultKeys DifficultKey)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO PracticeDifficultKeys ([Username],[SkillID] ,[Keyname]) " +
                    "VALUES(@Username, @SkillID ,@Keyname)";
                OleDbCommand cmd = new OleDbCommand(insertCommand, con);

                cmd.Parameters.AddWithValue("@Username", DifficultKey.Username);
                cmd.Parameters.AddWithValue("@SkillID", DifficultKey.SkillID);
                cmd.Parameters.AddWithValue("@Keyname", DifficultKey.Keyname);

                try
                {
                    con.Open();
                    int m = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert difficult key", ex);
                }
            }
        }
        #endregion Insert test difficult key

        #region Insert User Settings
        public void InsertUserSettings(UserSettings userSettings)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "INSERT INTO Usersettings ([Username], [moName], [moValue]) " +
                    "VALUES(@Username, @moName, @moValue)";

                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                cmd.Parameters.AddWithValue("@Username", userSettings.Username);
                cmd.Parameters.AddWithValue("@moName", userSettings.MoName);
                cmd.Parameters.AddWithValue("@moValue", userSettings.MoValue);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could not insert User", ex);
                }
            }
        }
        #endregion Insert User Settings

        
        #endregion Insert

        #region Get

        #region GetSkills
        public List<Skill> GetAllSkills()
        {
            using(OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Skills";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                List<Skill> skillsList = new List<Skill>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Skill skill = new Skill(Convert.ToString(reader["Skillname"]),Convert.ToString(reader["SkillID"]));
                        skillsList.Add(skill);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("could not read skills", ex);
                }
                return skillsList;

            }
        }      

        #endregion GetSkills

        #region GetUserSkills
        public List<UserSkill> GetUserSkills(string username)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM UserSkills WHERE Username= @Username";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@Username", username);
                List<UserSkill> userskillsList = new List<UserSkill>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserSkill userSkill = new UserSkill(Convert.ToString(reader["Username"]), Convert.ToString(reader["SkillID"]),
                            Convert.ToString(reader["Speed"]), Convert.ToString(reader["Accuracy"]));

                        userskillsList.Add(userSkill);
                        
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read user's skills", ex);
                }
                return userskillsList;

            }
        }

        #endregion GetSkills


        #region GetUsers
        public List<User> GetAllUsers()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Users";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                List<User> users = new List<User>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(Convert.ToString(reader["Username"]), Convert.ToString(reader["Password"]));
                        users.Add(user);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read users", ex);
                }
                return users;

            }
        }

        #endregion Get Users

        #region GetaUser
        public User GetaUser(string username)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Users WHERE Username= @Username";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@Username", username);
                User user = new User();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                         user = new User(Convert.ToString(reader["Username"]), Convert.ToString(reader["Password"]));
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read user", ex);
                }
                return user;

            }
        }

        #endregion Get User

        #region Get User's tests
        public List<Test> GetUserTests(string Username)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Tests WHERE Username=@Username";
                
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@Username", Username);
                List<Test> tests = new List<Test>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        Test test = new Test(Convert.ToString(reader["TestID"]),Convert.ToString(reader["TotalNumberOfkeyStrokes"]),
                            Convert.ToString(reader["NumberOfIncorrectKeyStrokes"]), Convert.ToString(reader["Duration"]),
                            Convert.ToString(reader["SkillID"]),Convert.ToString(reader["Testdate"]), Convert.ToString(reader["Testtime"]), 
                            Convert.ToString(reader["Username"]));

                        tests.Add(test);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read user's tests", ex);
                }
                return tests;

            }
        }

        #endregion Get User's Tests

        #region Get Modes
        public List<Mode> GetAllModes()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Modes";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                List<Mode> modes = new List<Mode>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Mode mode = new Mode(Convert.ToString(reader["ModeID"]), Convert.ToString(reader["Modename"]));
                        modes.Add(mode);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read modes", ex);
                }
                return modes;

            }
        }

        #endregion Get Modes

        #region Get Skill Files
        public List<File> GetSkillFiles(string SkillID)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Files WHERE SkillID=@SkillID";

                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@SkillID", SkillID);
                List<File> files = new List<File>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        File file = new File(Convert.ToString(reader["Filename"]),
                            Convert.ToString(reader["Location"]), Convert.ToString(reader["SkillID"]));
                        

                        files.Add(file);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read mode's files", ex);
                }
                return files;

            }
        }

        #endregion Get skill files

        #region Get tests
        public List<Test> GetUserTests()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Tests";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                List<Test> tests = new List<Test>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        //Test test = new Test(Convert.ToString(reader["TotalNumberOfKeyStrokes"]),
                        //    Convert.ToString(reader["NumberOfIncorrectKeyStrokes"]), Convert.ToString(reader["Duration"]),
                        //    Convert.ToString(reader["SkillID"]),Convert.ToString(reader["Testdate"]) ,Convert.ToString(reader["Testtime"]), 
                        //    Convert.ToString(reader["Username"]));

                        Test test = new Test(Convert.ToString(reader["TestID"]),Convert.ToString(reader["TotalNumberOfKeyStrokes"]), Convert.ToString(reader["NumberOfIncorrectKeyStrokes"]),
                            Convert.ToString(reader["Duration"]), Convert.ToString(reader["SkillID"]), Convert.ToString(reader["Testdate"]),
                            Convert.ToString(reader["Testtime"]), Convert.ToString(reader["Username"]));
                        

                        tests.Add(test);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read tests", ex);
                }
                return tests;

            }
        }

        #endregion Get Tests

        #region Get a control
        public Control GetAControl(string controlname)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM ManageOptions WHERE Controlname = @Controlname";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@Controlname", controlname);
                Control control = new Control();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        control = new Control(Convert.ToString(reader["Controlname"]), Convert.ToString(reader["Controlvalue"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read controls", ex);
                }
                return control;

            }
        }

        #endregion Get a control

        #region Get a user skill
        public UserSkill GetASkill(string skillid, string username)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM UserSkills WHERE  Username = @username";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);


                cmd.Parameters.AddWithValue("@username", username);
                //cmd.Parameters.AddWithValue("@skillid", skillid);
                UserSkill userskill = new UserSkill();
                try

                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string myid = Convert.ToString(reader["SkillID"]);
                        if ((string)myid == skillid.ToString().ToUpper())
                        {
                            userskill = new UserSkill(Convert.ToString(reader["Username"]), Convert.ToString(reader["SkillID"]),
                                Convert.ToString(reader["Speed"]), Convert.ToString(reader["Accuracy"]));
                            break;
                        }
                        //userskill = new Control(Convert.ToString(reader["Controlname"]), Convert.ToString(reader["Controlvalue"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read user skill", ex);
                }
                return userskill;

            }
        }

        #endregion Get a userskill

        #region Get an option 
        public ManageOptions GetAnOption(string optionName)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM manageOptions WHERE moName = @Controlname";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@Controlname", optionName);
                ManageOptions option = new ManageOptions();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        option = new ManageOptions(Convert.ToString(reader["moName"]), Convert.ToString(reader["moValue"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read controls", ex);
                }
                return option;

            }
        }

        #endregion Get an option

        #region Get controls
        public List<Control> GetControls()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM ManageOptions";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);

                List<Control> controls = new List<Control>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                       Control control = new Control(Convert.ToString(reader["Controlname"]), Convert.ToString(reader["Controlvalue"]));
                       controls.Add(control);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read controls", ex);
                }
                return controls;

            }
        }

        #endregion Get controls

        #region Get Options
        public List<ManageOptions> GetOptions()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM manageOptions";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);

                List<ManageOptions> options = new List<ManageOptions>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        ManageOptions controlll = new ManageOptions(Convert.ToString(reader["moName"]), Convert.ToString(reader["moValue"]));
                        options.Add(controlll);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read options", ex);
                }
                return options;

            }
        }

        #endregion Get controls

        #region Get Test's difficult keys
        public List<TestDifficultKeys> GetTestsDiffucultkeys(string testID)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM TestDifficultKeys WHERE TestID=@TestID";

                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@TestID", testID);
                List<TestDifficultKeys> mydifKeys = new List<TestDifficultKeys>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        TestDifficultKeys dk = new TestDifficultKeys(Convert.ToString(reader["TestID"]),Convert.ToString(reader["Keyname"]) );
                        
                        

                        //Test test = new Test(Convert.ToString(reader["TotalNumberOfkeyStrokes"]),
                        //    Convert.ToString(reader["NumberOfIncorrectKeyStrokes"]), Convert.ToString(reader["Duration"]),
                        //    Convert.ToString(reader["ModeID"]), Convert.ToString(reader["Testdate"]), Convert.ToString(reader["Testtime"]),
                        //    Convert.ToString(reader["Username"]));

                        mydifKeys.Add(dk);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read test's difficult keys", ex);
                }
                return mydifKeys;

            }
        }

        #endregion Get Get Tests Difficult keys

        #region Get All DifficultKeys
        public List<TestDifficultKeys> GetAllDiffucultkeys()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM TestDifficultKeys";

                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                //cmd.Parameters.AddWithValue("@TestID", testID);
                List<TestDifficultKeys> mydifKeys = new List<TestDifficultKeys>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        TestDifficultKeys dk = new TestDifficultKeys(Convert.ToString(reader["TestID"]), Convert.ToString(reader["Keyname"]));



                        //Test test = new Test(Convert.ToString(reader["TotalNumberOfkeyStrokes"]),
                        //    Convert.ToString(reader["NumberOfIncorrectKeyStrokes"]), Convert.ToString(reader["Duration"]),
                        //    Convert.ToString(reader["ModeID"]), Convert.ToString(reader["Testdate"]), Convert.ToString(reader["Testtime"]),
                        //    Convert.ToString(reader["Username"]));

                        mydifKeys.Add(dk);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read  difficult keys", ex);
                }
                return mydifKeys;

            }
        }

        #endregion Get Difficult keys

        #region PracticeDifficultskeys
        public List<PracticeDifficultKeys> GetPracticeDifficultKeys()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM PracticeDifficultKeys";
                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                List<PracticeDifficultKeys> difficultkeys = new List<PracticeDifficultKeys>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PracticeDifficultKeys dk = new PracticeDifficultKeys(Convert.ToString(reader["Username"]),
                            Convert.ToString(reader["SkillID"]), Convert.ToString(reader["Keyname"]));
                        //User user = new User(Convert.ToString(reader["Username"]), Convert.ToString(reader["Password"]));
                        difficultkeys.Add(dk);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read difficult keys", ex);
                }
                return difficultkeys;

            }
        }

        #endregion Get Users

        #region PracticeDifficultskeys
        public List<PracticeDifficultKeys> GetusersPracticeDifficultKeys(string username)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM PracticeDifficultKeys WHERE Username = \""+ username+ "\"";

                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                List<PracticeDifficultKeys> difficultkeys = new List<PracticeDifficultKeys>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PracticeDifficultKeys dk = new PracticeDifficultKeys(Convert.ToString(reader["Username"]),
                            Convert.ToString(reader["SkillID"]), Convert.ToString(reader["Keyname"]));
                        //User user = new User(Convert.ToString(reader["Username"]), Convert.ToString(reader["Password"]));
                        difficultkeys.Add(dk);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read difficult keys", ex);
                }
                return difficultkeys;

            }
        }

        #endregion Get Users


        #region Get user settings
        public List<UserSettings> GetUserSettings(string username)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Usersettings WHERE Username = @username";

                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@username", username);

                List<UserSettings> options = new List<UserSettings>();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        UserSettings controlll = new UserSettings(Convert.ToString(reader["Username"]),Convert.ToString(reader["moName"]), Convert.ToString(reader["moValue"]));
                        options.Add(controlll);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read options", ex);
                }
                return options;

            }
        }

        #endregion Get user settings

        #region Get a user choice
        public UserSettings GetChoice(string username, string moName)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string selectStatement = "SELECT * FROM Usersettings WHERE Username = @username " +
                    "AND moName = @moName";


                OleDbCommand cmd = new OleDbCommand(selectStatement, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@moName", moName);

                UserSettings option = new UserSettings();
                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        option = new UserSettings(Convert.ToString(reader["Username"]),Convert.ToString(reader["moName"]), Convert.ToString(reader["moValue"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("could not read controls", ex);
                }
                return option;

            }
        }

        #endregion Get a user choice

        


        #endregion Get


        #region Update
        #region Update Control
        public void updateControl(Control control)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string command = @"UPDATE ManageOptions SET [Controlvalue] = ? WHERE [Controlname] = ?";
                //string command = "UPDATE Control SET [Controlvalue] = '4' WHERE [Controlname] = 'Testduration'";
                OleDbCommand cmd = new OleDbCommand(command, con);
                cmd.Parameters.AddWithValue("Controlname", control.ControlName);
                cmd.Parameters.AddWithValue("Controlvalue", control.ControlValue);

                try
                {
                    con.Open();
                    int c = cmd.ExecuteNonQuery();
                }
                catch 
                {
                    throw new ApplicationException("Could not update control");
                }
            }
        }
        #endregion Update Control

        #region Update an option

        //public void updateOption(ManageOptions option)
        //{

        //    using (OleDbConnection con = new OleDbConnection(ConnectionString))
        //    {
        //        //string command = "UPDATE manageOptions SET moValue = @moValue WHERE (moName = @moName)";

        //        string command = "UPDATE manageOptions SET moValue =" + option.MoValue +" WHERE moName = "+ option.MoName+ ";";


        //        //string command = "UPDATE Control SET [Controlvalue] = '4' WHERE [Controlname] = 'Testduration'";
        //        OleDbCommand cmd = new OleDbCommand(command, con);
        //        cmd.Parameters.AddWithValue("@moName", option.MoName);
        //        cmd.Parameters.AddWithValue("@moValue", option.MoValue);

        //        try
        //        {
        //            con.Open();
        //            int c = cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Could not update option");
        //        }
        //    }
        //}

        public void updateOption(ManageOptions option)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                //string command = "UPDATE manageOptions SET moValue = @moValue WHERE (moName = @moName)";

                //string command = "UPDATE [manageOptions] SET moValue = ? WHERE moName = ? ;";
                string command = "UPDATE manageOptions SET [moValue] = \"" + option.MoValue +"\" WHERE [moName] = \"" + option.MoName + "\";";

                //string command = "UPDATE Control SET [Controlvalue] = '4' WHERE [Controlname] = 'Testduration'";
                OleDbCommand cmd = new OleDbCommand(command, con);

                //cmd.Parameters.AddWithValue("@moName1", option.MoName);
                //cmd.Parameters.AddWithValue("@moValue1", option.MoValue);

                try
                {
                    con.Open();
                    int c = cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    
                    throw new ApplicationException(ex.Message);
                }
            }
        }
        #endregion Update option
        #region Update User skill

        public void updateUserSkill(UserSkill userSkill)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
               

                string command = "UPDATE  UserSkills Set [Speed] = \"" + userSkill.Speed +
                    "\", [Accuracy] = \"" + userSkill.Accuracy + "\" WHERE " +
                    "[Username] = \"" + userSkill.UserName + "\" AND [SkillID] = \"" +
                    userSkill.SkillID + "\"";

                //string command = "UPDATE Control SET [Controlvalue] = '4' WHERE [Controlname] = 'Testduration'";
                OleDbCommand cmd = new OleDbCommand(command, con);

                

                try
                {
                    con.Open();
                    int c = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new ApplicationException(ex.Message);
                }
            }
        }

        #endregion Update user skill


        public void updateUserSettings(UserSettings option)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                //string command = "UPDATE manageOptions SET moValue = @moValue WHERE (moName = @moName)";

                //string command = "UPDATE [manageOptions] SET moValue = ? WHERE moName = ? ;";
                string command = "UPDATE Usersettings SET [moValue] = \"" + option.MoValue + "\" WHERE [moName] = \"" + option.MoName + "\" AND " +
                    "Username = \"" + option.Username + "\";";

                //string command = "UPDATE Control SET [Controlvalue] = '4' WHERE [Controlname] = 'Testduration'";
                OleDbCommand cmd = new OleDbCommand(command, con);

                //cmd.Parameters.AddWithValue("@moName1", option.MoName);
                //cmd.Parameters.AddWithValue("@moValue1", option.MoValue);

                try
                {
                    con.Open();
                    int c = cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    
                    throw new ApplicationException(ex.Message);
                }
            }
        }
        


        #endregion Update

        #region Delete

        #region Delete Test Difficult key

        public void DeleteTestDifficultKey(TestDifficultKeys mykey)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "DELETE FROM Testdifficultkeys " +
                    "WHERE [TestID] = " + int.Parse(mykey.TestID) + " AND "
                    + "[Keyname] = \"" + mykey.Keyname + "\"";


                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                //cmd.Parameters.AddWithValue("@TestID", test.TestID);



                try
                {
                    con.Open();
                    int m = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could delete key", ex);
                }
            }
        }

        public void DeleteTestDifficultKey(PracticeDifficultKeys mykey)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string insertCommand = "DELETE FROM PracticeDifficultkeys " +
                    "WHERE Username = \"" + mykey.Username + "\"" +
                    " AND Keyname = \"" + mykey.Keyname + "\"";


                OleDbCommand cmd = new OleDbCommand(insertCommand, con);
                //cmd.Parameters.AddWithValue("@TestID", test.TestID);



                try
                {
                    con.Open();
                    int m = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Could delete key", ex);
                }
            }
        }

        #endregion Delete test difficult key
        #endregion Delete
    }
}
