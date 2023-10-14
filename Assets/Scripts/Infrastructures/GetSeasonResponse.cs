using System;

[Serializable]
public class GetSeasonResponse
{
    public SeasonResponse[] seasons;
}


[Serializable]
public struct SeasonResponse
{
    public int id;
    public string name;
    public string start_at;
    public string end_at;
}