using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace NetJson
{
    class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<string> Roles { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread
            Account ac = GetAccount();
            try
            {
                
                var json = JsonSerializer.Serialize<Account>(ac);//将ac转换为json格式
                Console.WriteLine(json);
                //把json格式提取出来，生成对象
                Account dejson = JsonSerializer.Deserialize<Account>(json);
                Console.WriteLine(dejson.Email);
                Console.WriteLine(dejson.Active);
                Console.WriteLine(dejson.CreateDate);
                Console.WriteLine(dejson.Roles);
            }
            catch (Exception ex)
            {
                Console.WriteLine("出现异常！" + ex.Message);
            }
        }
        private static Account GetAccount()
        {
            Account account = new Account()
            {
                Email = "chunxin@email.com",
                Active = true,
                CreateDate = new DateTime(2021, 10, 7, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "admin",
                    "user"
                }
            };
            return account;
        }
    }
}
