using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxClasses
{
    class GetClassByRxcui
    {


        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class rxclassdata
        {

            private rxclassdataUserInput userInputField;

            private rxclassdataRxclassDrugInfo[] rxclassDrugInfoListField;

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
            [System.Xml.Serialization.XmlArrayItemAttribute("rxclassDrugInfo", IsNullable = false)]
            public rxclassdataRxclassDrugInfo[] rxclassDrugInfoList
            {
                get
                {
                    return this.rxclassDrugInfoListField;
                }
                set
                {
                    this.rxclassDrugInfoListField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataUserInput
        {

            private string relaSourceField;

            private string relasField;

            private ushort rxcuiField;

            /// <remarks/>
            public string relaSource
            {
                get
                {
                    return this.relaSourceField;
                }
                set
                {
                    this.relaSourceField = value;
                }
            }

            /// <remarks/>
            public string relas
            {
                get
                {
                    return this.relasField;
                }
                set
                {
                    this.relasField = value;
                }
            }

            /// <remarks/>
            public ushort rxcui
            {
                get
                {
                    return this.rxcuiField;
                }
                set
                {
                    this.rxcuiField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataRxclassDrugInfo
        {

            private rxclassdataRxclassDrugInfoMinConcept minConceptField;

            private rxclassdataRxclassDrugInfoRxclassMinConceptItem rxclassMinConceptItemField;

            private string relaField;

            private string relaSourceField;

            /// <remarks/>
            public rxclassdataRxclassDrugInfoMinConcept minConcept
            {
                get
                {
                    return this.minConceptField;
                }
                set
                {
                    this.minConceptField = value;
                }
            }

            /// <remarks/>
            public rxclassdataRxclassDrugInfoRxclassMinConceptItem rxclassMinConceptItem
            {
                get
                {
                    return this.rxclassMinConceptItemField;
                }
                set
                {
                    this.rxclassMinConceptItemField = value;
                }
            }

            /// <remarks/>
            public string rela
            {
                get
                {
                    return this.relaField;
                }
                set
                {
                    this.relaField = value;
                }
            }

            /// <remarks/>
            public string relaSource
            {
                get
                {
                    return this.relaSourceField;
                }
                set
                {
                    this.relaSourceField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataRxclassDrugInfoMinConcept
        {

            private ushort rxcuiField;

            private string nameField;

            private string ttyField;

            /// <remarks/>
            public ushort rxcui
            {
                get
                {
                    return this.rxcuiField;
                }
                set
                {
                    this.rxcuiField = value;
                }
            }

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string tty
            {
                get
                {
                    return this.ttyField;
                }
                set
                {
                    this.ttyField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxclassdataRxclassDrugInfoRxclassMinConceptItem
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
