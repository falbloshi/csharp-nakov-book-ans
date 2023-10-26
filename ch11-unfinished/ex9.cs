using System;
using System.Globalization;


//using the following links for reference
//https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact?view=netframework-4.8

class ex9
{	
	//to insert correct dates
	static DateTime DateInsertionMethod()
	{   
      DateTime checkValue;
    
      CultureInfo enEN = new CultureInfo("en-GB"); 

      Console.Write(">: ");
      
			string insertionFed  = Console.ReadLine();		
			while(!(DateTime.TryParseExact(insertionFed, "d/MM/yyyy", enEN, DateTimeStyles.None, out checkValue)))
			{
				Console.WriteLine("Please write correct format: ");
				Console.Write(">: ");
				insertionFed  = Console.ReadLine();
			}
			return checkValue;
	}
	
	static string[] AddingHolidayMethod(DateTime dateValue, DateTime futureValue)
	{
		CultureInfo enEN = new CultureInfo("en-GB"); 
			
		DateTime[] holidayList  = new DateTime[]
		{
			new DateTime(DateTime.Now.Year, 1, 1), // new year
			new DateTime(DateTime.Now.Year, 7, 4), //4th of july 
			new DateTime(DateTime.Now.Year, 11, 11), //thanks giving
			new DateTime(DateTime.Now.Year, 12, 25)  //Winter solace				
		};
		
		string[] yearHolliday = new string[holidayList.Length];
		for(int i = 0 ; i < holidayList.Length; i++)
		{
			 yearHolliday[i] = holidayList[i].ToString("dd/MM", enEN);		
		}
		return yearHolliday;

	}
	
	
	static string[] AddingSatMethod(DateTime dateValue, DateTime futureValue)
	{
		CultureInfo enEN = new CultureInfo("en-GB"); 
		DateTime[] saturdayList  = new DateTime[1];
		int newSize = 0;
		bool elseFlag = false;
		bool endOfSats = false;
		
		do
		{	
			Console.WriteLine("Please write the working saturdays(Write any other outside date to quit): ");
			
			DateTime checkValue = DateInsertionMethod();
			bool isBetweenTrueDates = (checkValue > dateValue) && (checkValue < futureValue);
			string toSatString = checkValue.ToString("ddd");
			
			if(toSatString == "Sat" && isBetweenTrueDates == true)
			{
				saturdayList[newSize] = checkValue;
				elseFlag = false;
			}
			else
			{
				Console.WriteLine("Please write a date between today and the date specified and is a saturday");
				elseFlag = true;
			}
			
			//to add new sats else end the block
			while(true)
			{
				string endingPos = "";
				Console.Write("\nDo you want to continue adding? [Y]/[N]: ");
				endingPos = Console.ReadLine();
				if(endingPos == "y" || endingPos == "Y")
				{	
					if(elseFlag == false)
					{	
						newSize++;
						Array.Resize(ref saturdayList, saturdayList.Length+newSize);
					}
					endOfSats = false;
					break;
				}
				else
				{
					endOfSats = true;
					break;
				}
			}
		}while(endOfSats == false);
		
		string[] newSatList = new string[saturdayList.Length];
		for(int i = 0 ; i < saturdayList.Length; i++)
		{
			 newSatList[i] = saturdayList[i].ToString("dd/MM/yyyy", enEN);
			 
		}
		return newSatList;
	}
	
	static void WorkDayChecker(DateTime dateValue, DateTime futureValue)
	{
		CultureInfo enEN = new CultureInfo("en-GB"); 
		 
		//adding list of holidays
		string[] holidayList = AddingHolidayMethod(dateValue, futureValue);
		string[] saturdayList = AddingSatMethod(dateValue, futureValue);
		DateTime workDays = dateValue;
		TimeSpan daysDiff = futureValue - dateValue; //using timeSpan
		int enumerator = (int)daysDiff.Days; 
		int calculation = 0;

		for(int i = 1; i < enumerator + 2; i++) 
		{		
	
			foreach(string m in holidayList)
			{
				bool ifWorkDaysH = (workDays.ToString("dd/MM", enEN)) == m; 
				if(ifWorkDaysH == true)
				{
					calculation--;
				}		
			}
			foreach(string m in saturdayList)
			{
				bool ifWorkDaysS = (workDays.ToString("dd/MM/yyyy", enEN)) == m; 
				if(ifWorkDaysS == true)
				{	
					calculation++;
				}		
			}
			
			if((workDays.ToString("ddd")) == "Sun" || (workDays.ToString("ddd")) == "Sat")
			{
				calculation--;
			}
			calculation++;
			workDays = DateTime.Now;
			workDays = workDays.AddDays(i);	
		}
	
		Console.WriteLine("You have approximately {0} working days from today {1} to last day {2}", calculation, dateValue.ToString("d/M/yy", enEN), futureValue.ToString("d/M/yy", enEN));
	}
	
	static void Main()
	{
		Console.WriteLine("Please write the date you want to calculate for workdays from today's date using d/MM/yyyy format");
		DateTime futureDate = DateInsertionMethod();
		DateTime todayDate = DateTime.Now;
	
		bool isInFuture = futureDate > todayDate;
		//tocheck if the date is in future
		while(isInFuture == false)
		{
			Console.WriteLine("You have written a date before today's date value");
			futureDate = DateInsertionMethod();
			if(futureDate > todayDate)
			{
				isInFuture = true;
			}
		}	
		WorkDayChecker(todayDate, futureDate);
	}
}
