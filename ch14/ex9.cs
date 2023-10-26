using System;
using System.Text;
using System.Collections.Generic;


class MobilePhone
{   
    private string model;
    private string manufacturer;
    private int price;
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
    public MobilePhone(string model, string manufacturer, int price)
        : this(model, manufacturer, price, null) 
    {}
   public MobilePhone(string model, string manufacturer, int price, string owner)
        : this(model, manufacturer, price, owner, 0) 
    {}
    public MobilePhone(string model, string manufacturer, int price, string owner, byte idleTime)
        : this(model, manufacturer, price, owner, idleTime, 0) 
    {}
    public MobilePhone(string model, string manufacturer, int price, string owner, byte idleTime, byte hoursTalk)
        : this(model, manufacturer, price, owner, idleTime, hoursTalk, 0) 
    {}
    public MobilePhone(string model, string manufacturer, int price, string owner, byte idleTime, byte hoursTalk, float screenSize)
        : this(model, manufacturer, price, owner, idleTime, hoursTalk,  screenSize, 0) 
    {}

    public MobilePhone(string model, string manufacturer, int price, string owner, byte idleTime, byte hoursTalk, float screenSize, double colorDepth)
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
       
    
    static void Main()
    {

    }
}