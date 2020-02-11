using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class OutcomeMeasurement
    {
        public string Grade { get; set; }
        public int? MathPreTest { get; set; }
        public int? MathPostTest { get; set; }
        public int? LanguagePreTest { get; set; }
        public int? LanguagePostTest { get; set; }
        public int? ReadingPreTest { get; set; }
        public int? ReadingFluencyTest { get; set; }
        public int? ReadingFluencyTest2 { get; set; }
        public int? ReadingFluencyTest3 { get; set; }
        public int? SelfEsteemPreTest { get; set; }
        public int? SelfEsteemPostTest { get; set; }
    }
}
