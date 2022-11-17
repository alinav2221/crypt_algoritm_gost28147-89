using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace УП03
{
    internal class E32
    {
        readonly byte[] encryptByteFile;
        readonly uint[] key;
        readonly ulong[] file;
        public E32(byte[] file, byte[] key)
        {
            this.key = GetKey(key);
            this.file = GetData(file);

            encryptByteFile = ConvertToByte(EncryptFile());
        }

        /// <summary>
        /// Получение байтов зашифрованного файла
        /// </summary>
        public byte[] GetEncryptFile
        {
            get { return encryptByteFile; }
        }

        /// <summary>
        /// Создание массива из шифрованных блоков (64 бита) файла  
        /// </summary>
        /// <returns></returns>
        private ulong[] EncryptFile()
        {
            Process[] K = new Process[8];
            ulong[] encryptFile = new ulong[file.Length];

            for (int k = 0; k < file.Length; k++)
            {
                encryptFile[k] = file[k];

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < K.Length; i++)
                    {
                        //создание накопителей N1 и N2 и ключа
                        K[i] = new Process(encryptFile[k], key[i]);
                        //процесс шифрования
                        encryptFile[k] = K[i].Encrypt(false);
                    }                 
                }

                for (int i = K.Length - 1; i >= 0; i--)
                {
                    K[i] = new Process(encryptFile[k], key[i]);

                    encryptFile[k] = i != 0 ? K[i].Encrypt(false) : K[i].Encrypt(true);
                }
            }

            return encryptFile;
        }

        /// <summary>
        /// Конвертирование зашифрованного блока в байты
        /// </summary>
        /// <param name="fl">Массив данных блоков файла</param>
        /// <returns></returns>
        public byte[] ConvertToByte(ulong[] fl)
        {
            byte[] temp = new byte[8];
            byte[] encryptByteFile = new byte[fl.Length * 8];

            for (int i = 0; i < fl.Length; i++)
            {
                temp = BitConverter.GetBytes(fl[i]);

                for (int j = 0; j < temp.Length; j++)
                    encryptByteFile[j + i * 8] = temp[j];
            }

            return encryptByteFile;
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
