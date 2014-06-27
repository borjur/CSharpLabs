using System;
using System.Collections.Generic;
using System.IO;

namespace DelegatesLab
{
  class FileSearchD
  {
    // Search for files in specified locations.
    // Once found, this class raises the FileFound event 
    // for each found file. 

    public String FileSpec;
    public String LookIn;
    public Boolean SearchSubfolders;

    public event FileFoundEventHandler FileFound;

    List<FileInfo> files = new List<FileInfo>();

    public FileSearchD(String lookIn, String fileSpec, Boolean searchSubFolders)
    {
      this.FileSpec = fileSpec;
      this.LookIn = lookIn;
      this.SearchSubfolders = searchSubFolders;
    }

    public List<FileInfo> Execute()
    {
      // Search for matching files.
      Search(this.LookIn);
      return files;
    }

    protected void OnFileFound(FileInfo file)
    {
      if (FileFound != null)
      {
        FileFound(this, new FileFoundEventArgs(file));
      }
    }

    internal virtual void Search(String Path)
    {
      DirectoryInfo localDirectory = new DirectoryInfo(Path);

      try
      {
        // Handle subfolders, if required.
        if (this.SearchSubfolders)
        {
          foreach (DirectoryInfo directory in
            localDirectory.GetDirectories())
          {
            Search(directory.FullName);
          }
        }

        // Search for matching file names.
        FileInfo[] localFiles =
          localDirectory.GetFiles(this.FileSpec);
        HandleFiles(localFiles);
        files.AddRange(localFiles);
      }
      catch (UnauthorizedAccessException)
      {
        // Don't do anything at all, just quietly 
        // get out. This means you weren't meant to 
        // be in this folder.
        // All other exceptions will bubble back out 
        // to the caller.
      }
    }
    
    private void HandleFiles(FileInfo[] localFiles)
    {
      foreach (FileInfo file in localFiles)
      {
        OnFileFound(file);
      }
    }
  }
}
