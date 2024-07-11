using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;

namespace Расписание
{
    public partial class aboutProgram : Form
    {
        public aboutProgram()
        {
            InitializeComponent();
        }

        private void aboutProgram_Load(object sender, EventArgs e)
        {
            try
            {
                using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "connection.txt")))
                {
                    var yaml = new YamlStream();
                    yaml.Load(reader);

                    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                    lblServer.Text = mapping.Children[0].Value.ToString();
                    lblDatabase.Text = mapping.Children[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
