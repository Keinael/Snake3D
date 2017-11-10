using UnityEngine;

public class BonusGeneration : MonoBehaviour {

	public GameObject bonusSnakeFoodPrefab;
	public GameObject bonusAccelerationPrefab;
	public GameObject bonusDecelerationPrefab;
	public GameObject bonusDecreasePrefab;
	public GameObject bonusReversPrefab;
	public float xSize = 8.9f;
	public float zSize = 8.9f;
	public GameObject curFood;
	public GameObject curBonus;
	public Vector3 curFoodPos;
	public Vector3 curBonusPos;
	public int bonusNumber;


	void Start () {	
		InvokeRepeating ("Spawn", 5, 10);
}


	void Spawn () {
		bonusNumber = Random.Range (1, 4);
		switch (bonusNumber) {
		case 1:
			CreatingObject (bonusAccelerationPrefab);
			break;
		case 2:
			CreatingObject (bonusDecelerationPrefab);
			break;
		case 3:
			CreatingObject (bonusDecreasePrefab);
			break;
		case 4:
			CreatingObject (bonusReversPrefab);
			break;
		}
	}
	void CreatingObject (GameObject bonus) 
	{
		curBonusPos = new Vector3 (Random.Range(xSize*-1,xSize),0.2f,Random.Range(zSize*-1,zSize));
		curBonus = GameObject.Instantiate (bonus, curBonusPos, Quaternion.Euler(new Vector3 (90, Random.Range(0, 360), 0))) as GameObject;
	}

	void AddNewFood() {
		curFoodPos = new Vector3 (Random.Range(xSize*-1,xSize),0.2f,Random.Range(zSize*-1,zSize));
		curFood = GameObject.Instantiate (bonusSnakeFoodPrefab, curFoodPos, Quaternion.identity) as GameObject;	
	}

	void Update () {
		if (!curFood) {
			AddNewFood ();
		} else {
			return;
		}
	}
}








