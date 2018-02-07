using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : Singleton<ViewManager> {

    [SerializeField]
    public Image fadeOverlay;
    [SerializeField]
    public GameObject mainMenu;
    [SerializeField]
    public GameObject game;
    [SerializeField]
    public GameObject settings;
    /*[SerializeField]
    public SoundButton settingsSoundButton;
    [SerializeField]
    public SoundButton pauseSoundButton;*/

    GameObject _upcomingView;

    const float _FADE_ANIMATION_DURATION = 0.5f;

    override public void Init()
    {
        //settingsSoundButton.Set();
    }

    void _SetSoundButtons()
    {
        //settingsSoundButton.Set();
        //pauseSoundButton.Set();
    }

    public void ShowGame()
    {
        _upcomingView = game;
        _StartFadeout();
    }

    public void ShowMenu()
    {
        _upcomingView = mainMenu;
        _StartFadeout();
    }

    public void ShowSettings()
    {
        _upcomingView = settings;
        _StartFadeout();
    }

    void _StartFadeout()
    {
		Debug.Log ("Starting fade out");
        Color c = fadeOverlay.color;
        c.a = 0;
        fadeOverlay.color = c;
        fadeOverlay.gameObject.SetActive(true);
        iTween.ValueTo(fadeOverlay.gameObject, iTween.Hash("from", 0, "to", 1, "time", _FADE_ANIMATION_DURATION, "onupdate", "_OnFadeUpdate", "onupdatetarget", gameObject, "oncomplete", "_OnFadeOutComplete", "oncompletetarget", gameObject));
    }

    void _OnFadeUpdate(float value)
    {
        Color c = fadeOverlay.color;
        c.a = value;
        fadeOverlay.color = c;
    }

    void _OnFadeOutComplete()
    {
        game.SetActive(false);
        mainMenu.SetActive(false);
        // settings.SetActive(false);
        // _SetSoundButtons();
        _upcomingView.SetActive(true);
        _StartFadeIn();
    }

    void _StartFadeIn()
    {
        //if (_upcomingView == game)
            // UIManager.Instance.ResetUI();

        Color c = fadeOverlay.color;
        c.a = 1;
        fadeOverlay.color = c;
        iTween.ValueTo(fadeOverlay.gameObject, iTween.Hash("from", 1, "to", 0, "time", _FADE_ANIMATION_DURATION, "onupdate", "_OnFadeUpdate", "onupdatetarget", gameObject, "oncomplete", "_OnFadeInComplete", "oncompletetarget", gameObject));
    }

    void _OnFadeInComplete()
    {
		Debug.Log ("fadeincomplete");
        fadeOverlay.gameObject.SetActive(false);
        if(_upcomingView == game)
        {
			Debug.Log ("calling gamemanger.StartGame()");
            GameManager.Instance.StartGame();
        }     
    }


}
