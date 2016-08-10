Sample app for using the Power BI REST API for displaying real-time streaming data on dashboards
=

The Power BI getting started sample shows you how to use the Power BI REST API to send streaming data to your dashboards, for use in real-time tiles.

This sample pushes current datetime and a random integer to the REST API every second

To run this sample:

1. Go to app.powerbi.com
2. Go to streaming data management page by via new dashboard > Add tile > Custom Streaming Data > manage data
3. Click "Add streaming dataset"
4. Select API, then Next, and give your streaming dataset a name
5. Add a field with name "ts", type DateTime
6. Add a field with name "value", type Number
7. Click "Create"
8. Copy the "push URL" at the top of the page
9. Copy the sample app locally, and in Program.cs, paste url copied in step 8 as the value of "realTimePushURL"
10. Run the sample app
11. With the sample app running, go to the dashboard, and create a real-time tile with with the data provided by the sample app

For more information about real-time streaming, see the [documentation](https://powerbi.microsoft.com/documentation/powerbi-service-real-time-streaming/)

Also, see [Overview of Power BI REST API](https://msdn.microsoft.com/en-US/library/dn877544(Azure.100).aspx) on MSDN.
