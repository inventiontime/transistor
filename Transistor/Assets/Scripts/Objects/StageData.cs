using System;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public LevelData[] levels;
    public string stageName;

    public int LevelIndex(LevelData levelData)
    {
        return Array.IndexOf(levels, levelData);
    }
}
