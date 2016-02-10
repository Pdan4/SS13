// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TopicInput : Game_Data {

		public string href = null;
		public dynamic href_list = null;

		// Function from file: topic_input.dm
		public TopicInput ( string thref = null, ByTable thref_list = null ) {
			this.href = thref;
			this.href_list = thref_list.Copy();
			return;
		}

		// Function from file: topic_input.dm
		public bool getList( string i = null ) {
			bool t = false;

			t = this.getAndLocate( i );
			return ( GlobalFuncs.islist( t ) ? t : false );
		}

		// Function from file: topic_input.dm
		public dynamic getPath( string i = null ) {
			dynamic t = null;

			t = this.get( i );

			if ( Lang13.Bool( t ) ) {
				t = Lang13.FindClass( t );
			}
			return ( t is Type ? t : null );
		}

		// Function from file: topic_input.dm
		public bool getType( string i = null, Type type = null ) {
			bool t = false;

			t = this.getAndLocate( i );
			return ( Lang13.Bool( ((dynamic)type).IsInstanceOfType( t ) ) ? t : false );
		}

		// Function from file: topic_input.dm
		public dynamic getStr( string i = null ) {
			dynamic t = null;

			t = this.get( i );
			return ( t is string ? t : null );
		}

		// Function from file: topic_input.dm
		public bool getArea( string i = null ) {
			bool t = false;

			t = this.getAndLocate( i );
			return ( t is Zone ? t : false );
		}

		// Function from file: topic_input.dm
		public bool getAtom( string i = null ) {
			return this.getType( i, typeof(Ent_Static) );
		}

		// Function from file: topic_input.dm
		public bool getTurf( string i = null ) {
			bool t = false;

			t = this.getAndLocate( i );
			return ( t is Tile ? t : false );
		}

		// Function from file: topic_input.dm
		public bool getMob( string i = null ) {
			bool t = false;

			t = this.getAndLocate( i );
			return ( t is Mob ? t : false );
		}

		// Function from file: topic_input.dm
		public bool getObj( string i = null ) {
			bool t = false;

			t = this.getAndLocate( i );
			return ( t is Obj ? t : false );
		}

		// Function from file: topic_input.dm
		public dynamic getNum( string i = null ) {
			dynamic t = null;

			t = this.get( i );

			if ( Lang13.Bool( t ) ) {
				t = String13.ParseNumber( t );
			}
			return ( Lang13.Bool( Lang13.IsNumber( t ) ) ? t : null );
		}

		// Function from file: topic_input.dm
		public bool getAndLocate( string i = null ) {
			dynamic t = null;

			t = this.get( i );

			if ( Lang13.Bool( t ) ) {
				t = Lang13.FindObj( t );
			}
			return Lang13.Bool( t ) || false;
		}

		// Function from file: topic_input.dm
		public dynamic get( string i = null ) {
			return GlobalFuncs.listgetindex( this.href_list, i );
		}

	}

}