using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    [Header("Players")]
    public GameObject Player1;
    public GameObject Player1Particle;
    public GameObject Player2;
    public GameObject Player2Particle;

    [Header("Enviroment")]
    public GameObject BackgroundPlatforms;
    public GameObject ForegroundPlatforms;
    public GameObject CageObjects;
    public GameObject StartingPlatforms;
    public GameObject Enviroment;

    [Header("Score")]
    public GameObject Player1Score;
    public GameObject Player2Score;

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

                    // Manage platforms
                    SetPlatformActive(true, false, false, false);
                    GoalItemObject.SetActive(false);
                    Player1Particle.SetActive(false);
                    Player2Particle.SetActive(false);
                    
                    break;
                case (GameState.Game):

                    // Manage platforms
                    SetPlatformActive(false, true, true, false);
                    GoalItemObject.SetActive(true);
                    Player1Particle.SetActive(true);
                    Player2Particle.SetActive(true);
                    GoalItemObject.GetComponent<GoalItem>().Initilize();
                    break;
                case (GameState.End):
                    
                    // Manage platforms
                    SetPlatformActive(false, false, false, true);
                    GoalItemObject.transform.position = new Vector3(0, 14, 0);
                    GoalItemObject.GetComponent<GoalItem>().SetColliderActive(false);
                    if (Player1Score.GetComponent<PlayerHeartManager>().GetScore() > Player2Score.GetComponent<PlayerHeartManager>().GetScore())
                    {
                        SetLoserPlayer(Player2, Player1Particle);
                    }
                    else
                    {
                        SetLoserPlayer(Player1, Player2Particle);
                    }
                    break;
                case (GameState.Credits):
                    
                    // Manage Platforms
                    SetPlatformActive(false, false, false, false);

                    break;
            }
            currentGameState = value;
        }
        get
        {
            return currentGameState;
        }
    }

    private void SetPlatformActive(bool Starting, bool Foreground, bool Background, bool Cage)
    {
        StartingPlatforms.SetActive(Starting);
        Enviroment.SetActive(!Starting);
        ForegroundPlatforms.SetActive(Foreground);
        BackgroundPlatforms.SetActive(Background);
        CageObjects.SetActive(Cage);
    }

    private void SetLoserPlayer(GameObject player, GameObject particle)
    {
        particle.SetActive(false);
        player.transform.position = new Vector3(0, -2, 0);
    }
    #endregion

    #region TimeDilation

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
