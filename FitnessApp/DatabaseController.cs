using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics;

namespace FitnessApp
{
    class DatabaseController
    {
        private const string HOST = "http://ec2-18-221-180-80.us-east-2.compute.amazonaws.com:3000";
        private const string DATE_FORMAT = "yyyy-MM-dd";
        private const string KEY_PASSWORD = "password";
        private const string KEY_RECORD_TYPE = "recordType";
        private const string KEY_USERNAME = "username";
        private const string MOZILLA = "Mozilla/5.0";
        //find date formatter
        private const string USER_AGENT = "User-Agent";

        public static string BODYWEIGHT_RECORD = "BodyweightRecord";
        public const string BODYWEIGHT_RECORD_LIST = "bodyweightRecords";
        public static string CALORIE_RECORD = "CalorieRecord";
        public const string CALORIE_RECORD_LIST = "calorieRecords";
        public static string EXERCISE = "Exercise";
        public const string EXERCISE_LIST = "exercises";
        public static string EXERCISE_RECORD = "ExerciseRecord";
        public const string EXERCISE_RECORD_LIST = "exerciseRecords";

        private string username;
        private string password;

        public DatabaseController() { }

        private HttpWebRequest establishRequest(string requestUrl, string method) {
            try {
                string uri = HOST + requestUrl;
                Console.WriteLine(uri);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                req.UserAgent = MOZILLA;
                req.Credentials = CredentialCache.DefaultCredentials;
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = method;
                return req;
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return null;
        }
        private bool resolveStatusCode(HttpWebResponse response) {
            HttpStatusCode code = response.StatusCode;
            if (code == HttpStatusCode.Accepted || code == HttpStatusCode.OK) { return true; }
            else {
                Console.WriteLine(code);
                Console.WriteLine(response.StatusDescription);
            }
            return false;
        }
        private bool streamJObject(JObject o, HttpWebRequest req) {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(o.ToString());
                req.ContentType = (bytes.Length).ToString();
                req.GetRequestStream().Write(bytes, 0, bytes.Length);
                req.GetRequestStream().Close();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        private JObject RecordToJObject(object o)
        {
            if (o is Exercise)
            {
                return new JObject(
                    new JProperty("id", ((Exercise)o).getId()),
                    new JProperty("name", ((Exercise)o).getName()),
                    new JProperty("date", ((Exercise)o).getRecordDate().ToString(DATE_FORMAT))
                    );
            }
            else if (o is ExerciseRecord)
            {
                return new JObject(
                    new JProperty("id", ((ExerciseRecord)o).getId()),
                    new JProperty("exerciseID", ((ExerciseRecord)o).getExerciseId()),
                    new JProperty("weight", ((ExerciseRecord)o).getWeight()),
                    new JProperty("date", ((ExerciseRecord)o).getRecordDate().ToString(DATE_FORMAT))
                    );
            }
            else if (o is CalorieRecord)
            {
                return new JObject(
                    new JProperty("id", ((CalorieRecord)o).getId()),
                    new JProperty("calories", ((CalorieRecord)o).getCalories()),
                    new JProperty("date", ((CalorieRecord)o).getRecordDate().ToString(DATE_FORMAT))
                    );
            }
            else if (o is BodyweightRecord)
            {
                return new JObject(
                    new JProperty("id", ((BodyweightRecord)o).getId()),
                    new JProperty("weight", ((BodyweightRecord)o).getWeight()),
                    new JProperty("date", ((BodyweightRecord)o).getRecordDate().ToString(DATE_FORMAT))
                    );
            }
            return null;
        }

        private string getResponseData(HttpWebResponse res)
        {
            Stream stream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string line = "";
            string data = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                data += line;
            }
            return data;
        }

        public bool Login(string username, string password) {
            try
            {
                HttpWebRequest req = establishRequest("/login",WebRequestMethods.Http.Post);
                JObject o = new JObject(
                    new JProperty(KEY_USERNAME, username),
                    new JProperty(KEY_PASSWORD, password)
                    );
                streamJObject(o,req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    this.username = username;
                    this.password = password;
                    res.Close();
                    return true;
                }
                res.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public bool AddUser(string username, string password) {
            try {
                HttpWebRequest req = establishRequest("/add/user/",WebRequestMethods.Http.Post);
                JObject user = new JObject(
                    new JProperty(KEY_USERNAME, username),
                    new JProperty(KEY_PASSWORD, password)
                    );
                streamJObject(user,req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    res.Close();
                    return true;
                }
                
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }

        public bool RemoveUser() {
            try {
                HttpWebRequest req = establishRequest("/remove/user/","DELETE");
                Console.WriteLine(this.username);
                Console.WriteLine(this.password);
                JObject user = new JObject(
                    new JProperty(KEY_USERNAME,this.username),
                    new JProperty(KEY_PASSWORD,this.password)
                    );
                streamJObject(user,req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    res.Close();
                    return true;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool UpdatePassword(string newPassword, string confirmedPassword) {
            try {
                HttpWebRequest req = establishRequest("/update/password",WebRequestMethods.Http.Put);
                JObject o = new JObject(
                    new JProperty(KEY_USERNAME,this.username),
                    new JProperty("oldPassword",this.password),
                    new JProperty("newPassword",newPassword),
                    new JProperty("confirmedPassword",confirmedPassword)
                    );
                streamJObject(o, req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    this.password = newPassword;
                    res.Close();
                    return true;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }

        public bool AddRecord(string rType, object record) {
            try {
                HttpWebRequest req = establishRequest("/add/",WebRequestMethods.Http.Post);
                JObject o = RecordToJObject(record);
                o.Add(KEY_USERNAME,this.username);
                o.Add(KEY_PASSWORD,this.password);
                o.Add("recordType",rType);
                streamJObject(o,req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    res.Close();
                    return true;
                }
            } catch(Exception e){ Console.WriteLine(e.ToString()); }
            return false;
        }
        
        public bool DeleteRecord(string rType, object record) {
            try {
                HttpWebRequest req = establishRequest("/remove/","DELETE");
                JObject o = RecordToJObject(record);
                o.Add(KEY_USERNAME, username);
                o.Add(KEY_PASSWORD, password);
                o.Add(KEY_RECORD_TYPE, rType);
                streamJObject(o,req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    res.Close();
                    return true;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool EditRecord(string rType, object record) {
            try {
                HttpWebRequest req = establishRequest("/update/",WebRequestMethods.Http.Put);
                JObject o = RecordToJObject(record);
                o.Add(KEY_USERNAME, username);
                o.Add(KEY_PASSWORD, password);
                o.Add(KEY_RECORD_TYPE, rType);
                streamJObject(o,req);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    res.Close();
                    return true;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        //NEEDS TESTING
        public int GenerateID(string rType) {
            try {
                string getUrl = "/" + username + "/" + password + "/generate/" + rType + "/id";
                HttpWebRequest req = establishRequest(getUrl,WebRequestMethods.Http.Get);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    string data = getResponseData(res);
                    int id = Convert.ToInt32(data);
                    res.Close();
                    return id;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return -1;
        }

        //NEEDS TESTING
        public int GetID(string rType, string name) {
            try {
                name = name.Replace(" ","&");
                string getUrl = "/getID/" + username + "/" + password + "/" + name + "/" + rType;
                HttpWebRequest req = establishRequest(getUrl, WebRequestMethods.Http.Get);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    string data = getResponseData(res);
                    int id = Convert.ToInt32(data);
                    res.Close();
                    return id;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return -1;
        }

        public Exercise[] GetExerciseList() {
            object[] list = GetRecordList(EXERCISE_LIST);
            if (list == null) { return new Exercise[0]; }
            Exercise[] exList = new Exercise[list.Length];
            for (int i = 0; i < list.Length; i++) {
                Console.WriteLine(exList[i]);
                exList[i] = (Exercise)list[i];
            }
            return exList;
        }
        public ExerciseRecord[] GetExerciseRecordList() {
            object[] list = GetRecordList(EXERCISE_RECORD_LIST);
            if (list == null) { return new ExerciseRecord[0]; }
            ExerciseRecord[] exrList = new ExerciseRecord[list.Length];
            for (int i = 0; i < list.Length; i++) {
                exrList[i] = (ExerciseRecord)list[i];
            }
            return exrList;
        }
        public ExerciseRecord[] GetExerciseRecordList(int exID) {
            object[] list = GetRecordList(EXERCISE_RECORD_LIST, exID);
            if (list == null) { return new ExerciseRecord[0]; }
            ExerciseRecord[] exrList = new ExerciseRecord[list.Length];
            for (int i = 0; i < list.Length; i++) {
                exrList[i] = (ExerciseRecord)list[i];
            }
            return exrList;
        }
        public CalorieRecord[] GetCalorieRecordList() {
            object[] list = GetRecordList(CALORIE_RECORD_LIST);
            if (list == null) { return new CalorieRecord[0]; }
            CalorieRecord[] crList = new CalorieRecord[list.Length];
            for (int i = 0; i < list.Length; i++) {
                crList[i] = (CalorieRecord)list[i];
            }
            return crList;
        }
        public CalorieRecord[] GetCalorieRecordList(DateTime d) {
            object[] list = GetRecordList(CALORIE_RECORD_LIST,d);
            if (list == null) { return new CalorieRecord[0]; }
            CalorieRecord[] crList = new CalorieRecord[list.Length];
            for (int i = 0; i < list.Length; i++) {
                crList[i] = (CalorieRecord)list[i];
            }
            return crList;
        }
        public BodyweightRecord[] GetBodyweightRecordList() {
            object[] list = GetRecordList(BODYWEIGHT_RECORD_LIST);
            if (list == null) { return new BodyweightRecord[0]; }
            BodyweightRecord[] bwrList = new BodyweightRecord[list.Length];
            for (int i = 0; i < list.Length; i++) {
                bwrList[i] = (BodyweightRecord)list[i];
            }
            return bwrList;
        }

        private object[] GetRecordList(string rList) {
            try {
                string getUrl = "/users/"+username+"/"+password+"/"+rList;
                HttpWebRequest req = establishRequest(getUrl, WebRequestMethods.Http.Get);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    string data = getResponseData(res);
                    JArray jData = JArray.Parse(data);
                    Console.WriteLine(jData);
                    object[] recordArray = JArrayToObjectArray(jData,rList);
                    return recordArray;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return new object[0];
        }
        
        private object[] GetRecordList(string rListType, int fKey) {
            try {
                string getUrl = "/users/" + username + "/" + password + "/" + rListType+"/exID/"+fKey;
                HttpWebRequest req = establishRequest(getUrl, WebRequestMethods.Http.Get);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    string data = getResponseData(res);
                    JArray jData = JArray.Parse(data);
                    Console.WriteLine(jData);
                    object[] recordArray = JArrayToObjectArray(jData,rListType);
                    return recordArray;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return new object[0];
        }
        private object[] GetRecordList(string rListType, DateTime d) {
            try {
                string getUrl = "/users/" + username + "/" + password + "/" + rListType + "/" + d.ToString(DATE_FORMAT);
                HttpWebRequest req = establishRequest(getUrl, WebRequestMethods.Http.Get);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (resolveStatusCode(res)) {
                    string data = getResponseData(res);
                    JArray jData = JArray.Parse(data);
                    Console.WriteLine(jData);
                    object[] recordArray = JArrayToObjectArray(jData,rListType);
                    return recordArray;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return new object[0];
        }
        private object[] JArrayToObjectArray(JArray arr,string rList) {
            Console.WriteLine("Method: JArrayToObjectArray");
            try {
                object[] objArr = new object[arr.Count];
                Console.WriteLine(arr.Count);
                for (int i = 0; i < objArr.Length; i++) {
                    JObject jObj = (JObject)arr.Children().ElementAt(i);
                    
                    Console.WriteLine(jObj);
                    int id = (int)jObj.GetValue("id");
                    string dateStr = jObj.GetValue("date").ToString();
                    DateTime date = DateTime.Parse(dateStr);
                    
                    switch (rList) {
                        case EXERCISE_LIST:
                            string name = jObj.GetValue("name").ToString();
                            objArr[i] = new Exercise(id,name,date);
                            break;
                        case EXERCISE_RECORD_LIST:
                            int exID = (int)jObj.GetValue("exerciseID");
                            double weight = (double)jObj.GetValue("weight");
                            objArr[i] = new ExerciseRecord(id,exID,weight,date);
                            break;
                        case CALORIE_RECORD_LIST:
                            int calories = (int)jObj.GetValue("calories");
                            objArr[i] = new CalorieRecord(id,calories,date);
                            break;
                        case BODYWEIGHT_RECORD_LIST:
                            double bWeight = (double)jObj.GetValue("weight");
                            break;
                    }
                }
                return objArr;
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return new object[0];
        }

        //static void Main() {
        //    DatabaseController dc = new DatabaseController();
        //    //Trace.Assert(dc.AddUser("test1","pass"),"Failed to add user!");
        //    bool loggedIn = dc.Login("user1","p123");
        //    Trace.Assert(loggedIn == true,"Failed to login");
        //    //Trace.Assert(dc.UpdatePassword("pass","pass"),"Failed to update password");
        //    //Trace.Assert(dc.RemoveUser(),"Failed to remove user");
        //    //Exercise ex = new Exercise(1,"Dumbell Shrug",DateTime.Now);
        //    //Trace.Assert(dc.AddRecord(EXERCISE,ex),"Failed to add record");
        //    //ex.setName("Shoulder Press");
        //    //Trace.Assert(dc.EditRecord(EXERCISE,ex),"Failed to edit record");
        //    //Trace.Assert(dc.DeleteRecord(EXERCISE,ex),"Failed to remove record");
        //    Trace.Assert(dc.GetExerciseList().Length != 0,"Exercise list length should be greater than 0");
        //    Trace.Assert(dc.GetExerciseRecordList().Length != 0, "Exercise Record list length should be greater than 0");
        //    Trace.Assert(dc.GetBodyweightRecordList().Length != 0, "Bodyweight record list should be greater than 0");
        //}
    }
    
}
