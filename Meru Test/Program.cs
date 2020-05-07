using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meru_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 6, 8, 3, 6, 12, 1, 2, 4, 2, 7, 9, 12, 3, 1, 6, 7, 10, 11 };
            var MaxSum = HighestSum(arr);
            Console.WriteLine(MaxSum);

            FindCustomer();

            Console.ReadKey();
        }

        static int HighestSum(int[] arr)
        {
            int MaxSum = 0, CurrentSum = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    CurrentSum = arr[i];
                ///if current number is a part of current series
                else if (arr[i]>arr[i-1])
                {
                    CurrentSum += arr[i];
                }
                ///new ascending series
                else
                {
                    if(CurrentSum > MaxSum)
                    {
                        MaxSum = CurrentSum;
                    }
                    CurrentSum = arr[i];
                }
                //Console.WriteLine($"CurrentSum: {CurrentSum}");
            }


            return MaxSum > CurrentSum ? MaxSum : CurrentSum;
        }

        static void FindCustomer()
        {
            var db = new CustomerDBContext();

            var city = new City() { CityName = "Pune", State = "MH" };

            var area = new Area() { AreaName = "Pashan", City = city };

            var subarea = new SubArea() { Area = area, SubAreaName = "Pune City" };

            var cust = new Customer() { SubArea = subarea, Address = "593", CustMobNo = 1234567890, CustName = "Ameya" };

            db.Customers.Add(cust);

            db.SaveChanges();

            int MobilNumToSearch = 1234567890;
            var foundCust = db.Customers.Where(c => c.CustMobNo.Equals(MobilNumToSearch)).Select(c => new { c.CustName, c.Address, c.SubArea.SubAreaName, c.SubArea.Area.AreaName, c.SubArea.Area.City.CityName }).FirstOrDefault().ToString();


            Console.WriteLine(foundCust);
        }
    }
}
