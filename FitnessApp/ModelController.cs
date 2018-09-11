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
        public bool UserSignOut() { return false; }
        public bool UserSignIn() { return false; }

        public bool CreateBodyweightRecord(double weight) { return false; }
        public bool CreateCalorieRecord(int calories) { return false; }
        public bool CreateExercise(string name) { return false; }
        public bool CreateExerciseRecord(string exName, double weight) { return false; }

        public bool DeleteBodyweightRecord(object o) { return false; }
        public bool DeleteCalorieRecord(object o) { return false; }
        public bool DeleteExercise(string exName) { return false; }
        public bool DeleteExerciseRecord(object o) { return false; }

        public double[] GetBWRWeightList() { return new double[0]; }
        public object[] GetBodyWeightRecordList() { return new object[0]; }
        public object[] GetCalorieRecordList() { return new object[0]; }
        public int GetDailyCalories() { return 0; }
        public double[] GetERWeightList() { return new double[0]; }
        public string[] GetExerciseNameList() { return new string[0]; }
        public object[] GetExerciseRecordList(string name) { return new object[0]; }



    }
}
