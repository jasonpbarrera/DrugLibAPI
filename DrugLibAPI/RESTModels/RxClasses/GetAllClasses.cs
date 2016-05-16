using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxClasses
{
    class GetAllClasses
    {


        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class rxclassdata
        {

            private rxclassdataUserInput userInputField;

            private rxclassdataRxclassMinConceptList rxclassMinConceptListField;

            /// <remarks/>
            public rxclassdataUserInput userInput
            {
                get
                {
                    return this.userInputField;
                }
                set
                {
                    this.userInputField = value;
                }
            }

            /// <remarks/>
            public rxclassdataRxclassMinConceptList rxclassMinConceptList
            {
                get
                {
                    return this.rxclassMinConceptListField;
                }
                set
                {
                    this.rxclassMinConceptListField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataUserInput
        {

            private string classTypeField;

            /// <remarks/>
            public string classType
            {
                get
                {
                    return this.classTypeField;
                }
                set
                {
                    this.classTypeField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataRxclassMinConceptList
        {

            private rxclassdataRxclassMinConceptListRxclassMinConcept[] rxclassMinConceptField;

            private string[] textField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("rxclassMinConcept")]
            public rxclassdataRxclassMinConceptListRxclassMinConcept[] rxclassMinConcept
            {
                get
                {
                    return this.rxclassMinConceptField;
                }
                set
                {
                    this.rxclassMinConceptField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataRxclassMinConceptListRxclassMinConcept
        {

            private string classIdField;

            private string classNameField;

            private string classTypeField;

            /// <remarks/>
            public string classId
            {
                get
                {
                    return this.classIdField;
                }
                set
                {
                    this.classIdField = value;
                }
            }

            /// <remarks/>
            public string className
            {
                get
                {
                    return this.classNameField;
                }
                set
                {
                    this.classNameField = value;
                }
            }

            /// <remarks/>
            public string classType
            {
                get
                {
                    return this.classTypeField;
                }
                set
                {
                    this.classTypeField = value;
                }
            }
        }



    }
}
