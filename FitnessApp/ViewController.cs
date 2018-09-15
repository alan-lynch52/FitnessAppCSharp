using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessApp
{
    class ViewController
    {
        public MainForm mainForm { get; set; }
        public LoginForm loginForm { get; set; }
        public NewUserForm newUserForm { get; set; }
        public ExerciseForm exerciseForm { get; set; }
        public ExerciseRecordForm exerciseRecordForm { get; set; }
        public CalorieRecordForm calorieRecordForm { get; set; }
        public BodyweightRecordForm bodyweightRecordForm { get; set; }

        public AddExerciseForm addExerciseForm { get; set; }
        public AddExerciseRecordForm addExerciseRecordForm { get; set; }
        public AddCalorieRecordForm addCalorieRecordForm { get; set; }
        public AddBodyweightRecordForm addBodyweightRecordForm { get; set; }

        public ModelController mc;

        ViewController() {
            mainForm = new MainForm();
            loginForm = new LoginForm();
            newUserForm = new NewUserForm();
            exerciseForm = new ExerciseForm();
            exerciseRecordForm = new ExerciseRecordForm();
            calorieRecordForm = new CalorieRecordForm();
            bodyweightRecordForm = new BodyweightRecordForm();

            addExerciseForm = new AddExerciseForm();
            addExerciseRecordForm = new AddExerciseRecordForm();
            addCalorieRecordForm = new AddCalorieRecordForm();
            addBodyweightRecordForm = new AddBodyweightRecordForm();

            mainForm.Left = loginForm.Left;
            mainForm.Top = loginForm.Top;
            newUserForm.Left = loginForm.Left;
            newUserForm.Top = loginForm.Top;
            exerciseForm.Top = loginForm.Top;
            exerciseForm.Left = loginForm.Left;
            exerciseRecordForm.Top = loginForm.Top;
            exerciseRecordForm.Left = loginForm.Left;
            calorieRecordForm.Top = loginForm.Top;
            calorieRecordForm.Left = loginForm.Left;
            bodyweightRecordForm.Left = loginForm.Left;
            bodyweightRecordForm.Top = loginForm.Top;

            addExerciseForm.Left = loginForm.Left;
            addExerciseForm.Top = loginForm.Top;
            addExerciseRecordForm.Left = loginForm.Left;
            addExerciseRecordForm.Top = loginForm.Top;
            addCalorieRecordForm.Left = loginForm.Left;
            addCalorieRecordForm.Top = loginForm.Top;
            addBodyweightRecordForm.Left = loginForm.Left;
            addBodyweightRecordForm.Top = loginForm.Top;



            mc = new ModelController();
        }
        public void Run() {
            initLoginForm();
            Application.Run(loginForm);
        }
        private void Exit() { Application.Exit(); }
        public void initLoginForm() {
            loginForm.loginBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                string username = loginForm.usernameTxt.Text;
                string password = loginForm.passwordTxt.Text;
                if (password == "" || username == "")
                {
                    //throw err
                    MessageBox.Show("Password or username left blank");
                }
                else {
                    if (mc.UserSignIn(username, password))
                    {
                        //loginForm.Close();
                        loginForm.Hide();
                        initMainForm();
                        mainForm.Show();
                    }
                    else { MessageBox.Show("Username or password incorrect"); }
                }
            });
            loginForm.newUserBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                loginForm.Hide();
                newUserForm.Show();
            });
        }
        public void initNewUserForm() {
            newUserForm.submitBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                string username = newUserForm.usernameTxt.Text;
                string password = newUserForm.passwordTxt.Text;
                string cPassword = newUserForm.cPasswordTxt.Text;
                if (username == "" || password == "" || cPassword == "") { MessageBox.Show("All fields must be complete"); }
                else {
                    if (password == cPassword)
                    {
                        if (mc.CreateUser(username, password, cPassword))
                        {
                            newUserForm.Hide();
                            mainForm.Show();
                        }
                        else { MessageBox.Show("Username already exists"); }
                    }
                    else { MessageBox.Show("Passwords must match"); }
                }
            });
            newUserForm.cancelBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                newUserForm.Hide();
                initLoginForm();
                loginForm.Show();
            });
        }
        public void initMainForm() {
            mainForm.exerciseBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                mainForm.Hide();
                initExerciseForm();
                exerciseForm.Show();
            });
            mainForm.exerciseRecordBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                mainForm.Hide();
                initExerciseRecordForm();
                exerciseRecordForm.Show();
            }); 
            mainForm.calorieRecordBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                mainForm.Hide();
                initCalorieRecordForm();
                calorieRecordForm.Show();
            });
            mainForm.bodyweightRecordBtn.Click += new EventHandler(delegate(object sender, EventArgs e){
                mainForm.Hide();
                initBodyweightRecordForm();
                bodyweightRecordForm.Show();
            });
            mainForm.logoutBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                mc.UserSignOut();
                mainForm.Hide();
                loginForm.Show();
            });
        }

        public void initExerciseForm() {
            //add button
            exerciseForm.addBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                exerciseForm.Hide();
                initAddExerciseForm();
                addExerciseForm.Show();
            });
            //back button
            exerciseForm.backBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                exerciseForm.Hide();
                mainForm.Show();
            });
            //list of exercises
            exerciseForm.exerciseList.DataSource = (new BindingSource()).DataSource = mc.GetExerciseNameList();
            exerciseForm.removeBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                string selected = (string)exerciseForm.exerciseList.SelectedItem;
                if (mc.DeleteExercise(selected)) {
                    MessageBox.Show("Removed");
                    exerciseForm.exerciseList.DataSource = mc.GetExerciseNameList();
                }
                else { MessageBox.Show("Failed to remove exercise"); }
            });
        }
        public void initAddExerciseForm() {
            //submit button
            addExerciseForm.submitBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                string exName = addExerciseForm.exerciseNameTxt.Text;
                if (exName != "") {
                    if (mc.CreateExercise(exName))
                    {
                        MessageBox.Show("Added Exercise");
                        addExerciseForm.Hide();
                        exerciseForm.Show();
                    }
                    else { MessageBox.Show("Failed to add to Exercise"); }
                }
                else { MessageBox.Show("Exercise name cannot be left blank"); }
            });
            //cancel button
            addExerciseForm.submitBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                addExerciseForm.Hide();
                exerciseForm.Show();
            });
        }

        public void initExerciseRecordForm() {
            //add button
            exerciseRecordForm.addBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                exerciseRecordForm.Hide();
                initAddExerciseRecordForm();
                addExerciseRecordForm.Show();
            });
            //back button
            exerciseRecordForm.backBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                exerciseRecordForm.Hide();
                mainForm.Show();
            });
            //combo box
            exerciseRecordForm.exerciseCmb.DataSource = mc.GetExerciseNameList();
            //exercise record list
            exerciseRecordForm.exerciseList.DataSource = mc.GetExerciseRecordList(
                (string)exerciseRecordForm.exerciseCmb.SelectedItem
                );
            //graph
            BindingSource bs = new BindingSource();
            bs.DataSource = mc.GetERWeightList(
                (string)exerciseRecordForm.exerciseCmb.SelectedItem
                );
            exerciseRecordForm.chart.DataSource = bs;
            //combo box event handler
            exerciseRecordForm.exerciseCmb.SelectionChangeCommitted += new EventHandler(delegate (object sender, EventArgs e) {
                string selected = (string)exerciseRecordForm.exerciseCmb.SelectedItem;
                //update list
                exerciseRecordForm.exerciseList.DataSource = (new BindingSource()).DataSource = mc.GetExerciseRecordList(selected);
                //update chart
                exerciseRecordForm.chart.DataSource = (new BindingSource()).DataSource = mc.GetERWeightList(selected);
            });
            //remove button
            exerciseRecordForm.removeBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                object toRemove = exerciseRecordForm.exerciseList.SelectedItem;
                if (mc.DeleteExerciseRecord(toRemove)) {
                    string selected = (string)exerciseRecordForm.exerciseCmb.SelectedItem;
                    //update list
                    exerciseRecordForm.exerciseList.DataSource = mc.GetExerciseRecordList(selected);
                    //update chart
                    exerciseRecordForm.chart.DataSource = mc.GetERWeightList(selected);
                }
            });
        }

        public void initAddExerciseRecordForm() {
            //exercise name list
            addExerciseRecordForm.exerciseCmb.DataSource = (new BindingSource()).DataSource = mc.GetExerciseNameList();
            //submit btn
            addExerciseRecordForm.submitBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                string exName = (string)addExerciseRecordForm.exerciseCmb.SelectedItem;
                double weight = Convert.ToDouble(addExerciseRecordForm.weightTxt.Text);
                if (exName != "")
                {
                    if (mc.CreateExerciseRecord(exName, weight))
                    {
                        MessageBox.Show("Added Exercise Record");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add exercise record");
                    }
                }
                else {
                    MessageBox.Show("Exercise Name cannot be left blank");
                }
            });
            //cancel btn
            addExerciseForm.cancelBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                addExerciseRecordForm.Hide();
                exerciseRecordForm.Show();
            });
        }


        public void initCalorieRecordForm() {
            //add button
            calorieRecordForm.addBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                calorieRecordForm.Hide();
                initAddCalorieRecordForm();
                addCalorieRecordForm.Show();
            });
            //back button
            calorieRecordForm.backBtn.Click += new EventHandler(delegate (object sender, EventArgs e) {
                calorieRecordForm.Hide();
                mainForm.Show();
            });
            //calorie text value
            calorieRecordForm.caloriesValueLbl.Text = mc.GetDailyCalories(DateTime.Now).ToString();
            
        }

        public void initAddCalorieRecordForm() {
            //submit button
            addCalorieRecordForm.submitBtn.Click += new EventHandler(delegate(object sender, EventArgs e){
                int calories = Convert.ToInt32(addCalorieRecordForm.caloriesTxt.Text);
                if (!(calories < 0)) {
                    if (mc.CreateCalorieRecord(calories))
                    {
                        MessageBox.Show("Added calorie record");
                        addCalorieRecordForm.Hide();
                        calorieRecordForm.Show();
                    }
                    else {
                        MessageBox.Show("Failed to add calorie record");
                    }
                }
                else { MessageBox.Show("Calories cannot be negative"); }
            });
            //cancel button
            addCalorieRecordForm.cancelBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                addCalorieRecordForm.Hide();
                calorieRecordForm.Show();
            });
        }
        public void initBodyweightRecordForm() {
            //add button
            bodyweightRecordForm.addBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                bodyweightRecordForm.Hide();
                initAddBodyweightRecordForm();
                addBodyweightRecordForm.Show();
            });
            //back button
            bodyweightRecordForm.backBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                bodyweightRecordForm.Hide();
                mainForm.Show();
            });
            //list
            object[] list = mc.GetBodyWeightRecordList();
            bodyweightRecordForm.bodyweightList.DataSource = list;
            //remove button
            bodyweightRecordForm.removeBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                object toRemove = bodyweightRecordForm.bodyweightList.SelectedItem;
                if (mc.DeleteBodyweightRecord(toRemove)) {
                    MessageBox.Show("Removed");
                    //update list
                    bodyweightRecordForm.bodyweightList.DataSource = mc.GetBodyWeightRecordList();
                    //update chart
                    bodyweightRecordForm.chart.DataSource = bodyweightRecordForm.bodyweightList;
                }
                else { MessageBox.Show("Failed to remove"); }
            });
            //chart
            bodyweightRecordForm.chart.DataSource = list;
        }
        public void initAddBodyweightRecordForm() {
            //submit button
            addBodyweightRecordForm.submitBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                double weight = Convert.ToDouble(addBodyweightRecordForm.weightTxt.Text);
                if (mc.CreateBodyweightRecord(weight))
                {
                    MessageBox.Show("Added bodyweight record");
                    addBodyweightRecordForm.Hide();
                    bodyweightRecordForm.Show();
                }
                else { MessageBox.Show("Failed to add bodyweight record"); }
            });
            //cancel button
            addBodyweightRecordForm.cancelBtn.Click += new EventHandler(delegate(object sender, EventArgs e) {
                addBodyweightRecordForm.Hide();
                bodyweightRecordForm.Show();
            });
        }
        [STAThread]
        static void Main(string[] args) {
            ViewController vc = new ViewController();
            vc.Run();
        }
    }
}
