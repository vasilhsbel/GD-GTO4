using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSpawner : MonoBehaviour
{
	private UnitFactory factory;

	private bool isBuilding = false;
		
	void Update ()
	{
		if (isBuilding)
		{

			if (Input.GetMouseButtonUp(0))
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					Debug.Log("Mouse was over UI!");
					return;
				}
				
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					Cell hitCell = hit.collider.GetComponentInParent<Cell>();
					if (hitCell != null)
					{
						factory.SpawnUnit(hitCell);
						ExitSpawnMode();
					}
			
				}
			}
		}
	}

	void OnDisable()
	{
		ExitSpawnMode();
	}
	
	public void ExitSpawnMode()
	{
		factory = null;
		isBuilding = false;
	}

	public void EnterSpawnMode(UnitFactory factory)
	{
		this.factory = factory;
		isBuilding = true;
	}	
}
