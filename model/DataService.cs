using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	public int number;

	private SQLiteConnection _connection;

	public DataService(){

		string DatabaseName = "DBDrago.db";

		#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

		if (!File.Exists(filepath))
		{
		Debug.Log("Database not in Persistent path");
		// if it doesn't ->
		// open StreamingAssets directory and load the db ->

		#if UNITY_ANDROID 
		var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
		while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
		// then save to Application.persistentDataPath
		File.WriteAllBytes(filepath, loadDb.bytes);
		#elif UNITY_IOS
		var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#elif UNITY_WP8
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

		#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#else
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

		#endif

		Debug.Log("Database written");
		}

		var dbPath = filepath;
		#endif
		_connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		Debug.Log("Final PATH: " + dbPath);     

		}

		public IEnumerable<Messegaealert> ViewTodo(){
			return _connection.Table<Messegaealert>();
		}

		public IEnumerable<Games> ViewGames(){
			return _connection.Table<Games>();
		}

		public IEnumerable<Activities> ViewActivities(){
			return _connection.Table<Activities>().Where(x => x.Id == number);
		}

		public IEnumerable<Activities> ViewActivitiesAll(){
			return _connection.Table<Activities>();
		}

		public IEnumerable<Messegaealert> ViewInfoint(){
			return _connection.Table<Messegaealert>().Where(x => x.Id == number);
		}

		public IEnumerable<Games> ViewGamesInt(){
			return _connection.Table<Games>().Where(x => x.Id == number);
		}

		public IEnumerable<Objective> ViewObjectiveInt(){
			return _connection.Table<Objective>().Where(x => x.Id == number);
		}

		public IEnumerable<Option> ViewOptionInt(){
			return _connection.Table<Option>().Where(x => x.Id == number);
		}

		public	void Updatemessege(int id,int ico, string titutext, string textcuerp,int aperc)
		{
		_connection.UpdateAll(
			new[]{
				new Messegaealert{
					Id = id,
					Ico = ico,
					TituText=titutext,
					Textcuerp = textcuerp,
					Aperc_Id = aperc
				}
			});
		}









		public void CreateDB(){
			_connection.DropTable<Messegaealert> ();
			_connection.CreateTable<Messegaealert> ();

			_connection.InsertAll (new[]{
				new Messegaealert{
					Id = 1,
					Ico = 1,
					TituText="Aqui",
					Textcuerp = "Perez",
					Aperc_Id = 1
				},
				new Messegaealert{
					Id = 2,
					Ico = 1,
					TituText="Aqui1",
					Textcuerp = "yolitos",
					Aperc_Id = 1
				}
			});
		}

}