﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1Driver
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Pig Latin Translator";

            string sentence = "";
            PigLatin translator;

            Menu menu = new Menu("Pig Latin Translator");
            menu = menu + "Open a text file" + "Type a sentence" + "Quit";

            Choices choice = (Choices)menu.GetChoice();
            while (choice != Choices.QUIT)
            {
                switch (choice)
                {
                    case Choices.OPEN:
                        sentence = FileHandler();
                        translator = new PigLatin(sentence);
                        Console.WriteLine("The sentence: \n\n" + sentence + "\n\ntranslates into: \n\n" + translator.ToString() + "\n\n");
                        Console.WriteLine("Press any key to go back to the menu...");
                        Console.ReadKey();
                        break;

                    case Choices.EDIT:
                        Console.WriteLine("Please type the sentence you would like to translate:");
                        sentence = Console.ReadLine();
                        translator = new PigLatin(sentence);
                        Console.WriteLine("The sentence: \n\n" + sentence + "\n\ntranslates into: \n\n" + translator.ToString() + "\n\n");
                        Console.WriteLine("Press any key to go back to the menu...");
                        Console.ReadKey();
                        break;

                    case Choices.CLOSE:
                        System.Environment.Exit(1);
                        break;
                }  // end of switch
                choice = (Choices)menu.GetChoice();
            }  // end of while

        }

        static string FileHandler()
        {
            StreamReader rdr = null;

            string sentence = "";
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Filter = "text files|*.txt;*.text";
            OpenDlg.InitialDirectory = Application.StartupPath;
            OpenDlg.Title = "Select a text file to translate the contents.";
            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                try
                {
                    rdr = new StreamReader(OpenDlg.FileName);

                    while (!rdr.EndOfStream)
                    {
                        sentence += rdr.ReadLine();
                    }
                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
                string fileName = OpenDlg.FileName;
            }
            else
            {

            }

            return sentence;
        }
    }
}
