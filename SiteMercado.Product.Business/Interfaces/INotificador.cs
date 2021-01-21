using SiteMercado.Product.Business.Notificacoes;
using System.Collections.Generic;

namespace SiteMercado.Product.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
