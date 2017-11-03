using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.formatoFecha
{
    class formatoFecha
    {
        public static void SetMyCustomFormatYYYYMMDDHORA(DateTimePicker dtp)
        {
            // Establecer el tipo de formato y la cadena CustomFormat.

            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd 00:00:00.000";

        }


        internal static void SetMyCustomFormatYYYYMMDD(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd ";
        }
    }
}
