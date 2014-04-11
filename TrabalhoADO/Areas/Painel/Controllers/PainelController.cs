using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoADO.Areas.Painel.Models;

namespace TrabalhoADO.Areas.Painel.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /Painel/Painel/
        public ActionResult _Index()
        {
            // Criando conexão com o DB...
            const string strConn = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var myConn = new SqlConnection(strConn);
            myConn.Open();

            // Executar um comando ...
            const string strQuery = "SELECT * FROM EMPRESA";
            var cmd = new SqlCommand(strQuery, myConn);
            var retorno = cmd.ExecuteReader();

            // Processar o retorno do DB ...
            var listaEmpresas = new List<Empresa>();

            while (retorno.Read())
            {
                var tempEmpresa = new Empresa();
                tempEmpresa.EmpresaId = int.Parse(retorno["EmpresaId"].ToString());
                tempEmpresa.Nome = retorno["Nome"].ToString();
                tempEmpresa.Telefone = retorno["Telefone"].ToString();
                tempEmpresa.Endereco = retorno["Endereco"].ToString();

                listaEmpresas.Add(tempEmpresa);
            }

            return View(listaEmpresas);
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (usuario.User.Equals("Jhonny") && usuario.Pass.Equals("123"))
            {
                return RedirectToAction("_Index");
            }
            return View();
        }

        public ActionResult NovoCadastro()
        {
            {
                //TODO: 1º Criar uma conexao com o banco de dados
                const string stringConexao = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
                var minhaConexao = new SqlConnection(stringConexao);
                minhaConexao.Open();

                //TODO: 2º Executar um comando no banco de dados
                var strQuery = "SELECT * FROM Categorias";
                var comando = new SqlCommand(strQuery, minhaConexao);
                var retorno = comando.ExecuteReader();

                //TODO: 3º Processar o retorno do banco de dados OU não

                var listaDeCategorias = new List<Categorias>();

                while (retorno.Read())
                {
                    var tempCat = new Categorias();
                    tempCat.catId = int.Parse(retorno["catId"].ToString());
                    tempCat.nomeCat = retorno["nomeCat"].ToString();
                    listaDeCategorias.Add(tempCat);
                }

                ViewBag.ListaDeCategorias = listaDeCategorias;

                return View(new Categorias());
            }
        }

        [HttpPost]
        public ActionResult NovoCadastro(Empresa empresa)
        {
            // Criando conexão com o DB...
            const string strConn = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var myConn = new SqlConnection(strConn);
            myConn.Open();

            // Executar um comando ...
            string strQueryInsert = string.Format("INSERT INTO EMPRESA(NOME, TELEFONE, ENDERECO, CATEGORIAID) VALUES('{0}', '{1}','{2}', '{3}')", empresa.Nome, empresa.Telefone, empresa.Endereco, empresa.EmpresaId);
            var cmd = new SqlCommand(strQueryInsert, myConn);
            var executeNonQuery = cmd.ExecuteNonQuery();

            return RedirectToAction("_Index", empresa);
        }

        public ActionResult Delete(int id)
        {
            // Criando conexão com o DB...
            const string strConn = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var myConn = new SqlConnection(strConn);
            myConn.Open();

            // Executar um comando ...
            var strQueryDelete = string.Format("DELETE FROM EMPRESA WHERE EMPRESAID = {0}", id);
            var cmd = new SqlCommand(strQueryDelete, myConn);
            cmd.ExecuteNonQuery();
            return RedirectToAction("_Index");
        }

        public ActionResult Update(int id)
        {
            //TODO: 1º Criar uma conexao com o banco de dados
            const string stringConexao =  @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var minhaConexao = new SqlConnection(stringConexao);
            minhaConexao.Open();

            //TODO: 2º Executar um comando no banco de dados
            var strQuery = string.Format("SELECT * FROM EMPRESA WHERE EmpresaId = {0}", id);
            var comando = new SqlCommand(strQuery, minhaConexao);
            var retorno = comando.ExecuteReader();

            //TODO: 3º Processar o retorno do banco de dados OU não

            var listaEmpresas = new List<Empresa>();

            while (retorno.Read())
            {
                var tempEmpresa = new Empresa();
                tempEmpresa.EmpresaId = int.Parse(retorno["EmpresaId"].ToString());
                tempEmpresa.Nome = retorno["Nome"].ToString();
                tempEmpresa.Telefone = retorno["Telefone"].ToString();
                tempEmpresa.Endereco = retorno["Endereco"].ToString();

                listaEmpresas.Add(tempEmpresa);
            }
            return View(listaEmpresas.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Update(Empresa empresa, int id)
        {
            // Criando conexão com o DB...
            const string strConn = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var myConn = new SqlConnection(strConn);
            myConn.Open();

            // Executar um comando ...
            var strQueryUpdate = string.Format("UPDATE EMPRESA SET NOME = '{0}', TELEFONE = '{1}', ENDERECO = '{2}' " +
                                               " WHERE EMPRESAID = '{3}'", empresa.Nome, empresa.Telefone, empresa.Endereco, id);
            var cmd = new SqlCommand(strQueryUpdate, myConn);
            cmd.ExecuteNonQuery();

            return RedirectToAction("_Index");
        }

        public ActionResult Detalhes(int id)
        {
            // Criando conexão com o DB...
            const string strConn = @"Data Source=PC;Initial Catalog=TrabalhoAreas;Integrated Security=True";
            var myConn = new SqlConnection(strConn);
            myConn.Open();

            // Executar um comando ...
            string strQuery = string.Format("SELECT * FROM EMPRESA WHERE EMPRESAID = '{0}'", id);
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
            return View(listaEmpresas.FirstOrDefault());
        }

    }
}