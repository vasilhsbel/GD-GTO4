using UnityEngine;

public class PlayerOwned : MonoBehaviour
{
    public Player Owner;

    public Renderer PlayerColorRenderer;

    public void SetOwner(Player owner)
    {
        Owner = owner;
        if (PlayerColorRenderer != null)
        {
            PlayerColorRenderer.material.color = owner.Color;
        }
    }

    public Player GetOwner()
    {
        return Owner;
    }

    public bool IsHostile(PlayerOwned other)
    {
        return Owner.IsHostile(other.Owner);
    }
}
