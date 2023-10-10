using System.Collections;
using System.Collections.Generic;
using Com.Hide.Managers;
using Com.Hide.ScriptableObjects;
using Photon.Pun.Demo.Cockpit.Forms;
using UnityEngine;
using EventType = Com.Hide.Managers.EventType;

public class JoinRoomHandler : MonoBehaviour
{
    [SerializeField] private SceneData roomSceneData;
    
    private void Start()
    {
        EventManager.Instance.AddListener(EventType.OnJoinedRoom, OnJoinedRoom);
    }

    private void OnJoinedRoom(EventType type, Component sender, object[] args)
    {
        LoadSceneManager.Instance.UnloadSceneAsync();
        LoadSceneManager.Instance.LoadSceneAsync(roomSceneData);
    }
}
