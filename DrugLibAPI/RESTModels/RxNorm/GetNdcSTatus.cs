using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxNorm
{
    class GetNdcSTatus
    {


        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class rxnormdata
        {

            private rxnormdataNdcStatus ndcStatusField;

            /// <remarks/>
            public rxnormdataNdcStatus ndcStatus
            {
                get
                {
                    return this.ndcStatusField;
                }
                set
                {
                    this.ndcStatusField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxnormdataNdcStatus
        {

            private string statusField;

            private string commentField;

            private rxnormdataNdcStatusNdcHistory ndcHistoryField;

            /// <remarks/>
            public string status
            {
                get
                {
                    return this.statusField;
                }
                set
                {
                    this.statusField = value;
                }
            }

            /// <remarks/>
            public string comment
            {
                get
                {
                    return this.commentField;
                }
                set
                {
                    this.commentField = value;
                }
            }

            /// <remarks/>
            public rxnormdataNdcStatusNdcHistory ndcHistory
            {
                get
                {
                    return this.ndcHistoryField;
                }
                set
                {
                    this.ndcHistoryField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class rxnormdataNdcStatusNdcHistory
        {

            private uint activeRxcuiField;

            private uint originalRxcuiField;

            private uint startDateField;

            private uint endDateField;

            /// <remarks/>
            public uint activeRxcui
            {
                get
                {
                    return this.activeRxcuiField;
                }
                set
                {
                    this.activeRxcuiField = value;
                }
            }

            /// <remarks/>
            public uint originalRxcui
            {
                get
                {
                    return this.originalRxcuiField;
                }
                set
                {
                    this.originalRxcuiField = value;
                }
            }

            /// <remarks/>
            public uint startDate
            {
                get
                {
                    return this.startDateField;
                }
                set
                {
                    this.startDateField = value;
                }
            }

            /// <remarks/>
            public uint endDate
            {
                get
                {
                    return this.endDateField;
                }
                set
                {
                    this.endDateField = value;
                }
            }
        }



    }
}
