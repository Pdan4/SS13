// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Newscaster_FeedChannel : Newscaster {

		public dynamic channel_name = "";
		public ByTable messages = new ByTable();
		public bool locked = false;
		public string author = "";
		public bool censored = false;
		public ByTable authorCensorTime = new ByTable();
		public ByTable DclassCensorTime = new ByTable();
		public bool authorCensor = false;
		public bool? is_admin_channel = false;

		// Function from file: newscaster.dm
		public void toggleCensorAuthor(  ) {
			
			if ( this.authorCensor ) {
				this.authorCensorTime.Add( GlobalVars.news_network.lastAction * -1 );
			} else {
				this.authorCensorTime.Add( GlobalVars.news_network.lastAction );
			}
			this.authorCensor = !this.authorCensor;
			GlobalVars.news_network.lastAction++;
			return;
		}

		// Function from file: newscaster.dm
		public void toggleCensorDclass(  ) {
			
			if ( this.censored ) {
				this.DclassCensorTime.Add( GlobalVars.news_network.lastAction * -1 );
			} else {
				this.DclassCensorTime.Add( GlobalVars.news_network.lastAction );
			}
			this.censored = !this.censored;
			GlobalVars.news_network.lastAction++;
			return;
		}

		// Function from file: newscaster.dm
		public string returnAuthor( int censor = 0 ) {
			string txt = null;

			
			if ( censor == -1 ) {
				censor = this.authorCensor ?1:0;
			}
			txt = "" + GlobalVars.news_network.redactedText;

			if ( !( censor != 0 ) ) {
				txt = this.author;
			}
			return txt;
		}

	}

}