using System;

[Serializable]
public struct PostAchievementRequest
{
    public int user_id;
    public int achievement_id;

    public PostAchievementRequest(int userId, int achievementId)
    {
        user_id = userId;
        achievement_id = achievementId;
    }
}
