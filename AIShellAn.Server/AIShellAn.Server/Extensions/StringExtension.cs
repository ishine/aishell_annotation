using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace AIShellAn.Server
{
    public static class StringExtenstion
    {
        public static string GetMD5HashCode(this string inputString)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString ?? ""));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将字符串中的半角字符转成全角字符。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSBC(this string value)
        {
            char[] chars = value.ToCharArray();
            ushort c = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                c = chars[i];
                if (c == 32) c = 12288;
                else if (c < 128) c += 65248;
                chars[i] = (char)c;
            }
            return new string(chars);
        }

        /// <summary>
        /// 将字符串中的全角字符转成半角字符。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDBC(this string value)
        {
            char[] chars = value.ToCharArray();
            ushort c = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                c = chars[i];
                if (c == 12288) c = 32;
                else if (c > 65280 && c < 65375) c -= 65248;
                chars[i] = (char)c;
            }
            return new string(chars);
        }

        /// <summary>
        /// 判断是否身份证号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIdCode(this string value)
        {
            var result = false;
            if (Regex.IsMatch(value, @"^[0-9|X|x]{1,}$"))
            {
                if (Regex.IsMatch(value, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$"))
                {
                    result = true;
                }
                else
                {
                    if (value.Length == 18)
                    {
                        value = value.ToUpper();//允许输入小写x
                        int[] wQuan = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
                        string checkWei = "10X98765432";
                        string number17 = value.Substring(0, 17);
                        string number18 = value.Substring(17);
                        int sum = 0;
                        for (int i = 0; i < 17; i++)
                        {
                            sum = sum + Convert.ToInt32(number17[i].ToString()) * wQuan[i];
                        }
                        int mod = sum % 11;
                        string rst = checkWei[mod].ToString();
                        if (number18.Equals(rst, StringComparison.OrdinalIgnoreCase))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
