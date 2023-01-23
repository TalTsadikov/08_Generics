using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    abstract class Dice<T> where T : IComparable<T>
    {
        public T Scalar { get; set; }
        public T BaseDie { get; set; }

        public Dice(T scalar, T baseDie)
        {
            this.Scalar = scalar;
            this.BaseDie = baseDie;
        }

        public abstract T RandomNumber();
    }

    class IntDice : Dice<int> , IRandomProvider
    {
        public int Scalar { get; set; }
        public int BaseDie { get; set; }
        public int Modifier { get; set; }

        public IntDice(int scalar, int baseDie) : base(scalar, baseDie) { }

        public override int RandomNumber()
        {
            int result = 0;

            for (int i = 0; i < base.Scalar; i++)
            {
                result += Random.Shared.Next(1, base.BaseDie + 1);
            }

            result += Modifier;

            return result;
        }

        public override string ToString()
        {
            return Scalar + "d" + BaseDie + "" + (Modifier >= 0 ? "+" : "-") + Modifier;
        }

        public override bool Equals(object obj)
        {
            IntDice dice = (IntDice)obj;
            return Scalar == dice.Scalar && BaseDie == dice.BaseDie && Modifier == dice.Modifier;
        }
    }
}