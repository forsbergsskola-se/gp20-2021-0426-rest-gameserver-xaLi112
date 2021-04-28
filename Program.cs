// Using StreamReader and StreamWriter
using System;
using System.IO;
using System.Net.Sockets;

public static class Program {
    static void Main(string[] arguments) {
        
        // Connect to acme.com Server via TCP on HTTP-Default-Port 80.
        var tcpClient = new TcpClient("acme.com", 80);
        
        // Send a HTTP-Request for the Root-Page
        var streamWriter = new StreamWriter(tcpClient.GetStream());
        streamWriter.Write("GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n");
        
        // Read the Response
        var streamReader = new StreamReader(tcpClient.GetStream());
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}