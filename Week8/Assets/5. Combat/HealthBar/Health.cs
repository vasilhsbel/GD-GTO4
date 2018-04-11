using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour // consider interface 'Destructible' for things that can be destroyed by damage
{
	public int MaxHealth;
	public int Current;
	
	public UnityEvent OnHealthChange = new UnityEvent();
	
	public void Damage(int hitpoints)
	{
		Current -= hitpoints;
		if (Current <= 0)
		{
			Current = 0;
			Kill();
		}
		OnHealthChange.Invoke();
	}

	public void Heal(int hitpoints)
	{
		Current += hitpoints;
		if (Current > MaxHealth)
		{
			Current = MaxHealth;
		}
		OnHealthChange.Invoke();
	}

	public void Kill()
	{
		Destroy(gameObject);
	}

}
