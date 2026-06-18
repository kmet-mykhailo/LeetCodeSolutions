namespace LeetcodeConsoleApp.Solutions.Staff;

public class AngleBetweenHandsOfClock : ISolution {
    public void Run()
    {
        (int hour, int minutes)[] inputs = [
            (12, 30), // 165
            (3, 15), // 7.5
            (3, 30) // 7.5
        ];
        foreach (var (hour, minutes) in inputs)
        {
            var result = AngleClock(hour, minutes);
            Console.WriteLine($"{hour}:{minutes} - {result}");
        }
    }
    
    public double AngleClock(int hour, int minutes)
    {
        double full = 360;
        double oneHour = full / 12;
        double oneMinute = full / 60;
        double half = full / 2; 

        double minuteAngle = oneMinute * minutes;
        double minutesPart = oneHour / (full / minuteAngle);
        double hourAngle = (oneHour * hour) % full + minutesPart;
        Console.WriteLine($"minuteAngle {minuteAngle}");
        Console.WriteLine($"hourAngle {hourAngle}");
        double angle = hourAngle > minuteAngle 
            ? hourAngle - minuteAngle
            : minuteAngle - hourAngle;
        
        Console.WriteLine($"angle {angle}");
        return  angle > half ? full - angle : angle ;
    }
}