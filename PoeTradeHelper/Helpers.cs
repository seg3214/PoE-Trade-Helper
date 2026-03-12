using System.IO;
namespace PoeTradeHelper
{
    public class Helpers
    {
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists) throw new DirectoryNotFoundException($"Not found: {dir.FullName}");
            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                file.CopyTo(Path.Combine(destinationDir, file.Name), true);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    CopyDirectory(subDir.FullName, Path.Combine(destinationDir, subDir.Name), true);
                }
            }
        }
        public static void FindGCF_fromDECIMALS()
        {

        }
        //GCF is the largest positive whole number that can divide two or more numbers evenly, with no remainder
        public static int FindGCF_fromINTS(int n1, int n2)
        {
            if (n1 == 0 || n2 == 0) return 0;
            int high1, low1;
            if (n1 > n2)
            {
                high1 = n1;
                low1 = n2;
            }
            else
            {
                high1 = n2;
                low1 = n1;
            }

            int res;
            res = high1 % low1;

            while (res != 0)
            {
                high1 = low1;
                low1 = res;

                res = high1 % low1;

            }
            //Debug.WriteLine($"n1={n1};n2={n2};gcf={low1}");
            return low1;
        }
        //LCM is the general term for the smallest positive integer that is divisible by two or more whole numbers.
        public static int FindLCM_fromINTS(int n1, int n2)
        {
            if (n1 == 0 || n2 == 0) return 0;
            int gcf = FindGCF_fromINTS(n1, n2);
            int lcd = n1 * n2 / gcf;

            // Debug.WriteLine($"n1={n1};n2={n2};lcd={lcd}");
            return lcd;
        }
    }
}