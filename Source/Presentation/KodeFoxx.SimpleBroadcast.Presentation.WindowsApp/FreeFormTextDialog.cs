using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    public partial class FreeFormTextDialog : Form
    {
        public string[] Content { get; private set; } = new string[] { };
        public bool HasParseErrors { get; private set; } = false;

        public FreeFormTextDialog()
        {
            InitializeComponent();            
        }

        private void cancelButton_Click(object sender, EventArgs e)
            => Close();
        private void okButton_Click(object sender, EventArgs e)
        { 
            Hide();
            ((Main)Owner).HandleArtistsFromFreeFormText(Content, HasParseErrors, this);
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            (HasParseErrors, Content) = TryParseFreeFormText(input.Text);
            previewList.Items.Clear();
            previewList.Items.AddRange(Content);

            if (HasParseErrors)
                previewList.ForeColor = Color.Salmon;
            else
                previewList.ForeColor = Color.LightGreen;            
        }        

        private (bool, string[]) TryParseFreeFormText(string freeFormText)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(freeFormText))
                    return (true, new[] { "Empty list" });

                var parsed = freeFormText.Split(Environment.NewLine)
                    .Where(l => !String.IsNullOrWhiteSpace(l))
                    .Select(l => l.Trim())
                    .ToArray();

                return (false, parsed);
            } catch(Exception exception) 
            {
                return (true, new[] { exception.Message });
            }
        }        
    }
}
