using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class FileWorkerSingleton
    {   
        private static readonly Lazy<FileWorkerSingleton> instance = 
            new Lazy<FileWorkerSingleton>(() => new FileWorkerSingleton());

        public static FileWorkerSingleton Instance { get { return instance.Value; } }
        public string FilePath { get; }

        public string Text { get; set; }
        private FileWorkerSingleton()
        {
            FilePath = "text.txt";
            ReadTextFromFile();              
        }

        public void WriteText(string text)
        {
            Text += text;
        }

        public void Save()
        {
            using(var writer = new StreamWriter(FilePath)) 
            {
                writer.WriteLine(Text);
            }
        }

        private void ReadTextFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Text = " ";
            }
            else
            {
                using(var reader = new StreamReader(FilePath))
                {
                    Text = reader.ReadToEnd();
                }
            }
        }
    }
}
