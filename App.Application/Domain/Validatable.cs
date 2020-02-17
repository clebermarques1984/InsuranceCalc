using Flunt.Notifications;
using Flunt.Validations;

namespace App.Application.Domain
{
	public abstract class Validatable : Notifiable, IValidatable
	{
		public abstract void Validate();
	}
}
