//Copyright Microsoft 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PBIRealTimeStreaming
{

    // Sample app demonstrating how to use the Power BI REST APIs for streaming data
    // Pushes current datetime and a random integer to the REST API every second
    // Full documentation: https://powerbi.microsoft.com/documentation/powerbi-service-real-time-streaming/

    // To run this sample:
    // 1. Go to app.powerbi.com
    // 2. Go to streaming data management page by via new dashboard > Add tile > Custom Streaming Data > manage data
    // 3. Click "Add streaming dataset"
    // 4. Select API, then Next, and give your streaming dataset a name
    // 5. Add a field with name "ts", type DateTime
    // 6. Add a field with name "value", type Number
    // 7. Click "Create"
    // 8. Copy the "push URL" and paste it as the value of "realTimePushURL" below

    class Program
    {

        // Paste your push URL below
        private static string realTimePushURL = "** paste your push URL here **";

        static void Main(string[] args)
        { 
            while (true) {
                try
                {
                    // Declare values that we're about to send
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    Random r = new Random();
                    int currentValue = r.Next(0, 100);

                    // Send POST request to the push URL
                    // Uses the WebRequest sample code as documented here: https://msdn.microsoft.com/en-us/library/debx8sh9(v=vs.110).aspx
                    WebRequest request = WebRequest.Create(realTimePushURL);
                    request.Method = "POST";
                    string postData = String.Format("[{{ \"ts\": {0}, \"value\":{1} }}]", unixTimestamp, currentValue);
                    Console.WriteLine(String.Format("Making POST request with data: {0}", postData));
                    
                    // Prepare request for sending
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;

                    // Get the request stream.
                    Stream dataStream = request.GetRequestStream();

                    // Write the data to the request stream.
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    // Close the Stream object.
                    dataStream.Close();

                    // Get the response.
                    WebResponse response = request.GetResponse();

                    // Display the status.
                    Console.WriteLine(String.Format("Service response: {0}", ((HttpWebResponse)response).StatusCode));

                    // Get the stream containing content returned by the server.
                    dataStream = response.GetResponseStream();

                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);

                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();

                    // Display the content.
                    Console.WriteLine(responseFromServer);

                    // Clean up the streams.
                    reader.Close();
                    dataStream.Close();
                    response.Close();

                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                // Wait 1 second before sending
                System.Threading.Thread.Sleep(1000);
            }
           
        }
    }
}
