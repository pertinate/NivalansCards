using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class UIHandler : MonoBehaviour {
    public void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }
    public void SetInterface(int i)
    {
        MainMenuUI.ifaceCount = (MainMenuUI.switchInterface)i;
    }
    public void SetGameMode(int i)
    {
        MultiplayerController.Singleton.gameVariation = (uint)i;
    }
    public void SetScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void StartMatchMaking()
    {
        MainMenuUI.singleton.modeCanvas.interactable = false;
        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(MultiplayerController.Singleton.minimumOpponents, MultiplayerController.Singleton.maximumOpponents, MultiplayerController.Singleton.gameVariation, MultiplayerController.Singleton);
    }
    public void StartLan()
    {
        PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(MultiplayerController.Singleton.minimumOpponents, MultiplayerController.Singleton.maximumOpponents, MultiplayerController.Singleton.gameVariation, MultiplayerController.Singleton);
    }
    public void StopAllMatchMaking()
    {
        PlayGamesPlatform.Instance.RealTime.LeaveRoom();
    }
}
