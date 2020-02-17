namespace App.Domain.Entities
{
	public class Veiculo
	{
		public int Id { get; set; }

		public string MarcaModelo { get; set; }

		public double Valor { get; set; }

		public Veiculo()
		{

		}

		public Veiculo(string marcaModelo, double valor)
		{
			MarcaModelo = marcaModelo;
			Valor = valor;
		}

	}
}
