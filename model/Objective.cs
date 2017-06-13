using SQLite4Unity3d;


public class Objective { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Obj { get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Obj};
		return mostrar;
	}

}