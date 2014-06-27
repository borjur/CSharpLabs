using System;
using System.Collections.Generic;
using System.IO;

namespace DelegatesLabCompleted
{
  public class FileFoundCancelEventArgs : EventArgs
  {
    private FileInfo _file = null;

    internal Boolean Cancel = false;

    public FileFoundCancelEventArgs(FileInfo file)
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
