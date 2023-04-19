using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public class Clock
{
    public uint hours { get; set; }
    public uint minutes { get; set; }

    public uint seconds { get; set; }

    public Clock(uint hours, uint minutes, uint seconds){
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

}

public static class Program
{
    public static int Request()
    {
    int answer = 0;
    Console.WriteLine("Do you want to change time?(1 - yes/ 0 - no)");
        answer = int.Parse(Console.ReadLine());
        if(answer != 0 && answer!=1)
            answer = 0;
        return answer;
    }
    public static uint GetData(string data)
    {
            Console.Write($"Enter {data}:");
            uint tmpData = uint.Parse(Console.ReadLine());
            return tmpData;
    }

     public static void CheckValidity(uint hours, uint minutes, uint seconds)
    {
        if (hours > 24 || minutes > 60 || seconds > 60 || hours < 0 || minutes < 0 || seconds < 0)
            Console.WriteLine("incorrect value");
      
    }

    public static string SaveInJSON(Clock timer)
    {
        string jsonTimer = JsonSerializer.Serialize(timer);
        return jsonTimer;
        //string jsonHours = JsonSerializer.Serialize(timer.hours);
        //string jsonMinutes = JsonSerializer.Serialize(timer.minutes);
        //string jsonSeconds = JsonSerializer.Serialize(timer.seconds);
        //Clock newTimer = new Clock();
        //newTimer.hours=JsonSerializer.Deserialize<uint>(jsonHours);
        //newTimer.minutes = JsonSerializer.Deserialize<uint>(jsonMinutes);
        //newTimer.seconds = JsonSerializer.Deserialize<uint>(jsonSeconds);
        //Console.WriteLine($"Time changed to {newTimer.hours}:{newTimer.minutes}:{newTimer.seconds}");
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(DateTime.Now);
        if(Request()==1)
            ChangeTime();      
    }
    
    public static void ChangeTime()
    {
        Clock timer = new Clock();
        uint hours = GetData("hours");
        uint minutes = GetData("minutes");
        uint seconds = GetData("seconds");        
        CheckValidity(hours, minutes, seconds);
        timer.GetValues(hours, minutes, seconds);
        SaveInJSON(timer);

    }
}