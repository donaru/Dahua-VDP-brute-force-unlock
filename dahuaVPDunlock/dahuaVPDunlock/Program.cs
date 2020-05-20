using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dahuaVPDunlock
{
    // Donald - This was built because the security guy ran off with the password.
    class Program
    {
        static void Main(string[] args)
        {
            string password = "a";
            while (password != "admin")
            {
                // - Modify this area to point to the VDP login screen

                Console.WriteLine(password);
                password = GetNextBase26(password);
            }

        }

        private static string GetNextBase26(string a)
        {
            return Base26Sequence().SkipWhile(x => x != a).Skip(1).First();
        }

        private static IEnumerable<string> Base26Sequence()
        {
            long i = 0L;
            while (true)
                yield return Base26Encode(i++);
        }

        // Donald - Tech support the password is normally numeric and lowercase values only
        private static char[] base26Chars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private static string Base26Encode(Int64 value)
        {
            string returnValue = null;
            do
            {

                returnValue = base26Chars[value % 36] + returnValue;
                value /= 36;
            } while (value-- != 0);
            return returnValue;
        }
    }



        
    
}
