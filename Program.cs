using Microsoft.Win32;
namespace _22._07
{
    internal class Program
    {
        static void Main()
        {
            string keyPath = @"Software\MyApplication";
            DateTime lastAccessTime = LoadLastTimeVisit(keyPath);
            if (lastAccessTime == DateTime.MinValue)
            {
                Console.WriteLine("Welcome to _22._07");
            }
            else
            {
                Console.WriteLine("Last access time: " + lastAccessTime);
            }
            SaveLastTimeVisit(keyPath, DateTime.Now);
        }
        static DateTime LoadLastTimeVisit(string keyPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue("LastAccessTime");
                    if (value != null)
                    {
                        return Convert.ToDateTime(value);
                    }
                }
            }
            return DateTime.MinValue;
        }
        static void SaveLastTimeVisit(string keyPath, DateTime lastAccessTime)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                key.SetValue("LastAccessTime", lastAccessTime.ToString());
            }
        }
    }
}
