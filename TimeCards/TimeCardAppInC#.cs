/*
To build a simple window where an employee can enter their times and submit them to the database, you can use a programming language and a framework with support for creating graphical user interfaces (GUIs) and connecting to databases. Here's an outline of the process using C# and Windows Forms with a SQL database:

Set up your development environment:

Install Visual Studio if you haven't already: https://visualstudio.microsoft.com/downloads/
Make sure you have the ".NET desktop development" workload installed.
Create a new Windows Forms App project:

Open Visual Studio and select "Create a new project".
Choose "Windows Forms App (.NET)" as the project template.
Enter a name and location for your project and click "Create".
Design the form:

Open the "Form1.cs [Design]" file in the Solution Explorer.
Drag and drop components like labels, text boxes, and buttons onto the form to create the desired layout for entering times and submitting the data. You can find the components in the Toolbox panel.
Set up the database connection:

Install the appropriate NuGet package for your database system (e.g., System.Data.SqlClient for SQL Server, MySql.Data for MySQL, or Npgsql for PostgreSQL).
Create a method to establish a connection to the database using the corresponding data provider.
Add the "Submit" button click event handler:

Double-click the "Submit" button in the form designer to generate an event handler in the code behind (Form1.cs).
In the event handler, retrieve the values entered in the text boxes and validate the data as necessary.
Use the established database connection to execute an INSERT query to add a new row to the TimeCard table with the entered values.
Here's a code snippet for the "Submit" button click event handler in C#: 
 * */



using System;

private void btnSubmit_Click(object sender, EventArgs e)
{
    // Retrieve and validate the entered data
    DateTime dateWorked = dateTimePickerDateWorked.Value;
    DateTime timeStart = dateTimePickerTimeStart.Value;
    DateTime lunchStart = dateTimePickerLunchStart.Value;
    DateTime lunchEnd = dateTimePickerLunchEnd.Value;
    DateTime timeOver = dateTimePickerTimeOver.Value;
    DateTime addTimeStart = dateTimePickerAddTimeStart.Value;
    DateTime addTimeOver = dateTimePickerAddTimeOver.Value;

    // Insert the data into the TimeCard table
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string query = @"INSERT INTO TimeCard (Date_Worked, TimeStart, LunchStart, LunchEnd, TimeOver, AddTimeStart, AddTimeOver)
                         VALUES (@Date_Worked, @TimeStart, @LunchStart, @LunchEnd, @TimeOver, @AddTimeStart, @AddTimeOver)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Date_Worked", dateWorked);
            command.Parameters.AddWithValue("@TimeStart", timeStart);
            command.Parameters.AddWithValue("@LunchStart", lunchStart);
            command.Parameters.AddWithValue("@LunchEnd", lunchEnd);
            command.Parameters.AddWithValue("@TimeOver", timeOver);
            command.Parameters.AddWithValue("@AddTimeStart", addTimeStart);
            command.Parameters.AddWithValue("@AddTimeOver", addTimeOver);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Time entry successfully submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to submit time entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
``
