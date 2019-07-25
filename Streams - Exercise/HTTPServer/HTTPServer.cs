using System;
using System.IO;
using System.Net;
using System.Text;

namespace HTTPServer
{
    public class HTTPServer
    {
        public static void Main()
        {
            HttpListener server = new HttpListener();  // this is the http server
            server.Prefixes.Add("http://localhost:5555/");
            server.Prefixes.Add("http://127.0.0.1:5555/");  //we set a listening address here (localhost)

            server.Start();   // and start the server

            Console.WriteLine("Server is now listening at port 5555...");

            while (true)
            {
                HttpListenerContext context = server.GetContext();
                //context: provides access to httplistener's response

                HttpListenerResponse response = context.Response;
                //the response tells the server where to send the data

                string requestedPage = context.Request.Url.LocalPath;
                string pagePath = @"../../.." + requestedPage;
                //this will get the page requested by the browser 

                if (requestedPage == "/")
                {
                    pagePath += "index.html";
                }

                if (File.Exists(pagePath))
                {
                    using (var reader = new StreamReader(pagePath))
                    {
                        string pageContent = reader.ReadToEnd();  //getting the page's content

                        byte[] buffer = Encoding.UTF8.GetBytes(pageContent); //then we transform it into a byte array

                        response.ContentLength64 = buffer.Length;  // set up the content's length
                        response.OutputStream.Write(buffer, 0, buffer.Length); // here we send all the content to the browser
                    }
                }
                else
                {
                    using (var reader = new StreamReader(@"../../../error.html"))
                    {
                        string errorPageContent = reader.ReadToEnd();

                        byte[] buffer = Encoding.UTF8.GetBytes(errorPageContent);

                        response.ContentLength64 = buffer.LongLength;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                }

                context.Response.Close();  // here we close the connection
            }
        }
    }
}
