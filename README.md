﻿# Kids-U Database
# Do not commit updates to this repository. All future work should be done in the new repository.

## Description:

The goal of this project is to refresh the Kids-U staff website and database system with new features.

## Cloning and Running

The easiest way to run the project is by opening it in Visual Studio. Visual Studio has built in Git functionality for cloning a repository or you can clone it yourself and open the 'Kids-U-Database-Reporting.sln' file. Use the green arrow button that says 'IIS Express' to run the project.

To view or edit the database through Visual Studio, go to View > SQL Server Object Explorer. In the new window, open the MSSQLLocalDB > Databases > {database name} > Tables. This will display many databases in the form dbo.databaseName. Right click the specific database and choose 'View Data' to display the database in table form.

## Usage

### Outcome Measurements

On the main Outcome Measurement page, all students are listed with their most recently added Outcome Measurement. To view all of a specific student's Outcome Measurements, click on the row of the desired student. When creating a new Outcome Measurement, a list of all students is available. To quickly select a desired student from the list, click on the drop down element and begin typing the first name of the student.

### Report Cards

On the main Report Card page, all students are listed with their most recently added Report Card. To view all of a specific student's Report Cards, click on the row of the desired student. When creating a new Report Card, a list of all students is available. To quickly select a desired student from the list, click on the drop down element and begin typing the first name of the student.

### Students

To view all of the details about a student, click their row on the Student Enrollment page. New students can be created with the 'Create New' button located on the  Student Enrollment page. Deleting a student also deletes all associated report cards and outcome measurements.

### Roles

There are two roles available, "Global Administrator" and "Site Coordinator". The Global Administrator has access to everything and can directly edit other user accounts such as changing passwords. The Site Coordinator can not access any management pages, only the student pages. They can only see Students, Report Cards, and Outcome Measurements for students that are at their assigned site. The assigned site is set when the account is made and can be changed by a Global Administrator. 

### Searching and Sorting

The searching and sorting functionality is available on all three student data entry pages. To apply seach filters or a sort that has been selected, press the 'Go' button. The text input in the top right will search for case-insensitive partial matches in the first and last name of every student. The drop-down select boxes provide options for making more specific searches. At the top right of the table is the number of results returned and a percentage of total active students returned. This means the percentage is only accurate when 'Active: Yes' is selected. The default value of 'Active' is 'Yes'. To view inactive students, 'Active' must be changed to 'No'. 

## Known Issues
- Opening an edit page and submitting without making any changes results in an edit failed page.
- Sorting by Grade Ascending/Descending puts 'K' at the wrong end of the results.
- Editing a school or site name will not be reflected on students who are already created.
- Forms can be submitted without required areas being filled out. This results in an error and the entered data is lost and has to be reentered.

## Potential Goals
- Paging for the Student, OM, and RC pages so long results are easier to view and might be faster. I believe this requires rewriting several of the services so they return an IEnumerable. [Link](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application)
- Set up emails for password resets so Admins don't have to manually reset them.
- Talking with project partner we've mentioned better data visualization to show student progress over time. Could make a new page that shows graphs and charts to help visualize student performance. Would talk to project partner about this.

## Technical Design:

### Back Buttons

The back buttons dynamically link to the page that the user just came from instead of always returning to the same page. 

For example, a User on the Student Enrollment page clicks link to view a student’s Report Cards. The current url is passed to the View Report Card page via the returnUrl parameter. If the user then goes to the Edit page of a specific Report Card, the returnUrl is passed. When editing is finished, the same returnUrl is passed back to the View page. Now the user can hit back and it will return to the Student Enrollment page with all the search settings preserved.

### Common Services

The CommonService.cs class holds some functions that are used in multiple Controllers to avoid repetiton. Some functions are for creating a list of objects that is then used to create select lists for adding or editing different objects. For instance, when creating a new Report Card, the GetStudentNameList() function is called which gets every active student from the database that the user has permission to view.

 ### Permissions and Roles
 
Site Coordinators have limited access since they are only able to view students that are at the same site as the Coordinator. This is done in the Services by filtering out students that don't have the same site as the logged in user. If the user is a Global Administrator, no students are filtered. To get the current user, the Controller action calling the service passes in the current user's username. The service then looks up the user by username and is able to access their role and site.

### Searching and Sorting

Searching and sorting are handled together and both use the Search model to store their data and pass it between components. The Search model uses strings for every attribute and these strings are used in the Services to filter out results. If a string is null, it is not used for filtering since no selection was made. The Active attribute is defaulted to "True" to filter out inactive students. When the results return, the Search model is passed back to the SearchData attribute of StudentViewModel. This data is used to set the select boxes to the value that was last chosen. This is done by the setSelectValue() JavaScript function which is  called onload of the Index page and sets the value of each box.

### Select Lists

The SelectLists Model is used to ensure consistency and reduce repetition. For lists that are repeated multiple times, they are added to the SelectLists Model and this model is then passed to any Views through the Controller. Inside the View, these lists can be used to create a select list element using the asp-for attribute.

#### Made by [UT Dallas EPICS](https://sites.utdallas.edu/epics-kids-u/) for [Kids-U](http://kids-u.org)
#### Spring 2021 Team:
[Douglas Covington](https://github.com/DouglasCovington-iii)\
[Jaden Dick](https://github.com/jadendick)\
[Satyam Jadav](https://github.com/satyamjadav)\
Shriya Jejurkar\
Michael Menjivar

#### Spring 2020 Team: 
Donovan Johnson\
Ryan Le\
Ben Monical\
Humza Salman\
Julie Whitmore
