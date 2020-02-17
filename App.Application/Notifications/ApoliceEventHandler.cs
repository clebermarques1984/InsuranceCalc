using App.Application.ApoliceCommands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Notifications
{
	public class ApoliceEventHandler : INotificationHandler<ApoliceNotification>
	{
		public Task Handle(ApoliceNotification notification, CancellationToken cancellationToken)
		{
			// Save the notification at the Azure blob storage

			return Task.CompletedTask;
		}
	}
}
