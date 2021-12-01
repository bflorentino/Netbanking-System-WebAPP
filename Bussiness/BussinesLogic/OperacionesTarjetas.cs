using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class OperacionesTarjetas
    {
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public List<Model.ViewModel.Tarjeta> GetTarjetas()
        {
            var tarjetas = (from cards in dbContext.Tarjetas
                           join clientestarjetas in dbContext.ClientesTarjetas 
                           on cards.NumeroTarjeta equals clientestarjetas.NumeroTarjeta
                           where ManageUsers.UserOnline.Cedula == clientestarjetas.Cedula
                           select cards.NumeroTarjeta).ToList();

            return tarjetas;
        }
    }
}
