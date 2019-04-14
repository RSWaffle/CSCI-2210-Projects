﻿using System;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Driver.cs
//	Description:       The driver class is where the main method is stored.
//
//	Course:            CSCI 2210 - Data Structures
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University
//	Created:           Tuesday, Apr 09 2019
//
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project4
{
    internal class Program
    {
        #region main

        /// <summary>
        /// Main - The method that drives the program.
        /// </summary>
        /// <param name="string[] args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Project 4: Supermarket Simulation";

            Supermarket market;
            int customers = 0;
            int hours = 0;
            int numRegisters = 0;

            Menu menu = new Menu("Simulation Menu");
            menu = menu + "Set the number of customers" +
                "Set the number of hours of operation" +
                "Set the number of registers" +
                "Run the simulation" + "End the program";

            Choices choice = (Choices)menu.GetChoice();
            while (choice != Choices.END)
            {
                switch (choice)
                {
                    case Choices.CUSTOMERS:

                        bool loopExit = true;

                        while (loopExit)
                        {
                            Console.WriteLine("How many customers will be served in a day?: ");
                            int.TryParse(Console.ReadLine(), out customers);

                            if (customers > 0)
                            {
                                loopExit = false;
                            }
                            else
                            {
                                Console.WriteLine("Must be a positive number greater than 0...");
                                Tools.PressAnyKey();
                            }

                            Tools.Skip();
                        }
                        break;

                    case Choices.HOURS:
                        bool loopExit2 = true;

                        while (loopExit2)
                        {
                            Console.WriteLine("How many hours will the business be open?: ");
                            int.TryParse(Console.ReadLine(), out hours);

                            if (hours > 0)
                            {
                                loopExit2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Must be a positive number greater than 0...");
                                Tools.PressAnyKey();
                            }

                            Tools.Skip();
                        }

                        break;

                    case Choices.REGISTERS:
                        bool loopExit3 = true;

                        while (loopExit3)
                        {
                            Console.WriteLine("How many lines are to be simulated?: ");
                            int.TryParse(Console.ReadLine(), out numRegisters);

                            if (numRegisters > 0)
                            {
                                loopExit3 = false;
                            }
                            else
                            {
                                Console.WriteLine("Must be a positive number greater than 0...");
                                Tools.PressAnyKey();
                            }

                            Tools.Skip();
                        }

                        break;

                    case Choices.RUN:
                        market = new Supermarket(customers, hours, numRegisters);

                        market.DoSimulation();
                        market.ShowStatistics();

                        break;

                    case Choices.END:
                        System.Environment.Exit(1);
                        break;
                }  // end of switch
                choice = (Choices)menu.GetChoice();
            }  // end of while
        }

        #endregion main
    }
}