using System;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.IO;

namespace filemake
{
    class Program
    {
        static int Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }

            Argument lang = new Argument<string>("language", "Specify the language you want to use.");
            Option fileName = new Option<string>("--name", "Specify the file name.");
            fileName.AddAlias("-n");
            fileName.IsRequired = false;

            RootCommand rootCommand = new RootCommand();
            rootCommand.AddArgument(lang);
            rootCommand.AddOption(fileName);

            rootCommand.Description = "Make Boilerplate Code for yourself.";

            rootCommand.Handler = CommandHandler.Create<string, string>(MakeFile);

            return rootCommand.Invoke(args);
        }

        static void MakeFile(string lang, string fileName = "main")
        {
            Console.WriteLine(lang);
            Console.WriteLine(fileName);
            return;

            //if (lang.ToLower() != "pygame" || lang.ToLower() != "c++")
            //{
            //    Console.WriteLine("Please select a correct language!");
            //    return;
            //}

            //if (lang.ToLower() == "pygame")
            //{
            //    Console.WriteLine("PYGAME!!");
            //    return;
            //}

            //if (lang.ToLower() == "c++")
            //{
            //    Console.WriteLine("C++");
            //    return;
            //}
        }
    }
}
