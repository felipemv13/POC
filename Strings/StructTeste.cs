using System.Collections.Generic;

namespace SAFe.Core.Common.Struct
{
    public struct StructExemplo
    {
        public List<string> ListaAprovados { get; set; }
        public List<string> ListaReprovados { get; set; }
        public int TotalAprovados { get; set; }
        public int TotalReprovados { get; set; }

        //necessário inicializar as listas da Struct, pois caso contrário não poderá ser feita adicão por estarem nulas.
    }
}