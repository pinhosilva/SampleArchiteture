﻿using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Exceptions;

namespace SampleArchiteture.Dominio.Tests
{
    internal class UsuarioTests
    {
        [Test]
        [ExpectedException(typeof(UsuarioException))]
        public void NaoDeveInativarUmUsuarioInativo()
        {
            var usuario = new Usuario
            {
                Nome = "Fakeman"
            };

            usuario.Inativar();

            usuario.Inativar();
        }
    }
}
