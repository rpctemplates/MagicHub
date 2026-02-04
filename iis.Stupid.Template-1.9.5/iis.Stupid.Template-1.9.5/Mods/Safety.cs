using UnityEngine;
using System;

public class SafetyMods : MonoBehaviour
{
    // ---------------- STATES ----------------
    public bool autoLeaveOnModerator;
    public bool autoLeaveOnOwner;
    public bool panicDisconnect;

    // ---------------- EVENTS (SIMULATED) ----------------
    // These would normally come from YOUR networking code
    public event Action<PlayerInfo> OnPlayerJoined;

    void Start()
    {
        OnPlayerJoined += HandlePlayerJoin;
    }

    void Update()
    {
        if (panicDisconnect)
        {
            Disconnect();
            panicDisconnect = false;
        }
    }

    void HandlePlayerJoin(PlayerInfo player)
    {
        if (autoLeaveOnModerator && player.isModerator)
            Disconnect();

        if (autoLeaveOnOwner && player.isRoomOwner)
            Disconnect();
    }

    void Disconnect()
    {
        Debug.Log("Safety Mod: Leaving room");
        // Replace with YOUR networking disconnect
    }
}

// ---------------- SUPPORT CLASS ----------------
public class PlayerInfo
{
    public string playerName;
    public bool isModerator;
    public bool isRoomOwner;
}
