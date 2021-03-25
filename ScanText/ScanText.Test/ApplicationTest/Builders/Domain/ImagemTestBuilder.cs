using ScanText.Domain.Linguagem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Test.ApplicationTest.Builders.Domain
{
    public class ImagemTestBuilder
    {
        protected Imagem Model;

        public ImagemTestBuilder()
        {
            Model = new Imagem();
        }

        public ImagemTestBuilder Default()
        {
            Model.Base64 = "base64,f0adfasdfjasdhfosaiyf9sa86f";
            Model.DataCadastro = DateTime.Now;
            Model.Formato = "png";
            Model.Id = Guid.NewGuid();
            Model.Linguagem = new Linguagem { Sigla = "pt", Id = Guid.NewGuid(), DataCadastro = DateTime.Now.AddMonths(-2), Idioma = "Português" };
            Model.MeanConfidence = 99.5f;
            Model.Nome = "imagem texto";
            Model.Size = 123232;
            Model.Texto = "Texto da imagem de teste";

            return this;
        }

        public Imagem Build()
        {
            return Model;
        }
    }
}
