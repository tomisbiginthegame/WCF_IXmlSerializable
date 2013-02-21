using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_IXmlSerializable
{
    public class TestService : ITestService
    {
        public TestClass HelloWorld()
        {
            return new TestClass() { TestType = "Math", Duration = "1 hour", TestDateTime = DateTime.Now.ToString() };
        }
    }
}
