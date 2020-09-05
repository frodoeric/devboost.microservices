﻿using devboost.Domain;
using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace devboost.Test.Domain.Handles.Command
{
    public class PayAPIHandlerTest
    {
        private readonly IPayAPIHandler payAPIHandler;
        private readonly HttpClient httpClient;

        public PayAPIHandlerTest()
        {
            this.payAPIHandler = new PayAPIHandler(httpClient);
            this.httpClient = new HttpClient();
        }

        [Fact]
        public void ReazliarPagamentoSucesso()
        {

            CmmPagRequest cmmPagRequest = new CmmPagRequest()
            {
                Bandeira = "visa",
                CodigoSeguranca = 321,
                CreatedAt = DateTime.Now,
                Name = "Eric",
                NumeroCartao = "321654",
                PayId = new Guid(),
                Status = StatusCartao.aguardandoAprovacao,
                Valor = 321,
                Vencimento = DateTime.Now
            };


            var result = this.payAPIHandler.PostRealizarPagamento(cmmPagRequest);

            Assert.NotNull(result);
        }
    }
}
