using System;
using System.Threading.Tasks;

namespace AutoService.ViewModel.Common
{
    public interface ILoadImage
    {
        string OpenFileDialog();
        string SaveImage(string filePath, string entityName,params Guid[] ids);
        void DeleteBackgroundLocal(string filePath, string pathToAdd);    
    }
}
