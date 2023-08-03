using Microsoft.AspNetCore.Components;
using TesteSinergyRHDev.Client.ServiceClient;
using TesteSinergyRHDev.Client.ServiceClient.Interfaces;
using TesteSinergyRHDev.Shared.Dto;
using TesteSinergyRHDev.Shared.Enum;

namespace TesteSinergyRHDev.Client.Pages
{
    public class PainelCafeteirabase : ComponentBase
    {

        [Inject]
        public ICatalogoService _catalogoService { get; set; }

        [Inject]
        public IPedidoService _pedidoService { get; set; }

        

        public string Letreiro { get; set; } = "Ecolha produto...";

        private decimal _totalDepositado;

        public decimal TotalDepositado 
        { 
            get { return _totalDepositado; } 
        }


        private List<decimal> _moedasDepositadas = new List<decimal>();

        public List<ProdutoDto> ProdutosDisponiveis = new List<ProdutoDto>();

        public void InserirMoeda(decimal moeda)
        {
            if (moeda == 0.05m || moeda == 0.01m)
            {
                Letreiro = $"Moeda não aceita";
            }
            else
            {
                _moedasDepositadas.Add(moeda);
                _totalDepositado = CalcularTotalDepositado();
                Letreiro = $"Depositado:{@TotalDepositado.ToString("C2")}";
            }
        }

        private bool ValidarValorSuficiente(decimal valorProduto)
        {
            if (TotalDepositado < valorProduto)
            {
                var diferenca = TotalDepositado - valorProduto;
                var resposta = diferenca * -1;

                Letreiro = $"Insira {resposta}";
                return false;
            }
            return true;
        }

        public async void ComprarProduto(Guid id)
        {
            var produto = ProdutosDisponiveis.FirstOrDefault(px => px.Id == id);
            if (!ValidarValorSuficiente(produto.Valor))
            {
                return;
            }

            try
            {
                var pedidoSolicitado = await _pedidoService.ComprarProduto(produto.Id, _totalDepositado);
                ProcessarRetornoPedido(pedidoSolicitado);                
            }
            catch (Exception)
            {
                Letreiro = "Erro ao comprar produto";
            }
        }

        public bool ExibirPreparoProduto { get; set; } = false;
        public bool ExibirTrocoCompra { get; set; } = false;


        private void ExibirImagemTroco(decimal troco)
        {
            Letreiro = $"Retire seu troco : {troco.ToString("C2")}";
            ExibirTrocoCompra = true;

            Task.Delay(5000).ContinueWith(t => 
            {                 
                Letreiro = "Ecolha produto...";
                ExibirTrocoCompra = false;
                StateHasChanged();
            });
        }

        private void ExibirImagemPreparo()
        {
            Letreiro = "Preparando...";
            ExibirPreparoProduto = true;

            Task.Delay(5000).ContinueWith(t =>
            {
                Letreiro = "Ecolha produto...";
                ExibirPreparoProduto = false;
                StateHasChanged();
            });
        }

        private void EntregarTroco(decimal troco)
        {
            ExibirImagemTroco(troco);
            _moedasDepositadas.Clear();
            _totalDepositado = CalcularTotalDepositado();            
        }

        private void ProcessarRetornoPedido(PedidoDto pedidoSolicitado)
        {
            switch (pedidoSolicitado.SituacaoPedido)
            {
                case StatusTransacao.Pago:
                    {
                        Letreiro = $"Preparando : {pedidoSolicitado.DescricaoProduto}";
                        ExibirImagemPreparo();
                        _moedasDepositadas.Clear();
                        break;
                    }
                case StatusTransacao.PagoContemTroco:
                    {
                        Letreiro = $"Preparando : {pedidoSolicitado.DescricaoProduto}";
                        ExibirImagemPreparo();
                        EntregarTroco(pedidoSolicitado.Troco);
                        break;                        
                    }
                case StatusTransacao.PendenciaValor:
                    Letreiro = $"Insira : {pedidoSolicitado.Valorfaltante}";
                    break;
            }
            StateHasChanged();
        }



        public async Task CarregarProdutos()
        {
            try
            {
                var resultado = await _catalogoService.GetProdutos();
                ProdutosDisponiveis.AddRange(resultado);
            }
            catch (Exception ex)
            {
                Letreiro = "Nenhum produto disponivel";
            }
        }


        protected override async Task OnInitializedAsync()
        {
            await CarregarProdutos();
        }


        private decimal CalcularTotalDepositado()
        {
            decimal total = 0;
            foreach (var moeda in _moedasDepositadas)
            {
                total += moeda;
            }
            return total;
        }

    }
}
