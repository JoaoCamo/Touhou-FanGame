using System;

[Serializable]
public struct BossAttackData
{
    public string danmakuName;
    public int bulletType;
    public float initalShotDelay;
    public float shotDelay;
    public bool repeats;
}
