using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAssignment
{
    /// <summary>
    /// main method class
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Volume volume = new Volume();
            volume.VolCheck();
        }
    }
        /// <summary>
        /// The publisher class
        /// </summary>
        internal class AirpodCheck  
    {
        public delegate void NotifyHandler();
        public event NotifyHandler NotifyOtherClasses;

        /// <summary>
        /// checks the volume
        /// </summary>
        public void AirpodVol()
        {
            for (int a=0; a<=85; a+=5)
            {
                Console.WriteLine(a);

                if(a==85)
                {
                    AirpodChecker();     
                }
            }
            
        }
        /// <summary>
        /// raises the event
        /// </summary>
        protected virtual void AirpodChecker()   
        {
            NotifyOtherClasses?.Invoke();     
        }

    }

    /// <summary>
    /// The subscriber class
    /// </summary>
    public class Volume   
    {
        public void VolCheck()
        {
            var vol = new AirpodCheck();
            vol.NotifyOtherClasses += DeviceDisplay;
            vol.AirpodVol();
        }



        /// <summary>
        /// to notify the user
        /// </summary>
        public void DeviceDisplay()     
        {
            Console.WriteLine("Volume too high. May cause hearing injuries");
            Console.ReadLine();
        }
    }
}
