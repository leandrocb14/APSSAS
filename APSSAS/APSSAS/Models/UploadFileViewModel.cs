using APSSAS.Infraestrutura;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace APSSAS.Models
{
    public class UploadFileViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public string Chave { get; set; }
        public string Processo { get; set; }        
        public string TipoCriptografia { get; set; }        
        public List<SelectListItem> ListaProcessos { get; set; }
        public List<SelectListItem> ListaTiposCriptografia { get; set; }

        public UploadFileViewModel()
        {
            ListaProcessos = CarregaListaProcessos();
            ListaTiposCriptografia = CarregaListaCriptografias();
        }        

        private List<SelectListItem> CarregaListaProcessos()
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            itens.Add(new SelectListItem() { Text = Infraestrutura.Processo.Encrypt.Description(), Value = Infraestrutura.Processo.Encrypt.DefaultValue() });
            itens.Add(new SelectListItem() { Text = Infraestrutura.Processo.Decrypt.Description(), Value = Infraestrutura.Processo.Decrypt.DefaultValue() });
            return itens;
        }

        private List<SelectListItem> CarregaListaCriptografias()
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            itens.Add(new SelectListItem() { Text = Criptografia.Base64.Description(), Value = Criptografia.Base64.DefaultValue() });
            itens.Add(new SelectListItem() { Text = Criptografia.DES.Description(), Value = Criptografia.DES.DefaultValue() });
            itens.Add(new SelectListItem() { Text = Criptografia.AES.Description(), Value = Criptografia.AES.DefaultValue() });
            return itens;
        }
    }
}