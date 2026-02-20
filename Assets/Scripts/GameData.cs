using System;
using System.IO;
using UnityEngine;

public class GameData
{
    public enum Nation
    {
        NATION_A,
        NATION_B,
        OTHER
    }

    [System.Serializable]
    public struct DocumentData
    {
        [TextArea]
        public string DocText;
        public Nation Nation;
        public DecisionEffect ApproveEffectA;
        public DecisionEffect DeclineEffectA;
        public DecisionEffect ApproveEffectB;
        public DecisionEffect DeclineEffectB;
    }
    
    [System.Serializable]
    public struct DecisionEffect
    {
        public float Money;
        public float Oil;
        public float Land;
    }
}

public static class StaticGameData
{
    public static int peaceDays;
    public static int Approves;
    public static int Declines;

    public static void CollectData()
    {
        string res = $"{peaceDays};{Approves};{Declines}\n";
        
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(documentsPath, "CollectedData.txt");
        File.AppendAllText(filePath, res);
    }
}