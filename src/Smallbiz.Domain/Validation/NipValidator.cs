using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Smallbiz.Domain.Validation
{
    public static class NipValidator
    {
        private static readonly int[] Weight = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };

        public static bool IsValid(string? nip)
        {
            if(string.IsNullOrWhiteSpace(nip)) return false;
            nip = nip.Replace(" ", "").Replace("-", "");
            if (nip.Length != 10) return false;
            int[] Cyfra = new int[10];

            for(int i = 0; i < 10; i++)
            {
                if (!char.IsAsciiDigit(nip[i])) return false;
                Cyfra[i] = nip[i] - '0';
            }

            int suma = 0;
            for(int i = 0; i < 9; i++)
            {
                suma += Weight[i] * Cyfra[i];
            }
            return suma % 11 == Cyfra[9];
        }
    }
}
