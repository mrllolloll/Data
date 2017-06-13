using SQLite4Unity3d;


public class Score { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Scr { get; set; }
	public int Activities_Id { get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Scr.ToString(),Activities_Id.ToString()};
		return mostrar;
	}

}