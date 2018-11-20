using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary
{
    interface ICallAzureAPI
    {
        Task<bool> FaceSave(String vardas, string imagestr);
      
        Task<Face[]> UploadAndDetetFaces(string imageFilePath);

        Task<String> RecognitionAsync(String TempImgPath);
    }
}
