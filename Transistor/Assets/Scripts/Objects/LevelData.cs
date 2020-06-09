using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public GameObject[] gates = null;

    public int rows => 1 + TruthTable.Count;
    public int columns => header.Count;

    public List<char> header;
    public int noOfInputs;
    public int noOfOutputs;
    public List<myList> TruthTable;
    public int minNoOfGates;
    public string preLevelText;

    [System.Serializable]
    public class myList
    {
        public List<bool> list;
    }
}
