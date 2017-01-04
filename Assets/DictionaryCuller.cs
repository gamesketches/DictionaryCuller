using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DictionaryCuller : MonoBehaviour {

	private class Point {
		public int x;
		public int y;

		public Point() {
			x = 0;
			y = 0;
		}

		public Point(int initX, int initY) {
			x = initX;
			y = initY;
		}

		public Point(float initX, float initY) {
			x = (int) initX;
			y = (int) initY;
		}
	};

	public int startX;
	public int startY;
	public int cellWidth;
	public int cellHeight;
	public int gridXSize;
	public int gridYSize;

	public float interval;
	private float timer;

	Dictionary<Point, List<GameObject>> dict;
	List<Point> activePoints;

	// Use this for initialization
	void Start () {
		if(cellWidth == 0) {
			cellWidth = 1;
		}
		if(cellHeight == 0) {
			cellHeight = 1;
		}
		dict = new Dictionary<Point, List<GameObject>>();
		timer = interval;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0) {
			Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
			Point playerPoint = new Point(playerPos.x / cellWidth, playerPos.y / cellHeight);
			GameObject[] theObjects = GameObject.FindGameObjectsWithTag("rando");
			foreach(GameObject obj in theObjects) {
				Point temp = new Point(obj.transform.position.x / cellWidth, obj.transform.position.y / cellHeight);
				Debug.Log(temp.x.ToString() + " " + temp.y.ToString());
				List<GameObject> oldList = null;
				foreach(KeyValuePair<Point, List<GameObject>>entry in dict) {
					if(entry.Key.x == temp.x && entry.Key.y == temp.y) {
						oldList = entry.Value;
						if(!oldList.Contains(obj)) {
							entry.Value.Add(obj);
						}
						Debug.Log(oldList.Count);
						break;
					}
				}
				if(oldList == null) {
					List<GameObject> newList = new List<GameObject>();
					newList.Add(obj);
					dict.Add(temp, newList);
				}
				if(temp.x != playerPoint.x || temp.y != playerPoint.y) {
					obj.SetActive(false);
				}
			}

			foreach(KeyValuePair<Point, List<GameObject>>entry in dict) {
					if(entry.Key.x == playerPoint.x && entry.Key.y == playerPoint.y) {
						foreach(GameObject obj in entry.Value) {
							obj.SetActive(true);	
						}
						Debug.Log("activating objects at " + playerPoint.x.ToString() + " " + playerPoint.y.ToString());
						break;
					}
				}
			timer = interval;
		}
	}
}
