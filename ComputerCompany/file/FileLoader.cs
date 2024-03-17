using DistractedCompany;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileLoader : IDisposable
{
  public readonly Dictionary<string, string> files;
  private readonly string DataFolder;

  private readonly FileSystemWatcher watcher;

  public FileLoader()
  {
    DataFolder = Path.Combine(Application.persistentDataPath, "ComputerCompany");
    Directory.CreateDirectory(DataFolder);

    watcher = new FileSystemWatcher(DataFolder, "*.lua");

    watcher.Created += OnCreated;
    watcher.Changed += OnChanged;
    watcher.Deleted += OnDeleted;
    watcher.Error += OnError;

    watcher.EnableRaisingEvents = true;

    files = new DirectoryInfo(DataFolder).GetFiles("*.lua").ToDictionary(i => i.Name, i => File.ReadAllText(i.FullName));
  }

  // https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#cascade-dispose-calls
  public void Dispose() => watcher.Dispose();

  private void OnChanged(object sender, FileSystemEventArgs e)
  {
    files[e.Name] = File.ReadAllText(e.FullPath);
  }

  private void OnCreated(object sender, FileSystemEventArgs e)
  {
    files.Add(e.Name, File.ReadAllText(e.FullPath));
  }

  private void OnDeleted(object sender, FileSystemEventArgs e)
  {
    files.Remove(e.Name);
  }

  private void OnError(object sender, ErrorEventArgs e) =>
        Plugin.Log.LogError($"File watcher error");
}