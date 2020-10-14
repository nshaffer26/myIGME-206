using System;

namespace Shaffer_UnitTest02_Q04
{
    public abstract class Phone
    {
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public string address;

        public abstract void Connect();
        public abstract void Disconnect();
    }

    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }

    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;

        private byte whichDrWho;
        public byte WhichDrWho
        {
            get
            {
                return whichDrWho;
            }
        }

        private string femaleSideKick;
        public string FemaleSideKick
        {
            get
            {
                return femaleSideKick;
            }
        }

        public double exteriorSurfaceArea;
        public double interiorVolume;

        public void TimeTravel()
        {

        }

        public static bool operator ==(Tardis t1, Tardis t2)
        {
            return (t1.whichDrWho == t2.whichDrWho);
        }
        public static bool operator !=(Tardis t1, Tardis t2)
        {
            return (t1.whichDrWho != t2.whichDrWho);
        }
        public static bool operator <(Tardis t1, Tardis t2)
        {
            if(t1.whichDrWho == t2.whichDrWho)
            {
                return false;
            }
            if (t1.whichDrWho == 10)
            {
                return false;
            }
            if (t2.whichDrWho == 10)
            {
                return true;
            }
            return (t1.whichDrWho < t2.whichDrWho);
        }
        public static bool operator >(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == t2.whichDrWho)
            {
                return false;
            }
            if (t2.whichDrWho == 10)
            {
                return false;
            }
            if (t1.whichDrWho == 10)
            {
                return true;
            }
            return (t1.whichDrWho > t2.whichDrWho);
        }
        public static bool operator <=(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == t2.whichDrWho)
            {
                return true;
            }
            if (t2.whichDrWho == 10)
            {
                return true;
            }
            if (t1.whichDrWho == 10)
            {
                return false;
            }
            return (t1.whichDrWho <= t2.whichDrWho);
        }
        public static bool operator >=(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == t2.whichDrWho)
            {
                return true;
            }
            if (t2.whichDrWho == 10)
            {
                return false;
            }
            if (t1.whichDrWho == 10)
            {
                return true;
            }
            return (t1.whichDrWho >= t2.whichDrWho);
        }
    }
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {

        }
        public void CloseDoor()
        {

        }
    }
}
