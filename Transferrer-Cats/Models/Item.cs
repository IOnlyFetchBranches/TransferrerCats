using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferrer_Cats.Models
{
    public interface Item
    {
        /// <summary>
        /// Returns Identifier For an Item
        /// </summary>
        /// <returns></returns>
        string Identifier();

        void SetIdentifier(string id);
        /// <summary>
        /// Returns Date associated with item
        /// Whatever is here will be written at the end of the note.
        /// </summary>
        /// <returns></returns>
        DateTime Date();

        void SetDate(DateTime date);
    }
}
