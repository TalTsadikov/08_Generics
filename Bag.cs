using Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Bag : IRandomProvider
    {
        int drawnNumber;
        List<int> numbers = new List<int>();
        List<int> usedNumbers = new List<int>();

        public Bag(int maxNumber)
        {
            for (int i = 0; i < maxNumber; i++)
            {
                numbers.Add(i);
            }
        }

        public int RandomNumber()
        {
            if (numbers.Count == 0)
            {
                for (int i = 0; i < usedNumbers.Count; i++)
                {
                    numbers.Add(usedNumbers[i]);
                }

                usedNumbers.Clear();
                GetRandomNumber();
            }
            else
            {
                GetRandomNumber();
            }

            return drawnNumber;
        }

        private int GetRandomNumber()
        {
            var randomIndex = Random.Shared.Next(0, numbers.Count);

            drawnNumber = numbers[randomIndex];
            usedNumbers.Add(numbers[randomIndex]);
            numbers.Remove(numbers[randomIndex]);

            return drawnNumber;
        }
    }
}