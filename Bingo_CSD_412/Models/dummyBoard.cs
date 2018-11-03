using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class dummyBoard
    {
        HashSet<int> IdSet { get; set; } //Set used to operate with random selection logic
        char[] DisplayBoard { get; set; } //Array that the user will see
        char[] dummyDatabase { get; set; } //place holder DB
        int[] FunctionalBoard { get; set; } //Array that tracks if a cell has been selected
        int size;

        public dummyBoard()
        {
            DisplayBoard = new char[25];
            FunctionalBoard = new int[25]; //This array stores values of either 0 for not selected or 1 for select
            IdSet = new HashSet<int>();
            size = 25;

            generateDummyDatabase();
            fillSet();
            fillBoard();
        }

        /*
        * This is a place holder method to be used while we are not connected to a database
        * This method constructs a char array where the index of the Array represents the ID of the data
        */
        private void generateDummyDatabase()
        {

            dummyDatabase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()".ToCharArray();
        }

        //This method creates a set of 25 random non-repeating IDs to be used to pull data from the DB
        private void fillSet()
        {
            Random rnd = new Random();
            bool ConfirmSize = false;

            while (!ConfirmSize)
            {
                int value = rnd.Next(40); //40 will be changed to the # of rows in the DB
                IdSet.Add(value);
                if (IdSet.Count == size)
                {
                    ConfirmSize = true;
                }
            }
        }

        //This populate the array that will be displayed in the view 
        private void fillBoard()
        {
            int index = 0;
            foreach (int i in IdSet)
            {
                /* get value of ID i from database and store it in DisplayBoard[index] */
                DisplayBoard[index] = dummyDatabase[i];
                index++;
            }
        }

        /* to be implemented later */
        public void cellSelect(int index)
        {
            FunctionalBoard[index] = 1;
            if (checkForBingo(index))
            {
                gameOver();
            }

        }

        /* to be implemented later*/
        private bool checkForBingo(int index)
        {
            //logic will check the current row and column and if applicable the diagnals for bingo
            return false; 
        }

        /*to be implemented later*/
        private void gameOver()
        {
            throw new NotImplementedException();
        }
    }
}
