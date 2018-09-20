using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CommonToolLib.CommanTools
{
    public class Rc4Encryption
    {
        byte[] S = new byte[256];  //状态向量S
        byte[] T = new byte[256];  //临时向量T
        byte[] K = new byte[16] { 15, 79, 11, 203, 9, 48, 39, 19, 22, 93, 52, 234, 106, 148, 194, 210 };
        int kenlen = 16;

        public Rc4Encryption()
        { 
        }

        public bool Rc4Cryption(string plainfile, string cipherfile, string key)
        {
            InitialKey(key);
            try
            {
                FileStream pffs = new FileStream(plainfile, FileMode.Open);
                FileStream cffs = new FileStream(cipherfile, FileMode.Create);

                BinaryReader pfbr = new BinaryReader(pffs);
                BinaryWriter cfbw = new BinaryWriter(cffs);

                byte[] parr;
                int rl = 0, iptr = 0;

                while (iptr < pffs.Length)
                {
                    parr = pfbr.ReadBytes(1024);
                    rl = parr.Length;
                    iptr += rl;
                    byte[] carr = Rc4Cript(parr, rl);
                    cfbw.Write(carr);
                }
                cfbw.Flush();
                cfbw.Close();
                pfbr.Close();
                cffs.Close();
                pffs.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private byte [] Rc4Cript(byte [] plaintext, int lenth)
        {
            byte[] ciphertext = new byte[lenth];
            int m = 0, i = 0, j = 0;
            int t;
            byte k;
            int n = 0;
            byte temp;
            while (lenth != 0)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
                t = (S[i] + S[j]) % 256;
                k = (byte)S[t];
                int Ascii = plaintext[n] ^ k;
                byte r = (byte)Ascii;
                ciphertext[m++] = r;
                n++;
                lenth--;
            }

            return ciphertext;
        }

        private void InitialKey(string key)
        {
            kenlen = key.Length;

            K = ASCIIEncoding.ASCII.GetBytes(key);

            int i, j;
            //状态向量S的初始化
            for (i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
                T[i] = K[i % kenlen];
            }

            j = 0;
            byte temp;

            for (i = 0; i < 256; i++)
            {
                j = (j + (int)S[i] + T[i]) % 256;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }
            //状态向量S的初始化结束
        }

        public bool Rc4DeCript(string cipherfile, string plainfile, string key)
        {
            InitialKey(key);
            try
            {
                FileStream cffs = new FileStream(cipherfile, FileMode.Open);
                FileStream pffs = new FileStream(plainfile, FileMode.Create);

                BinaryReader cfbr = new BinaryReader(cffs);
                BinaryWriter pfbw = new BinaryWriter(pffs);

                byte[] carr;
                int rl = 0, iptr = 0;

                while (iptr < cffs.Length)
                {
                    carr = cfbr.ReadBytes(1024);
                    rl = carr.Length;
                    iptr += rl;

                    byte[] parr = Rc4Cript(carr, rl);
                    pfbw.Write(parr);
                }
                pfbw.Flush();
                pfbw.Close();
                cfbr.Close();
                pffs.Close();
                cffs.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Byte[] EncryptEx(Byte[] data, String pass)
        {
            if (data == null || pass == null) return null;
            Byte[] output = new Byte[data.Length];
            Int64 i = 0;
            Int64 j = 0;
            Byte[] mBox = GetKey(Encoding.ASCII.GetBytes(pass), 256);
            // 加密  
            for (Int64 offset = 0; offset < data.Length; offset++)
            {
                i = (i + 1) % mBox.Length;
                j = (j + mBox[i]) % mBox.Length;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
                Byte a = data[offset];
                //Byte b = mBox[(mBox[i] + mBox[j] % mBox.Length) % mBox.Length];  
                // mBox[j] 一定比 mBox.Length 小，不需要在取模  
                Byte b = mBox[(mBox[i] + mBox[j]) % mBox.Length];
                output[offset] = (Byte)((Int32)a ^ (Int32)b);
            }
            return output;
        }
        public Byte[] DecryptEx(Byte[] data, String pass)
        {
            return EncryptEx(data, pass);
        }
        /// <summary>  
        /// 打乱密码  
        /// </summary>  
        /// <param name="pass">密码</param>  
        /// <param name="kLen">密码箱长度</param>  
        /// <returns>打乱后的密码</returns>  
        static private Byte[] GetKey(Byte[] pass, Int32 kLen)
        {
            Byte[] mBox = new Byte[kLen];
            for (Int64 i = 0; i < kLen; i++)
            {
                mBox[i] = (Byte)i;
            }
            Int64 j = 0;
            for (Int64 i = 0; i < kLen; i++)
            {
                j = (j + mBox[i] + pass[i % pass.Length]) % kLen;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
            }
            return mBox;
        }  
    }
}
