using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLabCompleted
{
  class LogFile
  {
    private string _FileName = null;

    public LogFile(string FileName)
    {
      _FileName = FileName;
    }

    public LogFile()
    {
    }

    public string FileName
    {
      get { return _FileName;  }
      set { _FileName = value; }
    }

    public string ReadText()
    {
      string results = String.Empty;
      if (!String.IsNullOrEmpty(_FileName))
      {
        results = File.ReadAllText(_FileName);
      }
      return results;
    }

    public void WriteText(string TextToWrite)
    {
      if (!String.IsNullOrEmpty(_FileName))
      {
        File.WriteAllText(_FileName, TextToWrite + "\n");
      }
    }

    public void WriteText(
      string TextToWrite, Boolean NewLine)
    {
      if (NewLine)
      {
        TextToWrite += "\n";
      }
      if (!String.IsNullOrEmpty(_FileName))
      {
        File.WriteAllText(_FileName, TextToWrite);
      }
    }

    public void AppendText(string TextToWrite)
    {
      if (!String.IsNullOrEmpty(_FileName))
      {
        File.AppendAllText(_FileName, TextToWrite + "\n");
      }
    }

    public void AppendText(
      string TextToWrite, Boolean NewLine)
    {
      if (NewLine)
      {
        TextToWrite += "\n";
      }
      if (!String.IsNullOrEmpty(_FileName))
      {
        File.AppendAllText(_FileName, TextToWrite);
      }
    }
  }
}

