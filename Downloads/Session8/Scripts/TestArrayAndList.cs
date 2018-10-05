using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArrayAndList : MonoBehaviour
{
	
	string[] arr;
	List<string> lst;

	void Start ()
	{
		arr = new string[]{"Hello","World","!!"};

		lst = new List<string>();
		lst.Add("Hello");
		lst.Add("World");
		lst.Add("!!");
	}
	
	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.A))
		{
			print("===Array["+arr.Length+"]===");
			for (int i = 0; i < arr.Length; i++)
			{
				print(i+":"+arr[i]);
			}
			print("==========");
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			print("===List["+lst.Count+"]===");
			for (int i = 0; i < lst.Count; i++)
			{
				print(i+":"+lst[i]);
			}
			print("===========");
		}
	}
}
