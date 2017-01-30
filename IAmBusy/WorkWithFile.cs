using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace IAmBusy
{
    public partial class WorkWithFile
    {
        public const string filename = "messageText.dat";
        public const string defaultText = "Я на данный момент занят, перезвоню позже";
        public string messageText = null;
        public StorageFolder storageFolder = null;
        public StorageFile storageFileName = null;
        public StorageFile dataFile = null;
        public string messageTextFromFile;


        public async void CheckFileIsExist() //Проверка существует ли файл
        {
            try
            {
                storageFolder = ApplicationData.Current.LocalFolder;
                dataFile = await storageFolder.GetFileAsync(filename);
                Debug.WriteLine("Файл существует. Имя файла " + filename);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("Файл не существует");
                CreateNewFile();
                messageText = defaultText;
                WriteToConfigFile(messageText);
            }
        }

        public async void CreateNewFile() //Создание нового файла
        {
            Debug.WriteLine("Создание файла");
            storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            storageFileName = await storageFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            Debug.WriteLine("Файл создан " + filename);
            messageText = defaultText;
            await FileIO.WriteTextAsync(storageFileName, messageText);
        }


        
        public async void getTextFromFile(string messageText)
        {
            dataFile = await storageFolder.GetFileAsync(filename);
            Debug.WriteLine("Получили значение свойства с именем файла " + filename);

            messageText = await FileIO.ReadTextAsync(dataFile);
            Debug.WriteLine("Прочитали значение из файла " + filename);
            Debug.WriteLine("В файле хранится значение" + messageText);
            this.messageTextFromFile = messageText;
        }

        public async void WriteToConfigFile(string messageText) //запись измененных параметров в конфиг.файл
        {
            await Windows.Storage.FileIO.WriteTextAsync(storageFileName, messageText);
            Debug.WriteLine("Записано значение "+messageText);
        }


    }
}
