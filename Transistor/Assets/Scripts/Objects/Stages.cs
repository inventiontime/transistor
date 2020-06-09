using System;
using UnityEngine;

[CreateAssetMenu]
public class Stages : ScriptableObject
{
    public StageData[] stages;

    public int StageIndex(StageData stageData)
    {
        return Array.IndexOf(stages, stageData);
    }
}
