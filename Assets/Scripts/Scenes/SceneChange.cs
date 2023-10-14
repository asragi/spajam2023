using System;
using UnityEngine.SceneManagement;

public class SceneChange
{
    private static readonly int TransitionFrame = 30;
    private readonly FrameWait _frameWait;
    private SceneEnum _sceneEnum;

    public SceneChange()
    {
        _frameWait = new(TransitionFrame, OnComplete);
    }

    public void ChangeScene(SceneEnum scene)
    {
        _frameWait.Start();
        _sceneEnum = scene;
    }

    public void Update()
    {
        _frameWait.Update();
    }

    private void OnComplete()
    {
        var str = SceneDictionary.Get(_sceneEnum);
        SceneManager.LoadScene(str);
    }

    private class FrameWait
    {
        private readonly int _totalFrame;
        private readonly Action _onComplete;
        private bool _isRunning;
        private int frame;

        public FrameWait(int frame, Action onComplete)
        {
            _totalFrame = frame;
            _onComplete = onComplete;
            _isRunning = false;
            frame = 0;
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Update()
        {
            if (!_isRunning) return;
            frame++;
            if (frame < _totalFrame) return;
            _onComplete();
            _isRunning = false;
        }
    }
}
