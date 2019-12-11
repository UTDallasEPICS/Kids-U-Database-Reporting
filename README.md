# kidsuDB: Kids-U Database Refresh:



## Description:

The goal of this project is the refresh the Kids-U staff website and the database system, with new features. 
Because we were unable to get the source code for the current website, we have started rebuilding the website from scratch. 

### Framework:

The current website is being hosted by [Everleap](https://www.everleap.com), which supports web applications written using the ASP.NET framework. To ensure that Kids-U can continue using this hosting service, we are using ASP.NET MVC.

### Database:

We originally attempted to use MySQL for our database, but ran into issues connecting the database with our project on Visual Studio. We have switched over to Microsoft SQL Server. So far, things appear to me moving more smoothly.

### Other Software:

- Visual Studio for ASP.NET MVC
- Microsoft SQL Server
- Microsoft Windows (We've had issues with MacOS)



## Requirements:

### Rebuilding:

- Replicated front-end UI
- Database w/ information for student, staff, schools, sites, etc.
- Ability to add new students and other data to database
- Ability to view basic table of information on each page
- Ability to export CSV files of information

### Search/Filter/Sort:

- Ability to search for students by name on relevant pages
- Advanced Search feature to filter the list of students based on certain information
- Sort-by feature that allows the list of students to be ordered based on certain information
- Ability to export CSV files of sorted/filtered results

### Progress Reporting:

- Long-term academic tracking system for students
- Ability to generate a student progress report based on accumulated data
- Ability to sort/search/filter students based on progress report results



## Progress:

### So far we have:

- Replicated the front end design for most of the pages of the current website. Some additional pages may be missing (e.g. edit interface). The front end is currently not dynamic, so the code will need to be adjusted to display the correct information from the database. 
- Began rebuilding the database and filling the database with dummy data.
- Began connecting the database to the project.

### To-Do:

- Add ability to add new students and other data to database
- Add ability to view information on each page
- Add ability to export CSV files of information
- Implement search feature
- Implement advanced searching
- Implement sorting
- Implement long-term academic tracking system for students
- Add ability to generate student progress reports
- Implement sort/search/filter functionality for progress report results
- Figure out deployment and hosting situation



## Overview of [Current Site](http://staff.kids-u.org):

### Login and Entry Portal:

- Nothing really special about the login page. We have added a temp button on our working revision to bypass the login for testing purposes. 
- The entry portal serves as a directory linking to all the other web pages. The navigation bar at the top of the page is shared on all the other pages. We have removed it from the login page on our revision because it serves no purpose on that page. We have also removed the attendance button from the navigation bar, because Kids-U no longer uses that page.

### Data Entry:

- The **enrollment** page displays all the student roster in a table.
- The **outcome measurements** page displays results of tests designed to measure student growth. The information displayed on this page was lost somehow previously, so the pages are currently empty.
- The **report cards** page displays report card grades of the students. Also, the information displayed on this page was also lost.
- The **attendance/meals** page has been removed because Kids-U not longer uses that page.

### Management:

- The **staff directory** page displays the staff roster in a table, along with a staff entry for each Kids-U site.
- The **program/facility sites** page displays a list of Kids-U sites.
- The **organizations** page displays a list of organizations associated with Kids-U.
- The **school districts** page displays a list of school districts that students attend. 
- The **schools** page displays a list of schools that students attend.

### Notes:

- We have replaced the create new and export buttons on each page with our new function bar in our revision. This function bar has new create new and export buttons, along with a sort-by dropdown, search bar, and advanced search menu.
- All of the pages have a details options that displays all the information on the entry on a separate page. It might be beneficial to remove the details option and display all the information on the primary table to avoid unnecessary complications and issues with sorting and searching by information that is not displayed. 



## Overview of Current Project:

### Code:

- **App_Start folder:** This folder contains RouteConfig.cs, which is used for communication with the browser.
- **Content folder:** This folder contains all the CSS and images used for the project. Currently we have 1 image used on the home page and 1 CSS file that we wrote that applies to all our pages (Site.css). The bootstrap CSS files were included with bootstrap.
- **Controllers folder:** This folder contains the controllers for the project. The controllers are basically classes that manage user interaction and flow control logic in MVC applications.
- **Scripts folder:** This folder contains all the Javascript for the project. Site.js is the only Javascript file we have written so far, everything else was added either by default or from other packages.
- **Views folder:** The folder contains the CSHTML files for the project. Each folder corresponds to a controller. The CSHTML files are similar to HTML with some small differences (e.g. linking between pages).
- **bin folder:** This folder contains compiled assemblies. You probably won't have to touch this folder unless something goes terribly wrong.
- **packages folder:** This folder contains the installed packages. You probably won't have to deal with this folder either.

- **.gitignore:** List of files and directories to be excluded when pushing to GitHub. These files all seem to contain local meta-data, so they were excluded to avoid merge conflicts. 
- **Global.asax & Global.asax.cs:** Handles application level events. We haven't needed to touch these files yet.
- **Web.config:** Contains the ASP.NET configuration settings that override settings in the Machine.config file, which exists somewhere on your local machine. A Web.config file also exists within the Views folder. I have had to edit these files a few times to fix errors that occurred after updating Visual Studios or certain packages (on MacOS).
- **packages.config:** Contains configuration settings for installed packages.
- **test.csproj & test.sln:** Contains information regarding the project and solution.

### Database:

- **Organizations:**
	- Contains information about organizations associated with Kids-U
	- Corresponds to **Organizations** page
- **Staff Directory:**
	- Contains staff information
	- Corresponds to **Staff Directory** page
	- May be used to store login information
	- Each facility also seems to have an entry in the staff directory page
- **Program Facility Sites:**
	- Contains information about each facility Kids-U uses to host programs
	- Corresponds to the **Program/Facility Sites** page
- **School Districts:**
	- Contains information about school districts
	- Corresponds to the **School Districts** page
	- One-to-many relationship with **Schools**
- **Schools:** 
	- Contains information about each school.
	- Corresponds to the **Schools** page
	- One-to-many relationship with **Students**
- **Students:**
	- Contains information about each student
	- Corresponds to the **Students** page
	- One-to-many relationship with **Outcome Measurements** and **Report Card**
- **Outcome Measurements:** 
	- Contains results for each student of pre- and post-tests designed to measure student growth
	- Corresponds to the **Outcome Measurements** page
- **Report Card:** 
	- Contains report card grades of each student
	- Corresponds to the **Report Cards** page
	- One-to-many relationship with **Reading**, **Language Arts**, and **Math**
- **Reading:** 
	- Contains report card grades for reading
	- Corresponds to the **Report Cards** page
- **Language Arts:**
	- Contains report card grades for language arts
	- Corresponds to the **Report Cards** page
- **Math:** 
	- Contains report card grades for math
	- Corresponds to the **Report Cards** page



## Relevant Links for Reference:

- [Retrieving data using a DataReader](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader)
- [Using SQL Queries in ASP.NET MVC 1](https://stackoverflow.com/questions/20772391/using-simple-queries-in-asp-net-mvc)
- [Using SQL Queries in ASP.NET MVC 2](https://stackoverflow.com/questions/43714608/how-to-use-sql-raw-query-in-asp-net-mvc-web-api)
- [Using SQL Queries in ASP.NET MVC 3](https://stackoverflow.com/questions/16807334/execute-raw-sql-query-in-asp-net-mvc-database-first-mode)
- [Using SQL Queries in ASP.NET MVC 4](https://stackoverflow.com/questions/12233746/asp-net-mvc-and-sql-queries)



## Code Snippets:

### SQL Queries:

**Sorting:**

	First Name A-Z		select * from test.students order by first_name asc;
	First Name Z-A		select * from test.students order by first_name desc;
	Last Name A-Z		select * from test.students order by last_name asc;
	Last Name Z-A		select * from test.students order by last_name desc;
	Enrolled Ascending	select * from test.students order by enrolled asc;
	Enrolled Descending	select * from test.students order by enrolled desc;
	Income Ascending	select * from test.students order by income asc;
	Income Descending	select * from test.students order by income desc;
	School A-Z		select * from test.students order by school asc;
	School Z-A		select * from test.students order by school desc;
	Kids-U Site A-Z		select * from test.students order by kidsu_site asc;
	Kids-U Site Z-A		select * from test.students order by kidsu_site desc;
	Grade Ascending		select * from test.students order by grade asc;
	Grade Descending	select * from test.students order by grade desc;

**Searching by name:**
	
	select * from test.students where first_name like "%<name>%" or last_name like "%<name>%";
	(<name> will be entered in search bar)

**Advanced (Students Page):**
	
	Ethnicity	select * from test.students where ethnicity like "<e>";
			(<e> is the ethnicity selected in the Advanced Search menu)
			select * from test.students where ethnicity like "<e>" or ethnicity like "<e2>" or ...
			(if multiple selections are required)

	Gender		select * from test.students where gender like "Male";
			select * from test.students where gender like "Female";
	
	Enrolled	select * from test.students where enrolled like "<n>";
			(<n> is the enrollment grade/age selected)

	Income		select * from test.students where income like "<20k";
			select * from test.students where income like "20k-25k";
			select * from test.students where income like ">25k";

	Free Lunch	select * from test.students where lunch like "Yes Free";
			select * from test.students where lunch like "No Free";

	School		select * from test.students where school like "<s>";
			(<s> is the school entered in the Advanced Search menu)

	Facility	select * from test.students where kidsu_site like "<f>";
			(<f> is the facility name entered in the Advanced Search menu)

	School Grade	select * from test.students where school_grade like "<n>";
			(<n> is the grade selected in the Advanced Search menu)



## Authors

- John Zhao (kxz170530@utdallas.edu)
- David Burgwin (dab180001@utdallas.edu)
- Utsav Malik (uxm170000@utdallas.edu)
- Rakeen Murtaza (mxm170055@utdallas.edu)
- Michael Villordon (mhv170000@utdallas.edu)