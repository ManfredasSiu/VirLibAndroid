
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary
{
    class FaceApiCalls : ICallAzureAPI
    {
        String _groupName = "UsersAndroid", _groupId = "usersAndroid";
        private IFaceServiceClient faceServiceClient;

        public FaceApiCalls()
        {
            try
            {
                faceServiceClient = new FaceServiceClient("782b7ef7c9ac484f8598b446283ea5cd", "https://northeurope.api.cognitive.microsoft.com/face/v1.0");
                CreateGroup();
            }
            finally { }
        }

        private async void CreateGroup()
        {
            await faceServiceClient.CreatePersonGroupAsync(_groupId, _groupName);
        }

        public async Task<bool> FaceSave(string vardas, string imagestr) //Veido issaugojimas Resource grupeje
        { 
            CreatePersonResult person = await faceServiceClient.CreatePersonAsync(_groupId, vardas); //Userio sukurimas
            try
            { 
                await faceServiceClient.AddPersonFaceAsync(_groupId, person.PersonId, imagestr);  //Veido pridejimas
                await faceServiceClient.TrainPersonGroupAsync(_groupId); //Grupe istreniruojama su nauju veidu
                return true;
            }
            catch
            {
                await faceServiceClient.DeletePersonAsync(_groupId, person.PersonId); //Jei treniravimas nepavyko - istrinti zmogu is grupes
                return false;
            }
        }

        public async Task<Face[]> UploadAndDetetFaces(string imageFilePath) //Veido atradimas
        {
            try
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    var faces = await faceServiceClient.DetectAsync(imageFileStream,
                        true,
                        true,
                        new FaceAttributeType[] {
                    FaceAttributeType.Gender,             //Gaunama lytis
                    FaceAttributeType.Age,                //Metai
                    FaceAttributeType.Emotion             //Veido emocija
                        });
                    return faces.ToArray();               //Grazinami visi nuotraukoje rasti veidai su ju atributais
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Face[0];
            }
        }

        public async Task<String> RecognitionAsync(String TempImgPath) //Veido atpazinimo uzklausa
        {

            Face[] faces = await UploadAndDetetFaces(TempImgPath); //Nuotraukoje atrandami veidai
            var faceIds = faces.Select(face => face.FaceId).ToArray(); //Veidu identifikaciniai numeriai perkeliami i kintamaji

            foreach (var identifyResult in await faceServiceClient.IdentifyAsync(_groupId, faceIds))
            {
                if (identifyResult.Candidates.Length != 0)
                {
                    var candidateId = identifyResult.Candidates[0].PersonId;  //Gauname visus atrastus veidus ir paimame veida arciausiai kameros
                    var person = await faceServiceClient.GetPersonAsync(_groupId, candidateId); //Gauname naudotojo informacija pagal jo veida
                    return person.Name;
                    // user identificated: person.name is the associated name
                }
            }
            return null;
        }
    }
}

