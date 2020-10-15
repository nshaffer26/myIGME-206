using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// Author: Nicholas Shaffer
// Date: 10/14/2020
namespace Shaffer_UnitTest02_Q10
{
    public abstract class Game
    {
        private byte rating;
        public string title;
        public string developer;
        public string publisher;

        public byte Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
            }
        }

        public virtual void Buy()
        {

        }
        public abstract void Play();
    }

    public interface IVideoGame
    {
        void Update();
        void Controls();
    }
    public interface IBoardGame
    {
        void SetUp();
        void Instructions();
    }

    public class BanjoKazooie : Game, IVideoGame
    {
        public int jiggiesCollected;
        public int musicalNotesCollected;

        public void Update()
        {

        }
        public void Controls()
        {

        }
        public override void Buy()
        {

        }
        public override void Play()
        {
            
        }
        public void TalonTrot()
        {

        }
    }
    public class Catan : Game, IBoardGame
    {
        public int numSheep;
        public int numWheat;
        public int numWood;
        public int numBrick;
        public int numOre;

        public void SetUp()
        {

        }
        public void Instructions()
        {

        }
        public override void Buy()
        {

        }
        public override void Play()
        {

        }
        public void BuildRoad()
        {

        }
    }

    public class Program
    { 
        public static void Main(string[] args)
        {
            BanjoKazooie mumboJumbo = new BanjoKazooie();
            Catan settlement = new Catan();

            PlayAGame(mumboJumbo);
            PlayAGame(settlement);
        }

        static void PlayAGame(object obj)
        {
            Game game = (Game)obj;
            game.Buy();

            if(obj.GetType() == typeof(BanjoKazooie))
            {
                BanjoKazooie bottles = (BanjoKazooie)obj;
                bottles.Update();
                game.Play();
                bottles.TalonTrot();
            }
            if (obj.GetType() == typeof(Catan))
            {
                Catan city = (Catan)obj;
                city.SetUp();
                game.Play();
                city.BuildRoad();
            }
        }
    }
}
