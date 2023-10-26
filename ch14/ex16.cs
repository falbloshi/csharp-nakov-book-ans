using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public enum BatteryEnum
{
    LiIon,
    LiPol,
    NiMH,
    NiCD,
}
public class Battery
{
    private static BatteryEnum batteries;
    private static byte idleTime;
    private static byte hoursTalk;

    public static BatteryEnum BatteryType
    {
        get { return batteries; }
        set { batteries = value; }
    }

    public static byte IdleTime
    {
        get { return idleTime; }
        set { idleTime = value; }
    }

    public static byte Hours
    {
        get { return hoursTalk; }
        set { hoursTalk = value; }
    }


}

public class Display : Battery
{
    private static float screenSize;
    private static double colorDepth;

    public static float ScnSize
    {
        get { return screenSize; }
        set { screenSize = value; }
    }

    public static double ColorDepth
    {
        get { return colorDepth; }
        set { colorDepth = value; }
    }

}

public class GSM : Display
{
    private static string model;
    private static string manufacturer;
    private static float price;
    private static string owner;

    public static string Model
    {
        get { return model; }
        set { model = value; }
    }

    public static string Manufacturer
    {
        get { return manufacturer; }
        set { manufacturer = value; }
    }

    public static float Price
    {
        get { return price; }
        set { price = value; }
    }

    public static string Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    public GSM()
        : this(null)
    { }
    public GSM(string model)
        : this(model, null)
    { }
    public GSM(string model, string manufacturer)
        : this(model, manufacturer, 0)
    { }
    public GSM(string model, string manufacturer, float price)
        : this(model, manufacturer, price, null)
    { }
    public GSM(string model, string manufacturer, float price, string owner)
         : this(model, manufacturer, price, owner, 0)
    { }
    public GSM(string model, string manufacturer, float price, string owner, byte idleTime)
        : this(model, manufacturer, price, owner, idleTime, 0)
    { }
    public GSM(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk)
        : this(model, manufacturer, price, owner, idleTime, hoursTalk, 0)
    { }
    public GSM(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk, float screenSize)
        : this(model, manufacturer, price, owner, idleTime, hoursTalk, screenSize, 0)
    { }
    public GSM(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk, float screenSize, double colorDepth)
       : this(model, manufacturer, price, owner, idleTime, hoursTalk, screenSize, colorDepth, (BatteryEnum)0)
    { }

    public GSM(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk, float screenSize, double colorDepth, BatteryEnum batteryType)
    {
        Model = model;
        Manufacturer = manufacturer;
        Price = price;
        Owner = owner;
        IdleTime = idleTime;
        Hours = hoursTalk;
        ScnSize = screenSize;
        ColorDepth = Math.Pow(2, colorDepth);
        BatteryType = batteryType;
    }

    public static GSM nokiaN95 = new GSM("N95", "Nokia", 355.554f, "Tyrell", 220, 6, 2.6f, 24.0, 0);

    public static void PrintPhoneINF(GSM myPhone)
    {
        if (!(Model == "") && !(Model == null))
        {
            Console.WriteLine($" -==== {Model} Information ====-");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Owner: {Owner}");
            Console.WriteLine($"Price: {Price:C2}");
            Console.WriteLine($"Standby: {IdleTime} Hours {BatteryType} Battery");
            Console.WriteLine($"Talk Time: {Hours} Hours");
            Console.WriteLine($"Screen Size: {ScnSize}\"");

            Console.WriteLine($"Colors: {ColorDepth,0:#} Colors");

            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Empty Phone");
        }
    }
    public class GSMTest
    {
        private static Dictionary<string, GSM> gsmDB = new Dictionary<string, GSM>();
        private static List<string> phoneName = new List<string>();
        private static StringBuilder modelSB = new StringBuilder();
        private static StringBuilder manufacturerSB = new StringBuilder();
        private static StringBuilder ownerSB = new StringBuilder();

        public static GSM CreatePhone()
        {
            try
            {
                Console.Write("\nPlease Insert Phone Informations:\n");


                //--
                Console.Write("Phone Model: ");
                modelSB.Append(Console.ReadLine());

                Console.Write("Manufacturer: ");
                manufacturerSB.Append(Console.ReadLine());

                Console.Write("Owner: ");
                ownerSB.Append(Console.ReadLine());

                Console.Write("Price: ");
                float prc = float.Parse(Console.ReadLine());

                Console.Write("Idle Time: ");
                byte idT = byte.Parse(Console.ReadLine());

                Console.Write("Hours Talk: ");
                byte hrs = byte.Parse(Console.ReadLine());

                Console.Write("Screen Size: ");
                float scSz = float.Parse(Console.ReadLine());

                Console.Write("Color Bit: ");
                double colDP = double.Parse(Console.ReadLine());

                Console.Write("Battery: ");
                string bType = Console.ReadLine();
                Enum.TryParse(bType, out BatteryEnum batteryType);
                //-
                phoneName.Add(modelSB.ToString());

                int count = phoneName.Count - 1;

                gsmDB.Add(phoneName[count], new GSM(phoneName[count], manufacturerSB.ToString(), prc, ownerSB.ToString(), idT, hrs, scSz, colDP, batteryType));

                modelSB.Clear();
                manufacturerSB.Clear();
                ownerSB.Clear();

                return gsmDB[$"{phoneName[count]}"];
            }
            catch (System.FormatException)
            {
                Console.WriteLine("You inserted wrong information");
                return new GSM();

            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("You inserted twice: Creating empty phone");
                return new GSM();
            }
        }

        public class Call
        { 
            private static List<Tuple<string, TimeSpan, DateTime>> callList = new List<Tuple<string, TimeSpan, DateTime>>();

            public static List<Tuple<string, TimeSpan, DateTime>> CallListLib
            {
                get { return callList; }
                set { callList = value; }
            }

            public static void CallStart()
            {
                StringBuilder numberDialed = new StringBuilder();
                Regex correctNumber = new Regex(@"(\b([0-9]{1,3})[[:blank:]])?([0-9]{8})");
                Console.Write("Dial Number: ");
                numberDialed.Append(Console.ReadLine());
                bool cnBool = correctNumber.IsMatch(numberDialed.ToString());
                if (!cnBool)
                {
                    Console.Write("Please dial the number correctly: ");
                    CallStart();
                }
                Console.Write("Connected\n");
                TimeSpan elapsedCallTime = Timer();
                Console.Write("Call Ended: {0:hh\\:mm\\:ss}\n", elapsedCallTime);
                DateTime dtNow = DateTime.Now;
                Console.Write($"{dtNow,0:hh:mm:ss} {dtNow,0:dd/MM/yy}\n");
                CallListLib.Add(Tuple.Create(numberDialed.ToString(), elapsedCallTime, dtNow));
                CallMaker();
            }

            public static TimeSpan Timer()
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (true)
                {
                    Console.WriteLine("Press 'E' to end call");
                    //using consolekey to get info without needing an enter button
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.E)
                    {
                        stopWatch.Stop();
                        break;
                    }

                }
                TimeSpan elapsedTimeSpan = stopWatch.Elapsed;
                return elapsedTimeSpan;
            }

            static void CallMaker()
            {
                Console.WriteLine("Do you want to make a call?\n[Y]es / [N]o: ");
                string s = Console.ReadLine();
                if (s.ToLower() == "y")
                {
                    CallStart();
                }
                else
                {
                    CallHistoryDisplay();
                }
            }

            static void CallHistoryDisplay()
            {
                Console.WriteLine("Do you want to display call history?\n[Y]es / [N]o: ");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Y)
                {   
                    int listNo = 0;
                    foreach(Tuple<string, TimeSpan, DateTime> callListTuple in CallListLib)
                    {
                        listNo++;
                        Console.WriteLine($"\n{listNo}. Number: {callListTuple.Item1}\nDate: {callListTuple.Item3,0:dd:mm:yy}\nDuration: {callListTuple.Item2,0:hh\\:mm\\:ss}\n\n");
                    }
                }
                else
                {
                   return;
                }

            }

            static void Main()
            {
                CallMaker();
            }

        }
    }
}