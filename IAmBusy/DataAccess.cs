using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Windows.Storage;
using System.Runtime.CompilerServices;



namespace IAmBusy
{
    public class DataAccess
    {
        public const string fileName = "messageFile.dat";
        public const string defaultMessageText = "Текст по умолчанию";
        public StorageFolder storageFolder = null;
        public StorageFile storageFile = null;
        public string messageText = null;


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

        public async void StoreToFile(string mtext)
        {
            try
            {
                storageFile = await storageFolder.GetFileAsync(fileName);
                await Windows.Storage.FileIO.WriteTextAsync(storageFile, mtext);

            }
            catch (FileNotFoundException)
            {
                CreateNewFile();

            }
        }

        public async void ReadFromFile()
        {
            //StorageFolder sFolder = storageFolder;
            
           try
            {
                string stemp;
                //storageFolder = ApplicationData.Current.LocalFolder;
                storageFile = await storageFolder.GetFileAsync(fileName);

                //string stemp = await FileIO.ReadTextAsync(storageFile);
                var buffer = await FileIO.ReadBufferAsync(storageFile);
                using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
                {
                    stemp = dataReader.ReadString(buffer.Length);
                }

                messageText = stemp;
                

                //sOutMesText = messageText;
   
            }
            catch (FileNotFoundException)
            {
                CreateNewFile();
                Debug.WriteLine("Файл был создан");
            }
          

        }




    }

    public partial class RecordingView : INotifyPropertyChanged
    {
        private string textMessage;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string MessageTextProp
        {
            set
            {
                textMessage = value;
                OnPropertyChanged();
            }

            get
            {
                return textMessage;
            }
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}