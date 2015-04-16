﻿using Autofac;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Data;
using Xunit;

namespace SampleArchiteture.Infraestrutura.Tests.Services
{
    public class UsuarioServiceTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            var container = SetupTest.Container.BeginLifetimeScope();

            _unitOfWork = container.Resolve<IUnitOfWork>();
            _usuarioRepository = container.Resolve<IUsuarioRepository>();
            _usuarioService = container.Resolve<UsuarioService>();
        }

        [Fact]
        public void DeveMarcarUmUsuarioParaReceberNovidades()
        {
            // arrange

            _usuarioRepository.Add(new Usuario
            {
                Nome = "Chuck Norris"
            });

            _unitOfWork.Commit();

            // act
            var usuario = _usuarioService.InscreverUsuario(1);

            // assert
            Assert.Equal(true, usuario.RecebeNovidades);
            Assert.Equal(1, usuario.Id);
        }
    }
}
