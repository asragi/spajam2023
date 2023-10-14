using System;

[Serializable]
public class GetAchievementResponse
{
    public AchievementResponse[] achievements;
}


[Serializable]
public struct AchievementResponse
{
    public int achievement_id;
    /// <summary>
    /// food id
    /// </summary>
    public int id;
    public string name;
    public bool is_achieved;
}
