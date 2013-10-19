using System;
using System.Security.Cryptography;


    public class RandomPasswordGenerator
    {
        // Define default password length.
        private static int DEFAULT_PASSWORD_LENGTH = 8;

        //No characters that are confusing: i, I, l, L, o, O, 0, 1, u, v

        public static string PASSWORD_CHARS_ALPHA =
                                "abcdefghjkmnpqrstwxyzABCDEFGHJKMNPQRSTWXYZ";
        public static string PASSWORD_CHARS_NUMERIC = "23456789";
        public static string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";
        public static string PASSWORD_CHARS_ALPHANUMERIC =
                                PASSWORD_CHARS_ALPHA + PASSWORD_CHARS_NUMERIC;
        public static string PASSWORD_CHARS_ALL =
                                PASSWORD_CHARS_ALPHANUMERIC + PASSWORD_CHARS_SPECIAL;

        //These overloads are only necesary in versions of .NET below 4.0

        private readonly Random _rng = new Random();
        private const string _chars = "ABCDFGHJKLMNPQRTUVWXY1269";

        public string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }

       

    }
