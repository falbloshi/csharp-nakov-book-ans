using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;



//creating enum new battery type
public enum BatteryEnum
{
    LiIon,
    LiPol,
    NiMH,
    NiCD,
}

//a new class which holds battery information including the above enum
public class Battery
{
    private static BatteryEnum batteries;
    private static byte idleTime;
    private static byte hoursTalk;

    //creating get sets properties for the above private fields
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

public class Display : Battery // inhereting battery class
{

    private static float screenSize;
    private static double colorDepth;

    //creating get sets properties for the above private fields
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

public class GSM : Display //inhereting display 
{


    private static string model;
    private static string manufacturer;
    private static float price;
    private static string owner;

    //creating get sets properties for the above private fields
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

    //creating constructors with default empty ones as null
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
    { }  //enum is written in this form as default

    //the main constructor
    public GSM(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk, float screenSize, double colorDepth, BatteryEnum batteryType)
    {
        // instead of this.privateField - we directly use the static properties for a new instance of class gsm

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

    //method to print info, notice the usage of properties for the class GSM as a parameter
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

        //creating user phone;
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
                return new GSM(); //returning an empty class

            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("You inserted twice: Creating empty phone");
                return new GSM(); //returning an empty class refrencing the same empty base class
            }
        }

        public class Call
        {
            //creating a new class Call

            //we can use generic class within generic classes to store a simple database
            //this is a list that stores a tuple of string, timespan and datetime
            private static List<Tuple<string, TimeSpan, DateTime>> callList = new List<Tuple<string, TimeSpan, DateTime>>();

            //the property of the above private List
            public static List<Tuple<string, TimeSpan, DateTime>> CallListLib
            {
                get { return callList; }
                set { callList = value; }
            }

            //a method to start a call and store its info in our CallListLib
            public static void CallStart()
            {
                //using stringbuilder is efficient, since it is stored in heap, and not stack like string
                StringBuilder numberDialed = new StringBuilder();

                //regex to check if number is correct
                Regex correctNumber = new Regex(@"(\b([0-9]{1,3})[[:blank:]])?([0-9]{8})");
                Console.Write("Dial Number: ");

                //appending from console
                numberDialed.Append(Console.ReadLine());
                //check if the number is correct otherwise repeat the operation
                bool cnBool = correctNumber.IsMatch(numberDialed.ToString());
                if (!cnBool)
                {
                    Console.WriteLine("Please dial the number correctly! ");
                    CallStart();
                }

                Console.Write("Connected\n");

                //timer returns a TimeSpan while also a prompt
                TimeSpan elapsedCallTime = Timer();

                //after closing the call, it is displayed how long the call lasted
                Console.Write("Call Ended: {0:hh\\:mm\\:ss}\n", elapsedCallTime);

                //stores the time the call last finished
                DateTime dtNow = DateTime.Now;

                //displays the information
                Console.Write($"{dtNow,0:hh:mm:ss} {dtNow,0:dd/MM/yy}\n");

                //adding the tuple into our CallListLib
                CallListLib.Add(Tuple.Create(numberDialed.ToString(), elapsedCallTime, dtNow));

                GSMCallHistoryTest.Returning();
            }

            //timer method used in our StartCall method - only method not public
            //since it is used in a public method
            static TimeSpan Timer()
            {
                //starting a stopwatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (true)
                {
                    //continues to stopwatch iteration until we press e, which will both stop the stopwatch time and 
                    //the while loop
                    Console.WriteLine("Press 'E' to end call");
                    //using consolekey to get info without needing an enter button
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.E)
                    {
                        stopWatch.Stop();
                        break;
                    }

                }

                //finally we return a TimeSpan
                TimeSpan elapsedTimeSpan = stopWatch.Elapsed;
                return elapsedTimeSpan;
            }

            //this will display the history of calls stored in our list
            public static void CallHistoryDisplay(List<Tuple<string, TimeSpan, DateTime>> CallListHistory)
            {
                //check if it is not empty
                if (CallListHistory.Count > 0)
                {
                    //foreach tuple in the call history
                    foreach (Tuple<string, TimeSpan, DateTime> callListTuple in CallListHistory)
                    {
                        Console.WriteLine($"\n{CallListHistory.IndexOf(callListTuple) + 1}. Number: {callListTuple.Item1}\nDate: {callListTuple.Item3,0:dd:mm:yy}\nDuration: {callListTuple.Item2,0:hh\\:mm\\:ss}\n");    
                    }
                    
                    GSMCallHistoryTest.Returning();
                }
                else
                {
                    Console.WriteLine("Empty History... ");

                    GSMCallHistoryTest.Returning();
                }
            }


            //deleting a call from index of the call history
            public static void CallHistoryDeleteCall(List<Tuple<string, TimeSpan, DateTime>> CallListHistory)
            {
                if (CallListHistory.Count > 0)
                {
                    //print again but with Time of the call as well
                    foreach (Tuple<string, TimeSpan, DateTime> callListTuple in CallListHistory)
                    {
                        Console.WriteLine($"\n{CallListHistory.IndexOf(callListTuple) + 1}. Number: {callListTuple.Item1}\nDate: {callListTuple.Item3,0:dd:mm:yy}\nTime: {callListTuple.Item3,0:hh\\:mm\\:ss}\n{callListTuple.Item2,0:mm\\:ss} Minutes");
                    }

                    //selecting a call to delete
                    Console.Write("Which call to delete, specify number: ");
                    bool numbSelected = short.TryParse(Console.ReadLine(), out short numb);
                    if (numbSelected)
                    {
                        try
                        {
                            numb -= 1; //its for an index
                            Console.WriteLine("\nNumber {0} at {1,0:hh\\:mm\\:ss} - {1:dd-MM-yyyy} deleted", CallListHistory[numb].Item1, CallListHistory[numb].Item3);
                            CallListHistory.RemoveAt(numb);
                            Console.WriteLine("");

                            CallHistoryDisplay(CallListHistory);
                            GSMCallHistoryTest.Returning();
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            //if index not in the list, we catch it
                            Console.WriteLine("Not in the list");

                            GSMCallHistoryTest.Returning();
                        }
                    }
                    else
                    {   // if its not a number
                        Console.WriteLine("Different Input");
                        GSMCallHistoryTest.Returning();
                    }
                }
                else
                {
                    Console.WriteLine("Already Empty");

                    GSMCallHistoryTest.Returning();
                }


            }

            public static void CallHistoryDeleteArchive(List<Tuple<string, TimeSpan, DateTime>> CallListHistory)
            {
                //deletes the whole archive
                Console.WriteLine("Deleting Call Archive...");
                CallListHistory.Clear();
                CallListHistory.TrimExcess();
                CallHistoryDisplay(CallListHistory);
                GSMCallHistoryTest.Returning();

            }

            //find the price of the call
            public static void TotalCallPrice(float price)
            {
                int totalCalls = CallListLib.Count;
                float totalPrice = 0f;
                TimeSpan totalCallTime = new TimeSpan();
                foreach (Tuple<string, TimeSpan, DateTime> callListTuple in CallListLib)
                {
                    totalCallTime += callListTuple.Item2;
                }
                if ((float)totalCallTime.Minutes < 1.0f)
                {
                    totalPrice = price;
                }
                else
                {
                    totalPrice = price * (float)totalCallTime.TotalMinutes;
                }
                Console.WriteLine($"Total Calls: {totalCalls}\nTotal Call Time: {totalCallTime,0:mm\\:ss}\nTotal Credit Due: {totalPrice,0:C2}");

                GSMCallHistoryTest.Returning();
            }

        }
    }


    public class GSMCallHistoryTest : GSMTest.Call
    {
        //creating a main menu
        static void MainMenu()
        {
            Console.Clear();
            string s = "VerozineIT";
            string m = ".:| 100%";
            string call = "1- Call";
            string history = "2- Call History";
            string delHistory = "3- Delete Call";
            string credit = "4- Credit";
            string emH = "5- Empty History";
            string shutdown = "6- Shutdown";
            Console.WriteLine("{0,10}{1,30}", s, m);
            Console.WriteLine("{0,-10}{1,-10}{2,21}", call, history, delHistory);
            Console.WriteLine("{0,-10}{1,-10}{2,17}", credit, emH, shutdown);

            var cki = Console.ReadKey();
            //\r to remove the number inserted from the screen
            Console.Write("\r");
            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    
                    CallStart();
                    break;
                case ConsoleKey.D2:
                    CallHistoryDisplay(CallListLib);
                    break;
                case ConsoleKey.D3:
                    CallHistoryDeleteCall(CallListLib);
                    break;
                case ConsoleKey.D4:
                    TotalCallPrice(0.37f);
                    break;
                case ConsoleKey.D5:
                    CallHistoryDeleteArchive(CallListLib);
                    break;
                case ConsoleKey.D6:
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        //returning to MainMenu after inserting any key.
        public static void Returning()
        {
            Console.ReadKey();
            MainMenu();
        }
        public static void Main()
        {
            MainMenu();
        }
    }
}