using Singleton;

var singleton = FileWorkerSingleton.Instance;

singleton.WriteText("Some text");
singleton.Save();