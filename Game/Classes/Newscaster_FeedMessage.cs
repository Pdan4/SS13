// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Newscaster_FeedMessage : Newscaster {

		public string author = "";
		public dynamic body = "";
		public ByTable authorCensorTime = new ByTable();
		public ByTable bodyCensorTime = new ByTable();
		public bool? is_admin_message = false;
		public Icon img = null;
		public string time_stamp = "";
		public ByTable comments = new ByTable();
		public bool locked = false;
		public string caption = "";
		public double creationTime = 0;
		public bool authorCensor = false;
		public bool bodyCensor = false;

		// Function from file: newscaster.dm
		public void toggleCensorBody(  ) {
			
			if ( this.bodyCensor ) {
				this.bodyCensorTime.Add( GlobalVars.news_network.lastAction * -1 );
			} else {
				this.bodyCensorTime.Add( GlobalVars.news_network.lastAction );
			}
			this.bodyCensor = !this.bodyCensor;
			GlobalVars.news_network.lastAction++;
			return;
		}

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
		public dynamic returnBody( int censor = 0 ) {
			dynamic txt = null;

			
			if ( censor == -1 ) {
				censor = this.bodyCensor ?1:0;
			}
			txt = "" + GlobalVars.news_network.redactedText;

			if ( !( censor != 0 ) ) {
				txt = this.body;
			}
			return txt;
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