// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TimedAlert : Game_Data {

		// Function from file: timed_alerts.dm
		public TimedAlert ( Mob target = null, string message = null, string title = null, string button1 = null, string button2 = null, string button3 = null ) {
			target = target ?? Task13.User;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				Interface13.Alert( target, message, title, button1, button2, button3 );
				return;
			}));
			return;
		}

	}

}