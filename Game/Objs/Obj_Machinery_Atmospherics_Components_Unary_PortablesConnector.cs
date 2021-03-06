// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components_Unary_PortablesConnector : Obj_Machinery_Atmospherics_Components_Unary {

		public Obj connected_device = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_unwrench = true;
			this.use_power = 0;
			this.level = 0;
			this.icon_state = "connector_map";
		}

		// Function from file: portables_connector.dm
		public Obj_Machinery_Atmospherics_Components_Unary_PortablesConnector ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			dynamic air_contents = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			air_contents = this.airs[1];
			air_contents.volume = 0;
			return;
		}

		// Function from file: portables_connector.dm
		public override GasMixture portableConnectorReturnAir(  ) {
			return this.connected_device.portableConnectorReturnAir();
		}

		// Function from file: portables_connector.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Wrench ) {
				
				if ( this.connected_device != null ) {
					user.WriteMsg( "<span class='warning'>You cannot unwrench this " + this + ", dettach " + this.connected_device + " first!</span>" );
					return 1;
				}
			}
			return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
		}

		// Function from file: portables_connector.dm
		public override dynamic Destroy(  ) {
			
			if ( this.connected_device != null ) {
				((Obj_Machinery_PortableAtmospherics)this.connected_device).disconnect();
			}
			return base.Destroy();
		}

		// Function from file: portables_connector.dm
		public override int? process_atmos(  ) {
			
			if ( !( this.connected_device != null ) ) {
				return null;
			}
			this.update_parents();
			return null;
		}

	}

}