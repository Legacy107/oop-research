using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcTodolist.Controllers;
using MvcTodolist.Data;
using MvcTodolist.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class TodoControllerTests
    {
        private Mock<ITodoRepository> _mockRepository;
        private TodoController _todoController;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<ITodoRepository>();
            _mockRepository
                .Setup(r => r.GetAllTodos())
                .Returns(Task.FromResult((new List<Todo>
                {
                    new Todo { Id = 1, Description = "todo 1", Done = false, DueDate = System.DateTime.Now},
                    new Todo { Id = 2, Description = "todo 2", Done = false, DueDate = System.DateTime.Now},
                    new Todo { Id = 3, Description = "todo 3", Done = true, DueDate = System.DateTime.Now},
                }).AsEnumerable()));

            _todoController = new TodoController(_mockRepository.Object);
        }

        [Test]
        public void TestGetAllTodos()
        {
            var view = _todoController.Index("");

            _mockRepository.Verify(r => r.GetAllTodos(), Times.Once());
        }
    }
}
