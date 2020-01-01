using System;
using System.IO;
using System.Text;

namespace RenamerForTimelapsePictures
{
    public static class MyWriter
    {
      public static void Write(string value, bool always = false)
        {
            if(always||!Globals.CalledByWindows)Console.Write(value);
        }

        public static void WriteLine(string value, bool always = false)
        {
            if(always||!Globals.CalledByWindows)Console.WriteLine(value);
        }
    }
}