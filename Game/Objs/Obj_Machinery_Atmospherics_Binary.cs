// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Binary : Obj_Machinery_Atmospherics {

		public GasMixture air1 = null;
		public GasMixture air2 = null;
		public Obj_Machinery_Atmospherics node1 = null;
		public Obj_Machinery_Atmospherics node2 = null;
		public Game_Data network1 = null;
		public Game_Data network2 = null;
		public string activity_log = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.initialize_directions = 3;
		}

		// Function from file: binary_atmos_base.dm
		public Obj_Machinery_Atmospherics_Binary ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			switch ((int)( this.dir )) {
				case 1:
					this.initialize_directions = 3;
					break;
				case 2:
					this.initialize_directions = 3;
					break;
				case 4:
					this.initialize_directions = 12;
					break;
				case 8:
					this.initialize_directions = 12;
					break;
			}
			this.air1 = new GasMixture();
			this.air2 = new GasMixture();
			this.update_icon();
			this.air1.volume = 200;
			this.air2.volume = 200;
			return;
		}

		// Function from file: binary_atmos_base.dm
		public override void unassign_network( PipeNetwork reference = null ) {
			
			if ( this.network1 == reference ) {
				this.network1 = null;
			}

			if ( this.network2 == reference ) {
				this.network2 = null;
			}
			return;
		}

		// Function from file: binary_atmos_base.dm
		public override dynamic disconnect( Obj_Machinery_Atmospherics reference = null ) {
			
			if ( reference == this.node1 ) {
				
				if ( this.network1 != null ) {
					GlobalFuncs.returnToPool( this.network1 );
				}
				this.node1 = null;
			} else if ( reference == this.node2 ) {
				
				if ( this.network2 != null ) {
					GlobalFuncs.returnToPool( this.network2 );
				}
				this.node2 = null;
			}
			return null;
		}

		// Function from file: binary_atmos_base.dm
		public override ByTable return_network_air( PipeNetwork reference = null ) {
			ByTable results = null;

			results = new ByTable();

			if ( this.network1 == reference ) {
				results.Add( this.air1 );
			}

			if ( this.network2 == reference ) {
				results.Add( this.air2 );
			}
			return results;
		}

		// Function from file: binary_atmos_base.dm
		public override bool reassign_network( Game_Data old_network = null, PipeNetwork new_network = null ) {
			
			if ( this.network1 == old_network ) {
				this.network1 = new_network;
			}

			if ( this.network2 == old_network ) {
				this.network2 = new_network;
			}
			return true;
		}

		// Function from file: binary_atmos_base.dm
		public override dynamic return_network( Obj reference = null ) {
			this.build_network();

			if ( reference == this.node1 ) {
				return this.network1;
			}

			if ( reference == this.node2 ) {
				return this.network2;
			}
			return null;
		}

		// Function from file: binary_atmos_base.dm
		public override dynamic build_network(  ) {
			
			if ( !( this.network1 != null ) && this.node1 != null ) {
				this.network1 = GlobalFuncs.getFromPool( typeof(PipeNetwork) );
				((dynamic)this.network1).normal_members += this;
				((dynamic)this.network1).build_network( this.node1, this );
			}

			if ( !( this.network2 != null ) && this.node2 != null ) {
				this.network2 = GlobalFuncs.getFromPool( typeof(PipeNetwork) );
				((dynamic)this.network2).normal_members += this;
				((dynamic)this.network2).build_network( this.node2, this );
			}
			return null;
		}

		// Function from file: binary_atmos_base.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			
			if ( this.node1 != null && this.node2 != null ) {
				return false;
			}
			this.node1 = this.findConnecting( Num13.Rotate( this.dir, 180 ) );
			this.node2 = this.findConnecting( this.dir );
			this.update_icon();
			return false;
		}

		// Function from file: binary_atmos_base.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.node1 != null ) {
				this.node1.disconnect( this );

				if ( this.network1 != null ) {
					GlobalFuncs.returnToPool( this.network1 );
				}
			}

			if ( this.node2 != null ) {
				this.node2.disconnect( this );

				if ( this.network2 != null ) {
					GlobalFuncs.returnToPool( this.network2 );
				}
			}
			this.node1 = null;
			this.node2 = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: binary_atmos_base.dm
		public override dynamic network_expand( PipeNetwork new_network = null, Obj_Machinery_Atmospherics reference = null ) {
			
			if ( reference == this.node1 ) {
				this.network1 = new_network;
			} else if ( reference == this.node2 ) {
				this.network2 = new_network;
			}

			if ( new_network.normal_members.Find( this ) != 0 ) {
				return 0;
			}
			new_network.normal_members.Add( this );
			return null;
		}

		// Function from file: binary_atmos_base.dm
		public override bool? buildFrom( Mob usr = null, Obj_Item_Pipe pipe = null ) {
			Ent_Static T = null;

			this.dir = pipe.dir;
			this.initialize_directions = pipe.get_pipe_dir();

			if ( Lang13.Bool( pipe.pipename ) ) {
				this.name = pipe.pipename;
			}
			T = this.loc;
			this.level = ( Lang13.Bool( ((dynamic)T).intact ) ? 2 : 1 );
			this.initialize();
			this.build_network();

			if ( this.node1 != null ) {
				this.node1.initialize();
				this.node1.build_network();
			}

			if ( this.node2 != null ) {
				this.node2.initialize();
				this.node2.build_network();
			}
			return true;
		}

		// Function from file: binary_atmos_base.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			ByTable node_list = null;

			node_list = new ByTable(new object [] { this.node1, this.node2 });
			base.update_icon( (object)(location), node_list );
			return null;
		}

		// Function from file: binary_atmos_base.dm
		public override string investigation_log( string subject = null, string message = null ) {
			this.activity_log += base.investigation_log( subject, message );
			return null;
		}

	}

}