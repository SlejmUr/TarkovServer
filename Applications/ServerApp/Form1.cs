namespace ServerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtConsoleManagement.Hide();
        }
    }
}