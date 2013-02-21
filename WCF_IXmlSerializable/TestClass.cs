using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace WCF_IXmlSerializable
{
    [XmlRoot("TEST_CLASS", Namespace = "www.test.com")]
    [XmlSchemaProvider("TestSchemaProvider")]
    public class TestClass : IXmlSerializable
    {
        public String TestType { get; set; }
        public String Duration { get; set; }
        public String TestDateTime { get; set; }

        public TestClass() { }        

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        //N.B. Code based on example on MSDN
        public static XmlQualifiedName TestSchemaProvider(XmlSchemaSet schemaSet)
        {            
            XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            //TODO Provide location of schema
            String xsdDir = "";
            String xsdFile = "TestSchema.xsd";
            XmlTextReader reader = new XmlTextReader(xsdDir + xsdFile);
            XmlSchema schema = (XmlSchema)schemaSerializer.Deserialize(reader, null);
            schemaSet.XmlResolver = new XmlUrlResolver();
            schemaSet.Add(schema);

            return new XmlQualifiedName("TestClass", "www.test.com");
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            //N.B. Not req. for this example
            throw new NotImplementedException();
        }

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            if (this.TestDateTime != null)
            {
                writer.WriteStartElement("TEST");
                if (this.TestType != null)
                    writer.WriteAttributeString("TYPE", this.TestType);
                if (this.Duration != null)
                    writer.WriteAttributeString("DURATION", this.Duration);
                writer.WriteString(this.TestDateTime);
                writer.WriteEndElement();
            }
        }
    }
}