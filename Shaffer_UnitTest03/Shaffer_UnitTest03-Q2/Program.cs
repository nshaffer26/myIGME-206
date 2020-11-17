using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Nicholas Shaffer
// Date: 11/17/2020
namespace Shaffer_UnitTest03_Q2
{
    class Program
    {
        enum room
        {
            Red, Orange, Yellow, Green, Blue, Indigo, Violet, Grey
        }

        static int[,] mCostGraph = new int[,]
        {
            //Red   Orange  Yellow  Green   Blue    Indigo  Violet  Grey
            { -1    , -1    , -1    , -1    ,  1    , -1    , -1    ,  5 },  //Red
            { -1    , -1    , -1    , -1    , -1    , -1    ,  1    , -1 },  //Orange
            { -1    , -1    , -1    ,  6    , -1    , -1    , -1    , -1 },  //Yellow
            { -1    , -1    , -1    , -1    , -1    , -1    , -1    , -1 },  //Green
            { -1    , -1    ,  8    , -1    , -1    ,  1    , -1    , -1 },  //Blue
            { -1    , -1    , -1    , -1    ,  1    , -1    , -1    ,  0 },  //Indigo
            { -1    , -1    ,  1    , -1    , -1    , -1    , -1    , -1 },  //Violet
            { -1    ,  1    , -1    , -1    , -1    ,  0    , -1    , -1 }   //Grey
        };

        static room[][] lRoomGraph = new room[][]
        {
            new room[] { room.Blue, room.Grey },        //Red
            new room[] { room.Violet },                 //Orange
            new room[] { room.Green },                  //Yellow
            null,                                       //Green
            new room[] { room.Yellow, room.Indigo },    //Blue
            new room[] { room.Blue, room.Grey },        //Indigo
            new room[] { room.Yellow },                 //Violet
            new room[] { room.Orange, room.Indigo }     //Grey
        };
        static int[][] lCostGraph = new int[][]
        {
            new int[] { 1, 5 },     //Red
            new int[] { 1 },        //Orange
            new int[] { 6 },        //Yellow
            null,                   //Green
            new int[] { 8, 1 },     //Blue
            new int[] { 1, 0 },     //Indigo
            new int[] { 1 },        //Violet
            new int[] { 1, 0 }      //Grey
        };

        static void Main(string[] args)
        {
        }
    }
}
