using System;

namespace UnifesoPoo.Api.Core.Domain.Shared.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string entityName, int cpf) : base($"O {entityName} não foi encontrado.")
        {
            Data.Add(nameof(cpf), cpf);
        }
    }
}