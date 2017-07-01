using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Registro_Viajes;

namespace UberFrba.BuilderObjectViews
{
    class BuilderObjectView
    {
        #region declaracion singleton
        private static BuilderObjectView instance;

        private BuilderObjectView() { }

        public static BuilderObjectView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuilderObjectView();
                }
                return instance;
            }
        }
        #endregion

        public ViajeView createViajeViewFromViaje(Viaje viaje)
        {
            return new ViajeView(viaje.Inicio, viaje.Fin, viaje.CantidadKilometros, viaje.Monto);
        }
    }
}
