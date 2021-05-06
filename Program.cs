using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

public static class Program {
    static void Main() {
        var tcpClient = new TcpClient();
        const string webSite = "www.acme.com";
        tcpClient.Connect(webSite, 80);
        var stream = tcpClient.GetStream();
        var send = Encoding.ASCII.GetBytes("GET / HTTP/1.1" + Environment.NewLine +
                                           "Host: acme.com" + Environment.NewLine+Environment.NewLine);
        stream.Write(send, 0, send.Length);
            
        var sr = new StreamReader(stream);
        var str = sr.ReadToEnd();
        //Console.WriteLine(str);
        tcpClient.Close();
        stream.Close();
    }
    static string Navigator(string subDir) {
        var tcpClient = new TcpClient();
        var webSite = "www.acme.com";
        tcpClient.Connect(webSite, 80);
        var stream = tcpClient.GetStream();
        var send = Encoding.ASCII.GetBytes($"GET /{subDir} HTTP/1.1" + Environment.NewLine +
                                           "Host: acme.com" + Environment.NewLine+Environment.NewLine);
        stream.Write(send, 0, send.Length);
            
        var sr = new StreamReader(stream);
        var str = sr.ReadToEnd();
        //Console.WriteLine(str);
        tcpClient.Close();
        stream.Close();
        return str;
    }
}