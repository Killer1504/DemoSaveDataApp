using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSaveData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Đường dẫn tương đối
            string path = "data.json";
            //TestSaveData(path);
            TestReadData(path);
            Console.ReadKey();
        }

        public static void TestSaveData(string path)
        {
            var user = new User()
            {
                Id = 1,
                Name = "Hung",
                Age = 30,
            };

            var ret = SaveData(path, user);
            if (ret)
                Console.WriteLine("Lưu OK");
            else
            {
                Console.WriteLine("Lưu failed");
            }
        }

        public static void TestReadData(string path)
        {
            if (File.Exists(path) == false)
            {
                Console.WriteLine("File không tồn tại");
                return;
            }
            var user = ReadData(path);
            if (user != null)
            {
                var json = JsonConvert.SerializeObject(user);
                Console.WriteLine(json);
                return;
            }
            Console.WriteLine("Chưa có data");
        }

        public static bool SaveData(string path, User user)
        {
            var json = JsonConvert.SerializeObject(user);
            File.WriteAllText(path, json);
            return true;
        }

        public static User ReadData(string path)
        {
            var content = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<User>(content);
            return obj;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}