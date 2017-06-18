using SQLite4Unity3d;


public class Activities { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Act { get; set; }
	public int Aperc_Id { get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Act,Aperc_Id.ToString()};
		return mostrar;
	}

}