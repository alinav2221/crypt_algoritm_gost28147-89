using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УП03
{
    internal class D32
    {
        readonly byte[] decryptByteFile;
        readonly uint[] key;
        readonly ulong[] file;
        public D32(byte[] file, byte[] key)
        {
            this.key = GetKey(key);
            this.file = GetData(file);

            decryptByteFile = ConvertToByte(DecryptFile());
        }

        /// <summary>
        /// Получение байтов расшифрованного файла
        /// </summary>
        public byte[] GetDecryptFile
        {
            get { return decryptByteFile; }
        }

        /// <summary>
        /// Создание массива из расшифрованных блоков (64 бита) файла  
        /// </summary>
        /// <returns></returns>
        private ulong[] DecryptFile()
        {
            Process[] K = new Process[8];
            ulong[] decryptFile = new ulong[file.Length];

            for (int k = 0; k < file.Length; k++)
            {
                decryptFile[k] = file[k];

                for (int i = 0; i < K.Length; i++)
                {
                    K[i] = new Process(decryptFile[k], key[i]);
                    decryptFile[k] = K[i].Encrypt(false);
                }

                for (int j = 0; j < 3; j++)
                {
                    for (int i = K.Length - 1; i >= 0; i--)
                    {
                        K[i] = new Process(decryptFile[k], key[i]);

                        decryptFile[k] = (j == 2) && (i == 0) ? K[i].Encrypt(true) : K[i].Encrypt(false);
                    }
                }
            }
            return decryptFile;
        }

        /// <summary>
        /// Конвертирование расшифрованных блоков в байты
        /// </summary>
        /// <param name="fl">Массив данных блоков файла</param>
        /// <returns></returns>
        public byte[] ConvertToByte(ulong[] fl)
        {
            byte[] temp = new byte[8];
            byte[] decryptByteFile = new byte[fl.Length * 8];

            for (int i = 0; i < fl.Length; i++)
            {
                temp = BitConverter.GetBytes(fl[i]);

                for (int j = 0; j < temp.Length; j++)
                    decryptByteFile[j + i * 8] = temp[j];
            }

            return decryptByteFile;
        }

        /// <summary>
        /// Создание 8 32-разрядных накопителей
        /// </summary>
        /// <param name="byteKey">Сгенерированный массив байт длиной 32</param>
        /// <returns></returns>
        public uint[] GetKey(byte[] byteKey)
        {
            uint[] key = new uint[8];

            for (int i = 0; i < key.Length; i++)
            {
                key[i] = BitConverter.ToUInt32(byteKey, i * 4);
            }

            return key;
        }

        /// <summary>
        /// Массив байт файла разбивается на блоки по 64 бита в каждом
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public ulong[] GetData(byte[] byteData)
        {
            ulong[] data = new ulong[byteData.Length / 8];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = BitConverter.ToUInt64(byteData, i * 8);
            }

            return data;
        }
    }
}

