using System;
using System.IO;

namespace AsynchronousFile {
    static class TestAsynchronousFile {
        static string filename = @"C:\Documents and Settings\cgross\My Documents\Visual Studio Codename Orcas\Projects\JugglingTasks\JugglingTasks\threads.cs";

        static void LoadFileAsynchronously() {

FileStream fs = new FileStream(filename,FileMode.Open); 
Byte[] data = new byte[200000];

IAsyncResult asyncResult = fs.BeginRead(data, 0, data.Length,
    (lambdaAsync) => {
        FileStream localFS = (FileStream)lambdaAsync.AsyncState;
        int bytesRead = localFS.EndRead(lambdaAsync);
        string buffer = System.Text.ASCIIEncoding.ASCII.GetString(data);
        Console.WriteLine("Buffer bytes read (" + bytesRead + ")");
        localFS.Close();
    },fs);
asyncResult.AsyncWaitHandle.WaitOne();
        }
        public static void RunAll() {
            LoadFileAsynchronously();
        }
    }
}