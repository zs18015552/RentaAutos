using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Frontera.Utilerias
{
    public class Enumeradores
    {
        public enum PuestoPersona
        {
            Propietario = 1,
            Cliente = 2,
            
        }
        public enum EstadoRenta
        {
            EN_PROCESO,
            FINALIZADA
        }
        public enum Meses
        {
            ENERO = 1,
            FEBRERO = 2,
            MARZO = 3,
            ABRIL = 4,
            MAYO = 5,
            JUNIO = 6,
            JULIO = 7,
            AGOSTO = 8,
            SEPTIEMBRE = 9,
            OCTUBRE = 10,
            NOVIEMBRE = 11,
            DICIEMBRE = 12
        }
        public static void EnumToListBox(Type EnumType, ListControl TheListBox, bool ValorNumerico)
        {
            Array Values = Enum.GetValues(EnumType);
            foreach (int Value in Values)
            {
                ListItem Item;
                string Display = Enum.GetName(EnumType, Value);
                if (ValorNumerico)
                {
                    Item = new ListItem(Display, Value.ToString());
                }
                else
                {
                    Item = new ListItem(Display, Display);
                }
                TheListBox.Items.Add(Item);
            }
        }
    }
}