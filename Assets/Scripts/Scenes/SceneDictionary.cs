using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneDictionary 
{
    private readonly static Dictionary<SceneEnum, string> s_dict;

    static SceneDictionary()
    {
        s_dict = new()
        {
            {SceneEnum.DevProvision, "DevProvision" },
            {SceneEnum.DevHttp, "DevHttp" },
            {SceneEnum.DevCamera, "DevCamera" },
            {SceneEnum.DevShake, "DevShake" },
            {SceneEnum.DevVibration, "DevVibration" },

        };
    }

    public static string Get(SceneEnum scene) => s_dict[scene];
}

public enum SceneEnum
{
    DevProvision,
    DevCamera,
    DevHttp,
    DevShake,
    DevVibration,
}
