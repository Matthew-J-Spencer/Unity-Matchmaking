using System;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyRoomPanel : MonoBehaviour {
    [SerializeField] private float _difficultyDialMaxAngle = 100f;

    [SerializeField] private TMP_Text _nameText, _typeText, _playerCountText;
    [SerializeField] private Transform _difficultyMeter;

    public Lobby Lobby { get; private set; }

    public static event Action<Lobby> LobbySelected;

    public void Init(Lobby lobby) {
        UpdateDetails(lobby);
    }

    public void UpdateDetails(Lobby lobby) {
        Lobby = lobby;
        _nameText.text = lobby.Name;
        _typeText.text = Constants.GameTypes[GetValue(Constants.GameTypeKey)];

        var point = Mathf.InverseLerp(0, Constants.Difficulties.Count - 1, GetValue(Constants.DifficultyKey));
        _difficultyMeter.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(_difficultyDialMaxAngle, -_difficultyDialMaxAngle, point));

        _playerCountText.text = $"{lobby.Players.Count}/{lobby.MaxPlayers}";

        int GetValue(string key) {
            return int.Parse(lobby.Data[key].Value);
        }
    }

    public void Clicked() {
        LobbySelected?.Invoke(Lobby);
    }
}