using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УП03
{
    internal class Process
    {
        uint N1, N2, X;

        /// <summary>
        /// Деление 64-битного блока на два подблока и взятие ключа из накопителя
        /// </summary>
        /// <param name="dateFragment"></param>
        /// <param name="keyFragment"></param>
        public Process(ulong dateFragment, uint keyFragment)
        {
            N1 = (uint)(dateFragment >> 32);
            N2 = (uint)((dateFragment << 32) >> 32);
            X = keyFragment;
        }

        /// <summary>
        /// Шифрование\расшифрование блока файла
        /// </summary>
        /// <param name="IsLastStep"></param>
        /// <returns></returns>
        public ulong Encrypt(bool IsLastStep)
        {
            return (Fourth(IsLastStep, Third(Second(First()))));
        }

        /// <summary>
        /// Первый подблок складывается по модулю 2^32 с фрагментом ключа
        /// </summary>
        /// <returns></returns>
        private uint First()
        {
            return (uint)((X + N1) % (Convert.ToUInt64(Math.Pow(2, 32))));
        }

        /// <summary>
        /// Проход подблока через таблицу подстановки, где группа бит отображается в другую группу бит 
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        private uint Second(uint S)
        {
            uint newS, S0, S1, S2, S3, S4, S5, S6, S7;

            S0 = S >> 28;
            S1 = (S << 4) >> 28;
            S2 = (S << 8) >> 28;
            S3 = (S << 12) >> 28;
            S4 = (S << 16) >> 28;
            S5 = (S << 20) >> 28;
            S6 = (S << 24) >> 28;
            S7 = (S << 28) >> 28;

            S0 = ReplaceTable.Table0[S0];
            S1 = ReplaceTable.Table1[0x10 + S1];
            S2 = ReplaceTable.Table2[0x20 + S2];
            S3 = ReplaceTable.Table3[0x30 + S3];
            S4 = ReplaceTable.Table4[0x40 + S4];
            S5 = ReplaceTable.Table5[0x50 + S5];
            S6 = ReplaceTable.Table6[0x60 + S6];
            S7 = ReplaceTable.Table7[0x70 + S7];

            newS = S7 + (S6 << 4) + (S5 << 8) + (S4 << 12) + (S3 << 16) +
                    (S2 << 20) + (S1 << 24) + (S0 << 28);

            return newS;
        }

        /// <summary>
        /// Сдвиг битов на 11 бит
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        private uint Third(uint S)
        {
            return (uint)(S << 11) | (S >> 21);
        }

        /// <summary>
        /// Сложение первого подблока с правым по модулю 2
        /// Второй блок приниает значение первого подблока
        /// Блоки меняются местами
        /// </summary>
        /// <param name="IsLastStep"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        private ulong Fourth(bool IsLastStep, uint S)
        {
            ulong N;

            S ^= N2;

            if (!IsLastStep)
            {
                N2 = N1;
                N1 = S;
            }
            else
                N2 = S;

            N = ((ulong)N2) | (((ulong)N1) << 32);

            return N;
        }
    }
}
