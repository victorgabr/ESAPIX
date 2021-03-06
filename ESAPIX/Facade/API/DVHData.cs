#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class DVHData : SerializableObject
    {
        public DVHData()
        {
            _client = new ExpandoObject();
        }

        public DVHData(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double Coverage
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Coverage") ? _client.Coverage : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Coverage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Coverage = value;
            }
        }

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CurveData")
                        ? _client.CurveData
                        : default(DVHPoint[]);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DVHPoint[]>(sc => { return local._client.CurveData; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CurveData = value;
            }
        }

        public DoseValue MaxDose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MaxDose") ? _client.MaxDose : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.MaxDose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaxDose = value;
            }
        }

        public DoseValue MeanDose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MeanDose") ? _client.MeanDose : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.MeanDose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MeanDose = value;
            }
        }

        public DoseValue MedianDose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MedianDose")
                        ? _client.MedianDose
                        : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.MedianDose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MedianDose = value;
            }
        }

        public DoseValue MinDose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MinDose") ? _client.MinDose : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.MinDose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MinDose = value;
            }
        }

        public double SamplingCoverage
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SamplingCoverage")
                        ? _client.SamplingCoverage
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SamplingCoverage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SamplingCoverage = value;
            }
        }

        public double StdDev
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StdDev") ? _client.StdDev : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.StdDev; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StdDev = value;
            }
        }

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Volume") ? _client.Volume : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Volume = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}