using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace App2.Droid
{
    public static class LogtoFileHelper
    {
        public static void Write(string t, [CallerMemberName] string att="")
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myfile.txt");

            using (var streamWriter = new StreamWriter(filename, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString() + "--" + att + "--" + t);
            }
        }
        public static IEnumerable<string> Read()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myfile.txt");
            using (var streamReader = new StreamReader(filename))
            {
                return streamReader.ReadToEnd().Split('\n');
            }
        }
    }
}