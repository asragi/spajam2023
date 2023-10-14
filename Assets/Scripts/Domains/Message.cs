public readonly struct Message
{
    public int FoodId { get; }
    public string Writer { get; }
    public string Text { get; }
    public bool IsUser { get; }

    public Message(int foodId, string writer, string text, bool isUser)
    {
        FoodId = foodId;
        Writer = writer;
        Text = text;
        IsUser = isUser;
    }
}