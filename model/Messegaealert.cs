using SQLite4Unity3d;


public class Messegaealert { 

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Ico { get; set; }
	public string TituText { get; set; }
	public string Textcuerp { get; set; }
	public int Aperc_Id { get; set; }

	public string[] Mostrar ()
	{
		var mostrar = new[]{Id.ToString(),Ico.ToString(),TituText,Textcuerp,Aperc_Id.ToString()};
		return mostrar;
	}

}