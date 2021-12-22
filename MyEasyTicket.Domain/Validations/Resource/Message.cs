﻿using System.ComponentModel;

namespace MyEasyTicket.Domain.Validations.Resource
{
    public enum Message
    {
        [Description("{0} é obrigatório.")]
        Required,

        [Description("Campo {0} permite de {1} caracteres.")]
        MoreExpected,

        [Description("{0} não encontrado.")]
        NotFound,

        [Description("{0} não é válido.")]
        RequestInvalid,

        [Description("Adicione {0} para cadastrar o {1}.")]
        EmptyList,

        [Description("Selecione um item da lista {0}")]
        SelectOneItem,

        [Description("Este {0} já existe na base de dados.")]
        Exist,

        [Description("O {0} deve ser maior que {1}.")]
        ValueExpected,

        [Description("Objeto não configurado")]
        ErrorNotConfigured
    }
}
