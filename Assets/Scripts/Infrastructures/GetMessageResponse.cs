using System;

[Serializable]
public class GetMessageResponse
{
    public MessageResponse[] messages;
}


[Serializable]
public struct MessageResponse
{
    public int food_id;
    public string text;
    public string created_at;
}
