using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeployData : MonoBehaviour
{
    [SerializeField]
    Transform _seasonTab;
    [SerializeField]
    Transform _allTab;
    [SerializeField]
    Transform _achievedTab;
    [SerializeField]
    MessageOutline _outlinePrefab;
    [SerializeField]
    TalkMono _talkMono;

    private GetMessages _getMessages;
    private GetAchieves _getAchieves;
    private GetSeasons _getSeasons;
    private UserClient _userClient;

    // TODO: Š®‘S‚É‚â‚ß‚½‚¢
    private bool _inFetch;
    private bool _didMessageFetched;
    private bool _didAchievesFetched;
    private bool _didSeasonFetched;

    private GetMessageResponse _messages;
    private GetAchievementResponse _achieves;
    private GetSeasonResponse _seasons;

    private void Awake()
    {
        _userClient = new();
        _getMessages = GetComponent<GetMessages>();
        _getMessages.Initialize(OnFetchMessages);
        _getAchieves = GetComponent<GetAchieves>();
        _getAchieves.Initialize(OnFetchAchievement);
        _getSeasons = GetComponent<GetSeasons>();
        _getSeasons.Initialize(OnFetchSeasons);
        RefreshAllTalk();
    }

    private void Update()
    {
        Reload();
        if (!_inFetch) return;
        if (!_didMessageFetched || !_didAchievesFetched || !_didSeasonFetched) return;
        _inFetch = false;
        InstantiateAll();
    }

    public void RefreshAllTalk()
    {
        _inFetch = true;
        _didMessageFetched = false;
        _didAchievesFetched = false;
        _didSeasonFetched = false;
        _getMessages.Get(_userClient.UserId);
        _getAchieves.Get(_userClient.UserId);
        _getSeasons.Get();
    }

    private void OnFetchMessages(GetMessageResponse response)
    {
        _didMessageFetched = true;
        _messages = response;
    }

    private void OnFetchAchievement(GetAchievementResponse response)
    {
        _didAchievesFetched = true;
        _achieves = response;
    }

    private void OnFetchSeasons(GetSeasonResponse response)
    {
        _didSeasonFetched = true;
        _seasons = response;
    }

    int nowSelectedFoodId = 1;
    Dictionary<int, List<Message>> messageDict;

    private void InstantiateAll()
    {
        ClearAll();
        var currentTime = DateTime.Now;
        var seasons = _seasons.seasons;
        var seasonModels = seasons.Select(s => new Season(s.id, s.start_at, s.end_at));
        var seasonFoods = seasonModels.Where(s => s.IsWithIn(currentTime));
        Debug.Log($"seasonNum: {seasonModels.Count()}, seasonFood: {seasonFoods.Count()}");
        var foodNameDict = seasons.ToDictionary(s => s.id, s => s.name);

        var achievements = _achieves.achievements;
        var achievedFoodIds = achievements.Select(s => s.id).ToArray();

        var messages = _messages.messages;
        messageDict = new();

        foreach ( var message in messages )
        {
            var foodId = message.food_id;
            if (!messageDict.ContainsKey(foodId))
            {
                messageDict[foodId] = new List<Message>();
            }
            var m = new Message(
                foodId,
                foodNameDict[foodId],
                message.text,
                message.is_user
                );
            messageDict[foodId].Add(m);
        }

        Action CreateOnClick(int foodId, string name)
        {
            var messages = messageDict[foodId];
            return () =>
            {
                _talkMono.Initialize(_userClient.UserId, messages, foodId, name, OnReload);
                nowSelectedFoodId = foodId;
            };
        }

        foreach( var seasonFood in seasonFoods )
        {
            var foodId = seasonFood.FoodId;
            var name = foodNameDict[foodId];
            if (!messageDict.ContainsKey(foodId))
                continue;
            var lastMessage = messageDict[foodId].First();
            var obj = Instantiate(_outlinePrefab, _seasonTab);
            obj.Initialize(lastMessage, CreateOnClick(foodId, name));
        }

        foreach ( var achieved in achievedFoodIds )
        {
            var foodId = achieved;
            var name = foodNameDict[foodId];
            if (!messageDict.ContainsKey(foodId))
                continue;
            var lastMessage = messageDict[foodId].First();
            var obj = Instantiate(_outlinePrefab, _achievedTab);
            obj.Initialize(lastMessage, CreateOnClick(foodId, name));
        }
        
        foreach ( var s in seasons )
        {
            var foodId = s.id;
            var name = foodNameDict[foodId];
            if (!messageDict.ContainsKey(foodId))
                continue;
            var lastMessage = messageDict[foodId].First();
            var obj = Instantiate(_outlinePrefab, _allTab);
            obj.Initialize(lastMessage, CreateOnClick(foodId, name));
        }

        _talkMono.Refresh(messageDict[nowSelectedFoodId], nowSelectedFoodId);
    }

    private void ClearAll()
    {
        foreach (Transform t in _seasonTab.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in _allTab.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in _achievedTab.transform)
        {
            Destroy(t.gameObject);
        }
    }

    private void OnReload()
    {
        _shouldReload = true;
    }

    bool _shouldReload;
    int frame;
    private void Reload()
    {
        if (!_shouldReload) return;
        frame++;
        if (frame < 30) return;
        _shouldReload = false;
        frame = 0;
        RefreshAllTalk();
    }
}
