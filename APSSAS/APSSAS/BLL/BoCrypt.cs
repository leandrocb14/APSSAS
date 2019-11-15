using APSSAS.Infraestrutura;
using APSSAS.Models;
using NETCore.Encrypt;
using System;
using System.IO;

namespace APSSAS.BLL
{
    public class BoCrypt
    {
        public byte[] CriptografarArquivo(UploadFileViewModel pUploadFileViewModel)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pUploadFileViewModel.File.InputStream.CopyTo(ms);
                if (ConstanteProcesso.ConvertStringToEnum(pUploadFileViewModel.Processo) == Processo.Encrypt)
                    return RealizarEncryptPorTipoCriptografia(ms.ToArray(), ConstanteCriptografia.ConvertStringToEnum(pUploadFileViewModel.TipoCriptografia), pUploadFileViewModel.Chave);
                else
                    return RealizarDecryptPorTipoCriptografia(ms.ToArray(), ConstanteCriptografia.ConvertStringToEnum(pUploadFileViewModel.TipoCriptografia), pUploadFileViewModel.Chave);
            }
        }

        private byte[] RealizarEncryptPorTipoCriptografia(byte[] pBytesFile, Criptografia pCriptografia, string pChave)
        {
            if (pCriptografia == Criptografia.Base64)
                return Convert.FromBase64String(EncryptProvider.Base64Encrypt(Convert.ToBase64String(pBytesFile)));
            else if (pCriptografia == Criptografia.DES)
                return EncryptProvider.DESEncrypt(pBytesFile, BuildKey(pChave, 24));
            else
                return Convert.FromBase64String(EncryptProvider.AESEncrypt(Convert.ToBase64String(pBytesFile), pChave));
        }

        private byte[] RealizarDecryptPorTipoCriptografia(byte[] pBytesFile, Criptografia pCriptografia, string pChave)
        {
            if (pCriptografia == Criptografia.Base64)
                return Convert.FromBase64String(EncryptProvider.Base64Decrypt(Convert.ToBase64String(pBytesFile)));
            else if (pCriptografia == Criptografia.DES)
                return EncryptProvider.DESDecrypt(pBytesFile, BuildKey(pChave, 24));
            else
                return Convert.FromBase64String(EncryptProvider.AESDecrypt(Convert.ToBase64String(pBytesFile), BuildKey(pChave, 32)));
            
        }

        private string BuildKey(string pKey, int pTamanhoMinimo)
        {
            if (pKey.Length == pTamanhoMinimo)
                return pKey;
            else
            {
                int i = 0;
                while (pKey.Length < pTamanhoMinimo)
                {
                    if (i >= 10)
                        i = 0;
                    pKey = pKey.Insert(0, Convert.ToString(i));
                    i++;
                }

                return pKey;
            }
        }
    }
}