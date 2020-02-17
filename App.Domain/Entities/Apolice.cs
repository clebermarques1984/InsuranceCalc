namespace App.Domain.Entities
{
	public class Apolice
	{
		private double txRisco = 0.025; // 5 / 2 = 2,5%
		private double txMargem = 0.03; // Fixo 3%
		private double txLucro = 0.05;  // Fixo 5%

		public int Id { get; set; }

		public double ValorSeguro { get; set; }
		public double ValorRisco { get; set; }
		public double ValorMargem { get; set; }

		public Segurado Segurado { get; set; }

		public Veiculo Veiculo { get; set; }

		public Apolice()
		{

		}

		public Apolice(Segurado segurado, Veiculo veiculo)
		{
			Segurado = segurado;
			Veiculo = veiculo;

			CalcValorSeguro(veiculo.Valor);
		}

		private void CalcValorSeguro(double valorVeiculo)
		{
			ValorRisco = valorVeiculo * txRisco;
			ValorMargem = ValorRisco * (1 + txMargem);
			ValorSeguro = ValorMargem * (1 + txLucro);
		}
	}
}
