using System;
using System.Text;



public enum BatteryEnum 
{
        LiIon, 
        LiPol,
        NiMH,
        NiCD,
}
class Battery
{
    private BatteryEnum batteries;
    
} 

class MobilePhone
{   
    private string model;
    private string manufacturer;
    private float price;
    private string owner;
    private byte idleTime;
    private byte hoursTalk;
    private float screenSize;
    private double colorDepth;

    public MobilePhone()
        : this(null) 
    {}
    public MobilePhone(string model)
        : this(model, null) 
    {}
    public MobilePhone(string model, string manufacturer)
        : this(model, manufacturer, 0) 
    {}
    public MobilePhone(string model, string manufacturer, float price)
        : this(model, manufacturer, price, null) 
    {}
   public MobilePhone(string model, string manufacturer, float price, string owner)
        : this(model, manufacturer, price, owner, 0) 
    {}
    public MobilePhone(string model, string manufacturer, float price, string owner, byte idleTime)
        : this(model, manufacturer, price, owner, idleTime, 0) 
    {}
    public MobilePhone(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk)
        : this(model, manufacturer, price, owner, idleTime, hoursTalk, 0) 
    {}
    public MobilePhone(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk, float screenSize)
        : this(model, manufacturer, price, owner, idleTime, hoursTalk,  screenSize, 0) 
    {}

    public MobilePhone(string model, string manufacturer, float price, string owner, byte idleTime, byte hoursTalk, float screenSize, double colorDepth)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.idleTime = idleTime;
        this.hoursTalk = hoursTalk;
        this.screenSize = screenSize;
        this.colorDepth = colorDepth;   
    }

    public static MobilePhone nokiaN95 = new MobilePhone("N95", "Nokia", 355.554f, "Tyrell", 220, 6, 2.6f, Math.Pow(2.0, 24.0));

    static void PrintPhoneINF(MobilePhone myPhone)
    {
        Console.WriteLine($" -==== {myPhone.model} Information ====-");
        Console.WriteLine($"Model: {myPhone.model}");
        Console.WriteLine($"Manufacturer: {myPhone.manufacturer}");
        Console.WriteLine($"Owner: {myPhone.owner}");
        Console.WriteLine($"Price: {myPhone.price:C2}");
        Console.WriteLine($"Standby: {myPhone.idleTime} Hours");
        Console.WriteLine($"Talk Time: {myPhone.hoursTalk} Hours");
        Console.WriteLine($"Screen Size: {myPhone.screenSize}\"");
        Console.WriteLine($"Colors: {myPhone.colorDepth,0:#,,}M");
        Console.WriteLine("");
    }
    
   
}

class GSM
{
    static void Main()
    {
        GSM exm = new GSM();
        Console.Write(exm.ToString());
    }
}