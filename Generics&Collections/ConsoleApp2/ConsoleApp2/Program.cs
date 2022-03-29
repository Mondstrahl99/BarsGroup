using ConsoleApp2;

var localFileLogger = new LocalFileLogger<int>(@"C:\Users\Ainur\Documents\Log.txt");
var localFileLogger1 = new LocalFileLogger<string>(@"C:\Users\Ainur\Documents\Log.txt");
var localFileLogger2 = new LocalFileLogger<double>(@"C:\Users\Ainur\Documents\Log.txt");

localFileLogger.LogInfo("info from localFileLogger");
localFileLogger.LogWarning("warning from localFileLogger");
localFileLogger.LogError("error from localFileLogger", new ArgumentException());

localFileLogger1.LogInfo("info from localFileLogger1");
localFileLogger1.LogWarning("warning from localFileLogger1");
localFileLogger1.LogError("error from localFileLogger1", new StackOverflowException());

localFileLogger2.LogInfo("info from localFileLogger2");
localFileLogger2.LogWarning("warning from localFileLogger2");
localFileLogger2.LogError("error from localFileLogger2", new DivideByZeroException());