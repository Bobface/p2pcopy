using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Globalization;
using System.IO;

namespace p2pcopy
{
    static class InternetTime
    {
        static internal List<string> servers = new List<string>()
        {
            "nist.colorado-networks.com",
            "nist.expertsmi.com",
            "nist.netservicesgroup.com",
            "nist-time-server.eoni.com",
            "nist1.aol-ca.symmetricom.com",
            "nist1.aol-va.symmetricom.com",
            "nist1.columbiacountyga.gov",
            "nist1.symmetricom.com",
            "nist1-atl.ustiming.org",
            "nist1-chi.ustiming.org",
            "nist1-la.ustiming.org",
            "nist1-lnk.binary.net",
            "nist1-lv.ustiming.org",
            "nist1-nj.ustiming.org",
            "nist1-ny.ustiming.org",
            "nist1-pa.ustiming.org",
            "nist1-sj.ustiming.org",
            "nisttime.carsoncity.k12.mi.us",
            "ntp-nist.ldsbc.edu",
            "time.nist.gov",
            "time-a.nist.gov",
            "time-a.timefreq.bldrdoc.gov",
            "time-b.nist.gov",
            "time-b.timefreq.bldrdoc.gov",
            "time-c.timefreq.bldrdoc.gov",
            "time-nw.nist.gov",
            "utcnist.colorado.edu",
            "utcnist2.colorado.edu"
        };

        static internal DateTime Get()
        {
            string server = servers[new Random().Next(0, servers.Count)];
            var client = new TcpClient(server, 13);
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
