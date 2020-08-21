using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Commons
{
    public static class StateHelper
    {
        public const int Pendiente = 1;
        public const int Proceso = 2;
        public const int Listo = 3;
        public const int Cancelado = 4;
    }
}
