﻿using System;

namespace Strings
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public long? IdMotivo { get; set; }
        public bool? Coletor { get; set; }
        public long? IdStatusFinal { get; set; }
        public long? IdMotivoFinal { get; set; }
        public string Dispositivo { get; set; }
        public string TipoDeEntrega { get; set; }
        public bool? DecisaoExterna { get; set; }
        public int? IdMotivoChargeback { get; set; }
        public string Operador { get; set; }
        public string Token { get; set; }
        public string NumeroIp { get; set; }
        public DateTime DataDaCompra { get; set; }
        public Guid IdEmpresa { get; set; }
        public Consumidor Consumidor { get; set; }
    }
}
