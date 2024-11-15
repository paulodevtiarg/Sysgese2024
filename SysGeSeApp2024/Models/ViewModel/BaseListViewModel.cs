namespace SysGeSeApp2024.Models.ViewModel
{
    public class BaseListViewModel
    {
        public BaseListViewModel(int totalItens, int paginaAtual, int qtdItensPagina)
        {
            TotalItens = totalItens;
            PaginaAtual = paginaAtual;
            QtdItensPagina = qtdItensPagina;
        }

        public double QtdItensPagina { get; set; }
        public int NumeroPaginas
        {
            get
            {
                if ((TotalItens / QtdItensPagina) < 1)
                {
                    return 1;
                }
                else
                {
                    if ((TotalItens / QtdItensPagina) % 2 == 0)
                    {
                        return (int)(TotalItens / QtdItensPagina);
                    }
                    else
                    {
                        if (TotalItens == QtdItensPagina)
                        {
                            return 1;
                        }
                        else
                        {
                            //pegar o resto da divisão
                            return (int)((TotalItens / QtdItensPagina) + 1);

                        }

                    }
                }
               


            }
        }
        public int PaginaAtual { get; set; }
        public double TotalItens { get; set; }
    }
}
