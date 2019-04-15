using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Create Object")]
public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
	public Vector2 newPosition;
	public bool relativeToThisObject;
	public int maxSpawns;

	// Creates a new GameObject
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(prefabToCreate != null)
		{
			string spawnName = this.gameObject.name + " Spawned Object";
			if (maxSpawns > 0)
			{
				int count = 0;
				GameObject[] allObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));
				foreach (GameObject GO in allObjects)
				{
					if (GO.name == spawnName)
					{
						++count;
						if (count >= maxSpawns)
							return false;
					}
				}
			}
			//create the new object by copying the prefab
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);
			newObject.name = spawnName;
			//is the position relative or absolute?
			Vector2 finalPosition = newPosition;
			if (relativeToThisObject)
			{
				finalPosition = (Vector2)transform.position + newPosition;
			}

			//let's place it in the desired position!
			newObject.transform.position = finalPosition;
			return true;
		}
		else
		{
			Debug.LogWarning("There is no Prefab assigned to this CreateObjectAction, so a new object can't be created.");
			return false;
		}
	}

}
