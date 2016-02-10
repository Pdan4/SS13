// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Backpack_Holding : Obj_Item_Weapon_Storage_Backpack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "bluespace=4";
			this.item_state = "holdingpack";
			this.max_w_class = 4;
			this.max_combined_w_class = 28;
			this.icon_state = "holdingpack";
		}

		// Function from file: backpack.dm
		public Obj_Item_Weapon_Storage_Backpack_Holding ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: backpack.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			int dist = 0;

			dist = Num13.MaxInt( ((int)( current_size ??0 )), 1 );
			GlobalFuncs.empulse( S.loc, dist * 2, dist * 4 );

			if ( ( S.current_size ??0) <= 3 ) {
				this.investigation_log( "singulo", "has been destroyed by a bag of holding." );
				GlobalFuncs.qdel( S );
			} else {
				this.investigation_log( "singulo", "has been weakened by a bag of holding." );
				S.energy -= ( S.energy ??0) / 3 * 2;
				S.check_energy();
			}
			GlobalFuncs.qdel( this );
			return 0;
		}

		// Function from file: backpack.dm
		public bool failcheck( dynamic user = null ) {
			Obj O = null;

			
			if ( Rand13.PercentChance( ((int)( this.reliability )) ) ) {
				return true;
			}

			if ( Rand13.PercentChance( ((int)( this.reliability )) ) ) {
				GlobalFuncs.to_chat( user, "<span class = 'warning'>The Bluespace portal resists your attempt to add another item.</span>" );
			} else {
				GlobalFuncs.to_chat( user, "<span class = 'danger'>The Bluespace generator malfunctions!</span>" );

				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
					O = _a;
					
					GlobalFuncs.qdel( O );
				}
				this.crit_fail = true;
				this.icon_state = "brokenpack";
			}
			return false;
		}

		// Function from file: backpack.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			
			if ( a == this ) {
				return _default;
			}

			if ( this.crit_fail ) {
				GlobalFuncs.to_chat( b, "<span class = 'warning'>The Bluespace generator isn't working.</span>" );
				return _default;
			}

			if ( a is Obj_Item_Weapon_Storage_Backpack_Holding && !a.crit_fail ) {
				this.investigation_log( "singulo", "has become a singularity. Caused by " + b.key );
				GlobalFuncs.message_admins( "" + this + " has become a singularity. Caused by " + b.key );
				GlobalFuncs.to_chat( b, "<span class = 'danger'>The Bluespace interfaces of the two devices catastrophically malfunction!</span>" );
				GlobalFuncs.qdel( a );
				a = null;
				new Obj_Machinery_Singularity( GlobalFuncs.get_turf( this ) );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( b ) + " detonated a bag of holding" );
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name( b ) + " detonated a bag of holding" ) ) );
				GlobalFuncs.to_chat( b, "<span class='danger'>FUCK</span>" );
				((Ent_Dynamic)b).throw_at( GlobalFuncs.get_turf( this ), 10, 5 );
				GlobalFuncs.qdel( this );
				return _default;
			}
			_default = base.attackby( (object)(a), (object)(b), (object)(c) );
			return _default;
		}

		// Function from file: backpack.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class = 'danger'><b>" ).item( user ).str( " puts the " ).item( this.name ).str( " on " ).his_her_its_their().str( " head and stretches the bag around " ).himself_herself_itself_themself().str( ". With a sudden snapping sound, the bag shrinks to it's original size, leaving no trace of " ).item( user ).str( " </b></span>" ).ToString() );
			this.loc = GlobalFuncs.get_turf( user );
			GlobalFuncs.qdel( user );
			return null;
		}

	}

}