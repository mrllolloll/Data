using SQLite4Unity3d;


public class Activities { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Act { get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Act};
		return mostrar;
	}

}