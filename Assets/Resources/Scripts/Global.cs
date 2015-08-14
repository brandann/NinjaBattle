using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    [Header("Players")]
    public GameObject Player1;

    [Header("Goal")]
    public GameObject GoalItemObject;

    [Header("GameStateStatus")]
    public static GameState currentGameState;

    public enum GameState { NULL, Start, Game, End, Credits }

	// Use this for initialization
	void Start () {
        CurrentGameState = GameState.NULL;
	}
	
	// Update is called once per frame
	void Update () {
	    if(CurrentGameState == GameState.NULL)
        {
            CurrentGameState = GameState.Start;
        }
	}

    #region GameState
    public GameState CurrentGameState
    {
        set
        {
            switch (value)
            {
                case (GameState.Start):
                    break;
                case (GameState.Game):
                    break;
                case (GameState.End):
                    break;
                case (GameState.Credits):
                    break;
            }
            currentGameState = value;
        }
        get
        {
            return currentGameState;
        }
    }

    #endregion

    #region OnGameStart
    public delegate void GameStartDelegate();
    private GameStartDelegate OnGameStart;

    public void SetNewDayListener(GameStartDelegate del)
    {
        OnGameStart += del;
    }

    public void RemoveNewDayListener(GameStartDelegate del)
    {
        OnGameStart -= del;
    }

    public void TriggerGameStart()
    {
        if (OnGameStart != null)
        {
            OnGameStart();
        }
    }
    #endregion

    #region OnGameEnd
    public delegate void GameEndDelegate();
    private GameEndDelegate OnGameEnd;

    public void SetNewDayListener(GameEndDelegate del)
    {
        OnGameEnd += del;
    }

    public void RemoveNewDayListener(GameEndDelegate del)
    {
        OnGameEnd -= del;
    }

    public void TriggerGameEnd()
    {
        if (OnGameEnd != null)
        {
            OnGameEnd();
        }
    }
    #endregion
}
