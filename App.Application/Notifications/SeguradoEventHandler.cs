using App.Application.SeguradoCommands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Notifications
{
	public class SeguradoEventHandler : INotificationHandler<SeguradoNotification>
	{
		public Task Handle(SeguradoNotification notification, CancellationToken cancellationToken)
		{
			// Save the notification at the Azure blob storage

			return Task.CompletedTask;
		}
	}
}
