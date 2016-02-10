// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ContextClick : Game_Data {

		public Obj_Item holder = null;

		// Function from file: context_click.dm
		public ContextClick ( Obj_Item to_hold = null ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.holder = to_hold;
			return;
		}

		// Function from file: context_click.dm
		public virtual dynamic action( dynamic used_item = null, dynamic user = null, dynamic _params = null ) {
			return null;
		}

		// Function from file: context_click.dm
		public dynamic return_clicked_id_by_params( dynamic _params = null ) {
			ByTable params_list = null;
			double? x_pos_clicked = null;
			double? y_pos_clicked = null;

			
			if ( !Lang13.Bool( _params ) ) {
				return null;
			}
			params_list = String13.ParseUrlParams( _params );
			x_pos_clicked = ( ( String13.ParseNumber( params_list["icon-x"] ) ??0) <= 1 ? 1 : ( ( String13.ParseNumber( params_list["icon-x"] ) ??0) >= 32 ? 32 : String13.ParseNumber( params_list["icon-x"] ) ) );
			y_pos_clicked = ( ( String13.ParseNumber( params_list["icon-y"] ) ??0) <= 1 ? 1 : ( ( String13.ParseNumber( params_list["icon-y"] ) ??0) >= 32 ? 32 : String13.ParseNumber( params_list["icon-y"] ) ) );
			return this.return_clicked_id( x_pos_clicked, y_pos_clicked );
		}

		// Function from file: context_click.dm
		public virtual dynamic return_clicked_id( double? x_pos = null, double? y_pos = null ) {
			return null;
		}

	}

}