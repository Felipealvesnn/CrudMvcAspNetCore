using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorattiMVC.Domain.Validation
{
   public class DommainValidacao : Exception
    {

        public DommainValidacao(string error): base (error)
        {
        }

        public static void Quando(bool TemError, string error) {

            if (TemError)
                throw new DommainValidacao(error);

        }
    }
}
