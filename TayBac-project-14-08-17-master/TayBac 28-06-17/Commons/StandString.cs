using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace TayBac_28_06_17.Commons
{
    public class StandString
    {
        public StandString()
        {

        }
        public static String generateBVID(int length)
        {
            const string alphanumericCharacters =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                //"abcdefghijklmnopqrstuvwxyz" +
        "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }
        public static String generateBNID(int length)
        {
            const string alphanumericCharacters =
       "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                //"abcdefghijklmnopqrstuvwxyz" +
       "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }
        public static String generateBESID(int length)
        {
            const string alphanumericCharacters =
       "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                //"abcdefghijklmnopqrstuvwxyz" +
       "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }
        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
        //
        public static string ConvertToUnsign(string str)
        {
            string[] signs = new string[] { 
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };
            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                {
                    str = str.Replace(signs[i][j], signs[0][i - 1]);
                }
            }
            return str;
        }
        //remove special character
        public static string RemoveSpecialCharacter(String str)
        {
            str = str.Trim();
            str = str.Replace(" ", "");
            str = str.Replace(",", "");
            str = str.Replace("-", "");
            return str;

        }
        //
        public static string FinalStandString(string str)
        {
            str = str.ToLowerInvariant();
            str = ConvertToUnsign(str);
            str = RemoveSpecialCharacter(str);
            return str;
        }

    }
}