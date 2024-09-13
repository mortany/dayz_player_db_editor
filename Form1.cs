namespace DZ_Players;

public partial class Form1 : Form
{
    private string _latestDbPath = string.Empty;
    private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
    public Form1()
    {
        InitializeComponent();
        CreateSettings();
    }

    private void CreateSettings() => _openFileDialog.Filter = "DayZ player datebase | *.db";

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (DialogResult.OK == _openFileDialog.ShowDialog(this))
        {
            _latestDbPath = _openFileDialog.FileName;
            panel1.LoadPlayerDB(_latestDbPath);
        }
    }

    private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(_latestDbPath != string.Empty) 
            panel1.ReloadDB(_latestDbPath);
    }
}
