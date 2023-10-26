using System;
using System.Text;
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
                string bType =  Console.ReadLine();
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
            catch(System.FormatException)
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

        static void Main()
        {
            PrintPhoneINF(nokiaN95);
            PrintPhoneINF(CreatePhone());
        }

    }
}