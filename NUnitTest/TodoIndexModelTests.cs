using Microsoft.AspNetCore.Mvc;
using Moq;
using RazorTodolist.Pages.Todolist;
using RazorTodolist.Data;
using RazorTodolist.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class TodoIndexModelTests
    {
        private Mock<ITodoRepository> _mockRepository;
        private IndexModel _indexModel;

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

            _indexModel = new IndexModel(_mockRepository.Object);
        }

        [Test]
        public async Task TestGetAllTodos()
        {
            await _indexModel.OnGetAsync();

            _mockRepository.Verify(r => r.GetAllTodos(), Times.Once());
        }
    }
}
