using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferrer_Cats.Models
{
    public class SimpleItem:Item
    {
        private string id;

        public string ID => id;


        private DateTime date;

        private Mode mode;



        public string Identifier() => id;

        public DateTime Date() => date;


        public void SetIdentifier(string id)
        {
            this.id = id;
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }
    }
}
