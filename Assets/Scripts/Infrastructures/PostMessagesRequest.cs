using System;

[Serializable]
public struct PostMessagesRequest
{
    public int user_id;
    public int food_id;
    public string text;
    public bool is_user;
    public PostMessagesRequest(int userId, int foodId, string text, bool is_user)
    {
        user_id = userId;
        food_id = foodId;
        this.text = text;
        this.is_user = is_user;
    }
}