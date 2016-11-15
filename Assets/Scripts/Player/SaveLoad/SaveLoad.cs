using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad<T> {
	private PlayerData<T> pd;
	public PlayerData<T> Data {
		get { 
			return pd;
		} set { 
			pd = value;
		}
	}
	private string path = "Saves";
	private string name = "datafile";

	public void Save () {
		Debug.Log (Application.persistentDataPath);
		string fileName = "/" + name + ".dat";
		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (path);
		}

		FileStream fs = File.Create (path + fileName);

		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (fs, pd);
		fs.Close ();
	}

	public void LoadData() {
		string fileName = "/" + name + ".dat";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Open(path + fileName, FileMode.Open);

		PlayerData<T> b = (PlayerData<T>)formatter.Deserialize(saveFile);
		saveFile.Close();
	}
}
