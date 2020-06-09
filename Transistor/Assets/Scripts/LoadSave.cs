using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LoadSave
{
    public static List<List<int>> stars = new List<List<int>>();

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/progress.gd");
        bf.Serialize(file, stars);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/progress.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/progress.gd", FileMode.Open);
            stars = (List<List<int>>)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void SetSize()
    {
        Load();

        int i = 0;
        foreach (var x in GameManager.Instance.stages.stages)
        {
            i++;
            if (stars.Count < i)
            {
                stars.Add(new List<int>(x.levels.Length));
            }
            else
            {
                while (stars[i - 1].Count < x.levels.Length)
                {
                    stars[i - 1].Add(0);
                }
            }
        }

        Save();
    }
}