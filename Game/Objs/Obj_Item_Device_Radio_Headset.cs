// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Radio_Headset : Obj_Item_Device_Radio {

		public bool translate_binary = false;
		public bool translate_hive = false;
		public dynamic keyslot1 = null;
		public dynamic keyslot2 = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "headset";
			this.starting_materials = new ByTable().Set( "$iron", 75 );
			this.subspace_transmission = true;
			this.canhear_range = 0;
			this.slot_flags = 16;
			this.maxf = 1489;
			this.icon_state = "headset";
		}

		// Function from file: headset.dm
		public Obj_Item_Device_Radio_Headset (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.keyslot1 = new Obj_Item_Device_Encryptionkey();
			this.recalculateChannels();
			return;
		}

		// Function from file: headset.dm
		public void recalculateChannels(  ) {
			dynamic ch_name = null;
			dynamic ch_name2 = null;
			dynamic ch_name3 = null;

			this.channels = new ByTable();
			this.translate_binary = false;
			this.translate_hive = false;
			this.syndie = false;

			if ( Lang13.Bool( this.keyslot1 ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.keyslot1.channels )) {
					ch_name = _a;
					
					Interface13.Stat( null, this.channels.Contains( ch_name ) );

					if ( false ) {
						continue;
					}
					this.channels.Add( ch_name );
					this.channels[ch_name] = this.keyslot1.channels[ch_name];
				}

				if ( Lang13.Bool( this.keyslot1.translate_binary ) ) {
					this.translate_binary = true;
				}

				if ( Lang13.Bool( this.keyslot1.translate_hive ) ) {
					this.translate_hive = true;
				}

				if ( Lang13.Bool( this.keyslot1.syndie ) ) {
					this.syndie = true;
				}
			}

			if ( Lang13.Bool( this.keyslot2 ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.keyslot2.channels )) {
					ch_name2 = _b;
					
					Interface13.Stat( null, this.channels.Contains( ch_name2 ) );

					if ( false ) {
						continue;
					}
					this.channels.Add( ch_name2 );
					this.channels[ch_name2] = this.keyslot2.channels[ch_name2];
				}

				if ( Lang13.Bool( this.keyslot2.translate_binary ) ) {
					this.translate_binary = true;
				}

				if ( Lang13.Bool( this.keyslot2.translate_hive ) ) {
					this.translate_hive = true;
				}

				if ( Lang13.Bool( this.keyslot2.syndie ) ) {
					this.syndie = true;
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( this.channels )) {
				ch_name3 = _c;
				
				this.secure_radio_connections[ch_name3] = GlobalFuncs.add_radio( this, GlobalVars.radiochannels[ch_name3] );
			}
			return;
		}

		// Function from file: headset.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic ch_name = null;
			dynamic T = null;
			dynamic T2 = null;

			((Mob)b).set_machine( this );

			if ( !( a is Obj_Item_Weapon_Screwdriver || a is Obj_Item_Device_Encryptionkey ) ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				
				if ( Lang13.Bool( this.keyslot1 ) || Lang13.Bool( this.keyslot2 ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.channels )) {
						ch_name = _a;
						
						GlobalVars.radio_controller.remove_object( this, GlobalVars.radiochannels[ch_name] );
						this.secure_radio_connections[ch_name] = null;
					}

					if ( Lang13.Bool( this.keyslot1 ) ) {
						T = GlobalFuncs.get_turf( b );

						if ( Lang13.Bool( T ) ) {
							this.keyslot1.loc = T;
							this.keyslot1 = null;
						}
					}

					if ( Lang13.Bool( this.keyslot2 ) ) {
						T2 = GlobalFuncs.get_turf( b );

						if ( Lang13.Bool( T2 ) ) {
							this.keyslot2.loc = T2;
							this.keyslot2 = null;
						}
					}
					this.recalculateChannels();
					GlobalFuncs.to_chat( b, "You pop out the encryption keys in the headset!" );
				} else {
					GlobalFuncs.to_chat( b, "This headset doesn't have any encryption keys!  How useless..." );
				}
			}

			if ( a is Obj_Item_Device_Encryptionkey ) {
				
				if ( Lang13.Bool( this.keyslot1 ) && Lang13.Bool( this.keyslot2 ) ) {
					GlobalFuncs.to_chat( b, "The headset can't hold another key!" );
					return null;
				}

				if ( !Lang13.Bool( this.keyslot1 ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.keyslot1 = a;
					}
				} else if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.keyslot2 = a;
				}
				this.recalculateChannels();
			}
			return null;
		}

		// Function from file: headset.dm
		public override int? receive_range( dynamic freq = null, dynamic level = null ) {
			Ent_Static H = null;

			
			if ( this.loc is Mob_Living_Carbon_Human ) {
				H = this.loc;

				if ( ((dynamic)H).ears == this ) {
					return base.receive_range( (object)(freq), (object)(level) );
				}
			}
			return -1;
		}

	}

}