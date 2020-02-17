using App.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Pipelines
{
	public class ValidateCommand<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TResponse : Result
	{
		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			if (request is Domain.Validatable validatable)
			{
				validatable.Validate();
				if (validatable.Invalid)
				{
					var validations = new Result();
					foreach (var notification in validatable.Notifications)
						validations.AddValidation(notification.Message);

					var response = validations as TResponse;
					return response;
				}
			}

			var result = await next();
			return result;
		}
	}
}
