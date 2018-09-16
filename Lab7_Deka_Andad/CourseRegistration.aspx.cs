using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class CourseRegistration : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (IsPostBack == false)
        {          
            // List course options on initial display using GetCourses() method

            foreach (Course course in Helper.GetCourses())
            {               
                // Create a check box option for each course in list using ToString Method from Course Classs
                CheckBoxList.Items.Add(course.ToString());
            }           
        } 
    }

    // Add student to list to use for the display table method 
    List<Student> studentType = new List<Student>();

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {            
            FullTimeStudent ftStudent = new FullTimeStudent(txtName.Text);

            studentType.Add(ftStudent); // Add the student to list

            foreach (ListItem chosenCourse in CheckBoxList.Items)
            {
                // if a course is selected do the following
                if (chosenCourse.Selected)
                {
                    try
                    {
                        // Add each selected course to the student's enrolled courses
                        foreach (Course course in Helper.GetCourses())
                        {
                            if (course.ToString() == chosenCourse.Text)
                            {
                                ftStudent.addCourse(course);
                            }
                        }                        
                    }
                    catch (Exception ex)
                    {
                        // Display error message if courses exceed 8 hours
                        lblError.Text = ex.Message;

                        // Continue with rest of code if there is no error
                        return;
                    }                   
                                      
                } // End of btn selection

            } // End of foreach                      

            // Display confirmation page for full-time student
            displayConfirmationPage(ftStudent);

        } // End of condition

        else if (RadioButton2.Checked)
        {
            PartTimeStudent ptStudent = new PartTimeStudent(txtName.Text);
            studentType.Add(ptStudent);

            foreach (ListItem chosenCourse in CheckBoxList.Items)
            {
                if (chosenCourse.Selected)
                {
                    try
                    {
                        foreach (Course course in Helper.GetCourses())
                        {
                            if (course.ToString() == chosenCourse.Text)
                            {                                
                                ptStudent.addCourse(course);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        return;
                    }

                } // end of btn selection

            } // end of foreach

            // Display confirmation page for part-time student
            displayConfirmationPage(ptStudent);

        } // end of condition

        else if (RadioButton3.Checked)
        {
            CoopStudent cpStudent = new CoopStudent(txtName.Text);
            studentType.Add(cpStudent);

            foreach (ListItem chosenCourse in CheckBoxList.Items)
            {
                if (chosenCourse.Selected)
                {
                    try
                    {
                        foreach (Course course in Helper.GetCourses())
                        {
                            if (course.ToString() == chosenCourse.Text)
                            {                                
                                cpStudent.addCourse(course);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        return;
                    }

                } // end of btn selection

            } // End of foreach

            // Display confirmation page for co-op student
            displayConfirmationPage(cpStudent);

        } // End of condition 

    } // End of btn submit method

    // Method to display confirmation page
    protected void displayConfirmationPage(Student studentStat)
    {   
        // Make a table for the student in the student list
        foreach (Student student in studentType)
        {
            // Make form contents disappear.
            optionsPage.Visible = false;

            // Display confirmation page
            confirmationPage.Visible = true;

            // Display the student's name that's in the list
            studentName.Text = student.Name;

            // Display the student's status
            studentStatus.Text = student.ToString();

            // Display basic table structure for student
            // Used this source for tables: How to Add Rows and Cells Dynamically to a Table Web Server Control
            // https://msdn.microsoft.com/en-us/library/7bewx260.aspx

            TableHeaderRow tableHeader = new TableHeaderRow();
            courseTable.Rows.Add(tableHeader);

            TableHeaderCell codeHeader = new TableHeaderCell();
            codeHeader.Text = "Course Code";
            tableHeader.Cells.Add(codeHeader);

            TableHeaderCell titleHeader = new TableHeaderCell();
            titleHeader.Text = "Course Title";
            tableHeader.Cells.Add(titleHeader);

            TableHeaderCell hoursHeader = new TableHeaderCell();
            hoursHeader.Text = "Weekly Hours";
            tableHeader.Cells.Add(hoursHeader);

            TableHeaderCell feeHeader = new TableHeaderCell();
            feeHeader.Text = "Fee Payable";
            tableHeader.Cells.Add(feeHeader);

            // For the student in the list, create table content for each course selected
            foreach (Course course in student.getEnrolledCourses())
            {
                // Create a table row
                TableRow tblRow = new TableRow();
                courseTable.Rows.Add(tblRow);

                // Create the row cells
                TableCell cellCode = new TableCell();
                cellCode.Text = course.Code;

                TableCell cellTitle = new TableCell();
                cellTitle.Text = course.Title;

                TableCell cellHours = new TableCell();
                cellHours.Text = course.WeeklyHours.ToString();

                TableCell cellFee = new TableCell();
                cellFee.Text = "$" + course.Fee.ToString();
                
                // Add course info seperately to each table cell
                tblRow.Cells.Add(cellCode);
                tblRow.Cells.Add(cellTitle);
                tblRow.Cells.Add(cellHours);
                tblRow.Cells.Add(cellFee);
            }

            // Create an additional table row for total hours and fee
            TableRow tblRowTotal = new TableRow();
            courseTable.Rows.Add(tblRowTotal);

            TableCell cellEmpty = new TableCell();
            cellEmpty.Text = "";
            tblRowTotal.Cells.Add(cellEmpty);

            TableCell cellTotalText = new TableCell();
            // Used similar method to align text based on second response on:
            // https://stackoverflow.com/questions/25245839/align-a-label-to-the-right-using-asp-net
            cellTotalText.Attributes.Add("Style", "text-align:right");
            cellTotalText.Text = "Total";
            tblRowTotal.Cells.Add(cellTotalText);

            TableCell cellTotalHours = new TableCell();
            cellTotalHours.Text = student.totalWeeklyHours().ToString();
            tblRowTotal.Cells.Add(cellTotalHours);

            TableCell cellTotalFee = new TableCell();
            cellTotalFee.Text = "$" + student.feePayable().ToString();
            tblRowTotal.Cells.Add(cellTotalFee);

        } // End of studentType list

    } // End of display confirmation page method

}