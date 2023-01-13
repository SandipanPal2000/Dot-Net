using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public class EvenArrayElements
    {
        public void Display()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12 };
            var result = (from indx in list
                          where indx % 2 == 0
                          select indx).ToList();
            foreach (var item in result)
                Console.WriteLine(item);
            Console.ReadLine();
        }

    }
}
