using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace CustomerRepo.WebMVC.Tests
{
    public class NotesControllerTests
    {
        [Fact]
        public void ShouldCreateNotesController()
        {
            var controller = new NotesController();
            Assert.NotNull(controller);
        }

        [Fact]
        public void ShouldReturnNoteesList()
        {
            var controller = new NotesController();
            var notesResult = controller.Index();
            var notesView = notesResult as ViewResult;
            var notesModel = notesView.Model as List<Notes>;
            Assert.NotNull(notesModel);
        }

        [Fact]
        public void ShouldCreateNote()
        {
            var notesControllerMock = new Mock<IRepository<Notes>>();
            var noteController = new NotesController(notesControllerMock.Object);
            noteController.Create();

            var result = noteController.Create(new Notes()
            {
                CustomerId = 1,
                Note = "Any note"
            }) as RedirectToRouteResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldEditNote()
        {
            var notesControllerMock = new Mock<IRepository<Notes>>();
            var noteController = new NotesController(notesControllerMock.Object);
            noteController.Edit(1);

            var result = noteController.Edit(1, new Notes()
            {
                CustomerId = 1,
                Note = "Any note"
            }) as RedirectToRouteResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldDeleteNote()
        {
            var notesControllerMock = new Mock<IRepository<Notes>>();
            var noteController = new NotesController(notesControllerMock.Object);
            noteController.Delete(1);

            var result = noteController.Delete(new Notes
            {
                CustomerId = 1,
                Note = "Any note"
            }) as RedirectToRouteResult;

            Assert.Empty("");
        }
    }
}
