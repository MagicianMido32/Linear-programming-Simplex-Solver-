using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Solvers;
using Microsoft.SolverFoundation.Services;
using System.IO;
namespace Linear_Programming_Solver
{
    public partial class Form1 : Form
    {
        SolverContext context = SolverContext.GetContext();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tpcom.SelectedIndex = 0;//object function type combobox
            cmbAlgorithm.SelectedIndex = 0;//Algorithm type combobox
        }
 private void Solv_Click(object sender, EventArgs e)
        {
     //Coded by : Mohammed Al Sayed 
     //Zagzig university ,Group B section 13
            if (Objtxt.Text == "")
            {
                MessageBox.Show("Please Enter The Object Function", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            try
            {
                Objtxt.Text = Objtxt.Text.ToLower().TrimEnd(Environment.NewLine.ToCharArray());//triming newline at the end
                string objectfunction = Objtxt.Text;

                //begin Setting object function

                Model model = context.CreateModel();//Creating Linear Programming Model

                for (int i = 0; i < objectfunction.Length; i++)
                {                                             //extracting Variables and adding decisions
                    if (char.IsNumber(objectfunction[i]) && char.IsLetter(objectfunction[i + 1]))
                    {
                        objectfunction = objectfunction.Insert(i + 1, "*");//Parsing text into an acceptable Term like 2*x+3*y  >> 2x become 2*x
                    }
                    else if (char.IsLetter(objectfunction[i])) 
                                                              
                    {
                        //Adding Decisions(Variables) into model
                        model.AddDecision(new Decision(Domain.RealNonnegative, objectfunction[i].ToString()));//each literal represent a variable
                    }
                }
                //end setting object function

                //begin SettingConstrains
                if (Cnstrntxt.Text == "")
                {
                    MessageBox.Show("Please Enter The Constrains", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                }

                Cnstrntxt.Text = Cnstrntxt.Text.ToLower().TrimEnd(Environment.NewLine.ToCharArray()); //removing newline at the end of the text
                string constrainsRaw = Cnstrntxt.Text;
                //parsing text into an acceptable MOL term ,, something like that 2*x+4*y a programatic equation
                for (int i = 0; i < constrainsRaw.Length - 1; i++)
                {
                    if (char.IsNumber(constrainsRaw[i]) && char.IsLetter(constrainsRaw[i + 1]))//2X
                    {
                        constrainsRaw = constrainsRaw.Insert(i + 1, "*");//2*x

                    }
                }
                //spliting constrains
                string[] constrains = constrainsRaw.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i <= constrains.GetUpperBound(0); i++)
                {
                    model.AddConstraint("Constrain_" + i.ToString(), constrains[i]);//each line represent a constrain
                }
                //end setting constrains

                //begin setting goal
                GoalKind goal;  //defining a goal 
                if (tpcom.SelectedIndex == 1)//goal type 
                {
                    goal = GoalKind.Minimize;
                }
                else
                {
                    goal = GoalKind.Maximize;
                }

                model.AddGoal("target", goal, objectfunction);
                //end setting goal

            //begin solving 
                
                SimplexDirective simplxReactor = new SimplexDirective();            ///solver object 
                if (Chksensitivity.Checked) simplxReactor.GetSensitivity = true; //sensitivity
                if (ChkInfeasibility.Checked) simplxReactor.GetInfeasibility = true; //infeasibility
                if (cmbAlgorithm.SelectedIndex == 1) simplxReactor.Algorithm = SimplexAlgorithm.Dual; //Algorithm used
                Solution solution = context.Solve(simplxReactor);
              
          
                Report report = solution.GetReport(); //defining a report


                if (ChkFullReport.Checked) txtreport.Text = report.ToString();//presenting the report in report textbox
                 ResultTextbox.Text = ""; //removing old values if existed
                 ResultTextbox.Text = solution.Goals.First().ToDouble().ToString();

                 VarResultTextbox.Text = "";
                foreach (Decision d in model.Decisions) //adding decisions(variables) and they production size in variable textbox
                {

                    VarResultTextbox.Text += d.Name + " = " + d.ToString() + Environment.NewLine;
                }

                //Duals aka shadow prices
                if (chkdual.Checked)
                {
                    txtdual.Text = "";//removing old values if existed
                    LinearReport lin = ((LinearReport)solution.GetReport());//generating a linear programming report out of the solution report

                    foreach (Microsoft.SolverFoundation.Services.Constraint constraint in model.Constraints)//getting constrains from the model 
                    {

                        foreach (var dual in lin.GetShadowPrices(constraint)) //getting the shadow prices for each constrain
                        {
                           
                            txtdual.Text += dual.Key + " = " + dual.Value.ToDouble().ToString() + Environment.NewLine;
                        }
                       
                    }

                }
                //end shadowprices

                //begin Sensitivity Analysis
                if(Chksensitivity.Checked)
                {
                    txtbound.Text = "";//removing old values if existed
                    LinearReport lin = ((LinearReport)solution.GetReport());//generating a linear programming report out of the solution report

                    foreach (Microsoft.SolverFoundation.Services.Constraint constraint in model.Constraints)//getting constrains from the model 
                    {

                        foreach (var bound in lin.GetConstraintBoundsSensitivity(constraint)) //getting the boundaries prices for each constrain
                        {
                            //parsing the boundaries into intervals
                            //opening the interval if infinity existed
                            txtbound.Text += bound.Key + " = " + bound.Value.Current.ToDouble().ToString() + Environment.NewLine +
                                (Double.IsInfinity(bound.Value.Lower.ToDouble()) ? "]" : "[") + bound.Value.Lower.ToDouble().ToString() + " , " + bound.Value.Upper.ToDouble().ToString()  + (Double.IsInfinity(bound.Value.Upper.ToDouble()) ? "[" : "]")
                                +Environment.NewLine+Environment.NewLine
                                ;
                        }

                    }
                }
                context.ClearModel();//killing the model object so we can create a new one 

            //end solving

           //begin handling errors
            }

            catch (Exception ex)
            {
                context.ClearModel();
                txtreport.Text = "An Error have occured  If you're sure about you entries  "
                    + "Please Send this report to the programmer" + Environment.NewLine + Environment.NewLine;
                txtreport.Text += Objtxt.Text + Environment.NewLine + Environment.NewLine;
                txtreport.Text += Cnstrntxt.Text + Environment.NewLine + Environment.NewLine;


                txtreport.Text += ex.Message;
                txtreport.ForeColor = Color.Red;
                MessageBox.Show("Error,Please Check your entries" + Environment.NewLine + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            tabControl1.SelectedIndex = 1;
          //end handling errors
        }

        private void sv_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "report.txt";

            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {

                StreamWriter writer = new StreamWriter(save.OpenFile());


                writer.Write(txtreport.Text);
                writer.Dispose();

                writer.Close();
                MessageBox.Show("Report Saved");
            }
        }

        private void cpy_Click(object sender, EventArgs e)
        {
            if (txtreport.Text == "") return;
            Clipboard.SetText(txtreport.Text);
        }

        private void clrbtn_Click(object sender, EventArgs e)
        {
            Objtxt.Text = "";
            Cnstrntxt.Text = "";
            txtreport.Text = "";
            VarResultTextbox.Text = "";
            ResultTextbox.Text = "";
            tabControl1.SelectedIndex = 0;
        }

       
        private void aboutbtn_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    
    }
}
