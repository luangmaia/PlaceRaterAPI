using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceRaterRestAPI
{
    public static class ErrorMessages
    {
        public static readonly string erroInternoServidor = "Problema no servidor";
        public static readonly string erroCamposVaziosInvalidos = "Campos vazios ou inválidos";
        public static readonly string erroUsuarioNaoExistente = "Usuário não existente";
        public static readonly string erroUsuarioJaExistente = "Usuário já existe";
        public static readonly string erroAvaliacaoInvalida = "Avaliação inválida";
        public static readonly string erroAvaliacaoNaoEncontrada = "Avaliação não encontrada";
    }
}