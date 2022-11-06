using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesFormApp.Classes
{
    internal class BogusOperations
    {
        public static void SimpleText()
        {
            var lorem = new Bogus.DataSets.Lorem(locale: "en");
            
            Debug.WriteLine(lorem.Lines());
        }
    }
}
