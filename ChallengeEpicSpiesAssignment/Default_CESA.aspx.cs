using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default_CESA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //loads only when first accessing page - initilizing calendar controls
            {
                DateTime Today = DateTime.Today;
                previousAssignCalendar.SelectedDate = Today;
                newAssignCalendar.SelectedDate = Today.AddDays(+14);
                newAssignEndCalendar.SelectedDate = Today.AddDays(+21);
            }
        }
        
        protected void previousAssignCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime previousDate = previousAssignCalendar.SelectedDate;
            //selectedPreviousDateLabel.Text = previousDate.ToShortDateString(); //to display selected date
        }


        protected void newAssignCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime newDate = newAssignCalendar.SelectedDate;
            //selectedNewDateLabel.Text = newDate.ToString(); //to display selected date
        }

        protected void newAssignEndCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime newEndDate = newAssignEndCalendar.SelectedDate;
            //selectedNewEndDateLabel.Text = newEndDate.ToString(); //to display selected date
        }
        
      
        protected void assignButton_Click(object sender, EventArgs e)
        {
            DateTime Today = DateTime.Today;

            DateTime previousDate = previousAssignCalendar.SelectedDate;
            selectedPreviousDateLabel.Text = previousDate.ToShortDateString();//to display selected date when button is clicked.

            DateTime newDate = newAssignCalendar.SelectedDate;
            selectedNewDateLabel.Text = newDate.ToShortDateString();//to display selected date when button is clicked.

            DateTime newEndDate = newAssignEndCalendar.SelectedDate;
            selectedNewEndDateLabel.Text = newEndDate.ToShortDateString();//to display selected date when button is clicked.

            //String assignmentTimeLength; - DAYS FROM

            TimeSpan betweenAssignments = (previousDate - newDate).Duration(); //14 days between previous date & new date
            Double daysBetweenAssignments = Convert.ToDouble(betweenAssignments.TotalDays);
            
            TimeSpan assignmentStartEnd = (newDate - newEndDate).Duration(); //up to 3 weeks $500 day, more than 3 weeks $500 + $1000
            Double numberOfAssignmentDays = Convert.ToDouble(assignmentStartEnd.TotalDays);

            /*
            //String assignmentTimeLength;
            String assignmentBudgetTotal;
            //TimeSpan assignmentStartEnd = (previousDate - newDate).Duration();
            TimeSpan assignmentStartEnd = (previousDate - newDate).Duration();
            Double numberOfNewAssignmentDays;
            */

            double assignmentBudgetTotal;

            ///if (numberOfAssignmentDays < 14)
            if (daysBetweenAssignments < 14)
                {
                previousDate.AddDays(+14);
                newAssignCalendar.SelectedDate = previousDate.AddDays(+14);
                string selectedNewDateLabel = Convert.ToString(newAssignCalendar.SelectedDate);
                //string selectedNewDateLabel = Convert.ToString(previousDate.AddDays(+14));
                //selectedNewDateLabel.Text = Convert.ToString(previousDate.AddDays(+14));
                string outputLess14days = String.Format("Error: {0}, you must allow at least 2 weeks between " +
                    "Previous Assignment and New Assignment: (earliest start date of new assignment is:{1:d, M, yy}).", nameTextBox.Text, selectedNewDateLabel);
                outputLabel.Text = outputLess14days;
            }
            //else if ((14 <= numberOfAssignmentDays) && (numberOfAssignmentDays <= 21))//$500/day
            else if (numberOfAssignmentDays <= 21)//$500/day
            {
                double assignmentBudget = (numberOfAssignmentDays * 500);
                assignmentBudgetTotal = assignmentBudget;
                string outputResult = String.Format("Assignment of {0} to assignment {1} is authorized. Budget total: {2:C}", nameTextBox.Text, assignNameTextBox.Text, assignmentBudgetTotal);
                outputLabel.Text = outputResult;

            }
            else if (21 < numberOfAssignmentDays) //$500/day + $1000
            {
                double assignmentBudget = ((numberOfAssignmentDays * 500) + 1000);
                assignmentBudgetTotal = assignmentBudget;
                string outputResult = String.Format("Assignment of {0} to assignment {1} is authorized. Budget total: {2:C}", nameTextBox.Text, assignNameTextBox.Text, assignmentBudgetTotal);
                outputLabel.Text = outputResult;
            }
            /*else
            {
                assignmentTimeLength = assignmentStartEnd.ToString();
                //assignmentTimeLength = numberOfAssignmentDays.ToString();

                string outputResult = String.Format("Assignment of {0} to assignment {1} is authorized. Budget total: {2}", nameTextBox.Text, assignNameTextBox.Text, assignmentTimeLength);

                outputLabel.Text = outputResult;
            */
        }
            
    }

    
}