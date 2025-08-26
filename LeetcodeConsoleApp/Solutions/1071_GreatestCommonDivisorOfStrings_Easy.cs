namespace LeetcodeConsoleApp.Solutions
{
    public class GreatestCommonDivisorOfStrings : ISolution
    {
        public void Run()
        {
            string str1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZQJXZKMPVYWTBAOHNRLIEGDSCUFABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ"; //"ABABABABAB";
            string str2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZZYXWVUTSRQPONMLKJIHGFEDCBAABCDEFGHIJKLMNOPQRSTUVWXYZ";//"ABABA";
            string str3 = "ABABABABAB";
            string str4 = "ABAB";

            var result1 = GetGreatestCommonDivisorOfStrings2(str1, str2);
            var result2 = GetGreatestCommonDivisorOfStrings2(str3, str4);

            Console.WriteLine($"Result: {result1}");
            Console.WriteLine($"Result: {result2}");
        }

        private static string GetGreatestCommonDivisorOfStrings(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1 || string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return "";

            var str1Length = str1.Length;
            var str2Length = str2.Length;

            string divisor = str1Length <= str2Length ? str1 : str2;
            while (divisor.Length > 0)
            {
                var isSplit = str1Length % divisor.Length == 0
                    && str2Length % divisor.Length == 0;

                if (isSplit)
                {
                    break;
                }

                divisor = divisor.Remove(divisor.Length - 1);
            }

            return divisor;
        }

        private static string GetGreatestCommonDivisorOfStrings2(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1 || string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return "";

            int greatestCommonDevisor = str1.Length;
            int str2Length = str2.Length;

            while (str2Length != 0)
            {
                int temp = str2Length;
                str2Length = greatestCommonDevisor % str2Length;
                greatestCommonDevisor = temp;
            }

            return str1.Substring(0, greatestCommonDevisor);
        }
    }
}
