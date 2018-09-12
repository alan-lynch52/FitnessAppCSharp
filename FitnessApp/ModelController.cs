using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    class ModelController
    {
        private DatabaseController dc;
        private string username;
        private string password;
        public ModelController() {
            dc = new DatabaseController();
        }
        public void UserSignOut() {
            this.username = null;
            this.password = null;
        }
        public bool UserSignIn(string username, string password) {
            try {
                if (dc.Login(username,password)) {
                    this.username = username;
                    this.password = password;
                    return true;
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool CreateUser(string username, string password, string confirmPassword) {
            try {
                if (password == confirmPassword && username != "" && password != "") {
                    if (dc.AddUser(username, password)) {
                        UserSignIn(username,password);
                        return true;
                    }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
            }

        public bool CreateBodyweightRecord(double weight) {
            try {
                if (!(weight <= 0.0)) {
                    int id = dc.GenerateID(DatabaseController.BODYWEIGHT_RECORD);
                    BodyweightRecord bwr = new BodyweightRecord(id,weight,DateTime.Now);
                    if (dc.AddRecord(DatabaseController.BODYWEIGHT_RECORD,bwr)) { return true; }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool CreateCalorieRecord(int calories) {
            try {
                if (!(calories <= 0)) {
                    int id = dc.GenerateID(DatabaseController.CALORIE_RECORD);
                    CalorieRecord cr = new CalorieRecord(id,calories,DateTime.Now);
                    if (dc.AddRecord(DatabaseController.CALORIE_RECORD, cr)) { return true; }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool CreateExercise(string name) {
            try {
                if (name != "") {
                    int id = dc.GenerateID(DatabaseController.EXERCISE);
                    if (id == -1) { return false; }
                    Exercise ex = new Exercise(id, name, DateTime.Now);
                    if (dc.AddRecord(DatabaseController.EXERCISE, ex)) { return true; }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool CreateExerciseRecord(string exName, double weight) {
            try {
                if (exName != "" && !(weight<0.0)) {
                    int exID = dc.GetID(DatabaseController.EXERCISE,exName);
                    if (exID == -1) { return false; }
                    int id = dc.GenerateID(DatabaseController.EXERCISE_RECORD);
                    if (id == -1) { return false; }
                    ExerciseRecord exr = new ExerciseRecord(id,exID,weight,DateTime.Now);
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }

        public bool DeleteBodyweightRecord(object o) {
            try {
                if (o != null) {
                    if (dc.DeleteRecord(DatabaseController.BODYWEIGHT_RECORD,o)) { return true; }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool DeleteCalorieRecord(object o) {
            try {
                if (o != null) {
                    if (dc.DeleteRecord(DatabaseController.CALORIE_RECORD, o)) { return true; }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool DeleteExercise(string exName) {
            try {
                if (exName != "") {
                    Exercise[] exList = dc.GetExerciseList();
                    foreach (Exercise e in exList) {
                        if (e.getName() == exName) {
                            if (dc.DeleteRecord(DatabaseController.EXERCISE, e)) { return true; }
                            else { return false; }
                        }
                    }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }
        public bool DeleteExerciseRecord(object o) {
            try {
                if (o != null) {
                    if (dc.DeleteRecord(DatabaseController.EXERCISE_RECORD,o)) { return true; }
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return false;
        }

        public double[] GetBWRWeightList() {
            BodyweightRecord[] bwrList = dc.GetBodyweightRecordList();
            double[] list = new double[bwrList.Length];
            for (int i = 0; i < bwrList.Length; i++) {
                list[i] = bwrList[i].getWeight();

            }
            return list;
        }
        public object[] GetBodyWeightRecordList() {
            return dc.GetBodyweightRecordList();
        }
        public object[] GetCalorieRecordList() {
            return dc.GetCalorieRecordList();
        }

        public int GetDailyCalories(DateTime d) {
            try {
                CalorieRecord[] dailyCals = dc.GetCalorieRecordList(d);
                int totalCalories = 0;
                foreach (CalorieRecord cr in dailyCals) { totalCalories += cr.getCalories(); }
                return totalCalories;
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return 0;
        }

        public double[] GetERWeightList(string name) {
            int index = 0;
            Exercise[] exList = dc.GetExerciseList();
            for (int i = 0; i < exList.Length; i++) {
                string curExName = exList[i].getName();
                if (curExName == name) {
                    index = i;
                    break;
                }
            }
            try {
                int exID = exList[index].getId();
                ExerciseRecord[] exrList = dc.GetExerciseRecordList(exID);
                double[] weights = new double[exrList.Length];
                for (int i = 0; i < exrList.Length; i++) {
                    weights[i] = exrList[i].getWeight();
                }
                return weights;
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
            return new double[0];
        }
        public string[] GetExerciseNameList() {
            Exercise[] exList = dc.GetExerciseList();
            string[] names = new string[exList.Length];
            for(int i = 0; i < exList.Length; i++) {
                names[i] = exList[i].getName();
            }
            return names;
        }

        public object[] GetExerciseRecordList(string name) {
            int index = 0;
            Exercise[] exList = dc.GetExerciseList();
            for (int i = 0; i < exList.Length; i++) {
                string curExName = exList[i].getName();
                if (curExName == name) {
                    index = i;
                    break;
                }
            }
            int exID = exList[index].getId();
            ExerciseRecord[] exrList = dc.GetExerciseRecordList(exID);
            return exrList;
        }
    }
}
