﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Resultado
{
    public class ResultadoVD
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Resultado { get; set; }
        public ResultadoVD()
        {

        }
        public ResultadoVD(string mensagem, bool sucesso, object resultado)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
            Resultado = resultado;
        }
        public ResultadoVD(string mensagem, bool sucesso)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
        }
        public ResultadoVD(string mensagem)
        {
            Mensagem = mensagem;

        }
        public ResultadoVD(bool sucesso)
        {
            Sucesso = sucesso;
        }
    }
}
