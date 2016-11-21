using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Algorithms
{
    public class Integer
    {

        public uint[] Value { get; }
        public uint NumeralBase { get; }


        public Integer(uint[] value, uint numeralBase)
        {
            Value = value;
            NumeralBase = numeralBase < 2 ? 2U : numeralBase;
        }

        public static Integer operator +(Integer number1, Integer number2)
        {
            if (number1.NumeralBase != number2.NumeralBase)
            {
                number2 = number2.GetInteger(number1.NumeralBase);
            }

            var sumArr = Add(number1.Value, number2.Value, number1.NumeralBase);

            return new Integer(sumArr, number1.NumeralBase);
        }

        public Integer GetInteger(uint numeralBase)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (NumeralBase <= 10)
            {
                return string.Join("", Value.Reverse());
            }
            else if (NumeralBase <= 16)
            {
                return string.Join("", (from v in Value.Reverse() select v.ToString("X")));
            }
            else
            {
                return string.Join(".", Value.Reverse());
            }
        }

        public static bool TryParse(string str, uint numeralBase, out Integer result)
        {
            result = null;

            try
            {
                result = Parse(str, numeralBase);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Integer Parse(string str, uint numeralBase)
        {
            // TODO: support of numeralBase > 16
            if (numeralBase > 16)
            {
                throw new NotImplementedException();
            }

            str = str.Trim();
            var components = str.Split(", ".ToCharArray());
            return new Integer((from component in components from ch in component select uint.Parse(ch.ToString(), NumberStyles.HexNumber)).Reverse().ToArray(), numeralBase);
        }

        public static uint[] Add(IList<uint> number1, IList<uint> number2, uint numeralBase = 2)
        {
            IList<uint> longer, shorter;
            uint[] result;

            if (number1.Count > number2.Count)
            {
                longer = number1;
                shorter = number2;
            }
            else
            {
                longer = number2;
                shorter = number1;
            }

            if (number2.Count == number1.Count)
            {
                result = new uint[longer.Count + 1];
            }
            else
            {
                result = new uint[longer.Count];
                
                for (var i = result.Length - 1; i > shorter.Count - 1; i--)
                {
                    result[i] = longer[i];
                }
            }
         
            for (var i = shorter.Count-1; i >=0; i--)
            {
                result[i] = longer[i];
                Add(result, i, shorter[i], numeralBase);
            }

            return result;
        }

        private static void Add(IList<uint> number, int index, uint value, uint numeralBase)
        {
            bool overflow;
            do
            {
                var result = number[index] + value;

                if (result < numeralBase)
                {
                    overflow = false;
                    number[index] = result;
                }
                else
                {
                    overflow = true;
                    number[index] = result - numeralBase;
                    value = 1;
                }
                index++;
            } while (index < number.Count && overflow);
        }
    }
}
