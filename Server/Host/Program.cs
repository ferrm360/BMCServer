using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Service.Implements;
using Service.Factories;


namespace Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost accountServiceHost = new ServiceHost(typeof(AccountService)))
                {
                    accountServiceHost.Open();
                    Console.WriteLine("AccountService is running...");


                    Console.WriteLine("Pre using");
                    Console.ReadLine();

                    using (ServiceHost chatServiceHost = new ServiceHost(typeof(ChatService)))
                    {
                        chatServiceHost.Open();
                        Console.WriteLine("PreOpen");
                        Console.ReadLine();
                     
                        Console.WriteLine("ChatService is running...");
                        Console.ReadLine();

                        using (ServiceHost profileServiceHost = new ServiceHost(typeof(ProfileService)))
                        {
                            profileServiceHost.Open();
                            Console.WriteLine("ProfileService is running...");
                            Console.WriteLine("Services are up and running.");
                            Console.WriteLine("Press Enter to terminate the services.");
                            Console.ReadLine();

                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
