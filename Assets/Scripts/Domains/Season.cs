using System;

public readonly struct Season
{
    public int FoodId { get; }
    public DateTime StartAt { get; }
    public DateTime EndAt { get; }

    public Season(int foodId, string startAt, string endAt)
    {
        FoodId = foodId;
        StartAt = DateTime.Parse(startAt);
        EndAt = DateTime.Parse(endAt);
    }

    public readonly bool IsWithIn(DateTime now)
    {
        if (now < StartAt) return false;
        if (now > EndAt) return false;
        return true;
    }
}