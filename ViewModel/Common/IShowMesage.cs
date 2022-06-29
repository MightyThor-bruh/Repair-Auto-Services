using System.Windows.Forms;

namespace AutoService.ViewModel.Common
{
    public interface IShowMesage
    {
        bool Show(string text, string title, MessageBoxButtons button, MessageBoxIcon image);
    }
}
