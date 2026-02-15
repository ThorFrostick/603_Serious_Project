
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
