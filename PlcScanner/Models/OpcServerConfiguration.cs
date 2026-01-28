using Opc.Ua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PlcScanner.Models
{
    public class OpcServerConfiguration : ICloneable
    {
        private string ConfigurationFilePath;
        public OpcServerConfiguration()
        {

        }
        public OpcServerConfiguration(string name ) {
            ConfigurationFilePath = Path.Combine(
                Helper.GetPath(PathType.Server, name),
                "Configuration.xml");
            this.Name = name;
            if (File.Exists(ConfigurationFilePath))
            {
                this.LoadConfiguration();
            } else
            {
                this.ApplicationUri = $"urn:localhost:{Helper.ToUpperCamelCase(name)}";
                this.BaseAddresses = new List<string>
                {
                    "opc.tcp://localhost:4840"
                };
                this.MessageSecurityMode = MessageSecurityMode.None;
                this.SecurityPolicyURI = SecurityPolicies.None;
                this.UserPolicy = UserTokenType.Anonymous;
                this.TransportQuotas = 15000;
                this.CertificateSubjectName = $"CN={Helper.ToUpperCamelCase(name)}";
                this.AutoAcceptUntrustedCertificates = true;
                this.AddAppCertToTrustedStore = true;
                this.Store();
            }
        }
        public Opc.Ua.StringCollection GetBaseAddresses()
        {
            var sc = new Opc.Ua.StringCollection();
            foreach (var str in this.BaseAddresses)
            {
                sc.Add(str);
            }
            return sc;
        }
        public string Name { get; set; }
        public string ApplicationUri { get; set; }
        public List<string> BaseAddresses { get; set; }
        public MessageSecurityMode MessageSecurityMode { get; set; }
        public string SecurityPolicyURI { get; set; }
        public UserTokenType UserPolicy { get; set; }
        public int TransportQuotas { get; set; }
        public string CertificateSubjectName { get; set; }
        public bool AutoAcceptUntrustedCertificates { get; set; }
        public bool AddAppCertToTrustedStore { get; set;  }
        public LogLevel LogLevel { get; set; }

        public void LoadConfiguration()
        {
            if (File.Exists(ConfigurationFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OpcServerConfiguration));
                using (StreamReader sr = new StreamReader(ConfigurationFilePath))
                {
                    var tmp = (OpcServerConfiguration)serializer.Deserialize(sr);
                    this.ApplicationUri = tmp.ApplicationUri;
                    this.BaseAddresses = tmp.BaseAddresses;
                    this.MessageSecurityMode = tmp.MessageSecurityMode;
                    this.SecurityPolicyURI = tmp.SecurityPolicyURI;
                    this.UserPolicy = tmp.UserPolicy;
                    this.TransportQuotas = tmp.TransportQuotas;
                    this.CertificateSubjectName = tmp.CertificateSubjectName;
                    this.AutoAcceptUntrustedCertificates = tmp.AutoAcceptUntrustedCertificates;
                    this.AddAppCertToTrustedStore = tmp.AddAppCertToTrustedStore;
                    this.LogLevel = tmp.LogLevel;
                    sr.Close();
                    sr.Dispose();
                }
            }
        }
        public void Store()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OpcServerConfiguration));
            using (TextWriter tw = new StreamWriter(ConfigurationFilePath))
            {
                serializer.Serialize(tw, this);
                tw.Close();
                tw.Dispose();
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
