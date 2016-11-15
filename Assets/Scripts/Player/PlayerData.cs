using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerData<T> {
	private List<T> _items = new List<T>();
	private int _coins;

	public List<T> Items {
		get {
			return _items;
		} set { 
			_items = value;
		}
	}
}
