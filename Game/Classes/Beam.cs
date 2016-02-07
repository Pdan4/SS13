// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Beam : Game_Data {

		public dynamic origin = null;
		public dynamic target = null;
		public ByTable elements = new ByTable();
		public Icon base_icon = null;
		public string icon = null;
		public string icon_state = "";
		public double? max_distance = 0;
		public double endtime = 0;
		public int sleep_time = 3;
		public bool finished = false;
		public dynamic target_oldloc = null;
		public dynamic origin_oldloc = null;
		public bool static_beam = false;
		public Type beam_type = typeof(Obj_Effect_Ebeam);

		// Function from file: beam.dm
		public Beam ( dynamic beam_origin = null, dynamic beam_target = null, string beam_icon = null, string beam_icon_state = null, double? time = null, double? maxdistance = null, Type btype = null ) {
			beam_icon = beam_icon ?? "icons/effects/beam.dmi";
			beam_icon_state = beam_icon_state ?? "b_beam";
			time = time ?? 50;
			maxdistance = maxdistance ?? 10;
			btype = btype ?? typeof(Obj_Effect_Ebeam);

			this.endtime = Game13.time + ( time ??0);
			this.origin = beam_origin;
			this.origin_oldloc = GlobalFuncs.get_turf( this.origin );
			this.target = beam_target;
			this.target_oldloc = GlobalFuncs.get_turf( this.target );

			if ( this.origin_oldloc == this.origin && this.target_oldloc == this.target ) {
				this.static_beam = true;
			}
			this.max_distance = maxdistance;
			this.base_icon = new Icon( beam_icon, beam_icon_state );
			this.icon = beam_icon;
			this.icon_state = beam_icon_state;
			this.beam_type = btype;
			return;
		}

		// Function from file: beam.dm
		public override dynamic Destroy(  ) {
			this.Reset();
			this.target = null;
			this.origin = null;
			return base.Destroy();
		}

		// Function from file: beam.dm
		public void Draw(  ) {
			double? Angle = null;
			Matrix rot_matrix = null;
			double DX = 0;
			double DY = 0;
			double N = 0;
			double length = 0;
			dynamic X = null;
			Icon II = null;
			double? Pixel_x = null;
			double? Pixel_y = null;
			int? a = null;

			Angle = Num13.Floor( GlobalFuncs.Get_Angle( this.origin, this.target ) );
			rot_matrix = Num13.Matrix();
			rot_matrix.Turn( Angle );
			DX = Convert.ToDouble( this.target.x * 32 + this.target.pixel_x - ( this.origin.x * 32 + this.origin.pixel_x ) );
			DY = Convert.ToDouble( this.target.y * 32 + this.target.pixel_y - ( this.origin.y * 32 + this.origin.pixel_y ) );
			N = 0;
			length = Num13.Floor( Math.Sqrt( Math.Pow( DX, 2 ) + Math.Pow( DY, 2 ) ) );

			foreach (dynamic _a in Lang13.IterateRange( 0, length - 1, 32 )) {
				N = _a;
				
				X = Lang13.Call( this.beam_type, this.origin_oldloc );
				X.owner = this;
				this.elements.Or( X );

				if ( N + 32 > length ) {
					II = new Icon( this.icon, this.icon_state );
					II.DrawBox( null, 1, length - N, 32, 32 );
					X.icon = II;
				} else {
					X.icon = this.base_icon;
				}
				X.transform = rot_matrix;
				Pixel_x = null;
				Pixel_y = null;

				if ( DX == 0 ) {
					Pixel_x = 0;
				} else {
					Pixel_x = Num13.Floor( Math.Sin( Angle ??0 ) + Math.Sin( Angle ??0 ) * ( N + 16 ) * 32 / 32 );
				}

				if ( DY == 0 ) {
					Pixel_y = 0;
				} else {
					Pixel_y = Num13.Floor( Math.Cos( Angle ??0 ) + Math.Cos( Angle ??0 ) * ( N + 16 ) * 32 / 32 );
				}
				a = null;

				if ( Math.Abs( Pixel_x ??0 ) > 32 ) {
					a = ( ( Pixel_x ??0) > 0 ? Num13.Floor( ( Pixel_x ??0) / 32 ) : GlobalFuncs.Ceiling( ( Pixel_x ??0) / 32 ) );
					X.x += a;
					Pixel_x %= 32;
				}

				if ( Math.Abs( Pixel_y ??0 ) > 32 ) {
					a = ( ( Pixel_y ??0) > 0 ? Num13.Floor( ( Pixel_y ??0) / 32 ) : GlobalFuncs.Ceiling( ( Pixel_y ??0) / 32 ) );
					X.y += a;
					Pixel_y %= 32;
				}
				X.pixel_x = Pixel_x;
				X.pixel_y = Pixel_y;
			}
			return;
		}

		// Function from file: beam.dm
		public void Reset(  ) {
			Obj_Effect_Ebeam B = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.elements, typeof(Obj_Effect_Ebeam) )) {
				B = _a;
				
				GlobalFuncs.qdel( B );
			}
			return;
		}

		// Function from file: beam.dm
		public void End(  ) {
			this.finished = true;
			return;
		}

		// Function from file: beam.dm
		public void Start(  ) {
			dynamic origin_turf = null;
			dynamic target_turf = null;

			this.Draw();

			while (!this.finished && Lang13.Bool( this.origin ) && Lang13.Bool( this.target ) && Game13.time < this.endtime && Map13.GetDistance( this.origin, this.target ) < ( this.max_distance ??0) && this.origin.z == this.target.z) {
				origin_turf = GlobalFuncs.get_turf( this.origin );
				target_turf = GlobalFuncs.get_turf( this.target );

				if ( !this.static_beam && ( origin_turf != this.origin_oldloc || target_turf != this.target_oldloc ) ) {
					this.origin_oldloc = origin_turf;
					this.target_oldloc = target_turf;
					this.Reset();
					this.Draw();
				}
				Task13.Sleep( this.sleep_time );
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}