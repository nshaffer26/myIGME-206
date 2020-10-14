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
