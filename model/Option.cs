using SQLite4Unity3d;


public class Option { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Opt { get; set; }
	public int ScoreSum{ get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Opt,ScoreSum.ToString()};
		return mostrar;
	}

}

