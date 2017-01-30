using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Windows.Storage;

namespace IAmBusy
{
    public class DataAccess
    {
        public const string fileName = "messageFile.dat";
        public const string defaultMessageText = "Текст по умолчанию";
        public StorageFolder storageFolder = null;
        public StorageFile storageFile = null;
        public string messageText = null;
        public static string mText;


        public async void ValidateFile()
        {
            try
            {
                storageFolder = ApplicationData.Current.LocalFolder;
                storageFile = await storageFolder.GetFileAsync(fileName);
            }
            catch (FileNotFoundException)
            {
                CreateNewFile();
                
            }
        }

        public async void CreateNewFile()
        {
            storageFile = await storageFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.FailIfExists);
            await Windows.Storage.FileIO.WriteTextAsync(storageFile, defaultMessageText);
        }

        public async void ReadFromFile()
        {
            //StorageFolder sFolder = storageFolder;
            
          // try
          //  {
                
                //storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                //storageFile = await storageFolder.GetFileAsync(fileName);

                messageText = await Windows.Storage.FileIO.ReadTextAsync(storageFile);
                DataAccess.mText = await FileIO.ReadTextAsync(storageFile); ;
                //sOutMesText = messageText;
   
          //  }
          //  catch (FileNotFoundException)
          //  {
          //      CreateNewFile();
          //  }
          

        }


    }
}