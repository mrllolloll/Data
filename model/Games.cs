using SQLite4Unity3d;


public class Games { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Objetive_Id { get; set; }
	public int Option_Id { get; set; }
	public int Activities_Id { get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Objetive_Id.ToString(),Option_Id.ToString(),Activities_Id.ToString()};
		return mostrar;
	}

}