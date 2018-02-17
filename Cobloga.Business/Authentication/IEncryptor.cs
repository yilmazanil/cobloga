using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobloga.Business.Authentication
{
    public interface IEncryptor
    {
        string Encrypt(string clearText);
        string Decrypt(string cipherText);
    }
}
