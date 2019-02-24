﻿///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         NameList.cs
//	Description:
//	Course:            CSCI 2210 - Data Structures
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University
//	Created:           Monday, Feb 04 2019
//  Modified:          Sunday, Feb 24 2019
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Project1
{
    internal class NameList
    {
        private List<Name> nameList = new List<Name>();
        private Name owner = new Name();

        #region Constructors
        /// <summary>
        ///  Basic constructor that does not take any parameters
        /// </summary>
        public NameList()
        {
            setOwnerName("Default Owner Name");
        }

        /// <summary>
        ///  Basic constructor  that takes in a string of names and fills the list with names
        /// <param String inNames>string of names with a delimiter</param>
        /// </summary>
        public NameList(string inNames)
        {
            nameList = populateList(Tools.Tokenize(inNames, "#,"));
        }


        /// <summary>
        ///  Basic copy constructor. Takes in a name list and creates an identical new one. 
        /// <param NameList original>the NameList to be copied</param>
        /// </summary>
        public NameList(NameList original)
        {
            setOwnerName(original.getOwnerName());

            for (int i = 0; i < nameList.Count; i++)
            {
                nameList.Add(original.getName(i));
            }
        }

        #endregion Constructors

        #region NameList Methods
        /// <summary>
        /// populateList - take in a string list and convert it into a name list.
        /// </summary>
        /// <param name="inNames"> a string list filled with names</param>
        /// <returns name="List<Name>"> returns a list of name objects</returns>
        public List<Name> populateList(List<String> inNames)
        {
            List<Name> outNames = new List<Name>();
            Name temp;

            for (int i = 0; i < inNames.Count; i ++)
            {
                temp = new Name(inNames[i]);
                outNames.Add(temp);
            }

            for (int y = 0;
            y < outNames.Count; y++)
            {
                Console.WriteLine(outNames[y]);
            }
            
            return outNames;
        }

        /// <summary>
        /// clear - Clears the list.
        /// </summary>

        public void clear()
        {
            nameList.Clear();
        }
        /// <summary>
        /// remove - remove an item from the list.
        /// </summary>
        /// <param name="i"> the position of which to be removed</param>

        public void remove(int i)
        {
            nameList.Remove(nameList[i]);
        }

        /// <summary>
        /// getName- returns a name object at a position i.
        /// </summary>
        /// <param name="i"> the position at which to get the name object</param>
        /// <returns name="Name"> returns the name object at that position i</returns>
        public Name getName(int i)
        {
            return nameList[i];

        }

        /// <summary>
        /// removeName - asks which contact to be removed, checks to see if the name is in the list, then removes the name from the list.
        /// </summary>

        public void removeName()
        {
            Console.WriteLine("Enter the name of the contact you wish to remove:");
            String name = Console.ReadLine().ToLower();

            for (int i = 0; i < nameList.Count; i++)
            {
                if (nameList[i].personNameFull.ToLower() == name)
                {
                    nameList.Remove(nameList[i]);
                    Console.WriteLine("Name Removed!");
                }
                else
                {
                    Console.WriteLine("Unable to find name in the list!/n");
                }
            }

        }
        /// <summary>
        /// Count - returns the count of the nameList.
        /// </summary>
        /// <return name="count"> the count of the name list</return>
        public int Count()
        {
            return nameList.Count;
        }

        /// <summary>
        /// ToString - returns a formatted string of all the names in the current list.
        /// </summary>
        /// <return name="output"> the entire string list of names</return>
        public String ToString()
        {
            String output = "";
            for (int i = 0; i < nameList.Count; i++)
            {
                output += (nameList[i].personNameFull + "\n");
            }
            return output;
        }

        #endregion NameList Methods

        #region OwnerMethods

        /// <summary>
        /// setOwnerName - sets the name of the owner of the list.
        /// </summary>
        /// <param name="input">the string to be set</param>

        public void setOwnerName(string input)
        {
            owner.personNameFull = input;
        }

        /// <summary>
        /// getOwnerName- returns the full name of the owner of the list.
        /// </summary>
        /// <returns name="personNameFull"> returns the full name of the owner</returns>
        public string getOwnerName()
        {
            return owner.personNameFull;
        }
        /// <summary>
        /// setOwnerPhone - sets the phone number of the owner of the list.
        /// </summary>
        /// <param name="input">the string to be set</param>
        public void setOwnerPhone(string input)
        {
            owner.phoneNumber = input;
        }
        /// <summary>
        /// getOwnerPhone- gets the phone number of the owner in the list.
        /// </summary>
        /// <returns name="phoneNumber"> returns the phone number of the owner</returns>
        public string getOwnerPhone()
        {
            return owner.phoneNumber;
        }
        /// <summary>
        /// setOwnerPhone - sets the email address of the owner of the list.
        /// </summary>
        /// <param name="input">the string to be set</param>
        public void setOwnerEmail(string input)
        {
            owner.email = input;
        }
        /// <summary>
        /// getOwnerEmail- gets the email of the owner in the list.
        /// </summary>
        /// <returns name="email"> returns the email of the owner</returns>
        public string getOwnerEmail()
        {
            return owner.email;
        }
        #endregion OwnerMethods

        #region Plus and Minus Operators

        /// <summary>
        /// Operator + adds a choice to the menu
        /// </summary>
        /// <param name="m">the menu to which the choice is added</param>
        /// <param name="name">the choice to be added</param>
        /// <returns></returns>
        public static NameList operator +(NameList m, Name name)
        {
            m.nameList.Add(name);
            return m;
        }

        /// <summary>
        /// Operator + adds a choice to the menu
        /// </summary>
        /// <param name="m">the menu to which the choice is added</param>
        /// <param name="name">the choice to be added</param>
        /// <returns></returns>
        public static NameList operator +(NameList m, NameList n)
        {
            for (int i = 0; i < n.Count(); i++)
            {
                m.nameList.Add(n.getName(i));
            }    
            return m;
        }

        /// <summary>
        /// Operator  - removes a choice from the menu
        /// </summary>
        /// <param name="m">the menu from which the choice is removed</param>
        /// <param name="item">the number of the choice to be removed</param>
        /// <returns></returns>
        public static NameList operator -(NameList m, Name n)
        {
            for (int i = 0; i < m.Count(); i++)
            {
                if (m.getName(i).ToString().ToLower() == n.personNameFull.ToLower())
                {
                    m.remove(i);
                    return m;
                }
                else
                {
                    Console.WriteLine("Unable to find name in the list!/n");
                }
            }
            return m;
        }

        #endregion Plus and Minus Operators
    }
}
