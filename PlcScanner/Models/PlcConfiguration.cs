using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PlcScanner.Models
{
    public class PlcConfiguration : ICloneable
    {
        public int TransportQuotasTimeout;
        public int ClientTimeout;
        public string OldConfigurationName;
        public string EndpointUrl;
        public string CertificateStorePath;
        public string CertificateStoreType;
        public string CertificateSubjectName;
        public MessageSecurityMode SecurityMode;
        public string ConfigurationName;
        public int LogLevel;
        public string DiscoveryNodeId;
        public PlcConfiguration() {
            this.ConfigurationName = string.Empty;
            this.LogLevel = 0;
            this.TransportQuotasTimeout = 15000;
            this.ClientTimeout = 60000;
            this.EndpointUrl = string.Empty;
            this.CertificateStorePath = string.Empty;
            this.CertificateStoreType = string.Empty;
            this.CertificateSubjectName = string.Empty;
            this.SecurityMode = MessageSecurityMode.None;
            this.DiscoveryNodeId = string.Empty;
            this.OldConfigurationName = null;
        }

        public bool Store(bool isCopy)
        {
            string FolderPath = Helper.GetPath(PathType.Base);
            if (isCopy)
            {
                if(this.OldConfigurationName != null && this.OldConfigurationName != this.ConfigurationName)
                {
                    if (Directory.Exists(Path.Combine(FolderPath, this.ConfigurationName)))
                        return false;
                    
                    Helper.CopyFolder(Path.Combine(FolderPath, OldConfigurationName),
                                      Path.Combine(FolderPath, ConfigurationName));
                    FolderPath = Path.Combine(FolderPath, this.ConfigurationName);
                }
            } else
            {
                FolderPath = Path.Combine(FolderPath, this.ConfigurationName);
                if(Directory.Exists(FolderPath) && (this.OldConfigurationName != null && this.OldConfigurationName != this.ConfigurationName))
                {
                    MessageBox.Show("A project with this name already exists!");
                    return false;
                } else if 
                    (
                        !Directory.Exists(FolderPath) && 
                        (
                            this.OldConfigurationName != null && 
                            Directory.Exists(
                                Path.Combine(Helper.GetPath(PathType.Base),this.OldConfigurationName)
                                )


                         )
                     )
                    FolderPath = Helper.RenameProjectPath(this.OldConfigurationName, this.ConfigurationName);
                else
                {
                    FolderPath = Helper.GetPath(PathType.ProjectFolder, this.ConfigurationName);
                }
            }
                string FilePath = Path.Combine(FolderPath, "Configuration.xml");
                XmlSerializer ser = new XmlSerializer(typeof(PlcConfiguration));
                TextWriter tw = new StreamWriter(FilePath);
                ser.Serialize(tw, this);
                tw.Close();
            return true;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
