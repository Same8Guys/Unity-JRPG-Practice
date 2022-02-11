using System.Collections.Generic;
using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>
{
    // PREGAME, RUNNING PAUSED
    public enum GameState
    {
        Pregame,
        Running,
        Paused
    }
}