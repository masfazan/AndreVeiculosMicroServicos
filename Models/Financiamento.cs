﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class Financiamento
    {
        public int Id { get; set; }
        public Venda Venda { get; set; } // Substitua por tipo da sua classe Venda
        public DateTime DataFinanciamento { get; set; }
        public Banco Banco { get; set; }
    
    }
}