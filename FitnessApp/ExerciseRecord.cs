using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    class ExerciseRecord
    {
        private int id;
        private int exerciseId;
        private double weight;
        private DateTime recordDate;

        public ExerciseRecord() { }
        public ExerciseRecord(int id, int exerciseId, double weight, DateTime recordDate) {
            this.id = id;
            this.exerciseId = exerciseId;
            this.weight = weight;
            this.recordDate = recordDate;
        }

        public void setId(int id) { this.id = id; }
        public void setExerciseId(int exerciseId) { this.exerciseId = exerciseId; }
        public void setWeight(double weight) { this.weight = weight; }
        public void setRecordDate(DateTime recordDate) { this.recordDate = recordDate; }

        public int getId() { return this.id; }
        public int getExerciseId() { return this.exerciseId; }
        public double getWeight() { return this.weight; }
        public DateTime getRecordDate() { return this.recordDate; }
        public override string ToString()
        {
            return "{" + "id: " + this.id + ", exerciseId: " + this.exerciseId + ", weight: " + this.weight
                + ", date: " + this.recordDate + "}";
        }
    }
}
