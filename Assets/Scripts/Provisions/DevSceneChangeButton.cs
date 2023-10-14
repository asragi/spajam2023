using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSceneChangeButton : MonoBehaviour
{
    public SceneEnum TransitionTo;
    private SceneChange _sceneChange;

    private void Awake()
    {
        _sceneChange = new();
    }

    public void OnClick()
    {
        _sceneChange.ChangeScene(TransitionTo);
    }

    private void Update()
    {
        _sceneChange.Update();
    }
}
