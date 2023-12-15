using ReaLTaiizor.Colors;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Util;
using ReaLTaiizor.Manager;
using ServerLib.Utilities;

namespace ServerApp
{
    public partial class MainForm : PoisonForm
    {
        #region Load and stuff
        private readonly MaterialSkinManager MM;
        public MainForm()
        {
            InitializeComponent();
            MM = MaterialSkinManager.Instance;
            MM.EnforceBackcolorOnAllComponents = true;
            MM.Theme = MaterialSkinManager.Themes.DARK;
            MM.ColorScheme = new(MaterialPrimary.Grey900, MaterialPrimary.Grey700, MaterialPrimary.Grey500, MaterialAccent.Orange400, MaterialTextShade.WHITE);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text += $" - {Versions.ServerVersion}";
        }
        #endregion
        #region Start and stop
        private void startButton_Click(object sender, EventArgs e)
        {
            var text = ip_port_textBox.Text;
            var splitted = text.Split(":");
            var ip = splitted[0];
            var port = splitted[1];
            if (!int.TryParse(port, out int o_port))
            {
                Console.WriteLine("Port cannot be parsed!");
                return;
            }
            ServerLib.Main.InitAll(ip, o_port, enableSSLCheckBox.Checked);
            serverStatusLabel.Text = "Server Status: Online";
            serverStatusLabel.ForeColor = Color.Green;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ServerLib.Main.Stop();
            serverStatusLabel.Text = "Server Status: Offline";
            serverStatusLabel.ForeColor = Color.Red;
        }
        #endregion

        private void consoleVisiblityButton_Click(object sender, EventArgs e)
        {
            if (ExtConsoleManagement._IsConsoleOpen)
            {
                consoleVisiblityButton.Text = "Show Console";
            }
            else
            {
                consoleVisiblityButton.Text = "Hide Console";
            }
            ExtConsoleManagement.ChangeConsole();
            this.Focus();
        }
    }
}