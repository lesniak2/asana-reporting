AsanaCrescent
===============

Pull important data related to tasks within your team project from Asana into Excel.

##User Notes:
	1) You can find your API Key [here](http://app.asana.com/-/account_api)
	2) Workspaces will not show up if you don't enter your API Key correctly or you do not have internet.
	3) Reports are currently saved in a folder called "reports" which will be created in the same directory
		as the executable.
	4) Date data in reports currently represents the most recent time a task was moved from one section to another.
	5) Currently pulling data from sub-tasks in Asana is not supported
	6) Everything is pulled dynamically as you would see it on the Asana Website. This means that if you are the assignee on a task,
		you will see "me" in the appropriate cell in Excel.
	7) Excel will not display more than 50 columns. (That would be a lot of Asana sections! but it could happen...)
	8) Back buttons will be slow if the internet connection is slow, especially when populating tasks.
		
##Developer Notes:
	1) Crescent.Designer.cs will not need to be edited unless you are improving the interface itself.
	2) Crescent.cs is where the bulk of the code for handling the interface lies. Data from Asana is pulled
		asynchronously and so code must be written appropriately if making changes to this file. The data flow
		in this application looks like: www.asana.com -> AsanaNet -> Crescent.cs -> Parser.cs -> Crescent.cs -> ExcelMaster.cs.
	3) Where possible, if data needs to be manipulated try to make the changes in or directly after the call to Parser.ParseStories() in this flow chart.
	4) AsanaNet Library has been included with this project due to editing the library to suit the application. Edits are as follows:
			a) A try-catch has been implemented inside InitFunctions()  in order to avoid adding repeat Function keys if the user
				switches to a different API key without re-opening the program.
			b) In AsanaDateTime.cs, the format string in the ToString() method has been edited to include the hours and minutes.
	5) Parser.cs contains all of the logic for handling the parsing of data in the stories for a task. This is where you change things like getting the
		first date rather than the last.
	6) ExcelMaster.cs is a small Asana-to-Excel interop library. Everything from adding worksheets to making tables to saving
		the report is within this file. Note that there is a limit of 50 columns allowed at the moment, which can be freely changed or made 
		dynamic as needed.
	7) Current implementation is adding data to excel row by row. There is a method to add a 2D array to excel but this has not been implemented yet
		in Crescent.cs. You may find it useful to make additions to ProjectInExcel.cs to implement this.
		
##Developer ToDo:
	1) Implement ExcelMaster.AddDataRange() in Cresent.cs instead of AddRow(). This theoretically will increase performance and reduce report 
		wait times.
	2) Nothing has been done to handle dropped internet connections in the middle of report generations or checkbox populations.
	3) -Optional- Add support for OAuth2 login