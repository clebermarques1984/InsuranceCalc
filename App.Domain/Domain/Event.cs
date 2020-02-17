using MediatR;
using System;

namespace App.Domain
{
	public class Event : INotification
	{
		public string EventName { get; set; }

		public DateTime Timestamp { get; private set; }

		protected Event()
		{
			Timestamp = DateTime.Now;
		}
	}
}
