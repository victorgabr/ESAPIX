#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class Applicator : AddOn
    {
        public Applicator()
        {
            _client = new ExpandoObject();
        }

        public Applicator(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}