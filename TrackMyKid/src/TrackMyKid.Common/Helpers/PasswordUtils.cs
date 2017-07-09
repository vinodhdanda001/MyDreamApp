﻿using System;
using System.Security.Cryptography;

namespace TrackMyKid.Common.Helpers
{
    public class PasswordUtils
    {
        public const int SaltByteSize = 24;
        public const int HashByteSize = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash 
        public const int Pbkdf2Iterations = 1000;
        public const int IterationIndex = 0;
        public const int SaltIndex = 1;
        public const int Pbkdf2Index = 2;

        public static Password Hash(string password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            
            return new Password
            {
                Hash = Convert.ToBase64String(hash), 
                Salt = Convert.ToBase64String(salt)
            };
        }

        public static bool Validate(string password, string passwordHash, string passwordSalt)
        {
            byte[] salt = Convert.FromBase64String(passwordSalt);
            byte[] hash = Convert.FromBase64String(passwordHash);

            var testHash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt) {IterationCount = iterations};

            return pbkdf2.GetBytes(outputBytes);
        }
    }

    public class Password
    {
        public string Hash;
        public string Salt;
    }
}