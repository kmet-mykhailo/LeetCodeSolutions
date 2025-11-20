namespace LeetcodeConsoleApp.Solutions.Intervals
{
    public class DetermineIfTwoEventsHaveConflict : ISolution
    {
        public void Run()
        {
            (string[] event1, string[] event2)[] inputs = [
                (["01:15", "02:00"], ["02:00", "03:00"]),// true
                (["10:00","11:00"],["14:00","15:00"]), // false
                (["14:13","22:08"],["02:40","08:08"]) // false
                ];
            foreach ((string[] event1, string[] event2) in inputs)
            {
                bool result = HaveConflict(event1, event2);
                Console.WriteLine(result);
            }
        }

        private static bool HaveConflict(string[] event1, string[] event2)
        {
            return (event2[0].CompareTo(event1[1]) <= 0) && (event2[1].CompareTo(event1[0]) >= 0);
        }

        private static bool HaveConflict3(string[] event1, string[] event2)
        {
            string[] event1StartSplitted = event1[0].Split(':');
            string[] event1EndSplitted = event1[1].Split(':');
            string[] event2StartSplitted = event2[0].Split(':');
            string[] event2EndSplitted = event2[1].Split(':');

            int event1Start = int.Parse(event1StartSplitted[0]) * 60 + int.Parse(event1StartSplitted[1]);
            int event1End = int.Parse(event1EndSplitted[0]) * 60 + int.Parse(event1EndSplitted[1]);

            int event2Start = int.Parse(event2StartSplitted[0]) * 60 + int.Parse(event2StartSplitted[1]);
            int event2End = int.Parse(event2EndSplitted[0]) * 60 + int.Parse(event2EndSplitted[1]);

            return event1Start < event2Start ? event2Start <= event1End : event1Start <= event2End;
        }

        private static bool HaveConflict2(string[] event1, string[] event2)
        {
            string format = "HH:mm";

            DateTime event1Start = DateTime.ParseExact(event1[0], format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime event1End = DateTime.ParseExact(event1[1], format, System.Globalization.CultureInfo.InvariantCulture);


            DateTime event2Start = DateTime.ParseExact(event2[0], format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime event2End = DateTime.ParseExact(event2[1], format, System.Globalization.CultureInfo.InvariantCulture);

            return event1Start < event2Start ? event2Start <= event1End : event1Start <= event2End;
        }

        private static bool HaveConflict1(string[] event1, string[] event2)
        {
            string[] event1Splitted = event1[1].Split(':');
            string[] event2Splitted = event2[0].Split(':');
            int hours1 = int.Parse(event1Splitted[0]);
            int hours2 = int.Parse(event2Splitted[0]);

            if (hours1 > hours2) return true;
            if (hours1 < hours2) return false;

            int minutes1 = int.Parse(event1Splitted[1]);
            int minutes2 = int.Parse(event2Splitted[1]);
            return minutes1 >= minutes2;
        }
    }
}
