using System;
using System.Collections.Generic;
using System.IO;

namespace DelegatesLab
{
  public class FileFoundEventArgs : EventArgs
  {
    private FileInfo _file = null;

    public FileFoundEventArgs(FileInfo file)
    {
      _file = file;
    }

    public FileInfo FileFound
    {
      get { return _file; }
      set { _file = value; }
    }
  }
}
