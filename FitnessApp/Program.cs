using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Exercise ex = new Exercise(10,"DB Chest Press", DateTime.Now);
            ExerciseRecord exr = new ExerciseRecord(1, 10, 34.0, DateTime.Now);
            CalorieRecord cr = new CalorieRecord(5, 1050, DateTime.Now);
            BodyweightRecord bwr = new BodyweightRecord(3, 80.5, DateTime.Now);
            Console.WriteLine(ex);
            Console.WriteLine(exr);
            Console.WriteLine(cr);
            Console.WriteLine(bwr);

        }
    }
}
