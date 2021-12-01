using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Bussiness.BussinesLogic
{
    internal class Contexto
    {
        static NetBanking_Sys_WebAppContext ctxto = new NetBanking_Sys_WebAppContext();
        private static Contexto contx;
        
        public  NetBanking_Sys_WebAppContext  Ctxto { get { return ctxto; } }

        private Contexto() { }

        public static Contexto GetContexto()
        {
            if(contx == null)
            {
                 contx =  new Contexto();
            }
            return contx;
        }
    }
}