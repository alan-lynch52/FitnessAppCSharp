using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    class CalorieRecord
    {
        private int id;
        private int calories;
        private DateTime recordDate;

        public CalorieRecord() { }
        public CalorieRecord(int id, int calories, DateTime recordDate) {
            this.id = id;
            this.calories = calories;
            this.recordDate = recordDate;
        }

        public void setId(int id) { this.id = id; }
        public void setCalories(int calories) { this.calories = calories; }
        public void setRecordDate(DateTime recordDate) { this.recordDate = recordDate; }

        public int getId() { return this.id; }
        public int getCalories() { return this.calories; }
        public DateTime getRecordDate() { return this.recordDate; }
        public override string ToString()
        {
            return "{" + "id: " + this.id + ", calories: " + this.calories + ", date: " + this.recordDate + "}";
        }
    }
}
