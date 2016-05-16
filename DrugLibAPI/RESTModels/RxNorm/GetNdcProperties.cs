using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxNorm
{
    public class GetNdcProperties
    {

        #region Inner Class Models


        public class Rootobject
        {
            public Ndcpropertylist ndcPropertyList { get; set; }
        }

        public class Ndcpropertylist
        {
            public Ndcproperty[] ndcProperty { get; set; }
        }

        public class Ndcproperty
        {
            public string ndcItem { get; set; }
            public string ndc9 { get; set; }
            public string ndc10 { get; set; }
            public string rxcui { get; set; }
            public string splSetIdItem { get; set; }
            public Packaginglist packagingList { get; set; }
            public Propertyconceptlist propertyConceptList { get; set; }
        }

        public class Packaginglist
        {
            public string[] packaging { get; set; }
        }

        public class Propertyconceptlist
        {
            public Propertyconcept[] propertyConcept { get; set; }
        }

        public class Propertyconcept
        {
            public string propName { get; set; }
            public string propValue { get; set; }
        }


        #endregion

    }
}
