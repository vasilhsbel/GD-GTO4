using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerUI : MonoBehaviour
{
    [Serializable] public class SetColorEvent : UnityEvent<Color> { }
    
    public SetColorEvent OnPlayerTurn = new SetColorEvent();

    private Player owner;
    
    void Start()
    {
        owner = GetComponent<Player>();
    }

    private void OnEnable()
    {
        if (owner != null)
        {
            OnPlayerTurn.Invoke(owner.Color);
        }
    }
}
