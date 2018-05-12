using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    class DataValidations {

        public static void AssignStringIfNotNull(out string instanceVariable,string value ) {
            if (String.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }
            instanceVariable = value;
        }
    }
}
