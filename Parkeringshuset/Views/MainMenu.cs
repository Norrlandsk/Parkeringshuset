﻿using System.Collections.Generic;
using System;
using Parkeringshuset.Models;
using Parkeringshuset.BusinessLogic;

namespace Parkeringshuset.Views
{
    public static class MainMenu
    {
        /// <summary>
        /// Check in and out menu for users of the parking garage.
        /// </summary>
        public static void RunMainMenu()
        {
            bool keepGoing = true;
            string pType = "";
            ParkingMeterLogic pML = new ();
            do
            {
                Console.Write("Enter your registration number: ");
                string regNr = Console.ReadLine();
                if (string.IsNullOrEmpty(regNr.Trim()))
                {
                    Console.WriteLine("Can not use empty registration number, please try again.");
                    continue;
                }
                var parkingTicket = ParkingMeterController.GetActiveTicket(regNr);
                if (parkingTicket is null)
                {
                    Console.WriteLine($"Checked In, what zone would you like to park in?: ");
                    Console.WriteLine("1. Regular vehicle");
                    Console.WriteLine("2. Electric vehicle");
                    Console.WriteLine("3. Handicaped");
                    Console.WriteLine("4. Monthly");
                    Console.WriteLine("5. Motorbike");
                    Console.WriteLine("6. Abort check in");
                    int.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 1:
                            pType = "Regular";
                            pML.CheckIn(regNr, pType);
                            PressAnyKeyToContinue();
                            break;
                        case 2:
                            pType = "Electric";
                            pML.CheckIn(regNr, pType);
                            PressAnyKeyToContinue();
                            break;
                        case 3:
                            pType = "Handicap";
                            pML.CheckIn(regNr, pType);
                            PressAnyKeyToContinue();
                            break;
                        case 4:
                            pType = "Monthly";
                            pML.CheckIn(regNr, pType);
                            PressAnyKeyToContinue();
                            break;
                        case 5:
                            pType = "Motorbike";
                            pML.CheckIn(regNr, pType);
                            PressAnyKeyToContinue();
                            break;
                        case 6:
                            keepGoing = false;
                            break;
                        default:
                            Console.WriteLine("Jerry created a problem, please try again!");
                            break;
                    }
                }
                else if (parkingTicket.Type.Name == "Monthly")
                {
                    Console.WriteLine("Welcome back!");
                    keepGoing = false;
                    PressAnyKeyToContinue();
                }
                else
                {
                    ParkingTicketController.CheckOut(parkingTicket);
                    Console.WriteLine("Thank you for using our garage, welcome back!");
                    keepGoing = false;
                    PressAnyKeyToContinue();
                }
            } while (keepGoing);
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
        }
    }
}
