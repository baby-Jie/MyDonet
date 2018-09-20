using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonToolLib.CommanTools
{
    public class Rc4CryptionHelper
    {
        /// <summary>
        /// 获取解密字符串 UTF-8
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="passKey"></param>
        /// <param name="outString"></param>
        /// <returns></returns>
        public static bool Rc4DecryptFromFileOutString(string filePath, string passKey, out string outString)
        { 
            if (!File.Exists(filePath))
            {
                outString = string.Empty;
                return false;
            }
            #region 读
            byte[] buffer;
            using (FileStream fsRead = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fsRead.Length];
                int n = fsRead.Read(buffer, 0, buffer.Length);
            }
            Rc4Encryption rc4 = new Rc4Encryption();
            byte[] buffer_out = rc4.DecryptEx(buffer, passKey);
            #endregion

            outString = Encoding.UTF8.GetString(buffer_out);

            if (string.IsNullOrWhiteSpace(outString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取加密字符串 UTF-8
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="passKey"></param>
        /// <param name="outString"></param>
        /// <returns></returns>
        public static bool Rc4EncryptFromFileOytString(string filePath, string passKey, out string outString)
        {
            if (!File.Exists(filePath))
            {
                outString = string.Empty;
                return false;
            }
            #region 读
            byte[] buffer;
            using (FileStream fsRead = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fsRead.Length];
                int n = fsRead.Read(buffer, 0, buffer.Length);
            }
            Rc4Encryption rc4 = new Rc4Encryption();
            byte[] buffer_out = rc4.EncryptEx(buffer, passKey);
            #endregion

            outString = Encoding.UTF8.GetString(buffer_out);

            if (string.IsNullOrWhiteSpace(outString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取解密文件
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="passKey"></param>
        public static void Rc4DecryptFile(string inputFilePath, string outputFilePath, string passKey)
        {
            #region 读
            byte[] buffer;
            using (FileStream fsRead = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fsRead.Length];
                int n = fsRead.Read(buffer, 0, buffer.Length);
            }
            Rc4Encryption rc4 = new Rc4Encryption();
            byte[] buffer_out = rc4.DecryptEx(buffer, passKey);
            #endregion

            #region 写
            using (FileStream fsWrite = File.Open(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                fsWrite.Write(buffer_out, 0, buffer_out.Length);
            }
            #endregion
        }

        public static void Rc4EncryptFile(string inputFilePath, string outputFilePath, string passKey)
        {
            #region 读
            byte[] buffer;
            using (FileStream fsRead = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fsRead.Length];
                int n = fsRead.Read(buffer, 0, buffer.Length);
            }
            Rc4Encryption rc4 = new Rc4Encryption();
            byte[] buffer_out = rc4.EncryptEx(buffer, passKey);
            #endregion

            #region 写
            using (FileStream fsWrite = File.Open(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                fsWrite.Write(buffer_out, 0, buffer_out.Length);
            }

            #endregion
        }
    }
}
