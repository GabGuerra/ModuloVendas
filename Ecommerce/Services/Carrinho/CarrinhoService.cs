using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models.Carrinho;
using Ecommerce.Models.Movimentacao;
using Ecommerce.Models.Produto;
using Ecommerce.Models.Resultado;
using Ecommerce.Repositories.Carrinho;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ecommerce.Services.Carrinho
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;

        }
        public async Task<ResultadoVD> AdicionarItem(int codProduto, int qtdAdicionar, int codCarrinho, string cpfUsuario, int codDeposito)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                _carrinhoRepository.AdicionarItem(new CarrinhoItemVD(codProduto, qtdAdicionar), codCarrinho);
                resultado = await ReservarEstoque(codProduto, qtdAdicionar, cpfUsuario, codDeposito);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível adicionar o item ao carrinho. {Environment.NewLine}{ex.Message}";
            }

            return resultado;
        }

        public async Task<ResultadoVD> ReservarEstoque(int codProduto, int qtdAdicionar, string cpfUsuario, int codDeposito)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    Documento docMov = new Documento();
                    docMov.TipoDocumento.CodTipoDocumento = 7;
                    docMov.ListaMovimentacaoDetalhe = new List<MovimentacaoDetalhe>();
                    docMov.ListaMovimentacaoDetalhe.Add(new MovimentacaoDetalhe(new ProdutoMovimentacao(codProduto), qtdAdicionar, new Deposito(codDeposito)));
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var data = new StringContent(JsonConvert.SerializeObject(docMov), Encoding.UTF8, "application/json");
                    var url = "https://localhost:44386/api/Movimentacao/MovimentarProdutos";
                    var res = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    var objResponse = res.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<ResultadoVD>(objResponse);

                }
            }
            catch (Exception)
            {

                throw;
            }

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
                resultado.Resultado = _carrinhoRepository.CriarCarrinho(cpfUsuario);
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

        public ResultadoVD FinalizarCompra(CarrinhoVD carrinho)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                var codPedido = _carrinhoRepository.InserirPedido(carrinho.CpfUsuario);
                foreach (var item in carrinho.ListaItens)
                {
                    _carrinhoRepository.InserirPedidoItem(item, codPedido);
                }
                _carrinhoRepository.LimparCarrinho(carrinho.CodCarrinho);
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
