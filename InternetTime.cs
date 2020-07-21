using System;
using System.Net.Sockets;
using System.Globalization;
using System.IO;

namespace p2pcopy
{
    static class InternetTime
    {
        static internal DateTime Get()
        {
            var client = new TcpClient("time.nist.gov", 13);
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                Console.WriteLine(response);
                var utcDateTimeString = response.Substring(7, 17);
                client.Close();
                return DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }
        }
    }
}
