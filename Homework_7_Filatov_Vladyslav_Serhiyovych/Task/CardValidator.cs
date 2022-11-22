﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class CardValidator
    {
        public static string CardValidate(string card_number)
        {
            if (LuhnAlgorithm(card_number))
            {
                string type = "This card is valid";
      
                if (card_number.Length == 15
                && string.Join("", card_number.Take(2)) is "34" or "37")
                {
                    type = "American Express";
                }
                else if (card_number.Length == 16
                && string.Join("", card_number.Take(2)) is "51" or "52" or "53" or "54" or "55")
                {
                    type = "MasterCard";
                }
                else if (card_number.Length is 13 or 16
                && string.Join("", card_number.Take(1)) is "4")
                {
                    type = "Visa";
                }

                return type;
            }
            else
                return "This card is invalid";
        }

        private static bool LuhnAlgorithm(string card_number)
        {
            int length = card_number.Length;

            int sum = 0;
            bool second = false;
            for (int i = length - 1; i >= 0; i--)
            {
                int d = card_number[i] - '0';

                if (second == true)
                    d = d * 2;

                sum += d / 10;
                sum += d % 10;

                second = !second;
            }

            if (sum % 10 == 0)
                return true;

            return false;
        }
    }
}