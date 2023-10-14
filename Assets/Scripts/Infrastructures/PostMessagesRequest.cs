using System;

[Serializable]
public struct PostMessagesRequest
{
    public int user_id;
    public int food_id;
    public string text;
    public PostMessagesRequest(int userId, int foodId, string text)
    {
        user_id = userId;
        food_id = foodId;
        this.text = text;
    }
}