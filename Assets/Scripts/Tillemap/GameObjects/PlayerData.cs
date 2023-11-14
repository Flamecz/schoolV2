using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public Quaternion rotation;

    public PlayerData(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}

