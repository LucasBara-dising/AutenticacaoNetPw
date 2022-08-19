using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace AutenticacaoNetPw.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "Informe seu nome")]
        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "o nome deve conter no maximo 100 caracteres")]
        public string UsuNome { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(50, ErrorMessage = "o login deve conter no maximo 50 caracteres")]
        [Remote("Action", "Autentifiacao", ErrorMessage = "O login já existe")]
         public string Login { get; set; }


            [Required(ErrorMessage = "Informe a senha")]
            [MaxLength(50, ErrorMessage = "A senha deve conter no maximo 50 caracteres")]
            [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
            [DataType(DataType.Password)]
            public string Senha { get; set; }

            [Required(ErrorMessage = "Confirme a senha")]
            [Display(Name = "Confirme a senha")]
            [System.ComponentModel.DataAnnotations.Compare(nameof(Senha), ErrorMessage = "As senhas são diferentes")]
            [DataType(DataType.Password)]
            public string ConfirmaSenha { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand command = new MySqlCommand();
        
        public void InsertUsuario(Usuario usuario)
        {
            conexao.Open();
            command.CommandText = "call InsertUsu(@UsuNome, @Login, @Senha);";
            command.Parameters.Add("@UsuNome", MySqlDbType.VarChar).Value = usuario.UsuNome;
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = usuario.Login;
            command.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = usuario.Senha;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }
    }
}