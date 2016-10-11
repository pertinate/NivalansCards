using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using System;
using GooglePlayGames.BasicApi;
using Pertinate.GooglePlay;
using System.Collections.Generic;
using GooglePlayGames.BasicApi.Nearby;

public class MultiplayerController : RealTimeMultiplayerListener
{
    public enum modeType
    {
        None = 0,
        BlackJack,
        Poker
    }
    private static MultiplayerController _instance = null;
    private MultiplayerController()
    {

    }
    public static MultiplayerController Singleton
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MultiplayerController();
            }
            return _instance;
        }
    }
    public uint minimumOpponents = 1;
    public uint maximumOpponents = 3;
    public uint gameVariation = 0;

    public modeType modetype()
    {
        return (modeType)gameVariation;
    }

    public List<Participant> GetAllPlayers()
    {
        return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
    }

    public string GetMyParticipantID()
    {
        return PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId;
    }
    

    public void OnRoomSetupProgress(float percent)
    {
        Debug.Log("We are " + percent + "% done with setup.");
        PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI();
    }

    public void OnRoomConnected(bool success)
    {
        if (success)
        {
            Debug.Log("Connected to room.");
            PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI();
            MainMenuUI.singleton.modeCanvas.interactable = false;
            Debug.Log(GetAllPlayers()[0].DisplayName + " and " + GetAllPlayers()[1].DisplayName);
        }
        else
        {
            MainMenuUI.singleton.modeCanvas.interactable = true;
            Debug.Log("Failed to connect to room.");
        }
    }

    public void OnLeftRoom()
    {
        Debug.Log("We have left the room.");
        MainMenuUI.singleton.modeCanvas.interactable = true;
    }

    public void OnParticipantLeft(Participant participant)
    {
        Debug.Log(participant.DisplayName + "has left.");
    }

    public void OnPeersConnected(string[] participantIds)
    {
        foreach(string participantID in participantIds)
        {
            Debug.Log("Player " + participantID + " has joined.");
        }
    }

    public void OnPeersDisconnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
            Debug.Log("Player " + participantID + " has left.");
        }
    }

    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
    {
        Debug.Log("We have received some gameplay messages from: " + senderId);
    }
}
