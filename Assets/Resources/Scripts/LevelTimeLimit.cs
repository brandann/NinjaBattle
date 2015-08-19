using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimeLimit : MonoBehaviour {

    public Text TextDisplay;

    private float _starttime;
    private float _maxtime;
    private float _currenttime;

    private bool _displayon;
    private bool _active;
   

	// Use this for initialization
	void Start () {
        MaxTime = 100;
        ResetTimer();
        StartTimer();
	}
	
	// Update is called once per frame
	void Update () {

	    if(_active)
        {
            _currenttime -= Time.deltaTime * Time.timeScale;
            if(_currenttime <= 0)
            {
                OnEndTimer();
            }
        }
	}

    void LateUpdate()
    {
        if (_displayon)
        {
            TextDisplay.text = ((int)_currenttime + 1).ToString();
        }
        else
        {
            TextDisplay.text = " ";
        }
        
    }

    public bool IsRunning()
    {
        return _active;
    }

    public void StopTimer()
    {
        _active = false;
    }

    public void ResetTimer()
    {
        _currenttime = _maxtime;
    }

    public void StartTimer()
    {
        _active = true;
        _displayon = true;
    }

    public float GetRemainingTime()
    {
        return _currenttime;
    }

    public float MaxTime
    {
        set { _maxtime = value; }
        get { return _maxtime; }
    }

    public void ToggleTextView()
    {
        _displayon = !_displayon;
    }

    private void OnEndTimer()
    {
        Debug.Log("Level ran out of time!");
        StopTimer();
    }
}
