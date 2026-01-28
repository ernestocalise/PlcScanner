using Opc.Ua;
using Opc.Ua.Server;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using PlcScanner.Models;
using System.Threading;
using PlcScanner.Routine;

namespace PlcScanner
{
    internal class OpcUaSimulationServer : StandardServer
    {
        private XMLOpcNodeManager nodeManager;
        private string Name;
        public OpcServerConfiguration OpcServerConfiguration;
        private LogHandler _log;
        private RoutineScheduler _scheduler;
        public bool IsRunning { get; private set; }
        public OpcUaSimulationServer(string name) : base ()
        {
            this.Name = name;
            this.IsRunning = false;
            this.OpcServerConfiguration = new OpcServerConfiguration(name);
            _log = new LogHandler(LogType.Server, (int)OpcServerConfiguration.LogLevel, name);
        }
        public void SetOpcServerConfiguration(OpcServerConfiguration input)
        {
            this.OpcServerConfiguration = input;
        }
        public LogHandler GetLogger()
        {
            return this._log;
        }
        public async Task<ApplicationConfiguration> GetConfiguration(string name)
        {

            var config = new ApplicationConfiguration
            {
                ApplicationName = name,
                ApplicationType = ApplicationType.Server,
                ApplicationUri = OpcServerConfiguration.ApplicationUri,

                ServerConfiguration = new ServerConfiguration
                {
                    BaseAddresses = OpcServerConfiguration.GetBaseAddresses(),
                    SecurityPolicies = new ServerSecurityPolicyCollection
                    {
                        new ServerSecurityPolicy
                        {
                            SecurityMode = OpcServerConfiguration.MessageSecurityMode,
                            SecurityPolicyUri = OpcServerConfiguration.SecurityPolicyURI
                        }
                    },
                    UserTokenPolicies = new UserTokenPolicyCollection
                    {
                        new UserTokenPolicy(OpcServerConfiguration.UserPolicy)

                    }
                },

                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas
                {
                    OperationTimeout = 15000
                },
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier
                    {
                        StoreType = "Directory",
                        StorePath = Path.Combine(Helper.GetPath(PathType.ServerCertificates, name), "Own"),
                        SubjectName = OpcServerConfiguration.CertificateSubjectName
                    },
                    TrustedPeerCertificates = new CertificateTrustList
                    {
                        StoreType = "Directory",
                        StorePath = Path.Combine(Helper.GetPath(PathType.ServerCertificates, name), "Peers")
                    },
                    TrustedIssuerCertificates = new CertificateTrustList
                    {
                        StoreType = "Directory",
                        StorePath = Path.Combine(Helper.GetPath(PathType.ServerCertificates, name), "Issuer"),
                    },
                    RejectedCertificateStore = new CertificateTrustList
                    {
                        StoreType = "Directory",
                        StorePath = Path.Combine(Helper.GetPath(PathType.ServerCertificates, name), "Rejected")
                    },
                    AutoAcceptUntrustedCertificates = OpcServerConfiguration.AutoAcceptUntrustedCertificates,
                    AddAppCertToTrustedStore = OpcServerConfiguration.AddAppCertToTrustedStore
                },
                DisableHiResClock = false
            };
            config.TraceConfiguration = new TraceConfiguration
            {
                OutputFilePath = @"OpcLogs.log",
                TraceMasks = Utils.TraceMasks.All,
            };


            try
            {
                await config.Validate(ApplicationType.Server);
                _log.WriteDebug("Configuration Initialized");
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to initialize configuration! [{ex.Message}]");
            }

            return config;
        }
        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            nodeManager = new XMLOpcNodeManager(server, configuration, this.Name);
            nodeManager.SetLogger(_log);
            return new MasterNodeManager(
                server,
                configuration,
                null,
                nodeManager);
        }
        protected override ServerProperties LoadServerProperties()
        {
            return new ServerProperties
            {
                ManufacturerName = "PlcScanner",
                ProductName = "PlcScanner Simulation Server",
                ProductUri = "urn:PlcScanner:OpcUaSimServer",
                SoftwareVersion = "1.0",
                BuildNumber = "1",
                BuildDate = DateTime.UtcNow
            };
        }
        protected override void OnServerStarting(ApplicationConfiguration configuration)
        {
            _log.WriteInfo("Starting Server...");
            base.OnServerStarting(configuration);
        }
        protected override void OnServerStarted(IServerInternal server)
        {
            base.OnServerStarted(server);
            _log.WriteInfo($"Server [{this.Name}] Started!");
            this.IsRunning = true;
            _scheduler = new RoutineScheduler(server.DefaultSystemContext);
        }
        protected override ValueTask OnServerStoppingAsync(CancellationToken cancellationToken = default)
        {
            _log.WriteInfo($"Server [{this.Name}] stopping!");
            this.IsRunning = false;
            return base.OnServerStoppingAsync(cancellationToken);
        }
        public void AddRoutine(string RoutinePath, string rName)
        {
            StreamReader sr = new StreamReader(RoutinePath);
            string str = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            if (RoutinePath.EndsWith("json"))
            {
                List<TagChange> changes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TagChange>>(str);
                _scheduler.RegisterRoutine(new RecordedRoutine(rName, changes, nodeManager));
            } else
            {
                List <ProgrammedRoutineStep> steps = JsonConvert.DeserializeObject<List<ProgrammedRoutineStep>>(str);
                _scheduler.RegisterRoutine(new ProgrammedRoutine(rName, steps, nodeManager));
            }
        }
        public BaseRoutine GetRoutineByName(string name)
        {
            return _scheduler.GetRoutineByName(name);
        }
        public void StartRoutineByName(string name)
        {
            _scheduler.StartRoutine(name);
        }
        public void StopAllRoutines()
        {
            if(_scheduler != null )
            _scheduler.StopAllRoutines();
        }
    }
}
