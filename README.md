# kidsuDB: Kids-U Database Refresh:

## Description:

The goal of this project is the refresh the Kids-U staff website and the database system, with new features. 
Because we were unable to get the source code for the current website, we have started rebuilding the website from scratch. 

### Framework:

The current website is being hosted by Everleap, which supports web applications written using the ASP.NET framework. To ensure that Kids-U can continue using this hosting service, we are using ASP.NET MVC.

### Database:

We originally attempted to use MySQL for our database, but ran into issues connecting the database with our project on Visual Studio. We have switched over to Microsoft SQL Server. So far, things appear to me moving more smoothly.

### Other Software:

Visual Studio for ASP.NET MVC
Microsoft SQL Server
Microsoft Windows (Mac only has limited support)

## Requirements:

## To-Do:

## Project Overview:

## Code Snippets:

### SQL Queries:

Sorting:

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

Searching by name:
	
	select * from test.students where first_name like "%<name>%" or last_name like "%<name>%";
	(<name> will be entered in search bar)

Advanced (Students Page):
	
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


