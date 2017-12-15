using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Infrastructure.Entity;
namespace Infrastructure
{
   public class ClientSsh
    {
        private static readonly  ClientSsh clientSSH = new ClientSsh();
        private  SshClient sshClient = null;
        private ClientSsh()
        {
            uint port = uint.Parse(SSHInfo.Instance.local_port);
            string host = SSHInfo.Instance.local_ip;
            PasswordConnectionInfo passwordConnectionInfo = new PasswordConnectionInfo(SSHInfo.Instance.publish_ip, int.Parse(SSHInfo.Instance.publish_port), SSHInfo.Instance.publish_usr, SSHInfo.Instance.publish_pws);
            passwordConnectionInfo.Timeout = TimeSpan.FromSeconds(30);
            sshClient = new SshClient(passwordConnectionInfo);
            if (!sshClient.IsConnected)
            {
                sshClient.Connect();
            }

            ForwardedPortLocal localFwdPort = new ForwardedPortLocal(host, port, host, port);
            sshClient.AddForwardedPort(localFwdPort);
            localFwdPort.Start();
        }
        public static ClientSsh Instance {
            get {
                return clientSSH;
            }
        }
        public void Disconnect() {
            sshClient.Disconnect();
        }
    }
}
