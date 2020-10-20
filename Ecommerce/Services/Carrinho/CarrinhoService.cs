using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Carrinho;
using Ecommerce.Models.Resultado;
using Ecommerce.Repositories.Carrinho;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Services.Carrinho
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;

        }
        public ResultadoVD AdicionarItem(int codProduto, int qtdAdicionar, int codCarrinho)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                _carrinhoRepository.AdicionarItem(new CarrinhoItemVD(codProduto, qtdAdicionar), codCarrinho);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível adicionar o item ao carrinho. {Environment.NewLine}{ex.Message}";
            }

            return resultado;
        }

        public CarrinhoVD CarregarDetalheCarrinho(int codCarrinho)
        {
            return _carrinhoRepository.CarregarDetalheCarrinho(codCarrinho);
        }

        public ResultadoVD CriarCarrinho(string cpfUsuario)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                resultado.ObjResultado = _carrinhoRepository.CriarCarrinho(cpfUsuario);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível criar o  carrinho. {Environment.NewLine}{ex.Message}";
            }
            return resultado;
        }

        public ResultadoVD RemoverItem(int codProduto, int qtdRemover, int codCarrinho)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                _carrinhoRepository.RemoverItem(new CarrinhoItemVD(codProduto, qtdRemover), codCarrinho);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível remover o item ao carrinho. {Environment.NewLine}{ex.Message}";
            }

            return resultado;
        }
    }
}
