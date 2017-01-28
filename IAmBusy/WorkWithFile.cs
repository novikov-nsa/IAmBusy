using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace IAmBusy
{
    public partial class WorkWithFile
    {
        public string filename = null;
        public StorageFolder storageFolder = null;
        public StorageFile storageFileName = null;


        public async void CheckFileIsExist() //Проверка существует ли файл
        {

        }

        public async void CreateNewFile() //Создание нового файла
        {
            storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            storageFileName = await storageFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);

        }


        public async void ReadFromConfigFile()
        {
            Debug.WriteLine("");
            
            
            //чтение параметров из конфигюфайла
        }

        public async void WriteToConfigFile()
        {
            //запись измененных параметров в конфиг.файл
        }


    }
}
