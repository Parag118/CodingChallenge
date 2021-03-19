using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
            var vowels = new Dictionary<char, char> { { 'a', '1' }, { 'e', '2' }, { 'i', '3' }, { 'o', '4' }, { 'u', '5' } };
            string consonants = "abcdefghijklmnopqrstuvwxyz";
            char alphabet = 'y';
            char[] messages = message.ToLower().ToCharArray();
            string result = "";
            string reverseNumber = string.Empty;

            foreach (var item in messages)
            {
                string numberResult = string.Empty;
                if (reverseNumber != string.Empty)
                    numberResult = reversDigits(Convert.ToInt32(reverseNumber)).ToString();

                if (Char.IsLetter(item.ToString(), 0) == true)
                {
                    if (item == alphabet)
                        result += numberResult + string.Join("", numberResult + item.ToString().Replace(alphabet.ToString(), " "));
                    else
                        result += numberResult + string.Join("", vowels.ContainsKey(item) ? vowels[item] : consonants[consonants.IndexOf(item) - 1]);
                    reverseNumber = string.Empty;
                }
                else if (Regex.IsMatch(item.ToString(), @"\d"))
                    reverseNumber += string.Join("", item.ToString());
                else
                {
                    result += numberResult + string.Join("", item.ToString().Replace(" ", alphabet.ToString()));
                    reverseNumber = string.Empty;
                }

                if (Regex.IsMatch(item.ToString(), @"\d") && message.Length - 1 == message.IndexOf(item))
                    result += reversDigits(Convert.ToInt32(reverseNumber)).ToString();


            }
            return result;



        }

        private int reversDigits(int num)
        {
            int rev_num = 0;
            while (num > 0)
            {
                rev_num = rev_num * 10 + num % 10;
                num = num / 10;
            }
            return rev_num;
        }
    }
}