using UnityEngine;
using System.Collections;
using UnityEditor;

public class DataReading : MonoBehaviour {

	public TextAsset dataFile;
	public float xCoordinate, yCoordinate, zCoordinate;
	public GameObject cube;
	public int selectedX, selectedY, selectedZ;
	GameObject point;
	// Use this for initialization
	void Start () {
		Vector3 a = new Vector3 (0, 0, 0);
		string path1 = AssetDatabase.GetAssetPath(dataFile);
		string data = System.IO.File.ReadAllText(path1);
		string[] rows = data.Split ('\n');
		foreach (string i in rows) 
		{
			string[] coordinates = i.Split (',');
			Vector3 z = new Vector3((float.Parse(coordinates[selectedX]))*100f, (float.Parse(coordinates[selectedY]))*100f, (float.Parse(coordinates[selectedZ]))*100f);
			point = (GameObject) Instantiate(cube, z,Quaternion.identity);
			switch (coordinates [4]) 
			{
			case "Iris-setosa":
				point.GetComponent<Renderer> ().material.color = Color.blue;
				break;
			case "Iris-versicolor":
				point.GetComponent<Renderer> ().material.color = Color.green;
				break;
			case "Iris-virginica":
				point.GetComponent<Renderer> ().material.color = Color.red;
				break;
			default :
				point.GetComponent<Renderer> ().material.color = Color.white;
				break;
			}

			Debug.Log (coordinates [3]);
		}

		Debug.Log (rows [5]);
		point = (GameObject) Instantiate(cube, a,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
