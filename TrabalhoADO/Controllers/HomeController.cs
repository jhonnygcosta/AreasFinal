using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoADO.Areas.Painel.Models;

namespace TrabalhoADO.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Criando conexão com o DB... @"data source=PC-Lucas; Integrated Security=SSPI; Initial Catalog= TrabalhoAreas"
            const string strConn = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var myConn = new SqlConnection(strConn);
            myConn.Open();

            // Executar um comando ...
            string strQuery = string.Format("SELECT * FROM EMPRESA");
            var cmd = new SqlCommand(strQuery, myConn);
            var retorno = cmd.ExecuteReader();

            // Processar o retorno do DB ...
            var listaEmpresas = new List<Empresa>();

            while (retorno.Read())
            {
                var tempEmpresa = new Empresa
                {
                    EmpresaId = int.Parse(retorno["EmpresaId"].ToString()),
                    Nome = retorno["Nome"].ToString(),
                    Telefone = retorno["Telefone"].ToString(),
                    Endereco = retorno["Endereco"].ToString()
                };

                listaEmpresas.Add(tempEmpresa);
            }
            return View(listaEmpresas);
        }
    }
}