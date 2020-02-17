using App.Domain;

namespace App.Application.SeguradoCommands
{
	public class SeguradoNotification : Event
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string CPF { get; set; }

		public int Idade { get; set; }
	}
}
