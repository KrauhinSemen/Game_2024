using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ChangerScene
{
    public List<Sentence> sentences;
    public Sprite background;
    public ChangerScene nextScene;
    public bool IsLastScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Character character;
    }
}

public class ChangerScene: ScriptableObject
{}