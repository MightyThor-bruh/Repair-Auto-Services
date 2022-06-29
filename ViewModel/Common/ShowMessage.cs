using System.Windows.Forms;

namespace AutoService.ViewModel.Common
{
    public class ShowMessage : IShowMesage
    {
        public bool Show(string text, string title, MessageBoxButtons button, MessageBoxIcon image)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show(text, title, button, image);
            return DialogResult.Yes == result;
        }
    }
}
