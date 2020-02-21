using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LivrariaTJ;
using LivrariaTJ.Controllers;
using LivrariaTJ.Models;
using Xunit;
using System.Threading.Tasks;

namespace LivrariaTJ.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Livro()
        {
            // Arrange
            LivrosController controller = new LivrosController();
            Livro meuLivro = new Livro();
            meuLivro.Autor = "JRR Tolkien";
            meuLivro.DataPublicacao = DateTime.Parse("01/01/1988");
            meuLivro.Descricao = "lorem";
            meuLivro.Editora = "lorem";
            meuLivro.Genero = "lorem";
            meuLivro.ImagemCapa = "lorem";
            meuLivro.LinksParaCompra = "lorem";
            meuLivro.NumeroPaginas = 324;
            meuLivro.Sinopse = "lorem sinopse";
            meuLivro.Titulo = "O Hobbit";

            LivrariaTJ.DAL.LivrariaContext contextoDB = new DAL.LivrariaContext();

            //TODO terminar testes

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            //// Arrange
            //var mockRepo = new Mock<IBrainstormSessionRepository>();
            //mockRepo.Setup(repo => repo.ListAsync())
            //    .ReturnsAsync(GetTestSessions());
            //var controller = new HomeController(mockRepo.Object);

            //// Act
            //var result = await controller.Index();

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(2, model.Count());
        }
    }
}
