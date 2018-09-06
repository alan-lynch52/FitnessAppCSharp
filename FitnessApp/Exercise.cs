using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    class Exercise
    {
        private int id;
        private String name;
        private DateTime recordDate;
        public Exercise() {}
        public Exercise(int id, String name, DateTime recordDate) {
            this.id = id;
            this.name = name;
            this.recordDate = recordDate;
        }
        public void setId(int id) { this.id = id; }
        public void setName(String name) { this.name = name; }
        public void setDate(DateTime date) { this.recordDate = date; }
        public int getId() { return this.id; }
        public String getName() { return this.name; }
        public DateTime getRecordDate() { return this.recordDate; }
        public override string ToString()
        {
            return "{" + "id: " + this.id + ", name: "+ this.name + ", date: "+ this.recordDate+"}";
        }
    }
}
