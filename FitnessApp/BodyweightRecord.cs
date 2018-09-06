using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    class BodyweightRecord
    {
        private int id;
        private double weight;
        private DateTime recordDate;

        public BodyweightRecord() { }
        public BodyweightRecord(int id, double weight, DateTime recordDate) {
            this.id = id;
            this.weight = weight;
            this.recordDate = recordDate;
        }
        public void setId(int id) { this.id = id; }
        public void setWeight(double weight) { this.weight = weight; }
        public void setRecordDate(DateTime recordDate) { this.recordDate = recordDate; }

        public int getId() { return this.id; }
        public double getWeight() { return this.weight; }
        public DateTime getRecordDate() { return this.recordDate; }
        public override string ToString()
        {
            return "{" + "id: " + this.id + ", weight: " + this.weight + ", date: " + recordDate + "}";
        }
    }
}
