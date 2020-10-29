using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaffer_PE21
{
    static class Program
    {
        enum dir
        {
            north,
            south,
            east,
            west,
            none
        }
        enum room
        {
            A, B, C, D, E, F, G, H
        }

        static dir[,] mDirGraph = new dir[,]
        {
            //A            B            C            D            E            F            G            H
            { dir.north  , dir.south  , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none  },  //A
            { dir.none   , dir.none   , dir.south  , dir.east   , dir.none   , dir.none   , dir.none   , dir.none  },  //B
            { dir.none   , dir.north  , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.south },  //C
            { dir.none   , dir.west   , dir.south  , dir.none   , dir.north  , dir.east   , dir.none   , dir.none  },  //D
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.south  , dir.none   , dir.none  },  //E
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.east   , dir.none  },  //F
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.north  , dir.none   , dir.none   , dir.south },  //G
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none  }   //H
        };
        static int[,] mCostGraph = new int[,]
        {
            //A      B    C    D    E    F    G    H
            { 0,     2,   -1,  -1,  -1,  -1,  -1,  -1 }, //A
            { -1,    -1,  2,   3,   -1,  -1,  -1,  -1 }, //B
            { -1,    2,   -1,  -1,  -1,  -1,  -1,  20 }, //C
            { -1,    3,   5,   -1,  2,   4,   -1,  -1 }, //D
            { -1,    -1,  -1,  -1,  -1,  3,   -1,  -1 }, //E
            { -1,    -1,  -1,  -1,  -1,  -1,  1,   -1 }, //F
            { -1,    -1,  -1,  -1,  0,   -1,  -1,  2  }, //G
            { -1,    -1,  -1,  -1,  -1,  -1,  -1,  -1 }  //H
        };

        static dir[][] lDirGraph = new dir[][]
        {
            new dir[] { dir.north, dir.south, dir.east },           //A
            new dir[] { dir.south, dir.east },                      //B
            new dir[] { dir.north, dir.south },                     //C
            new dir[] { dir.north, dir.south, dir.east, dir.west }, //D
            new dir[] { dir.south },                                //E
            new dir[] { dir.east },                                 //F
            new dir[] { dir.north, dir.south },                     //G
            null                                                    //H
        };
        static room[][] lRoomGraph = new room[][]
        {
            new room[] { room.A, room.B, room.A },         //A
            new room[] { room.C, room.D },                 //B
            new room[] { room.B, room.H },                 //C
            new room[] { room.E, room.C, room.F, room.B }, //D
            new room[] { room.F },                         //E
            new room[] { room.G },                         //F
            new room[] { room.E, room.H },                 //G
            null                                           //H
        };
        static int[][] lCostGraph = new int[][]
        {
            new int[] { 0, 2, 0 },      //A
            new int[] { 2, 3 },         //B
            new int[] { 2, 20 },        //C
            new int[] { 2, 5, 4, 3 },   //D
            new int[] { 3 },            //E
            new int[] { 1 },            //F
            new int[] { 0, 2 },         //G
            null                        //H
        };

        static void Main(string[] args)
        {
        }
    }
}
