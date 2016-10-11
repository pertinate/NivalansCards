using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.EventSystems;
using Pertinate.GooglePlay;
using GooglePlayGames.BasicApi.SavedGame;

public class MainMenuUI : MonoBehaviour {
    public static MainMenuUI singleton;
    public enum switchInterface
    {
        main,
        game,
        mode,
        credit,
        options
    }
    public GameObject[] mainMenuControl;
    public static switchInterface ifaceCount = switchInterface.main;
    public GameObject modeholder;
    public Text modeText;
    public CanvasGroup mainCanvas;
    public CanvasGroup modeCanvas;

    public void Awake()
    {
        singleton = this;
        mainCanvas.interactable = false;
    }
    public void Start()
    {
        if (GooglePlaySingleton.singleton.signedIn())
        {
            Debug.Log("Authenticated as: " + Social.localUser.userName);
            mainCanvas.interactable = true;
        }
        PlayGamesPlatform.Instance.SavedGame.ShowSelectSavedGameUI("Select", 5, false, true, OnSavedGameSelected);
    }

    private void OnSavedGameSelected(SelectUIStatus arg1, ISavedGameMetadata arg2)
    {
        if(arg1 == SelectUIStatus.SavedGameSelected)
        {
            Debug.Log("Game save selected");
        }
        else
        {

        }
    }

    public void LateUpdate()
    {
        if (mainMenuControl != null)
        {
            switch (ifaceCount)
            {
                case switchInterface.main:
                    setOneActive(0);
                    break;
                case switchInterface.game:
                    setOneActive(1);
                    break;
                case switchInterface.mode:
                    setOneActive(2);
                    if (modeText.text != MultiplayerController.Singleton.modetype().ToString())
                        modeText.text = MultiplayerController.Singleton.modetype().ToString();
                    break;
                case switchInterface.credit:
                    setOneActive(3);
                    break;
                case switchInterface.options:
                    setOneActive(4);
                    break;
                default:
                    break;
            }
        }
    }
    public void setOneActive(int s)
    {
        for (int i = 0; i < mainMenuControl.Length; i++)
        {
            if (i == s)
            {
                mainMenuControl[i].SetActive(true);
            }
            else
            {
                mainMenuControl[i].SetActive(false);
            }
        }
    }
}
