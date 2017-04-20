# ASP.NET-WindowsFormsSample.

The Power BI WinForms sample shows you how to

- Register a Power BI ASP.NET web app in web browser in Window Form.
- Create a simple Power BI app that load list of reports into a textbox, and show embedded report in web-browser.

	- Use **PowerBIClient** to get a list of reports.
	- Use **PowerBIToken.CreateReportEmbedToken** to create an embed token.
	- User selects one report.
	- Navigate using a web browser to the Embed URL of the selected report.
	- using postMessage, invoke loadReport javascript method to load the embedded report with embed token.
